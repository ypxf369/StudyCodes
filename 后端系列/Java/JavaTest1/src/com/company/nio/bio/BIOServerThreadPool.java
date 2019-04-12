package com.company.nio.bio;

import java.io.IOException;
import java.io.InputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Scanner;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Semaphore;

/**
 * Created by yepeng on 2019/04/06.
 */
public class BIOServerThreadPool {
    private static final int THREAD_SIZE=3;
    public static void main(String[] args) {
        Semaphore semaphore=new Semaphore(3);
        ExecutorService executorService = Executors.newFixedThreadPool(THREAD_SIZE);
        try (ServerSocket serverSocket = new ServerSocket(8888)) {
            System.out.println("ServereSocket is started,listening on port: " + serverSocket.getLocalSocketAddress());

            while (true) {
                if(semaphore.availablePermits()==0){
                    System.out.println("连接已满......");
                }
                Socket clientSocket = serverSocket.accept();
                executorService.execute(() -> {
                    try {
                        // 获取许可
                        semaphore.acquire();
                        System.out.println("Connection from " + clientSocket.getRemoteSocketAddress());
                        InputStream inputStream = clientSocket.getInputStream();
                        try (Scanner input = new Scanner(inputStream)) {
                            while (true) {
                                String request = input.nextLine();
                                System.out.println(String.format("From %s : %s", clientSocket.getRemoteSocketAddress(), request));
                                if (request.equals("quit")) {
                                    // 释放许可
                                    semaphore.release();
                                    break;
                                }
                                String response = "Hello " + request + "\n";
                                clientSocket.getOutputStream().write(response.getBytes());
                            }
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                });
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        executorService.shutdown();
    }
}
