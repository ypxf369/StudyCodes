package com.yp.consumer;

import com.yp.api.DemoService;
import org.springframework.context.support.ClassPathXmlApplicationContext;

/**
 * Created by yepeng on 2019/03/30.
 */
public class Consumer {
    public static void main(String[] args) {
        ClassPathXmlApplicationContext context = new ClassPathXmlApplicationContext("consumer.xml");
        DemoService demoService = (DemoService) context.getBean("demoService");//获取远程服务代理
        String hello = demoService.sayHello("yepeng");//执行远程方法
        System.out.println(hello);
    }
}
