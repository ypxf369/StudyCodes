package com.yp.bloomfilter;

import org.springframework.beans.factory.annotation.Autowired;

import java.io.*;
import java.util.HashSet;
import java.util.List;

/**
 * Created by yepeng on 2019/02/25.
 */
public class BloomFilter {
    @Autowired
    private RedisService redisService;

    //总的bitmap大小  64M
    private static final int cap = 1 << 29;
    /*
     * 不同哈希函数的种子，一般取质数
     * seeds数组共有8个值，则代表采用8种不同的哈希函数
     */
    private int[] seeds = new int[]{3, 5, 7, 11, 13, 31, 37, 61};

    private int hash(String value, int seed) {
        int result = 0;
        int length = value.length();
        for (int i = 0; i < length; i++) {
            result = seed * result + value.charAt(i);
        }
        return (cap - 1) & result;
    }


    public void insertRedis() throws IOException {
        FileInputStream inputStream = new FileInputStream("/XXXX.csv");
        BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream));
        HashSet<Long> totalSet = new HashSet<>();
        String word = null;
        while ((word = bufferedReader.readLine()) != null) {
            for (int seed : seeds) {
                int hash = hash(word, seed);
                totalSet.add((long) hash);
            }
            long[] offsets = new long[totalSet.size()];
            int i = 0;
            for (Long l : totalSet) {
                offsets[i++] = l;
            }
            //setbit的offset是用大小限制的，在0到 232（最大使用512M内存）之间，即0~4294967296之前，超过这个数会自动将offset转化为0，
            redisService.multiSetBit("BLOOM_FILTER_WORDS_DICTIONARY", true, offsets);
        }
    }

    public boolean query() {
        String word = "XXXX"; //实际输入
        long[] offsets = new long[seeds.length];
        for (int i = 0; i < seeds.length; i++) {
            int hash = hash(word, seeds[i]);
            offsets[i] = hash;
        }
        List<Boolean> results = redisService.multiGetBit("BLOOM_FILTER_WORDS_DICTIONARY", offsets);
        //判断是否都为true （则存在)
        boolean isExisted = true;
        for (Boolean result : results) {
            if (!result) {
                isExisted = false;
                break;
            }
        }
        return isExisted;
    }
}
