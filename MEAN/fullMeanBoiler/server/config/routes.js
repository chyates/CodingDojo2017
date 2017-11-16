var mongoose = require('mongoose');

// Tables in DB
// **CHANGE THE FOLLOWING LINES BASED ON PROJECT
var Player = mongoose.model('Player');
var players = require('../controllers/players.js');

//GET requests

module.exports = function (app) {

    app.get('/', function(req, res){
        players.index(req, res);
    });
    
    // POST requests
    
    app.post('/register', function(req, res){
        // **CHANGE THE FOLLOWING LINE BASED ON PROJECT
        players.create(req, res);
    });
    
    // Last catch-all route
    app.all("*", (req, res, next) => {
        res.sendFile(path.resolve("./frontEnd/dist/index.html"))
    });
}