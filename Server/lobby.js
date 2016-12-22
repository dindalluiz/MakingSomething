var io = require('socket.io')({
	transports: ['websocket'],
});

var helper = require('./JS/helper.js');

io.attach(4065);

console.log("Lobby Server started! Vai serginhooo");

function getAllIDS()
{
	var array = [];
	
	for(i=0;i<helper.getPlayerList().length;i++)
	{
		if(helper.getPlayerList()[i] != null)
			array.push(helper.getPlayerList()[i].id);
	}
	
	return array;
} 

io.on('connection', function(socket){
	var player = helper.player().create();
	player.id = helper.generateID(getAllIDS(), 10);
	socket.id = player.id;
	console.log("["+player.id+"]"+" Connected");
	helper.addPlayerList(socket.id, player);
	console.log(helper.getPlayerList(), 'geral');
	
	
	socket.on('SetName', function(data){
		helper.setPlayerListName(socket.id, data.name);
		io.emit("GetUsers", {users: helper.formatString(helper.getPlayerList(),",")});
		
		console.log("["+socket.id+"]"+" change the name to: " + data.name);
	});
	
	socket.on('GetUsers', function(){
		console.log("["+socket.id+"]"+" required list of users");
		socket.emit("GetUsers", {users: helper.formatString(helper.getPlayerList(),",")});
	});
	
	socket.on('disconnect', function () {
		console.log("["+socket.id+"]"+" disconnected");
		io.emit("GetUsers", {users: helper.formatString(helper.getPlayerList(),",")});
		helper.removePlayerList(socket.id);
	});
});