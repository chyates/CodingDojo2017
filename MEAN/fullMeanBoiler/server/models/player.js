var mongoose = require('mongoose');
var bcrypt = require('bcrypt-nodejs');

// **CHANGE THE FOLLOWING LINE BASED ON PROJECT
var PlayerSchema = new mongoose.Schema({
    name: { type: String, required: true, minlength: 2 },
    preferredPosition: { type: String, minlength: 2 }
});

mongoose.model('Player', PlayerSchema);