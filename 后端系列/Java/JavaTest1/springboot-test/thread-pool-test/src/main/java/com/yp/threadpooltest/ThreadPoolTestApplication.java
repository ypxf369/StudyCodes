package com.yp.threadpooltest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import javax.annotation.Resource;
import java.util.concurrent.ExecutorService;

@SpringBootApplication
public class ThreadPoolTestApplication {


    private static ThreadPoolTest threadPoolTest;

    @Autowired
    public void setThreadPoolTest(ThreadPoolTest threadPoolTest) {
        this.threadPoolTest = threadPoolTest;
    }

    public static void main(String[] args) {

        SpringApplication.run(ThreadPoolTestApplication.class, args);

        threadPoolTest.execute();
    }

}
