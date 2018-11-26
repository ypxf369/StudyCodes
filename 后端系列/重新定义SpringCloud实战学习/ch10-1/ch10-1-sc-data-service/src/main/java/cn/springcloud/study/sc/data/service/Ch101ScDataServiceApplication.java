package cn.springcloud.study.sc.data.service;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.circuitbreaker.EnableCircuitBreaker;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
@EnableCircuitBreaker
public class Ch101ScDataServiceApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch101ScDataServiceApplication.class, args);
    }
}
