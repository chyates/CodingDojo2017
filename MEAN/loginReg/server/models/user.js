var mongoose = require('mongoose');
var bcrypt = require('bcrypt-nodejs');

var UserSchema = new mongoose.Schema({
    firstName: { type: String, required: true, minlength: 2 },
    lastName: { type: String, required: true, minlength: 2 },
    email: { type: String, required: true, minlength: 2 },
    birthday: { type: Date, required: true },
    password: { type: String, required: true, minlength: 8, maxlength: 15 }
});

mongoose.model('User', UserSchema);