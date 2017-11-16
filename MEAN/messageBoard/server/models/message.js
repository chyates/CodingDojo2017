var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var MessageSchema = new mongoose.Schema({
    name: { type: String, required: true, minlength: 4},
    content: {type: String, required: true },
    _comments: [{ type: Schema.Types.ObjectId, ref: 'Comment'}]
});

mongoose.model('Message', MessageSchema);