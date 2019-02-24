package com.company.juc;

/**
 * Created by yepeng on 2019/02/24.
 * 死锁案例：线程A获取线程B持有的锁，线程B要获取线程A持有的锁，双方都要获取对方的锁，那么就进入无限循环阶段，便是死锁
 */
public class DeadLock {
    private static final Object lock1=new Object();
    private static final Object lock2=new Object();

    public static void main(String[] args){

        new Thread(()->{
            synchronized (lock1){
                System.out.println("thread1 get lock1");
                try {
                    Thread.sleep(1000);
                    synchronized (lock2){
                        System.out.println("thread1 get lock2");;
                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }).start();

        new Thread(()->{
            synchronized (lock2){
                System.out.println("thread2 get lock2");
                try {
                    Thread.sleep(1000);
                    synchronized (lock1){
                        System.out.println("thread2 get lock1");
                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        }).start();
    }
}
