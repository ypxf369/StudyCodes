package com.yp.threadpooltest;

import com.google.common.util.concurrent.ThreadFactoryBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.concurrent.*;

/**
 * Created by yepeng on 2019/06/02.
 */
@Configuration
public class ThreadPoolConfig {

    /**
     * 消费队列线程
     */
    @Bean(name = "consumerThreadPool")
    public ExecutorService consumerThreadPool(){
        ThreadFactory build = new ThreadFactoryBuilder().setNameFormat("consumer-thread-pool-%d").build();

        ThreadPoolExecutor threadPoolExecutor = new ThreadPoolExecutor(5, 5, 0L, TimeUnit.MILLISECONDS, new ArrayBlockingQueue<>(5), build, new ThreadPoolExecutor.AbortPolicy());

        return threadPoolExecutor;
    }

}
