package cn.springcloud.study.ch6_1_clientservice;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.hystrix.EnableHystrix;

@SpringBootApplication
@EnableHystrix
public class Ch61ClientServiceApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch61ClientServiceApplication.class, args);
    }
}
