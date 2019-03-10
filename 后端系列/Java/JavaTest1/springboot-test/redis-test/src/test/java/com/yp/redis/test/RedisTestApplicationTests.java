package com.yp.redis.test;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;
import redis.clients.jedis.Jedis;
import redis.clients.jedis.Transaction;

import java.util.UUID;

@RunWith(SpringRunner.class)
@SpringBootTest
public class RedisTestApplicationTests {

    @Test
    public void contextLoads() {
    }

    @Test
    public void redisTest() {
        Jedis jedis = new Jedis("localhost");
        try {
            Transaction transaction = jedis.multi();
            transaction.set("test", "124");
            //int a=6/0;
            transaction.set("test", "111");
            transaction.exec();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Test
    public void redisDistributedLockTest() {
        Jedis jedis = new Jedis("localhost");
        String requestId = UUID.randomUUID().toString();
        boolean result = RedisTool.tryGetDistributedLock(jedis, "test", requestId, 10000);
        System.out.println(result);
        boolean result1 = RedisTool.tryGetDistributedLock(jedis, "test", requestId, 10000);
        System.out.println(result1);

        boolean releaseReuslt = RedisTool.releaseDistributedLock(jedis, "test", requestId);
        System.out.println(releaseReuslt);
        boolean result3 = RedisTool.tryGetDistributedLock(jedis, "test", requestId, 10000);
        System.out.println(result3);
    }

}
