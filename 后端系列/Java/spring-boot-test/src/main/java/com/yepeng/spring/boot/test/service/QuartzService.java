package com.yepeng.spring.boot.test.service;

import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by yepeng on 2018/10/29.
 * 该方法是spring boot 内置的定时任务，如果不做配置的话，默认多任务会出现问题，因为都在同一个线程中执行。
 * 多线程模式加入如下配置类：
 * @Configuration
 * @EnableAsync
 * public class AsyncConfig {
 *
 *     此处成员变量应该使用@Value从配置中读取
 *
 *private int corePoolSize=10;
        *private int maxPoolSize=200;
        *private int queueCapacity=10;
        *@Bean
 *public Executor taskExecutor(){
        *ThreadPoolTaskExecutor executor=new ThreadPoolTaskExecutor();
        *executor.setCorePoolSize(corePoolSize);
        *executor.setMaxPoolSize(maxPoolSize);
        *executor.setQueueCapacity(queueCapacity);
        *executor.initialize();
        *return executor;
        *}
        *}
 *
 * 然后再定时任务的类或者方法上加入 @Async 注解
 */
@Component
public class QuartzService {
    //每秒运行
    @Scheduled(cron = "0/1 * * * * ?")
    public void timerToNow(){
        System.out.println("now time:" + new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date()));
    }
}
