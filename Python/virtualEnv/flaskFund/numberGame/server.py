from flask import Flask, session, request, redirect, render_template, session

app = Flask(__name__)
app.secret_key = '41d523f352d8f31a25feed9d6f06d2d7'

import random

@app.route('/')
def index():
    if 'random_number' not in session:
        session['random_number'] = random.randrange(0, 101)

    return render_template('index.html')

@app.route('/check', methods=['POST'])
def play():

    num_guess = int(request.form['num_guess'])
    if num_guess < session['random_number']:
        session['result'] = 'Your guess was too low!'
    elif num_guess > session['random_number']:
        session['result'] = 'Your guess was too high!'
    elif num_guess == session['random_number']:
        session['result'] = 'You got it!'

    return redirect('/')

@app.route('/reset')
def reset():
    session.clear()
    return redirect('/')


app.run(debug=True)




