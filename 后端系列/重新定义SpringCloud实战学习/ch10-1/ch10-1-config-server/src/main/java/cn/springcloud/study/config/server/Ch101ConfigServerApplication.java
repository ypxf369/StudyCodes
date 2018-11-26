package cn.springcloud.study.config.server;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.config.server.EnableConfigServer;

@SpringBootApplication
@EnableConfigServer
public class Ch101ConfigServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch101ConfigServerApplication.class, args);
    }
}
