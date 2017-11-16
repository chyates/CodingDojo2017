from flask import Flask, request, redirect, render_template, session, flash

app = Flask(__name__)
app.secret_key  = 'cd96daba41b5af9a2b88f7291a20895a'

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

    if len(your_name) < 1 or len(comments) < 1:
        flash('Required fields cannot be left blank!')
    elif len(comments) > 120:
        flash('You have exceeded the max character limit')
    else:
        flash('Success! Thanks for submitting your information.')

    return redirect('/')


app.run(debug=True)