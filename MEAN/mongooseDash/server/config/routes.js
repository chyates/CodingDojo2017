var mongoose = require('mongoose');
var Pig = mongoose.model('Pig');
var pigs = require('../controllers/pigs.js')

module.exports = function (app) {
    // GET requests
    app.get('/', function (req, res) {
        pigs.index(req, res);
    });

    app.get('/pigs/new', function (req, res) {
        res.render('newPig');
    });

    app.get('/pigs/:id', function (req, res) {
        pigs.show(req, res);
    });

    app.get('/pigs/:id/edit', function (req, res) {
        pigs.edit(req, res);
    });

    // POST requests
    app.post('/pigs', function (req, res) {
        pigs.create(req, res);
    });

    app.post('/pigs/:id', function (req, res) {
        pigs.update(req, res);
    });

    app.post('/pigs/:id/delete', function (req, res) {
        pigs.delete(req, res);
    });
}
