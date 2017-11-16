from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def hello_world():
    return render_template('/index.html')

@app.route('/bio.html')
def bio():
    return render_template('/bio.html')

@app.route('/projects.html')
def projects():
    return render_template('/projects.html')


app.run(debug=True)