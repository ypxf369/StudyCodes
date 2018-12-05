package cn.springcloud.study.servicea.controller;

import cn.springcloud.study.servicea.service.SkyFeignSerivece;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/12/05.
 */
@RestController
@RequestMapping("skyController")
public class SkyController {

    @Autowired
    private SkyFeignSerivece skyFeignSerivece;

    @RequestMapping("getInfo")
    public String getInfo() {
        return skyFeignSerivece.getSendInfo("service-a");
    }
}
