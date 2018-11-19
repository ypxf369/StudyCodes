package cn.springcloud.study.ch4_1_hello.service;

import cn.springcloud.study.ch4_1_hello.HelloFeignServiceConfig;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

/**
 * Created by yepeng on 2018/11/19.
 */
@FeignClient(name = "github-client",url = "https://api.github.com",configuration = HelloFeignServiceConfig.class)
public interface HelloFeignService {
    @GetMapping("/search/repositories")
    String searchRepo(@RequestParam("q")String queryStr);
}
