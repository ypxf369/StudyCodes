package com.company;

/**
 * Cre ated by yepeng on 2019/02/08.
 */
public class DeadLoopClass {
    static class StaticClass {
        static {

            System.out.println(Thread.currentThread());
        }
    }

}
