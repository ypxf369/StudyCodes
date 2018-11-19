package cn.springcloud.study.ch4_1_gzip.controller;

import cn.springcloud.study.ch4_1_gzip.service.GZipFeignService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/11/19.
 */
@RestController
public class GZipFeignController {
    @Autowired
    private GZipFeignService GZipFeignService;

    // 服务消费者对应提供的服务
    @GetMapping("/search/github")
    public ResponseEntity<byte[]> searchGithubRepoByStr(@RequestParam("str")String queryStr ){
        return GZipFeignService.searchRepo(queryStr);
    }
}
