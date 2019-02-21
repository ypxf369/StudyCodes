package com.company;

/**
 * Created by yepeng on 2019/02/12.
 */
public class SingletonTest {
    private SingletonTest() {
    }

    private volatile SingletonTest instance;

    public SingletonTest getInstance() {
        if (instance == null) {
            synchronized (SingletonTest.class) {
                if (instance == null) {
                    instance = new SingletonTest();
                }
            }
        }
        return instance;
    }
}
