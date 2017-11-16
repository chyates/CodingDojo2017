var express = require('express');
var bodyParser = require('body-parser');
var path = require('path');
var session = require('express-session');
var mongoose = require('mongoose');

var app = express();

app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, './frontEnd/dist')));
app.use(session({
    secret: '4f618bcbe5cf3f63570db6ddce45d768',
    resave: false,
    saveUninitialized: true
}))

app.set('views', path.join(__dirname, './client/views'));
app.set('view engine', 'ejs');

require('./server/config/mongoose.js');

var routesSetter = require('./server/config/routes.js');
routesSetter(app);

app.listen(8000, function() {
    console.log("listening on port 8000");
})