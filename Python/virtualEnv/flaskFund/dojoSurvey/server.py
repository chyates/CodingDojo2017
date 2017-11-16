from flask import Flask, session, request, redirect, render_template, session

app = Flask(__name__)
app.secret_key  = '50615aea897d53f9911a8f6458caa728'

@app.route('/')
def index():
    if 'summaries' not in session:
        session['summaries'] = []
    return render_template('index.html')

@app.route('/authenticate', methods=['POST'])
def auth(): 
    your_name = request.form['yourName']
    location = request.form['dojo_loc']
    fav_lang = request.form['fav_lang']
    comments = request.form['addl_comm']

    summary = {
        'name': your_name,
        'location': location,
        'fav_lang': fav_lang,
        'comments': comments
    }

    summaries = session['summaries']
    summaries.append(summary)
    session['summaries'] = summaries

    return redirect('/')


app.run(debug=True)