from flask import Flask, session, request, redirect, render_template, flash
import re

app = Flask(__name__)
app.secret_key = 'cabdc0b5a7ffa24de264a936fdf13ad3'
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route('/')
def index():

    return render_template('index.html')

@app.route('/process', methods=['POST'])
def process():

    first_name = request.form['f_name']
    last_name = request.form['l_name']
    email = request.form['email']
    password = request.form['password']
    confirm_password = request.form['rep_password']

    if len(first_name) < 1 or len(last_name) < 1 or len(email) < 1 or len(password) < 1 or len(confirm_password) < 1:
        flash('Required field cannot be left blank')
    elif not EMAIL_REGEX.match(email):
        flash('Invalid email address.')
    elif len(password) < 8:
        flash('Password must be more than 8 characters')
    elif any(char.isdigit() for char in password) == False:
        flash('Passwords must contain at least one number')
    elif any(char.isupper() for char in password) == False:
        flash('Passwords must contain at least one uppercase letter')
    elif password != confirm_password:
        flash('Passwords do not match')
    elif any(char.isdigit() for char in first_name) or any(char.isdigit() for char in last_name):
        flash ('Names cannot contain numbers.')
    else:
        flash('Thanks for submitting your information!')

    return redirect('/')


app.run(debug=True)

#validation conditionals:
    #no field can be blank
    #first/last name cannot contain numbers
    #password should be > 8 characters
    #email should be a valid email (should contain an @ sign?)
    #password and confirm password should match exactly
    #if all of that is valid, return a string of 'Thanks for submitting your information!'