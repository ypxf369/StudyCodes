package com.yp.runner.test;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class RunnerTestApplication {

    public static void main(String[] args) {
        System.out.println(111);
        SpringApplication.run(RunnerTestApplication.class, args);
        System.out.println(222);
    }

}

