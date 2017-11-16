from flask import Flask, session, request, redirect, render_template
from mysqlconnection import MySQLConnector

app = Flask(__name__)
app.secret_key = 'df8fdd1b395c324eed654636fc51a90a'
mysql_connection = MySQLConnector(app, 'friends')

@app.route('/', methods=['GET', 'POST'])
def index():
    query = 'SELECT first_name, last_name, age FROM friends'
    results = mysql_connection.query_db(query)

    return render_template('index.html', friends=results)

@app.route('/process', methods=['POST'])
def process():
    parameters = {
        'parameter_first_name': request.form['first_name'],
        'parameter_last_name': request.form['last_name'],
        'parameter_age': request.form['age']
    }

    query = 'INSERT INTO friends (first_name, last_name, age) VALUES (:parameter_first_name, :parameter_last_name, :parameter_age)'
    results = mysql_connection.query_db(query, parameters)
    return redirect('/')


app.run(debug=True)