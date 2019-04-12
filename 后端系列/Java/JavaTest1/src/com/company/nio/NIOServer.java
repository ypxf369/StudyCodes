package com.company.nio;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.nio.ByteBuffer;
import java.nio.channels.SelectionKey;
import java.nio.channels.Selector;
import java.nio.channels.ServerSocketChannel;
import java.nio.channels.SocketChannel;
import java.nio.charset.Charset;
import java.util.Iterator;
import java.util.Set;

/**
 * Created by yepeng on 2019/04/06.
 */
public class NIOServer {
    public static void main(String[] args) throws IOException {
        // 服务端连接
        ServerSocketChannel serverChannel = ServerSocketChannel.open();
        // 设置为非阻塞
        serverChannel.configureBlocking(false);
        // 服务端连接绑定端口
        serverChannel.bind(new InetSocketAddress(9999));

        System.out.println("NIO NIOServer has started,listening on port: " + serverChannel.getLocalAddress());

        // 打开一个选择器（Map集合，存放serverCahnnel连接及状态）
        Selector selector = Selector.open();
        // 注册到选择器上，标识状态为已连接
        serverChannel.register(selector, SelectionKey.OP_ACCEPT);
        // 定义返回数据的缓冲区
        ByteBuffer buffer = ByteBuffer.allocate(1024);

        while (true) {
            // 唯一一个会阻塞的地方，所有的等待都汇集到这边(等待客户端的连接,及输入)
            // 选择一个已经准备好IO操作的通道
            int select = selector.select();
            if (select == 0) {
                continue;
            }
            // 如果selector中有channel的话 SelectionKey可以理解为代表的是服务端和客户端的channel
            Set<SelectionKey> selectionKeys = selector.selectedKeys();
            Iterator<SelectionKey> iterator = selectionKeys.iterator();
            while (iterator.hasNext()) {
                SelectionKey key = iterator.next();
                // 判断是否已经连接
                if (key.isAcceptable()) {
                    ServerSocketChannel channel = (ServerSocketChannel) key.channel();
                    // 建立连接，进行监听
                    SocketChannel clientChannel = channel.accept();
                    System.out.println("Connection from " + clientChannel.getRemoteAddress());
                    // 配置为非阻塞
                    clientChannel.configureBlocking(false);
                    // 将客户端channe注册到选择器上，并且将状态标识为可读状态
                    clientChannel.register(selector, SelectionKey.OP_READ);
                }
                // 如果连接是可读状态（OP_READ）
                if (key.isReadable()) {
                    SocketChannel channel = (SocketChannel) key.channel();
                    channel.read(buffer);
                    String request = new String(buffer.array()).trim();
                    buffer.clear();
                    System.out.println(String.format("From %s : %s", channel.getRemoteAddress(), request));
                    String response = "Hello " + request + "\n";
                    channel.write(ByteBuffer.wrap(response.getBytes(Charset.forName("UTF-8"))));
                }
                iterator.remove();
            }
        }
    }
}
