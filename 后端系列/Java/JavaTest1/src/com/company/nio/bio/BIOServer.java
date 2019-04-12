package com.company.nio.bio;

import java.io.IOException;
import java.io.InputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Scanner;

/**
 * Created by yepeng on 2019/04/06.
 */
public class BIOServer {
    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(8888)) {
            System.out.println("ServereSocket is started,listening on port: " + serverSocket.getLocalSocketAddress());

            while (true) {
                Socket clientSocket = serverSocket.accept();
                System.out.println("Connection from " + clientSocket.getRemoteSocketAddress());
                InputStream inputStream = clientSocket.getInputStream();
                try (Scanner input = new Scanner(inputStream)) {
                    while (true) {
                        String request = input.nextLine();
                        System.out.println(String.format("From %s : %s", clientSocket.getRemoteSocketAddress(), request));
                        if (request.equals("quit")) {
                            break;
                        }
                        String response = "Hello " + request + "\n";
                        clientSocket.getOutputStream().write(response.getBytes());
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
