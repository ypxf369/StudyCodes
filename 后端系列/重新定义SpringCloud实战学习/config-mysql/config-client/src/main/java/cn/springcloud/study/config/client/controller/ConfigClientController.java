package cn.springcloud.study.config.client.controller;

import cn.springcloud.study.config.client.config.ConfigInfoProperties;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/11/29.
 */
@RestController
@RequestMapping("configConsumer")
public class ConfigClientController {
    @Autowired
    private ConfigInfoProperties configInfoProperties;

    @RequestMapping("getConfigInfo")
    public String getConfigInfo() {
        String value= configInfoProperties.getConfig();
        return value;
    }
}
