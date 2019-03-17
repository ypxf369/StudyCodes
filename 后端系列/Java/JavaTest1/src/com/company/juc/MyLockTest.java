package com.company.juc;

/**
 * Created by yepeng on 2019/03/17.
 */
public class MyLockTest {
    private int n = 0;
     MyLock lock = new MyLock();

    private  void increment() {
        //lock.lock();
        try {
            n++;
        } finally {
            //lock.unlock();
        }

    }

    public static void main(String[] args) throws InterruptedException {
        MyLockTest test = new MyLockTest();
        Thread[] threads=new Thread[20000];
        for (int i = 0; i < 20000; i++) {
            threads[i]=new Thread(() -> {
                test.increment();

            });
            threads[i].start();
            //threads[i].join();
        }
        Thread.sleep(5000);
        System.out.println(test.n);
    }
}
