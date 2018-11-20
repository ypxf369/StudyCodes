package cn.springcloud.study.ch6_1_clientservice.controller;

import cn.springcloud.study.ch6_1_clientservice.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import javax.websocket.server.PathParam;

/**
 * Created by yepeng on 2018/11/20.
 */
@RestController
public class TestController {
    @Autowired
    private UserService userService;

    @GetMapping("/getUser")
    public String getUser(@RequestParam("username") String username) throws Exception {
        return userService.getUser(username);
    }
}
