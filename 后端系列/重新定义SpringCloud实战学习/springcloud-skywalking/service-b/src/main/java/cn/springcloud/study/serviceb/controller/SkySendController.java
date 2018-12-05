package cn.springcloud.study.serviceb.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/12/05.
 */
@RestController
public class SkySendController {
    @GetMapping("getSendInfo")
    String getSendInfo(@RequestParam("serviceName") String serviceName) {
        return serviceName + "------> " + "service-b";
    }
}
