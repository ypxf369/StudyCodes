package com.yepeng.spring.boot.test.service;

import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by yepeng on 2018/10/29.
 */
@Component
public class QuartzService {
    //每秒运行
    @Scheduled(cron = "0/1 * * * * ?")
    public void timerToNow(){
        System.out.println("now time:" + new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date()));
    }
}
