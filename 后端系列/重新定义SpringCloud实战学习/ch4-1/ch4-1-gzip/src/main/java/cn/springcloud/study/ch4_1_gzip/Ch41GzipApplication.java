package cn.springcloud.study.ch4_1_gzip;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.openfeign.EnableFeignClients;

@SpringBootApplication
@EnableFeignClients
public class Ch41GzipApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch41GzipApplication.class, args);
    }
}
