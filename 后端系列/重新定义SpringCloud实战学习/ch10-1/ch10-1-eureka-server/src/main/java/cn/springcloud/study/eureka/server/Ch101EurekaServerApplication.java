package cn.springcloud.study.eureka.server;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@SpringBootApplication
@EnableEurekaServer
public class Ch101EurekaServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch101EurekaServerApplication.class, args);
    }
}
