package cn.springcloud.study.ch7_2_clienta.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/11/20.
 */
@RestController
public class TestController {
    @GetMapping("/add")
    public Integer add(Integer a,Integer b){
        return a+b;
    }
}
