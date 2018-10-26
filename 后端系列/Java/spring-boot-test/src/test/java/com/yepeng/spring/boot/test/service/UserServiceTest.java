package com.yepeng.spring.boot.test.service;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import static org.junit.Assert.*;

/**
 * Created by yepeng on 2018/10/25.
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class UserServiceTest {

    @Autowired
    private UserService userService;

    @Test
    public void createUser() {
        userService.createUser("yp1", "123");
        userService.createUser("yp2", "123");
        userService.createUser("yp3", "123");
        userService.createUser("yp4", "123");
        userService.createUser("yp5", "123");
        userService.createUser("yp6", "123");
        userService.createUser("yp7", "123");
        userService.createUser("yp8", "123");
        userService.createUser("yp9", "123");
        userService.createUser("yp10", "123");
    }

    @Test
    public void getUserById() {
    }

    @Test
    public void updateUserById() {
    }

    @Test
    public void deleteUserById() {
    }
}