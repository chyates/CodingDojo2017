from flask import Flask, session, request, redirect, render_template
from mysqlconnection import MySQLConnector

app = Flask(__name__)
mysql = MySQLConnector(app, 'world')

@app.route('/', methods=['GET', 'POST'])
def index():
    if request.method == 'POST':
        print request.form['country_name']
        return redirect('/')
    else:
        query = 'select name, indep_year, head_of_state from countries'
        results = mysql.query_db(query)
        return render_template('index.html', countries = results)


app.run(debug=True)