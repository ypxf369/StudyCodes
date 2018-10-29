package com.yepeng.spring.boot.test.controller;

import com.yepeng.spring.boot.test.entity.User;
import com.yepeng.spring.boot.test.service.UserService;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiImplicitParam;
import io.swagger.annotations.ApiImplicitParams;
import io.swagger.annotations.ApiOperation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;

/**
 * Created by yepeng on 2018/10/25.
 */
@Api(value = "用户操作控制器",description = "提供用户相关操作的增删改查")
@RequestMapping("user")
@RestController
public class UserController {
    @Autowired
    private UserService userService;

    @ApiOperation(value="创建用户",notes = "使用姓名、密码来创建用户")
    @ApiImplicitParams({
            @ApiImplicitParam(name = "name",value = "用户名",required = true,dataType = "String"),
            @ApiImplicitParam(name = "password",value = "密码",required = true,dataType = "String")
    })
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
