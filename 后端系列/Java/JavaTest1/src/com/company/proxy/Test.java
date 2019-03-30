package com.company.proxy;

import com.company.proxy.dynamicProxy.DynamicProxy;
import com.company.proxy.staticProxy.UserDao;
import com.company.proxy.staticProxy.UserDaoImpl;
import com.company.proxy.staticProxy.UserDaoLogProxy;
import com.company.proxy.staticProxy.UserDaoPowerProxy;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;

/**
 * Created by yepeng on 2019/03/19.
 */
public class Test {
    public static void main(String[] args) {

        UserDaoLogProxy userDao = new UserDaoLogProxy();
        //userDao.query();
        //UserDaoPowerProxy userDaoPowerProxy = new UserDaoPowerProxy(userDao);
        //userDaoPowerProxy.getUser();

        UserDao userDao1 = (UserDao) DynamicProxy.newInstance(new UserDaoImpl());
        userDao1.getUser();
        System.out.println(userDao1.getUser(23));

    }
}
