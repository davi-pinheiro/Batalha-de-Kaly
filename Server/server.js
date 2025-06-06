const WebSocket = require ('ws');
const PORT = 3000;
const ws_server = new WebSocket.Server({port: 3000},() =>
{
    console.log('server started')
});

ws_server.on('connection', (ws_client)=>
{
    ws_client.on('message', (message)=>
    {
        console.log(message.toString());
        ws_client.send.toString('Ouvido');
    })
})

ws_server.on('listening', ()=>
{
    console.log('Porta: ' + PORT);
})