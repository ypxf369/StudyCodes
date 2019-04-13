package com.yp.server2.netty;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;
import com.yp.server2.myTransaction.transactional.MyTransaction;
import com.yp.server2.myTransaction.transactional.MyTransactionManager;
import com.yp.server2.myTransaction.transactional.TransactionType;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;
import org.springframework.stereotype.Component;

/**
 * Created by yepeng on 2019/04/13.
 */
@Component
public class NettyClientHandler extends ChannelInboundHandlerAdapter {
    private ChannelHandlerContext context;
    private String transactionId;

    @Override
    public void channelActive(ChannelHandlerContext ctx) throws Exception {
        context = ctx;
    }

    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) throws Exception {
        System.out.println("client接收数据:" + msg.toString());

        JSONObject jsonObject = JSON.parseObject((String) msg);
        String groupId = jsonObject.getString("groupId");
        String command = jsonObject.getString("command");

        System.out.println("接收command:" + command);
        // 对事务进行操作
        MyTransaction myTransaction = MyTransactionManager.getByGroupId(groupId).stream().filter(i -> i.getTransactionalId().equals(transactionId)).findFirst().get();
        //MyTransaction myTransaction = MyTransactionManager.getTMAP(groupId);
        if (command.equals("commit")) {
            myTransaction.setType(TransactionType.COMMIT);
        } else {
            myTransaction.setType(TransactionType.ROllBACK);
        }
        // 唤醒线程
        myTransaction.getTask().signalTask();

    }

    public synchronized Object call(JSONObject data, String type) {
        if (type.equals("tx")) {
            transactionId = data.getString("transactionId");
        }
        context.writeAndFlush(data.toJSONString());
        return null;
    }
}
