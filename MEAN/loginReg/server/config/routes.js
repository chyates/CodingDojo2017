var mongoose = require('mongoose');
var User = mongoose.model('User');
var users = require('../controllers/users.js');

//GET requests

app.get('/', function(req, res){
    res.render('index');
});

// POST requests

app.post('/register', function(req, res){
    users.create(req, res);
})