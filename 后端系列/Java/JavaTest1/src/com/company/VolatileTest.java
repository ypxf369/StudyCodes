package com.company;

import java.util.concurrent.atomic.AtomicInteger;

/**
 * Created by yepeng on 2019/02/12.
 */
public class VolatileTest {
    //static volatile int result = 0;
    static AtomicInteger result = new AtomicInteger(0);
    static final int THREAD_COUNT = 20;

    static void add() {
        //result++;
        result.incrementAndGet();
    }


    public static void main(String[] args) {
        Thread[] threads = new Thread[THREAD_COUNT];
        for (int i = 0; i < THREAD_COUNT; i++) {
            threads[i] = new Thread(() -> add());
            threads[i].start();
        }
        // 等待所有累加线程都结束
        while (Thread.activeCount() > 1) {
            Thread.yield();
        }
        System.out.println(result);
    }
}
