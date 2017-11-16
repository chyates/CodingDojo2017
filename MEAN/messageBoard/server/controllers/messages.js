var mongoose = require('mongoose');
var Message = mongoose.model('Message');
var Comment = mongoose.model('Comment');

module.exports = {
    index: function(req, res) {
        Message.find({}).populate('_comments').exec(function (error, results){
            if (error) {
                console.log(error);
            }
            else {
                console.log("no errors");
                res.render('index', { messages: results});
            }
        });
    },
    create: function(req, res) {
        var newMessage = new Message ({name: req.body.name, content: req.body.content});
        newMessage.save(function(error){
            if (error) {
                console.log(error);
            }
            else {
                res.redirect('/');
            }
        });
    },
    addComment: function(req, res) {
        Message.findOne({_id: req.params.id}, function(error, message){
            var comment = new Comment({name: req.body.name, content: req.body.content});
            comment._message = req.params.id;
            Message.update({_id: req.params.id}, {$push: {"_comments": comment}}, function(error){

            });
            comment.save(function (error) {
                    if (error) {
                        console.log(error);
                    }
                    else {
                        res.redirect('/');
                    }
                });
            });
    }
}