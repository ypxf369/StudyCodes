package com.company.juc;


import java.util.ArrayList;
import java.util.Arrays;
import java.util.concurrent.*;

/**
 * Created by yepeng on 2019/02/21.
 *
 * CountDownLatch 当指定线程数任务都完成时，在执行此任务
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
//        Executor executorService = Executors.newFixedThreadPool(2);
//        executorService.execute(t1);
//        executorService.execute(t2);

        ThreadPoolExecutor poolExecutor=new ThreadPoolExecutor(2, 2, 2, TimeUnit.SECONDS,new LinkedBlockingQueue(2));
        poolExecutor.execute(t1);
        poolExecutor.execute(t2);

        System.out.println("等待两个线程执行完毕");
        _latch.await();
        System.out.println("两个子线程执行完毕");
        System.out.println("继续执行主线程");
    }
}
