from flask import Flask, session, request, redirect, render_template, flash
from mysqlconnection import MySQLConnector
import re

app = Flask(__name__)
app.secret_key = '52713a74fceed975a63c9b15a8ff442d'
mysql = MySQLConnector(app, 'email_valid')
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=['POST'])
def process():
    email = request.form['email']
    if not EMAIL_REGEX.match(email):
        flash('Invalid email address!')
        return redirect('/')
    else:
        parameters = {
            'parameter_email_address': request.form['email'],
        }

        query = 'INSERT INTO emails (email_address, created_at) VALUES (:parameter_email_address, NOW())'
        results = mysql.query_db(query, parameters)
    return redirect('/success')

@app.route('/success')
def success():

    query = 'SELECT email_address, created_at FROM emails'
    results = mysql.query_db(query)
    return render_template('success.html', emails=results)

app.run(debug=True)