import * as http from 'http'; //using improts this way is required to target ECMA scripts, technically slightly slower, but faster.
const port = process.env.port || 1337
http.createServer(function (_req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('Hello World\n');
}).listen(port);