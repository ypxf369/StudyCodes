package com.company.juc;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.Executor;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * Created by yepeng on 2019/02/21.
 */
public class CountDownLatchTest {
    public static void main(String[] args) throws InterruptedException {
        final CountDownLatch _latch = new CountDownLatch(2);
        Thread t1 = new Thread(() -> {
            try {
                System.out.println("子线程" + Thread.currentThread().getName() + "开始执行");
                Thread.sleep(3000);
                System.out.println("子线程" + Thread.currentThread().getName() + "执行完毕");
                _latch.countDown();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        Thread t2 = new Thread(() -> {
            try {
                System.out.println("子线程" + Thread.currentThread().getName() + "开始执行");
                Thread.sleep(3000);
                System.out.println("子线程" + Thread.currentThread().getName() + "执行完毕");
                _latch.countDown();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });
        Executor executorService = Executors.newFixedThreadPool(2);
        executorService.execute(t1);
        executorService.execute(t2);
        System.out.println("等待两个线程执行完毕");
        _latch.await();
        System.out.println("两个子线程执行完毕");
        System.out.println("继续执行主线程");
    }
}
