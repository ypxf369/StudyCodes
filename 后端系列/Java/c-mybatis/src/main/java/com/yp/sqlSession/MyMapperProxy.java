package com.yp.sqlSession;

import com.yp.config.Function;
import com.yp.config.MapperBean;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.util.List;

/**
 * Created by yepeng on 2019/02/23.
 * <p>
 * 此代理类完成xml方法和真实方法的对应，执行查询
 */
public class MyMapperProxy implements InvocationHandler {
    private MySqlSerssion sqlSerssion;
    private MyConfiguration configuration;

    public MyMapperProxy(MySqlSerssion sqlSerssion, MyConfiguration configuration) {
        this.sqlSerssion = sqlSerssion;
        this.configuration = configuration;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) {
        MapperBean mapperBean = configuration.readMapper("UserMapper.xml");
        //是否是xml文件对应的接口
        if (!method.getDeclaringClass().getName().equals(mapperBean.getInterfaceName())) {
            return null;
        }
        List<Function> list = mapperBean.getList();
        if (list != null || list.size() > 0) {
            for (Function function : list) {
                //id是否和接口方法名一样
                if (method.getName().equals(function.getFuncName())) {
                    return sqlSerssion.selectOne(function.getSql(), String.valueOf(args[0]));
                }
            }
        }
        return null;
    }
}
