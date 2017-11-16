var express = require("express");
var path = require("path");
var session = require('express-session');
var bodyParser = require('body-parser');

var app = express();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(session({secret: 'testkey'}));
app.use(express.static(path.join(__dirname, "./static")));

app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

app.get('/', function(req, res) {
    var count;
    if (!req.session.attempt) {
        req.session.attempt = 1;
        count = req.session.attempt;
    }
    else {
        req.session.attempt += 1;
        count = req.session.attempt;
    }
    console.log(count);
    res.render("index", {count: count});
})

app.listen(8000, function() {
    console.log("listening on port 8000");
});
