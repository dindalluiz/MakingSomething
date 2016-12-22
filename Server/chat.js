var io = require('socket.io')({
	transports: ['websocket'],
});

var playerScript = require('./JS/player.js');
var helper = require('./JS/helper.js');
var lobby = require('./lobby.js');

io.attach(4066);

console.log("Chat Server started! Vai serginhooo");

var playerList = [];

io.on('connection', function(socket){
    socket.on('Message', function(data){
		playerList = lobby.getAllUsersInServer(data.channel);
		socket.id = lobby.getID();
		var name = lobby.getUserByID(socket.id).name;
		
		console.log("["+socket.id+"]"+"["+name+"] send a message: "+ data.message);
	
		for(var i=0;i<playerList.length;i++)
		{
			io.to(playerList[i].id).emit("Message", {channel: data.channel,message: data.message});
		}
	});
})

