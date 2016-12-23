var io = require('socket.io')({
	transports: ['websocket'],
});

var helper = require('./JS/helper.js');
var lobby = require('./lobby.js');

io.attach(4066);

console.log("Chat Server started! Vai serginhooo");

io.on('connection', function(socket){	
	//player.addIDServer(, "Lobby");

	io.sockets.emit('Teste');

    socket.on('SendMessage', function(data){
		var playerList = helper.getAllPlayersInServer(data.channel);
		var name = helper.getUserByID(socket.id).name;
		
		console.log("["+socket.id+"]"+"["+name+"] send a message: "+ data.sendMessage);
		
		/*for(i=0;i<playerList.length;i++)
		{
			io.to(0).emit("ReceiveMessage", {message: data.message});
		}*/
		
		io.to("0").emit('ReceiveMessage', {message: data.sendMessage});
	});
})

