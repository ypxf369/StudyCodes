package com.yepeng.spring.boot.test.model;

/**
 * Created by yepeng on 2018/10/26.
 */
public class Result<T> {
    //状态值，0 为成功，其他值代表失败
    private Integer status;

    //错误消息，若status=0时，则为success
    private String msg;

    private T data;

    public void setStatus(Integer status) {
        this.status = status;
    }

    public void setMsg(String msg) {
        this.msg = msg;
    }

    public void setData(T data) {
        this.data = data;
    }

    public Integer getStatus() {
        return status;
    }

    public String getMsg() {
        return msg;
    }

    public T getData() {
        return data;
    }

    @Override
    public String toString() {
        return "Result{" +
                "status=" + status +
                ", msg='" + msg + '\'' +
                ", data=" + data +
                '}';
    }
}
