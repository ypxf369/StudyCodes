package com.company;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;

public class SocketReciveDemo {
    public static void main(String[] args) throws IOException {
        DatagramSocket socket = new DatagramSocket(8888);

        byte[] bytes = new byte[1024];
        DatagramPacket packet = new DatagramPacket(bytes, bytes.length);
        socket.receive(packet);
        int length=packet.getLength();

        //解析数据
        byte[] data = packet.getData();
        System.out.println(new java.lang.String(data, 0, length));

    }
}
