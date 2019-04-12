package com.yp.server1.myTransaction.transactional;

import com.alibaba.fastjson.JSONObject;
import com.yp.server1.netty.NettyClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.*;

/**
 * Created by yepeng on 2019/04/13.
 */
@Component
public class MyTransactionManager {
    private static NettyClient nettyClient = null;

    private static Map<String, List<MyTransaction>> transactionMap = new HashMap<>();

    private static ThreadLocal<MyTransaction> current = new ThreadLocal<>();

    private static ThreadLocal<String> currentGroupId = new ThreadLocal<>();
    private static ThreadLocal<Integer> currentGroupTransactionCount = new ThreadLocal<>();

    public static Map<String, MyTransaction> TMAP = new HashMap<>();

    @Autowired
    public void setNettyClient(NettyClient nettyClient) {
        MyTransactionManager.nettyClient = nettyClient;
    }

    public static String createTransactionGroup() {
        JSONObject jsonObject = new JSONObject();
        String groupId = UUID.randomUUID().toString();
        jsonObject.put("groupId", groupId);
        jsonObject.put("command", "create");
        currentGroupId.set(groupId);
        transactionMap.put(groupId, new ArrayList<>());
        nettyClient.send(jsonObject);

        System.out.println("创建事务组");

        return groupId;
    }

    public static MyTransaction createTranscation(String groupId) {
        MyTransaction myTransaction = new MyTransaction(UUID.randomUUID().toString(), groupId);
        transactionMap.get(groupId).add(myTransaction);
        current.set(myTransaction);
        TMAP.put(groupId, myTransaction);
        return myTransaction;
    }

    public static void addTransaction(MyTransaction transaction, TransactionType type, boolean isEnd) {
        JSONObject jsonObject = new JSONObject();
        jsonObject.put("command", "add");
        jsonObject.put("groupId", transaction.getGroupId());
        jsonObject.put("transactionId", transaction.getTransactionalId());
        jsonObject.put("transactionType", type);
        jsonObject.put("isEnd", isEnd);
        jsonObject.put("transactionCount", transactionMap.get(transaction.getGroupId()).size());
        nettyClient.send(jsonObject);
        System.out.println("添加事务");
    }

    public static MyTransaction getByGroupId(String groupId) {
        //return transactionMap.get(groupId);
        return null;
    }

    public static MyTransaction getTMAP(String groupId) {
        return TMAP.get(groupId);
    }

    public static void setCurrentGroupId(String groupId) {
        currentGroupId.set(groupId);
    }

    public static String getCurrentGroupId() {
        return currentGroupId.get();
    }

    public static void setTransactionCount(int count) {
        currentGroupTransactionCount.set(count);
    }

    public static int getTransactionCount() {
        return currentGroupTransactionCount.get();
    }

    public static MyTransaction getCurrent() {
        return current.get();
    }
}
