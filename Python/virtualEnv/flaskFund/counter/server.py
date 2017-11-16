from flask import Flask, session, request, redirect, render_template, session

app = Flask(__name__)
app.secret_key = '5ad5356aae67f7eb24e62bd78904bec0'

@app.route('/')
def index():
    try:
        session['times'] += 1
    except:
        session['times'] = 1
    return render_template('index.html')


app.run(debug=True)