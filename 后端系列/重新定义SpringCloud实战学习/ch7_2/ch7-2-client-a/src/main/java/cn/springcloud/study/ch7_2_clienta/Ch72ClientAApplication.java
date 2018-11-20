package cn.springcloud.study.ch7_2_clienta;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
@EnableDiscoveryClient
public class Ch72ClientAApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch72ClientAApplication.class, args);
    }
}
