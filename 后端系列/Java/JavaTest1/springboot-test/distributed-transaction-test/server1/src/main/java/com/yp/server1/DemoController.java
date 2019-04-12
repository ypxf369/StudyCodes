package com.yp.server1;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2019/04/11.
 */
@RestController
@RequestMapping("server1")
public class DemoController {
    @Autowired
    private DemoService demoService;

    @RequestMapping(value = "/test")
    public void test() {
        demoService.test();
    }
}
