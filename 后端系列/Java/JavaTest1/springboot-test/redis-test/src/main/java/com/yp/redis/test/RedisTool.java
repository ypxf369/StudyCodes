package com.yp.redis.test;

import redis.clients.jedis.Jedis;
import redis.clients.jedis.params.SetParams;

import java.util.Collections;

/**
 * Created by yepeng on 2019/03/10.
 */
public class RedisTool {
    private static final String LOCK_SUCCESS = "OK";
    private static final Long RELEASE_SUCCESS = 1L;

    /**
     * @param
     * @Description: 尝试获取分布式锁
     * @Param: jedis Redis客户端
     * @Param: lockKey 锁
     * @Param: requestId 请求标识--判断加锁和解锁是否是同一个客户端（可靠性）
     * @Param: expireTime 超时时间
     * @return: 是否请求成功
     * @Author: yepeng
     * @Date: 2019/03/10
     */
    public static boolean tryGetDistributedLock(Jedis jedis, String lockKey, String requestId, long expireTime) {
        String result = jedis.set(lockKey, requestId, new SetParams().nx().px(expireTime));
        if (LOCK_SUCCESS.equals(result)) {
            return true;
        }
        return false;
    }

    /**
     * 释放分布式锁
     *
     * @param jedis     Redis客户端
     * @param lockKey   锁
     * @param requestId 请求标识
     * @return 是否释放成功
     */
    public static boolean releaseDistributedLock(Jedis jedis, String lockKey, String requestId) {

        String script = "if redis.call('get', KEYS[1]) == ARGV[1] then return redis.call('del', KEYS[1]) else return 0 end";
        Object result = jedis.eval(script, Collections.singletonList(lockKey), Collections.singletonList(requestId));

        if (RELEASE_SUCCESS.equals(result)) {
            return true;
        }
        return false;

    }
}
