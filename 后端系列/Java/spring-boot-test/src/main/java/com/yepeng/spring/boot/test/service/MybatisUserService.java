package com.yepeng.spring.boot.test.service;

import com.yepeng.spring.boot.test.entity.User;
import com.yepeng.spring.boot.test.service.mapper.MybatisUserMapper;
import com.yepeng.spring.boot.test.service.mapper.MybatisUserXmlMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * Created by yepeng on 2018/10/29.
 */
@Service
public class MybatisUserService {
    @Autowired
    //private MybatisUserMapper userMapper;
    private MybatisUserXmlMapper userMapper;

    public void createUser(String name, String password) {
        userMapper.createUser(name, password);
    }

    public User getUserById(Integer id) {
        return userMapper.getUserById(id);
    }

    public void updateUserById(Integer id, String name) {
        userMapper.updateUserById(id, name);
    }

    public void deleteUserById(Integer id) {
        userMapper.deleteUserById(id);
    }
}
