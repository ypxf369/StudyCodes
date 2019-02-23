package com.yp;

import com.yp.bean.User;
import com.yp.mapper.UserMapper;
import com.yp.sqlSession.MySqlSerssion;


/**
 * Created by yepeng on 2019/02/23.
 */
public class TestMybatis {
    public static void main(String[] args) {
        MySqlSerssion sqlSerssion = new MySqlSerssion();
        UserMapper mapper = sqlSerssion.getMapper(UserMapper.class);
        User user = mapper.getUserById("1");
        System.out.println(user);
    }
}
