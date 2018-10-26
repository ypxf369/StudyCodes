package com.yepeng.spring.boot.test.controller;

import com.yepeng.spring.boot.test.model.Config;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/10/25.
 */
@RequestMapping("test")
@RestController
public class TestController {
    @Autowired
    private Config config;

    @GetMapping("config")
    public Config getConfig(){
        return config;
    }
}
