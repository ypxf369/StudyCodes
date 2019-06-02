package com.yp.threadpooltest;

import org.springframework.stereotype.Component;

import javax.annotation.Resource;
import java.util.concurrent.ExecutorService;

/**
 * Created by yepeng on 2019/06/02.
 */
@Component
public class ThreadPoolTest {

    @Resource(name = "consumerThreadPool")
    private ExecutorService consumerExecutorService;

    public void execute() {
        for (int i = 0; i < 10; i++) {
            consumerExecutorService.execute(new MyThread(String.valueOf(i)));
        }
    }

    class MyThread implements Runnable {
        private String name;

        public MyThread(String name) {
            this.name = name;
        }

        @Override
        public void run() {
            System.out.println("running_" + name);
        }
    }
}
