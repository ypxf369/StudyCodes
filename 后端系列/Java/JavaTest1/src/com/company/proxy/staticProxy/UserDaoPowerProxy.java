package com.company.proxy.staticProxy;

/**
 * Created by yepeng on 2019/03/19.
 * 采用接口进行代理
 */
public class UserDaoPowerProxy implements UserDao {
    private UserDaoImpl userDao;

    public UserDaoPowerProxy(UserDaoImpl userDao) {
        this.userDao = userDao;
    }

    @Override
    public void getUser() {
        System.out.println("检查该用户的查询权限");
        userDao.getUser();
        System.out.println("用户查询完成");
    }
}
