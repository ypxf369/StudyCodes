package com.yepeng.spring.boot.test.redis;

import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.concurrent.TimeUnit;

/**
 * Created by yepeng on 2018/10/29.
 */
@RunWith(SpringRunner.class)
@SpringBootTest
public class RedisTest {
    @Autowired
    private StringRedisTemplate stringRedisTemplate;

    @Test
    public void save(){

        stringRedisTemplate.opsForValue().set("redis-test","yepeng",1,TimeUnit.MINUTES);
        Assert.assertEquals("yepeng",stringRedisTemplate.opsForValue().get("redis-test"));
    }
}
