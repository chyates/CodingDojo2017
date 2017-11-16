var mongoose = require('mongoose');
var bcrypt = require('bcrypt-nodejs');
var Schema = mongoose.Schema;

// **CHANGE THE FOLLOWING LINE BASED ON PROJECT
var ListingSchema = new mongoose.Schema({
    title: { type: String, required: true, minlength: 4 },
    desc: { type: String, required: true, maxlength: 200 },
    price: { type: Number, required: true, min: 1  },
    location: { type: String, required: true },
    image: { type: String, required: true },
    _user: { type: Schema.Types.ObjectId, ref: 'User'}
});

mongoose.model('Listing', ListingSchema);