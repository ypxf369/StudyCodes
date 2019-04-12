package com.yp.server1.netty;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;
import com.yp.server1.myTransaction.transactional.MyTransaction;
import com.yp.server1.myTransaction.transactional.MyTransactionManager;
import com.yp.server1.myTransaction.transactional.TransactionType;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;

/**
 * Created by yepeng on 2019/04/13.
 */
public class NettyClientHandler extends ChannelInboundHandlerAdapter {
    private ChannelHandlerContext context;

    @Override
    public void channelActive(ChannelHandlerContext ctx) throws Exception {
        context = ctx;
    }

    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception {
        System.out.println("接收数据:" + msg.toString());

        JSONObject jsonObject = JSON.parseObject((String) msg);
        String groupId = jsonObject.getString("groupId");
        String command = jsonObject.getString("command");

        System.out.println("接收command:" + command);
        // 对事务进行操作
        //MyTransaction myTransaction = MyTransactionManager.getCurrent();
        MyTransaction myTransaction = MyTransactionManager.getTMAP(groupId);
        if (command.equals("commit")) {
            myTransaction.setType(TransactionType.COMMIT);
        } else {
            myTransaction.setType(TransactionType.ROllBACK);
        }
        // 唤醒
        myTransaction.getTask().signalTask();

    }

    public synchronized Object call(JSONObject data) {
        context.writeAndFlush(data.toJSONString());
        return null;
    }
}
