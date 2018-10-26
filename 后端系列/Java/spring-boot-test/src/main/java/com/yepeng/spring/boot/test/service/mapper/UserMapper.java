package com.yepeng.spring.boot.test.service.mapper;

import com.yepeng.spring.boot.test.entity.User;

/**
 * Created by yepeng on 2018/10/25.
 */
public interface UserMapper {
    int createUser(String name, String password);

    User getUserById(Integer id);

    void updateUserById(Integer id, String name);

    void deleteUserById(Integer id);
}
