package ie.gmit.sw.server;

import java.net.Socket;

public class ClientConnection implements Runnable {
	private Socket clientSocket;
	private long lastOperateTime = System.currentTimeMillis();
	private boolean runningFlag = true;

	public void run() {
		while (runningFlag) {
			System.out.println("cli port: " + clientSocket.getPort());
			try {
				Thread.sleep(10000);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
	
	public void refreshLastOperateTime() {
		lastOperateTime = System.currentTimeMillis();
	}
	
	public void refreshTimeoutFlag() {
		long current = System.currentTimeMillis();
		if (current - lastOperateTime > 5 * 60 * 1000) {
			runningFlag = false;
		}
	}

	public Socket getClientSocket() {
		return clientSocket;
	}

	public void setClientSocket(Socket clientSocket) {
		this.clientSocket = clientSocket;
	}

	public boolean isRunningFlag() {
		return runningFlag;
	}

	public void setRunningFlag(boolean runningFlag) {
		this.runningFlag = runningFlag;
	}
	
}
