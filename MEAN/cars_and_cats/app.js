var http = require('http');
var fs = require('fs');

var server = http.createServer(function (request, response) {
    console.log('client request URL: ', request.url);
    if (request.url === '/') {
        fs.readFile('./views/index.html', 'utf8', function (errors, contents) {
            response.writeHead(200, { 'Content-Type': 'text/html' }); // send data about response
            response.write(contents); // send response body
            response.end(); // finished!
        });
    }
    else if(request.url === '/stylesheets/style.css'){
        fs.readFile('./stylesheets/style.css', 'utf8', function(errors, contents){
         response.writeHead(200, {'Content-type': 'text/css'});
         response.write(contents);
         response.end();
        })
      }    
    else if (request.url === '/cats') {
        fs.readFile('./views/cats.html', 'utf8', function (errors, contents) {
            response.writeHead(200, { 'Content-Type': 'text/html' }); // send data about response
            response.write(contents); // send response body
            response.end(); // finished!
        });
    }
    else if(request.url === '/images/thundercats.jpg'){
        // notice we won't include the utf8 encoding
        fs.readFile('./images/thundercats.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        })
      }
    else if (request.url === '/cars') {
        fs.readFile('./views/cars.html', 'utf8', function (errors, contents) {
            response.writeHead(200, { 'Content-Type': 'text/html' }); // send data about response
            response.write(contents); // send response body
            response.end(); // finished!
        });
    }
    else if(request.url === '/images/cars.jpg'){
        // notice we won't include the utf8 encoding
        fs.readFile('./images/cars.jpg', function(errors, contents){
            response.writeHead(200, {'Content-type': 'image/jpg'});
            response.write(contents);
            response.end();
        })
      }
    else if (request.url === '/cars/new') {
        fs.readFile('./views/newCar.html', 'utf8', function (errors, contents) {
            response.writeHead(200, { 'Content-Type': 'text/html' }); // send data about response
            response.write(contents); // send response body
            response.end(); // finished!
        });
    }
    else {
        response.writeHead(404);
        response.end('File not found!!!');
    }
});
server.listen(7707);
console.log("Running in localhost at port 7707");