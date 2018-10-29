package com.yepeng.spring.boot.test.controller;

import com.yepeng.spring.boot.test.entity.User;
import com.yepeng.spring.boot.test.service.MybatisUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;

/**
 * Created by yepeng on 2018/10/29.
 */
@RestController
@RequestMapping("myBatis")
public class MyBatisController {
    @Autowired
    private MybatisUserService userService;

    @PostMapping("createUser")
    public void createUser(@RequestParam("name") String name, @RequestParam("password") String password) {
        userService.createUser(name, password);
    }

    @PostMapping("createUser2")
    public String createUser2(@Valid User user, BindingResult bindingResult) {
        if (bindingResult.hasErrors()) {
            return bindingResult.getFieldError().getDefaultMessage();
        }
        userService.createUser(user.getName(), user.getPassword());
        return "ok";
    }

    @GetMapping("getUser/{id}")
    public User getUserById(@PathVariable("id") Integer id) {
        return userService.getUserById(id);
    }

    @PostMapping("updateUser")
    public void updateUserById(@RequestParam("id") Integer id, @RequestParam("name") String name) {
        userService.updateUserById(id, name);
    }

    @PostMapping("deleteUser/{id}")
    public void deleteUserById(@PathVariable("id") Integer id) {
        userService.deleteUserById(id);
    }
}
