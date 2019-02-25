package com.yp.bloomfilter;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.RedisCallback;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by yepeng on 2019/02/25.
 */
@Service
public class RedisService {
    @Autowired
    private StringRedisTemplate template;

    public void multiSetBit(String name, boolean value, long... offsets) {
        template.executePipelined((RedisCallback<Object>) connection -> {
            for (long offset : offsets) {
                connection.setBit(name.getBytes(), offset, value);
            }
            return null;
        });
    }

    public List<Boolean> multiGetBit(String name, long... offsets) {
        List<Object> results = template.executePipelined((RedisCallback<Object>) connection -> {
            for (long offset : offsets) {
                connection.getBit(name.getBytes(), offset);
            }
            return null;
        });
        List<Boolean> list = new ArrayList<>();
        results.forEach(obj -> {
            list.add((Boolean) obj);
        });
        return list;
    }
}
