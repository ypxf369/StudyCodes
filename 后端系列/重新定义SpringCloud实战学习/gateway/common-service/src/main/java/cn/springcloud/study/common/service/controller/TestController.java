package cn.springcloud.study.common.service.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/12/06.
 */
@RestController
public class TestController {
    @GetMapping("test")
    public String test() {
        return "test success!!!";
    }
}
