var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CommentSchema = new mongoose.Schema({
    _message: {type: Schema.Types.ObjectId, ref: 'Message'},
    name: { type: String, required: true, minlength: 4},
    content: { type: String, required: true}
});

mongoose.model('Comment', CommentSchema);