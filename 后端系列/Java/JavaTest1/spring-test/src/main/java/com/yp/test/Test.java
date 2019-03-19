package com.yp.test;

import com.yp.app.AopTest;
import com.yp.app.AppConfig;
import com.yp.app.Hello;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;

/**
 * Created by yepeng on 2019/03/18.
 */
public class Test {
    public static void main(String[] args){
        AnnotationConfigApplicationContext context=new AnnotationConfigApplicationContext(AppConfig.class,Hello.class, AopTest.class);
        Hello hello = (Hello)context.getBean("Hello");
        hello.sayHello();
    }
}
