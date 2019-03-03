package com.company.thread;

/**
 * Created by yepeng on 2019/03/03.
 */
public class WaitTest {
    private static final Object lock = new Object();

    public static void main(String[] args) {
        Thread t1 = new Thread(() -> {
            synchronized (lock) {
                try {
                    for (int i = 0; i < 20; i++) {
                        if (i == 10) {
                            lock.wait();
                        }
                        System.out.println(i);
                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        });

        Thread t2 = new Thread(() -> {
            synchronized (lock) {
                try {
                    System.out.println("111");
                    Thread.sleep(2000);
                    System.out.println("yepeng");
                    lock.notifyAll();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        });
        t1.start();
        t2.start();
    }
}
