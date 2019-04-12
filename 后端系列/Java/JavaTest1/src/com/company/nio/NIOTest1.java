package com.company.nio;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.nio.ByteBuffer;
import java.nio.channels.SocketChannel;
import java.nio.charset.Charset;

/**
 * Created by yepeng on 2019/02/26.
 */
public class NIOTest1 {
    private Charset charset = Charset.forName("UTF-8");

    private SocketChannel channel;


    private void readHtmlContent() {
        try {
            connect();
            sendRequest();
            readResponse();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (channel != null) {
                try {
                    channel.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    private void connect() throws IOException {
        InetSocketAddress socketAddress = new InetSocketAddress("www.csdn.net", 80);
        channel = SocketChannel.open(socketAddress);
        channel.configureBlocking(false);
    }

    private void sendRequest() throws IOException {
        channel.write(charset.encode("GET"));
    }

    private void readResponse() throws IOException {
        ByteBuffer buffer = ByteBuffer.allocate(1024);//创建缓冲区
        while (channel.read(buffer) != -1) {
            buffer.flip();
            System.out.println(charset.decode(buffer));
            buffer.clear();
        }
    }

    public static void main(String[] args) {
        new NIOTest1().readHtmlContent();
    }
}
