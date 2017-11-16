from flask import Flask, session, request, redirect, render_template, flash
from mysqlconnection import MySQLConnector
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = 'cd52951f7c0dc0850f2c6c9cb7be9474'
mysql = MySQLConnector(app, 'login_reg')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/login')
def login():
    return render_template('login.html')

@app.route('/homepage')
def homepage():
    return render_template('/homepage.html')

@app.route('/process', methods=['POST'])
def process():
    is_valid = True

    server_first_name = request.form['f_name']
    server_last_name  = request.form['l_name']
    server_email = request.form['email']
    server_password = request.form['password']
    server_confirm = request.form['con_password']

    if len(server_first_name) < 2 or len(server_last_name) < 2:
        is_valid = False
        flash('Name field must be longer than two characters')

    if any(char.isdigit() for char in server_first_name) or any(char.isdigit() for char in server_last_name):
        is_valid = False
        flash ('Names cannot contain numbers')

    if server_password != server_confirm:
        is_valid = False
        flash('Passwords do not match!')

    if len(server_password) < 8: 
        is_valid = False
        flash('Password must be longer than 8 characters')

    if not EMAIL_REGEX.match(server_email):
        is_valid = False
        flash('Invalid email')

    if is_valid:
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

            flash('Success!')
            return redirect('/homepage')
        except:
            flash('User already exists')
            return redirect('/')
    else:
        return redirect('/homepage')

@app.route('/auth', methods=['POST'])
def auth():

    is_valid = True

    server_email = request.form['email']
    server_password = request.form['password']

    if len(server_email) < 2:
        is_valid = False
        flash('Username must be longer than two characters')
    
    if is_valid:
        ## QUERY DATABASE
        parameters = {
            'parameter_email': server_email,
        }
        query = 'select * from users where email = :parameter_email'
        results = mysql.query_db(query, parameters)
        
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
                return redirect('/homepage')
            else:
                ## PASSWORD DOES NOT MATCH UP AGAINST DATABASE
                flash('Incorrect password.  Did you forget your password?')
                return redirect('/login')

    else:
        return redirect('/login')

@app.route('/logout')
def logout():
    session.clear()
    return redirect('/')

app.run(debug=True)