package cn.springcloud.study.eureka.server.skywalking;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@SpringBootApplication
@EnableEurekaServer
public class EurekaServerSkywalkingApplication {

    public static void main(String[] args) {
        SpringApplication.run(EurekaServerSkywalkingApplication.class, args);
    }
}
