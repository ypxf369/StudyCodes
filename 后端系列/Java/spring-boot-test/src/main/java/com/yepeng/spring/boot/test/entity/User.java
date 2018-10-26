package com.yepeng.spring.boot.test.entity;

import javax.validation.constraints.Max;
import javax.validation.constraints.Min;

/**
 * Created by yepeng on 2018/10/25.
 */
public class User {
    private Integer id;
    private String name;
    @Max(value = 9999,message = "超过最大数值")
    @Min(value = 0000,message = "密码设定不正确")
    private String password;
    private String mobile;
    private String address;
    private String createTime;
    private String updateTime;

    public void setId(Integer id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public void setMobile(String mobile) {
        this.mobile = mobile;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public void setCreateTime(String createTime) {
        this.createTime = createTime;
    }

    public void setUpdateTime(String updateTime) {
        this.updateTime = updateTime;
    }

    public Integer getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getPassword() {
        return password;
    }

    public String getMobile() {
        return mobile;
    }

    public String getAddress() {
        return address;
    }

    public String getCreateTime() {
        return createTime;
    }

    public String getUpdateTime() {
        return updateTime;
    }
}
