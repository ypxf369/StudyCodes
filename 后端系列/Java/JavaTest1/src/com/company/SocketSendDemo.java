package com.company;


import java.io.IOException;
import java.net.*;

public class SocketSendDemo {
    public static void main(String[] args) throws IOException {
        DatagramSocket socket = new DatagramSocket();
        String msg = "hello world,im yepeng";
        byte[] bytes = msg.getBytes();
        DatagramPacket packet = new DatagramPacket(bytes, bytes.length);
        packet.setAddress(InetAddress.getLocalHost());
        packet.setPort(8888);
        socket.send(packet);
        socket.close();
    }
}
