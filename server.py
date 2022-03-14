# server.py
# TC2005B.441 202211
# Sergio. Server para CSTD
# 
from http.server import BaseHTTPRequestHandler, HTTPServer
import logging
import json

class Servidor(BaseHTTPRequestHandler):
	def _set_response(self):
		self.send_response(200)
		self.send_header('Content-type', 'text/html')
		self.end_headers()
	
	def do_GET(self):
		logging.info("GET request\nPath:\n%s\nHeaders:\n%s\n", str(self.path), str(self.headers))
		self._set_response()
		#self.wfile.write("GET request para {}".format(self.path).encode('utf-8'))
		usuario = {
			'id' : 1,
			'userId' : 2,
			'title' : "The Boss",
			'body' : "Im the boss!"
		}
		self.wfile.write(str(usuario).encode('utf-8'))
		#self.wfile.write("<b>En bold</b>".encode('utf-8'))
	
	def do_POST(self):
		logging.info("POST request\nPath:\n%s\nHeaders:\n%s\n", str(self.path), str(self.headers))
		self._set_response()
		self.wfile.write("POST request para {}".format(self.path).encode('utf-8'))

########################################################

def run(server_class=HTTPServer, handler_class=Servidor, port=8686):
	logging.basicConfig(level=logging.INFO)
	server_address = ('', port) # http://localhost:8686  o bien 127.0.0.1:8686
	httpd = server_class(server_address, handler_class)
	# HTTPD es HTTP daemon: daemon es un programa que se ejecuta sin parar.
	logging.info("Starting httpd...\n")
	try:
		httpd.serve_forever()
	except KeyboardInterrupt:     # CTRL+C para detenerlo!
		pass
	httpd.server_close()
	logging.info("Stopping httpd...\n")
	
if __name__ == '__main__':
	from sys import argv
	if len(argv) == 2:
		run(port=int(argv[1]))
	else:
		run()
	















