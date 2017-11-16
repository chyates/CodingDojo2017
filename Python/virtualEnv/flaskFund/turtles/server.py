from flask import Flask, request, redirect, render_template

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/ninja')
def ninja():
    return render_template('ninja.html')

@app.route('/ninja/<color>')
def show_color(color):

    if color == 'purple':
        return render_template('color.html', color='purple')
    elif color == 'blue':
        return render_template('color.html', color='blue')
    elif color == 'orange':
        return render_template('color.html', color='orange')
    elif color == 'red':
        return render_template('color.html', color='red')
    else: 
        return render_template('color.html')


app.run(debug=True)