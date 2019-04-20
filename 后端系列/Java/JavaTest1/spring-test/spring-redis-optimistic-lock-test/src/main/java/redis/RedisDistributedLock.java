package redis;

import redis.clients.jedis.Jedis;

import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.Condition;

/**
 * Created by yepeng on 2019/04/20.
 * 基于Redis的SETNX操作实现的分布式锁
 * <p>
 * 获取锁时最好用lock(long time,TimeUnit unit)，以免网络问题而导致线程一直阻塞
 */
public class RedisDistributedLock extends AbstractLock {

    private Jedis jedis;

    // 锁的名字
    protected String lockKey;

    // 锁的有效时长(毫秒ms)
    protected long lockExpires;

    public RedisDistributedLock(Jedis jedis, String lockKey, long lockExpires) {
        this.jedis = jedis;
        this.lockKey = lockKey;
        this.lockExpires = lockExpires;
    }

    protected void unlock0() {
        // 判断锁是否过期
        String value = jedis.get(lockKey);
        if (isTimeExpired(value)) {
            doUnlock();
        }
    }

    /**
     * 阻塞式获取锁的实现
     */
    protected boolean lock(boolean useTimeout, long time, TimeUnit unit, boolean interrupt) throws InterruptedException {
        System.out.println("test1");
        if (interrupt) {
            checkInterruption();
        }

        System.out.println("test2");
        long start = System.currentTimeMillis();
        long timeout = unit.toMillis(time);

        while (useTimeout ? isTimeout(start, timeout) : true) {
            System.out.println("test3");
            if (interrupt) {
                checkInterruption();
            }

            // 锁到期的时间
            long lockExpireTime = System.currentTimeMillis() + lockExpires + 1;
            String stringOfLockExpireTime = String.valueOf(lockExpireTime);

            System.out.println("test4");
            if (jedis.setnx(lockKey, stringOfLockExpireTime) == 1) {
                // 获取到锁
                System.out.println("test5");
                // 成功获取到锁，设置相关标识
                locked = true;
                setExclusiveOwnerThread(Thread.currentThread());
                return true;
            }
            // 说明其他线程获取了锁，再次获取锁
            System.out.println("test6");
            String value = jedis.get(lockKey);
            if (value != null && isTimeExpired(value)) {
                System.out.println("test7");
                // 锁已经过期
                // 假设多个线程同时走到这里
                String oldValue = jedis.getSet(lockKey, stringOfLockExpireTime);// 原子操作
                // 但是走到这里时每个线程拿到的oldValue肯定不可能一样(因为getset是原子操作)
                // 假如拿到的oldValue依然是expired的，那么就说明拿到锁了。
                System.out.println("test8");
                if (oldValue != null && isTimeExpired(oldValue)) {
                    System.out.println("test9");
                    // 成功获取到锁，设置相关标识
                    locked = true;
                    setExclusiveOwnerThread(Thread.currentThread());
                    return true;
                }
            } else {

            }
        }
        System.out.println("test10");
        return false;
    }

    public boolean tryLock() {
        // 锁到期的时间
        long lockExpireTime = System.currentTimeMillis() + lockExpires + 1;
        String stringOfLockExpireTime = String.valueOf(lockExpireTime);

        if (jedis.setnx(lockKey, stringOfLockExpireTime) == 1) {
            // 获取到锁
            // 成功获取到锁，设置相关标识
            locked = true;
            setExclusiveOwnerThread(Thread.currentThread());
            return true;
        }
        // 说明其他线程获取了锁，再次获取锁
        String value = jedis.get(lockKey);
        if (value != null && isTimeExpired(value)) {
            // 锁已经过期
            // 假设多个线程同时走到这里
            String oldValue = jedis.getSet(lockKey, stringOfLockExpireTime);// 原子操作
            // 但是走到这里时每个线程拿到的oldValue肯定不可能一样(因为getset是原子操作)
            // 假如拿到的oldValue依然是expired的，那么就说明拿到锁了。
            if (oldValue != null && isTimeExpired(oldValue)) {
                // 成功获取到锁，设置相关标识
                locked = true;
                setExclusiveOwnerThread(Thread.currentThread());
                return true;
            }
        } else {

        }
        return false;
    }

    /**
     * 查询此锁是否被线程占有
     */
    public boolean isLocked() {
        if (locked) {
            return true;
        } else {
            String value = jedis.get(lockKey);
            /**
             * TODO 这里其实有问题，想：当get方法返回value后，假设这个value已经过期了，
             * 而就在这瞬间，另一个节点set了value，这时锁被别的线程(节点持有)，而接下来的判断
             * 是检测不出这种情况的，不过这个问题应该不会导致其他问题的出现，因为这个方法的目的本来就
             * 不是同步控制，它只是一种锁状态的报告。
             */
            return !isTimeExpired(value);
        }
    }

    public Condition newCondition() {
        return null;
    }

    private void checkInterruption() throws InterruptedException {
        if (Thread.currentThread().isInterrupted()) {
            throw new InterruptedException();
        }
    }

    private boolean isTimeout(long start, long timeout) {
        return (start + timeout) > System.currentTimeMillis();
    }

    private boolean isTimeExpired(String value) {
        return Long.parseLong(value) < System.currentTimeMillis();
    }

    private void doUnlock() {
        jedis.del(lockKey);
    }
}
