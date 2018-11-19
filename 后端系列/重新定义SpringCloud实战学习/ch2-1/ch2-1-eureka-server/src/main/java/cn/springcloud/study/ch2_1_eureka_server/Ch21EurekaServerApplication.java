package cn.springcloud.study.ch2_1_eureka_server;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@SpringBootApplication
@EnableEurekaServer
public class Ch21EurekaServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch21EurekaServerApplication.class, args);
    }
}
