var mongoose = require('mongoose');
var Message = mongoose.model('Message');
var messages = require('../controllers/messages.js');
// var Comment = mongoose.model('Comment');
// var comments = require('../controllers/comments.js');
// controller file should be plural of model name
// must require each model/controller file if more than one

module.exports = function(app) {
    // GET requests
    app.get('/', function(req, res) {
        messages.index(req, res);
    });

    // POST requests
    app.post('/addMessage', function(req, res) {
        messages.create(req, res);
    });

    app.post('/:id/addComment', function (req, res) {
        messages.addComment(req, res);
    });
}