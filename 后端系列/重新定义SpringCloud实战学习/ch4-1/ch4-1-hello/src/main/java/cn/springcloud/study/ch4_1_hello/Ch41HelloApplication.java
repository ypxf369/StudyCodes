package cn.springcloud.study.ch4_1_hello;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.openfeign.EnableFeignClients;

@SpringBootApplication
@EnableFeignClients
public class Ch41HelloApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch41HelloApplication.class, args);
    }
}
