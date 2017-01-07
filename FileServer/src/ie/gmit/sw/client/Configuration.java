package ie.gmit.sw.client;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.net.UnknownHostException;

import org.dom4j.Attribute;
import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

public class Configuration {
	private String username;
	private String serverhost;
	private int serverport;
	private String downloaddir;
	private Socket serverSocket;
	private String file;


	public void connectToServer() {
		try {
			serverSocket = new Socket(serverhost, serverport);
			System.out.println(username + ", welcome to file server!");
			System.out.println();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void printFile(File file, int level ){
		
		
			System.out.println(file.getName());
			
			if(file.isDirectory()){
				File[] files = file.listFiles();
				for(File temp : files){
					printFile(temp, level+1);
				}
		
			}
	}
	
	public void download(File dfile) {
		if (dfile.isFile()){
			String filePath = dfile.getAbsolutePath();//获取绝对路径
			String newFilePath = filePath.substring(1) + "/newdir";//不知道怎么修改
			File parentFile = new File(newFilePath).getAbsoluteFile();
			if(!parentFile.exists()){
				parentFile.mkdirs();
				
			}
			
			
				FileInputStream fis = null;
				FileOutputStream fos = null;
				try{
				fis = new FileInputStream(filePath);
				fos = new FileOutputStream(newFilePath);
				//copy
				byte[] bytes = new byte[102400]; 
				int temp = 0;
				while((temp = fis.read(bytes)) !=-1){
					fos.write(bytes,0,temp);
				}
				fos.flush();
				}catch (Exception e) {
					e.printStackTrace();
				}finally{
					if(fis!=null)
						try {
							fis.close();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
					if(fos!=null)
						try {
							fos.close();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
				}
			}
		
		}
		

	public void loadConfig() {
		try {
			SAXReader saxReader = new SAXReader();
			Document document = saxReader.read(new File(Configuration.class.getResource("./config.xml").getFile()));
			Element root = document.getRootElement();

			Attribute attribute = root.attribute("username");
			username = attribute.getValue();

			Element element = root.element("server-host");
			serverhost = element.getStringValue();

			element = root.element("server-port");
			serverport = Integer.parseInt(element.getStringValue());

			element = root.element("download-dir");
			downloaddir = element.getStringValue();
		} catch (DocumentException e) {
			e.printStackTrace();
		}
	}

	public String getUsername() {
		return username;
	}

	public String getServerhost() {
		return serverhost;
	}

	public int getServerport() {
		return serverport;
	}

	public String getDownloaddir() {
		return downloaddir;
	}

	public Socket getServerSocket() {
		return serverSocket;
	}

	public void setServerSocket(Socket serverSocket) {
		this.serverSocket = serverSocket;
	}

}
