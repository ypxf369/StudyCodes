package cn.springcloud.study.ch4_1_hello.controller;

import cn.springcloud.study.ch4_1_hello.service.HelloFeignService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/11/19.
 */
@RestController
public class HelloFeignController {
    @Autowired
    private HelloFeignService helloFeignService;

    // 服务消费者对应提供的服务
    @GetMapping("/search/github")
    public String searchGithubRepoByStr(@RequestParam("str")String queryStr ){
        return helloFeignService.searchRepo(queryStr);
    }
}
