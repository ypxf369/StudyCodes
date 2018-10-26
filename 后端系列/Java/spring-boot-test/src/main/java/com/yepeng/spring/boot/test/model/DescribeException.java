package com.yepeng.spring.boot.test.model;

/**
 * Created by yepeng on 2018/10/26.
 */
public class DescribeException extends RuntimeException {
    private Integer code;

    public DescribeException(ExceptionEnum exceptionEnum) {
        super(exceptionEnum.getMsg());
        this.code = exceptionEnum.getCode();
    }

    public DescribeException(Integer code, String msg) {
        super(msg);
        this.code = code;
    }

    public Integer getCode() {
        return code;
    }

    public void setCode(Integer code) {
        this.code = code;
    }
}
