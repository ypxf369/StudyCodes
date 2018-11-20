package cn.springcloud.study.ch5_1_client_a.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.servlet.http.HttpServletRequest;

/**
 * Created by yepeng on 2018/11/20.
 */
@RestController
public class TestController {
    @GetMapping("/add")
    public String add(Integer a, Integer b, HttpServletRequest request) {
        return " From Port: " + request.getServerPort() + ",Result: " + (a + b);
    }
}
