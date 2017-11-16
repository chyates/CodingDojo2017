from flask import Flask, session, request, redirect, render_template, flash
from mysqlconnection import MySQLConnector
import re

email_regex = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = 'cd52951f7c0dc0850f2c6c9cb7be9474'
mysql_db = MySQLConnector(app, 'the_wall')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/login')
def login():
    return render_template('user_entry.html')

@app.route('/authenticate', methods=['POST'])
def authenticate():
    print request.form
    is_valid = True

    server_username = request.form['html_username']
    server_password = request.form['html_password']

    if len(server_username) < 2:
        is_valid = False
        flash('Username must be longer that two characters')
    

    if is_valid:
        ## QUERY DATABASE
        parameters = {
            'parameter_username': server_username,
        }
        query = 'select * from users where username = :parameter_username'
        results = mysql_db.query_db(query, parameters)
        
        ## VALIDATE USER
        if len(results) == 0:
            flash('User does not exist')
            return redirect('/login')
        else:
            ## USER DOES EXIST, CHECK PASSWORD IS VALID
            user = results[0]
            if user['password'] == server_password:
                ## PASSWORD MATCHES UP AGAINST DATABASE
                session['user_id'] = user['id']
                session['email'] = user['email']
                session['username'] = user['username']
                return redirect('/')
            else:
                ## PASSWORD DOES NOT MATCH UP AGAINST DATABASE
                flash('Incorrect password.  Did you forget your password?')
                return redirect('/login')


    else:
        return redirect('/login')


@app.route('/register', methods=['POST'])
def register():
    print request.form
    is_valid = True

    server_username = request.form['html_username']
    server_email = request.form['html_email']
    server_password = request.form['html_password']
    server_confirm = request.form['html_confirm']

    if len(server_username) < 2:
        is_valid = False
        flash('Username must be longer that two characters')

    if server_password != server_confirm:
        is_valid = False
        flash('Passwords do not match!')

    if not email_regex.match(server_email):
        is_valid = False
        flash('Invalid email')

    if is_valid:
        try:
            parameters = {
                'parameter_username': server_username,
                'parameter_email': server_email,
                'parameter_password': server_password,
            }
            insert_user = 'insert into users (username, email, password, created_at, updated_at) values (:parameter_username, :parameter_email, :parameter_password, NOW(), NOW())'
            
            user_id = mysql_db.query_db(insert_user, parameters)
            
            session['user_id'] = user_id
            session['email'] = server_email
            session['username'] = server_username

            return redirect('/')
        except:
            flash('User exists')
            return redirect('/login')
    else:
        return redirect('/login')

@app.route('/logout')
def logout():
    session.clear()
    return redirect('/')

app.run(debug=True)