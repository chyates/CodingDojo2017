var express = require("express");
var path = require("path");
var app = express();
var bodyParser = require('body-parser');

var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/messageBoard');
require('./server/config/mongoose.js');

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, "./static")));

app.set('views', path.join(__dirname, './client/views'));
app.set('view engine', 'ejs');

var routes_setter = require('./server/config/routes.js');
routes_setter(app);

app.listen(8000, function(){
  console.log("Running on port 8000");
});