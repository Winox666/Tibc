import asyncio
import websockets
import json

class TibiaServer:
    def __init__(self):
        self.clients = set()
        self.game_map = self.load_tibia_map()
        
    def load_tibia_map(self):
        # Mapa básico (implementar mapa real aquí)
        return {
            "width": 100,
            "height": 100,
            "tiles": [[{"walkable": True} for _ in range(100)] for _ in range(100)]
        }

    async def handle_client(self, websocket):
        self.clients.add(websocket)
        try:
            async for message in websocket:
                await self.broadcast(message)
        finally:
            self.clients.remove(websocket)

    async def broadcast(self, message):
        for client in self.clients:
            await client.send(message)

server = TibiaServer()
start_server = websockets.serve(server.handle_client, "0.0.0.0", 8765)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()