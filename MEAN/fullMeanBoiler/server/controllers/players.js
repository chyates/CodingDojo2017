var mongoose = require('mongoose');

// **CHANGE THE FOLLOWING LINE BASED ON PROJECT
var Player = mongoose.model('Player');

module.exports = {
    index: function (req, res) {
        res.json();
    }
}