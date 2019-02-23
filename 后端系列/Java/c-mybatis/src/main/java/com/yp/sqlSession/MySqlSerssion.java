package com.yp.sqlSession;

import java.lang.reflect.Proxy;

/**
 * Created by yepeng on 2019/02/23.
 */
public class MySqlSerssion {
    private Excutor excutor = new MyExcutor();

    private MyConfiguration configuration = new MyConfiguration();

    public <T> T selectOne(String statement, Object parameter) {
        return excutor.query(statement, parameter);
    }

    @SuppressWarnings("unchecked")
    public <T> T getMapper(Class<T> clazz) {
        //动态代理调用
        return (T) Proxy.newProxyInstance(clazz.getClassLoader(), new Class[]{clazz}, new MyMapperProxy(this, configuration));
    }
}
