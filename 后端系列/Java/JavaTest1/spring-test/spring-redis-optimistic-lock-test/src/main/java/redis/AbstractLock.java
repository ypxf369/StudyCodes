package redis;

import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.Lock;

/**
 * Created by yepeng on 2019/04/20.
 * 锁的骨架实现，真正的获取锁的步骤由子类去实现
 */
public abstract class AbstractLock implements Lock {

    /**
     * 这里需不需要保证可见性值得讨论，因为是分布式锁
     * 1.同一个jvm的多个线程使用不同的锁对象其实也是可以的，这种情况下不需要保证可见性
     * 2.同一个jvm的多个线程使用同一个锁对象，那可见性就必须要保证了。
     */
    protected volatile boolean locked;

    /**
     * 当jvm内持有该锁的线程
     */
    private Thread exclusiveOwnerThread;

    public void lock() {
        try {
            lock(false, 0, null, false);
        } catch (InterruptedException e) {

        }
    }

    public void lockInterruptibly() throws InterruptedException {
        lock(false, 0, null, true);
    }

    public boolean tryLock(long time, TimeUnit unit) throws InterruptedException {
        try {
            System.out.println("try get lock...");
            return lock(true, time, unit, false);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return false;
    }

    public boolean tryLockInterruptibly(long time, TimeUnit unit) throws InterruptedException {
        return lock(true, time, unit, true);
    }

    public void unlock() {
        // TODO 检查当前线程是否持有锁
        if (Thread.currentThread() != getExclusiveOwnerThread()) {
            throw new IllegalMonitorStateException("current thread does not hold the lock");
        }

        unlock0();
        setExclusiveOwnerThread(null);
    }

    protected void setExclusiveOwnerThread(Thread thread) {
        exclusiveOwnerThread = thread;
    }

    protected final Thread getExclusiveOwnerThread() {
        return exclusiveOwnerThread;
    }

    protected abstract void unlock0();

    /**
     * 阻塞式获取锁的实现
     *
     * @param useTimeout
     * @param time
     * @param unit
     * @param interrupt  是否响应中断
     * @return
     * @throws InterruptedException
     */
    protected abstract boolean lock(boolean useTimeout, long time, TimeUnit unit, boolean interrupt) throws InterruptedException;
}
