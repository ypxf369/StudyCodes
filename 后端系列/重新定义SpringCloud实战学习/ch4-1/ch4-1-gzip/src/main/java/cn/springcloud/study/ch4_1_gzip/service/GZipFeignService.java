package cn.springcloud.study.ch4_1_gzip.service;

import cn.springcloud.study.ch4_1_gzip.GZipFeignServiceConfig;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

/**
 * Created by yepeng on 2018/11/19.
 */
@FeignClient(name = "github-client",url = "https://api.github.com",configuration = GZipFeignServiceConfig.class)
public interface GZipFeignService {
    @GetMapping("/search/repositories")
    ResponseEntity<byte[]> searchRepo(@RequestParam("q") String queryStr);
}
