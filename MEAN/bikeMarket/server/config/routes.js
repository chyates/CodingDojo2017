var mongoose = require('mongoose');

// Tables in DB
// **CHANGE THE FOLLOWING LINES BASED ON PROJECT
var User = mongoose.model('User');
var Listing = mongoose.model('Listing');
var users = require('../controllers/users.js');
var listings = require('../controllers/listings.js')

//GET requests

module.exports = function (app) {

    app.get('/api/login', function(req, res){
        users.find(req, res);
    });

    app.get('/api/allListings', function (req, res){
        listings.find(req, res);
    });
    
    // POST requests
    
    app.post('/api/register', function(req, res){
        // **CHANGE THE FOLLOWING LINE BASED ON PROJECT
        users.create(req, res);
    });

    app.post('/api/add', function(req, res){
        listings.create(req, res);
    });
    
    // Last catch-all route
    app.all("*", (req, res, next) => {
        res.sendFile(path.resolve("./frontEnd/dist/index.html"))
    });
}