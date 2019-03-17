package com.company.juc;

import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.AbstractQueuedSynchronizer;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;

/**
 * Created by yepeng on 2019/03/17.
 */
public class MyLock implements Lock {
    private Helper helper = new Helper();

    @Override
    public void lock() {
        helper.acquire(1);
    }

    @Override
    public void lockInterruptibly() throws InterruptedException {
        helper.acquireInterruptibly(1);
    }

    @Override
    public boolean tryLock() {
        return helper.tryAcquire(1);
    }

    @Override
    public boolean tryLock(long time, TimeUnit unit) throws InterruptedException {
        return helper.tryAcquireNanos(1, unit.toNanos(time));
    }

    @Override
    public void unlock() {
        helper.release(1);
    }

    @Override
    public Condition newCondition() {
        return helper.newConditionObject();
    }

    private class Helper extends AbstractQueuedSynchronizer {
        /**
         * 以独占的方式获取锁
         */
        @Override
        protected boolean tryAcquire(int arg) {
            // 获取当前锁的状态
            int state = getState();
            if (state == 0) {//代表锁没有被线程独占
                // 利用CAS修改状态
                if(compareAndSetState(state, arg)){
                    // 让当前线程以独占的方式占有锁
                    setExclusiveOwnerThread(Thread.currentThread());
                    return true;
                }
            }
            return false;
        }

        /**
         * 以独占的方式释放锁
         */
        @Override
        protected boolean tryRelease(int arg) {
            // 获取当前锁状态
            int state = getState() - arg;
            if (state == 0) {
                // 让当前线程释放锁
                setExclusiveOwnerThread(null);
                setState(state);
                return true;
            }
            return false;
        }

        protected Condition newConditionObject() {
            return new ConditionObject();
        }
    }
}
