package com.company;

import org.junit.Test;

import java.lang.reflect.Constructor;
import java.lang.reflect.InvocationTargetException;

public class JavaReflator {
    public JavaReflator(){
        System.out.println("无参构造函数执行了。");
    }
    @Test
    public void method() throws NoSuchMethodException, IllegalAccessException, InvocationTargetException, InstantiationException {
        Class clazz=JavaReflator.class;
        Constructor constructor = clazz.getConstructor();
        Object object = constructor.newInstance();

        System.out.println("sdfsdf");

    }
}

