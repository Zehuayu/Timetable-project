package ie.gmit.sw.server;

import java.util.ArrayList;

public class Poison implements Runnable {
	private ArrayList<ClientConnection> clientConns;
	private boolean runningFlag = true;

	public void run() {
		while(runningFlag) {
			if (clientConns != null) {
				for (int i = clientConns.size() - 1; i > -1; i--) {
					ClientConnection clientConnection = clientConns.get(i);
					clientConnection.refreshTimeoutFlag();
					if (!clientConnection.isRunningFlag()) {
						clientConns.remove(i);
					}
				}
			}
			try {
				Thread.sleep(1 * 1000);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
	
	public void shutdownAll() {
		for (int i = clientConns.size() - 1; i > -1; i--) {
			ClientConnection clientConnection = clientConns.get(i);
			clientConnection.setRunningFlag(false);
			clientConns.remove(i);
		}
	}

	public ArrayList<ClientConnection> getClientConns() {
		return clientConns;
	}

	public void setClientConns(ArrayList<ClientConnection> clientConns) {
		this.clientConns = clientConns;
	}

	public void setRunningFlag(boolean runningFlag) {
		this.runningFlag = runningFlag;
	}

}
