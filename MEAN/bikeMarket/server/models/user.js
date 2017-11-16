var mongoose = require('mongoose');
var bcrypt = require('bcrypt-nodejs');
var Schema = mongoose.Schema;

// **CHANGE THE FOLLOWING LINE BASED ON PROJECT
var UserSchema = new mongoose.Schema({
    firstName: { type: String, required: true, minlength: 2 },
    lastName: { type: String, required: true, minlength: 2 },
    email: { type: String, required: true, minlength: 2 },
    password: { type: String, required: true, minlength: 8 },
    listing: [{ type: Schema.Types.ObjectId, ref: 'Listing' }]
});

mongoose.model('User', UserSchema);