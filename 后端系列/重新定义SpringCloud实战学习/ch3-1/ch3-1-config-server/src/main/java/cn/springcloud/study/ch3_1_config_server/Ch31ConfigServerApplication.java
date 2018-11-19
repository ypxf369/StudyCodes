package cn.springcloud.study.ch3_1_config_server;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.config.server.EnableConfigServer;

@SpringBootApplication
@EnableConfigServer
public class Ch31ConfigServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch31ConfigServerApplication.class, args);
    }
}
