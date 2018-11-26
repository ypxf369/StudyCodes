package cn.springcloud.study.zuul.server;

import cn.springcloud.study.zuul.server.filter.AuthFilter;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.circuitbreaker.EnableCircuitBreaker;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.netflix.zuul.EnableZuulProxy;
import org.springframework.cloud.netflix.zuul.ZuulProxyAutoConfiguration;
import org.springframework.context.annotation.Bean;

@SpringBootApplication(exclude = ZuulProxyAutoConfiguration.class)
@EnableDiscoveryClient
@EnableZuulProxy
@EnableCircuitBreaker
public class Ch101ZuulServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(Ch101ZuulServerApplication.class, args);
    }
    @Bean
    public AuthFilter preRequestFilter() {
        return new AuthFilter();
    }
}
