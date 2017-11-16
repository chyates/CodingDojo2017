var mongoose = require('mongoose');

// **CHANGE THE FOLLOWING LINE BASED ON PROJECT
var Listing = mongoose.model('Listing');

module.exports = {
    find: function(req, res){
        Listing.find({}, function (err, results){
            if (err){
                res.json({'errors': err})
            } else {
                res.json({'results': results})
            }
        });
    },

    create: function (req, res){
        Listing.create(req.body, function(err, listing){
            if (err) {
                res.json({'errors': err})
            } else {
                res.json({'listing': listing})
            }
        });
    }
}