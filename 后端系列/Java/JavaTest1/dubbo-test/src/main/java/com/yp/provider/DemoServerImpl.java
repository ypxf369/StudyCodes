package com.yp.provider;

import com.yp.api.DemoService;

/**
 * Created by yepeng on 2019/03/30.
 */
public class DemoServerImpl implements DemoService {
    public String sayHello(String name) {
        return "Hello " + name;
    }
}
