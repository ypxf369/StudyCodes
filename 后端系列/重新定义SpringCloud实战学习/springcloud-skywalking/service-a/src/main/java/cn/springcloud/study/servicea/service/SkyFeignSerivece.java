package cn.springcloud.study.servicea.service;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;

/**
 * Created by yepeng on 2018/12/05.
 */
@FeignClient(name = "service-b")
public interface SkyFeignSerivece {
    /**
     * serviceName 是传递过去的service-a
     */
    @GetMapping("getSendInfo")
    String getSendInfo(@RequestParam("serviceName") String serviceName);
}
