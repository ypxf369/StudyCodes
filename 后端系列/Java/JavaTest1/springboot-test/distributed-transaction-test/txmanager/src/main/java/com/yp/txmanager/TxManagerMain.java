package com.yp.txmanager;

/**
 * Created by yepeng on 2019/04/12.
 */
public class TxManagerMain {
    public static void main(String[] args) {
        NettyServer server = new NettyServer();
        server.start("localhost", 8080);
        System.out.println("Netty 启动成功");
    }
}
