var express = require('express');
var path = require('path');
var bodyParser = require('body-parser');

var app = express();
var mongoose = require('mongoose');

// Add mongoose, change DB name
mongoose.connect('mongodb://localhost/quotingDojo');

var QuoteSchema = new mongoose.Schema({
    name: String,
    quote: String
});

// saving the model to use later
var Quote = mongoose.model('quotes', QuoteSchema);

app.use(bodyParser.urlencoded({ extended: true }));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

// ** If communicationg with DB, responses should be in the callback
app.get('/', function (req, res) {
    res.render('index');
});

app.post('/addQuote', function (req, res) {
    Quote.create(req.body, function(error){
        if(error){
            console.log(error);
        }
        else{
            console.log("no errors");
            res.redirect('/quotes');
        }
    });
});

app.get('/quotes', function(req, res){
    Quote.find({}, function(error, results){
        if(error){
            console.log(error);
        }
        else{
            res.render('quotes', {quotes: results});
        }
    });
});

app.listen(8000);