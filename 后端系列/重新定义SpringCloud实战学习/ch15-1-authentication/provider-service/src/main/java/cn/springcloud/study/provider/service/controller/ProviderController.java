package cn.springcloud.study.provider.service.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.servlet.http.HttpServletRequest;

/**
 * Created by yepeng on 2018/12/04.
 */
@RestController
public class ProviderController {
    @GetMapping("provider/test")
    public String test(HttpServletRequest request) {
        System.out.println("------------------SUCCESS access provider service---------------------");
        return "success access provider service!";
    }
}
