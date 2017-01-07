package ie.gmit.sw;

import java.io.File;
import java.util.Scanner;

import ie.gmit.sw.client.Configuration;

public class Client {
	public static void main(String[] args) {
		Configuration configuration = new Configuration();
		
		configuration.loadConfig();
		
		String option = Client.printMenu();
		while (true) {
			if ("1".equals(option)) {
				//1. Connect to Server
				System.out.println("1");
				configuration.connectToServer();
			} else if ("2".equals(option)) {
				// 2. Print File Listing
				System.out.println("2");
				File file1 = new File("/Users/yuzehua/Downloads");
				configuration.printFile(file1, 0);
			} else if ("3".equals(option)) {
				// 3. Download File
				System.out.println("3");
				File file2 = new File("/Users/yuzehua/Downloads");
				configuration.download(file2);
				
			} else if ("4".equals(option)) {
				// 4. Quit
				System.out.println("Quit client");
				System.exit(0);
			} else {
				System.out.println("This is not an available option, please type again.");
			}
			option = Client.printMenu();
		}
	}

	public static String printMenu() {
		System.out.println("1. Connect to Server");
		System.out.println("2. Print File Listing");
		System.out.println("3. Download File");
		System.out.println("4. Quit");
		System.out.println("");
		System.out.print("Type Option [1-4]>");
		Scanner scanner = new Scanner(System.in);
		return scanner.next();
	}
}
