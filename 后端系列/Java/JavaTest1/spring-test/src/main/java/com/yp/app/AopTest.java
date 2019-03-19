package com.yp.app;

import org.aspectj.lang.annotation.After;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Pointcut;
import org.springframework.stereotype.Component;

/**
 * Created by yepeng on 2019/03/18.
 */
@Component
@Aspect
public class AopTest {
    @Pointcut("excution(com.yp.app..*)")
    private void declarePointcut(){

    }
    
    @After("declarePointcut()")
    public void doTest(){
        System.out.println("after");
    }
}
