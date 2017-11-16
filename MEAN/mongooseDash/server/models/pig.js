var mongoose = require('mongoose');

var PigSchema = new mongoose.Schema({
    name: String,
    breed: String,
    weight: Number,
    age: Number
});

mongoose.model('Pig', PigSchema);