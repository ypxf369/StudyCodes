package com.company.proxy.staticProxy;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;

/**
 * Created by yepeng on 2019/03/19.
 */
public class UserDaoImpl implements UserDao {
    public void query() {
        System.out.println("查询用户数据");
    }

    @Override
    public void getUser() {
        System.out.println("查询到一个用户");
    }

    @Override
    public String getUser(int id) {
        return "User_" + id;
    }

}
