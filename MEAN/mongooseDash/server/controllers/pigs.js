var mongoose = require('mongoose');
var Pig = mongoose.model('Pig');

module.exports = {
    index: function(req, res){
        Pig.find({}, function (error, results) {
            if (error) {
                console.log(error);
            }
            else {
                console.log("no errors");
                res.render('index', { pigs: results });
            }
        });
    },
    show: function(req, res){
        Pig.find({ _id: req.params.id }, function (error, response) {
            if (error) {
                console.log(error);
            }
            else {
                res.render('pig', { pig: response[0] });
            }
        });
    },
    edit: function(req, res){
        Pig.find({ _id: req.params.id }, function (error, response) {
            if (error) {
                console.log(error);
            }
            else {
                res.render('updatePig', { pig: response[0] });
            }
        });
    },
    create: function(req, res){
        Pig.create(req.body, function (error, results) {
            if (error) {
                console.log(error);
            }
            else {
                console.log("no errors");
                res.redirect('/');
            }
        });
    },
    update: function(req, res){
        Pig.update({ _id: req.params.id }, req.body, function (error, results) {
            if (error) {
                console.log(error);
            }
            else {
                res.redirect('/');
            }
        });
    },
    delete: function(req, res){
        Pig.remove({ _id: req.param.id }, function (error, result) {
            if (error) {
                console.log(error);
            }
            else {
                res.redirect('/');
            }
        });
    }
}