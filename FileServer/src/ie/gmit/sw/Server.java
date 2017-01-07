package ie.gmit.sw;

import ie.gmit.sw.server.CoreServer;

public class Server {
	public static void main(String[] args) {
		CoreServer coreServer = new CoreServer();
		int port = Integer.parseInt(args[0]);
		String folderPath = args[1];
		coreServer.setPort(port);
		coreServer.setFolderPath(folderPath);
		coreServer.start();
	}
}
