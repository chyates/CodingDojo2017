var express = require('express');
var bodyParser = require('body-parser');
var path = require('path');
var mongoose = require('mongoose');

var app = express();

app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, './frontEnd/dist')));

app.set('views', path.join(__dirname, './client/views'));
app.set('view engine', 'ejs');

require('./server/config/mongoose.js');

var routesSetter = require('./server/config/routes.js');
routesSetter(app);

app.listen(8000, function() {
    console.log("listening on port 8000");
})