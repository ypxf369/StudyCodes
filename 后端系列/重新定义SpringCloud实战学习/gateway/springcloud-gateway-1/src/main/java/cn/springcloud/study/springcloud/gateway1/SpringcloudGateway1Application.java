package cn.springcloud.study.springcloud.gateway1;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.gateway.route.RouteLocator;
import org.springframework.cloud.gateway.route.builder.RouteLocatorBuilder;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class SpringcloudGateway1Application {

//    @Bean
//    public RouteLocator customRouteLocator(RouteLocatorBuilder builder) {
//        return builder.routes()
//                // basic proxy
//                .route(r -> r.path("/jd").uri("http://jd.com:80/").id("jd_route"))
//                .build();
//    }

    public static void main(String[] args) {
        SpringApplication.run(SpringcloudGateway1Application.class, args);
    }
}
