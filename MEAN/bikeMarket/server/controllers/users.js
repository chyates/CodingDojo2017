var mongoose = require('mongoose');

// **CHANGE THE FOLLOWING LINE BASED ON PROJECT
var User = mongoose.model('User');

module.exports = {
    create: function (req, res) {
        var newUser = new User(req.body);
        newUser.save(function(err, user){
            if(err){
                res.json({error: "there were errors"})
            } else {
                res.json({user: user, loggedIn: true});
                req.session.user = user;
            }
        });
    //    User.create(req.body, function (err, user){
    //        if (err){
    //            res.json({'errors': err})
    //        } else {
    //            req.session.id = user._id
    //            console.log(req.session.id)
    //            res.json({'user': user})
    //        }
    //    }); 
    },

    find: function (req, res) {
        // User.find({email: req.body.email}, function (err, response) {
        //     if (err) {
        //         res.json({'errors': err})
        //     } else {
        //         res.json({response: response})
        //     }
        // });
        User.findOne({email: req.body.logEmail}, function (err, user){
            if (user === null){
                res.json({error: err}, loggedIn = false)
            } else {
                req.session.user = user;
                res.json({user: user})
            }
        })
    },

    logout: function (req, res){
        req.session.destroy
    }
}