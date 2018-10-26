package com.yepeng.spring.boot.test.service;

import com.yepeng.spring.boot.test.entity.User;
import com.yepeng.spring.boot.test.service.mapper.UserMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * Created by yepeng on 2018/10/25.
 */
@Service
public class UserService {
    @Autowired
    private UserMapper userMapper;

    public int createUser(String name, String password) {
        return userMapper.createUser(name, password);
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
