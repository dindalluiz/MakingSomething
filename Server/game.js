var io = require('socket.io')({
	transports: ['websocket'],
});

var player = require('./JS/player.js');

io.attach(4068);

var playerList = [];

console.log("Vai serginhooo")

io.on('connection', function(socket){
    var player2 = player.create(socket.id,0, 0, "");
	console.log("User: " + player2.id + " Connected");
	
	/*playerList.push(player2);*/
	
	socket.on('updatePos', function(data){
		console.log("BUCETINHA:");
		//socket.emit('updatePos', {id: data.id, x: data.x, y: data.y});
		io.emit('updatePos', {message: "true"});
		
	});

	socket.on('disconnect', function(){
		io.emit('user disconnected', {id: socket.id});
		console.log("User: " + socket.id + " Desconnected");
	});
})

