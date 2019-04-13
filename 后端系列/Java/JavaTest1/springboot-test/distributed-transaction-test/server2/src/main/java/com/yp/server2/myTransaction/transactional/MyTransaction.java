package com.yp.server2.myTransaction.transactional;

import com.yp.server2.myTransaction.util.Task;

/**
 * Created by yepeng on 2019/04/12.
 */
public class MyTransaction {
    private String transactionalId;
    private String groupId;
    private TransactionType type;
    private Task task;

    public Task getTask() {
        return task;
    }

    public MyTransaction(String transactionalId, String groupId) {
        this.transactionalId = transactionalId;
        this.groupId = groupId;
        this.task = new Task();
    }

    public MyTransaction(String transactionalId, String groupId, TransactionType type) {
        this.transactionalId = transactionalId;
        this.groupId = groupId;
        this.type = type;
    }

    public String getTransactionalId() {
        return transactionalId;
    }

    public void setTransactionalId(String transactionalId) {
        this.transactionalId = transactionalId;
    }

    public String getGroupId() {
        return groupId;
    }

    public void setGroupId(String groupId) {
        this.groupId = groupId;
    }

    public TransactionType getType() {
        return type;
    }

    public void setType(TransactionType type) {
        this.type = type;
    }
}
