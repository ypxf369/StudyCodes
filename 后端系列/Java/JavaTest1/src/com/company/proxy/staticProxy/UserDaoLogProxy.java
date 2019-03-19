package com.company.proxy.staticProxy;

/**
 * Created by yepeng on 2019/03/19.
 * 采用继承进行代理
 */
public class UserDaoLogProxy extends UserDaoImpl {
    @Override
    public void query() {
        System.out.println("用户查询开始");
        super.query();
        System.out.println("用户查询结束");
    }
}
