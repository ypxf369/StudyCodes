package com.company.nio.netty;

import io.netty.bootstrap.ServerBootstrap;
import io.netty.buffer.UnpooledUnsafeDirectByteBuf;
import io.netty.channel.*;
import io.netty.channel.nio.NioEventLoopGroup;
import io.netty.channel.socket.nio.NioServerSocketChannel;

/**
 * Created by yepeng on 2019/04/06.
 */
public class NettyServer {
    public static void main(String[] args) {
        NioEventLoopGroup bossGroup = new NioEventLoopGroup(1);
        NioEventLoopGroup workerGroup = new NioEventLoopGroup();
        try {
            ServerBootstrap b = new ServerBootstrap();
            b.group(bossGroup, workerGroup)
                    .channel(NioServerSocketChannel.class)
                    .option(ChannelOption.SO_BACKLOG, 128)
                    .childHandler(new ChannelInboundHandlerAdapter() {
                        @Override
                        public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception {
                            //String request = new String(((UnpooledUnsafeDirectByteBuf)msg).array());
                            //System.out.println(String.format("From %s : %s" + ctx.channel().remoteAddress(), request));
                            String response = "Hello: " + msg.toString();
                            ctx.writeAndFlush("aaa");
                        }
                    });
            ChannelFuture channelFuture = b.bind(6666).sync();
            channelFuture.channel().closeFuture().sync();
        } catch (Exception e) {

        }finally {
            bossGroup.shutdownGracefully();
            workerGroup.shutdownGracefully();
        }
    }
}
