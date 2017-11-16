from flask import Flask, session, request, redirect, render_template, flash, url_for
from mysqlconnection import MySQLConnector
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = '5a2bbc096dc8ad38472510a5b425d741'
mysql = MySQLConnector (app, 'the_wall_2')

#GLOBAL FUNCTIONS
def valid_reg():
    is_valid = True

    if len(request.form['first_name']) < 2 or len(request.form['last_name']) < 2:
        is_valid = False
        flash('Name field must be longer than two characters')

    if any(char.isdigit() for char in request.form['first_name']) or any(char.isdigit() for char in request.form['last_name']):
        is_valid = False
        flash ('Names cannot contain numbers')

    if request.form['password'] != request.form['confirm_password']:
        is_valid = False
        flash('Passwords do not match!')

    if len(request.form['password']) < 8: 
        is_valid = False
        flash('Password must be longer than 8 characters')

    if not EMAIL_REGEX.match(request.form['email']):
        is_valid = False
        flash('Invalid email')
    return is_valid

# def valid_log():

# GET REQUESTS
@app.route('/')
def index():
    return render_template('index.html')

@app.route('/wall')
def dash():
    if session['first_name']:
        query = "SELECT first_name, last_name, message, DATE_FORMAT(messages.created_at, '%M %D %Y %H:%i') AS created_at, messages.id, user_id FROM messages JOIN users ON messages.user_id = users.id ORDER BY messages.created_at DESC"
        message_list = mysql.query_db(query)
        query = "SELECT first_name, last_name, reply, DATE_FORMAT(replies.created_at, '%M %D %Y %H:%i') AS created_at, message_id FROM replies JOIN users ON replies.user_id = users.id ORDER BY replies.created_at"
        reply_list = mysql.query_db(query)
        return render_template('wall.html', message_list = message_list, reply_list = reply_list)
    else:
        return redirect('/')

@app.route('/logout')
def logout():
    session.clear()
    return redirect('/')

# POST REQUESTS
@app.route('/register', methods=['POST'])
def register():
    if valid_reg() == False:
        return redirect('/')
    else:
        server_first_name = request.form['first_name']
        server_last_name  = request.form['last_name']
        server_email = request.form['email']
        server_password = request.form['password']
        server_confirm = request.form['confirm_password']
        try:
            parameters = {
                'parameter_first_name': server_first_name,
                'parameter_last_name': server_last_name,
                'parameter_email': server_email,
                'parameter_password': server_password,
            }
            insert_user = 'insert into users (first_name, last_name, email, password, created_at, updated_at) values (:parameter_first_name, :parameter_last_name, :parameter_email, :parameter_password, NOW(), NOW())'
            
            user_id = mysql.query_db(insert_user, parameters)
            
            session['user_id'] = user_id
            session['email'] = server_email
            session['first_name'] = server_first_name

            return redirect('/wall')

        except:
            flash('User already exists')
            return redirect('/')

@app.route('/auth', methods=['POST'])
def auth():
    
    is_valid = True

    server_email = request.form['log_email']
    server_password = request.form['log_password']

    if len(server_email) < 2:
        is_valid = False
        flash('Username must be longer than two characters')
    
    if is_valid:
        parameters = {
            'parameter_email': server_email,
        }
        query = 'select * from users where email = :parameter_email'
        results = mysql.query_db(query, parameters)

        if len(results) == 0:
            flash('User does not exist')
            return redirect('/')
        else:
            user = results[0]
            if user['password'] == server_password:
                session['user_id'] = user['id']
                session['email'] = user['email']
                session['first_name'] = user['first_name']
                return redirect('/wall')
            else:
                flash('Incorrect password.  Did you forget your password?')
                return redirect('/')

    else:
        return redirect('/')

@app.route('/add_message', methods=['POST'])
def add_message():
    if session['email']:
        parameters = {
            'parameter_message': request.form['message'],
            'parameter_id' : session['user_id'],
        }

        query = 'INSERT INTO messages (user_id, message, created_at, updated_at) VALUES (:parameter_id, :parameter_message, NOW(), NOW())'
        results = mysql.query_db(query, parameters)
        print results
        return redirect('/wall')

@app.route('/addReply/<message_id>', methods =['POST'])
def addReply(message_id):
    data = {
        'reply': request.form['reply'],
        'user_id': session['user_id'],
        'message_id': message_id
    }
    query = "INSERT INTO replies (user_id, message_id, reply, created_at, updated_at) VALUES (:user_id, :message_id, :reply, Now(), Now())"
    mysql.query_db(query, data)
    return redirect('/wall')

app.run(debug=True)