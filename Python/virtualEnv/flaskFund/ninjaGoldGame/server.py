from flask import Flask, session, request, redirect, render_template, url_for

app = Flask(__name__)
app.secret_key = '9b2f2e722ef1f44be8db10daf7f09dd1'

import random

@app.route('/')
def index():

    if 'gold' not in session:
        session['gold'] = 0
    if 'activities' not in session:
        session['activities'] = []

    return render_template('index.html')

@app.route('/process_gold', methods=['POST'])
def process_gold():

    activity = ''

    if request.form['building'] == 'farm':
        gold = random.randrange(10,21)
    elif request.form['building'] == 'cave':
        gold = random.randrange(5,11)
    elif request.form['building'] == 'house':
        gold = random.randrange(2,6)
    elif request.form['building'] == 'casino':
        gold = random.randrange(-50,51)

    if gold >= 0:
        activity += 'Earned ' + str(gold) + ' gold from the ' + str(request.form['building'])
        print activity
    else:
        activity += 'Entered a casino and lost ' + str(gold) + ' gold. Ouch!.'
        print activity
        
    session['gold'] += gold
    session['activities'].insert(0, activity)
    return redirect(url_for('index'))

app.run(debug=True)