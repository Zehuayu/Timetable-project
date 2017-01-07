package ie.gmit.sw.server;

import java.io.File;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class CoreServer {
	private int port;
	private String folderPath;
	private File folder;

	public void start() {
		ServerSocket serverSocket = null;
		ArrayList<ClientConnection> clientConns = new ArrayList<>();
		Poison poison = new Poison();
		Thread poisonThread = null;
		ExecutorService fixedThreadPool = Executors.newFixedThreadPool(8);
		try {
			serverSocket = new ServerSocket(port);
			System.out.println("Started server on port " + port);
			
			folder = new File(folderPath);

			poison.setClientConns(clientConns);
			poisonThread = new Thread(poison);
			poisonThread.start();

			while (true) {
				Socket clientSocket = serverSocket.accept();

				ClientConnection clientConnection = new ClientConnection();
				clientConnection.setClientSocket(clientSocket);
				fixedThreadPool.execute(clientConnection);
				clientConns.add(clientConnection);
				
				System.out.println("Client port: " + clientSocket.getPort());
			}
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			try {
				if (serverSocket != null) {
					serverSocket.close();
				}
				if (poison != null) {
					poison.shutdownAll();
					poison.setRunningFlag(false);
				}
				if (fixedThreadPool != null) {
					fixedThreadPool.shutdownNow();
				}
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	public int getPort() {
		return port;
	}

	public void setPort(int port) {
		this.port = port;
	}

	public String getFolderPath() {
		return folderPath;
	}

	public void setFolderPath(String folderPath) {
		this.folderPath = folderPath;
	}

}
