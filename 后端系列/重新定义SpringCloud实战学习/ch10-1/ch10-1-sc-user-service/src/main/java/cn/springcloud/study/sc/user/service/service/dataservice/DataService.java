package cn.springcloud.study.sc.user.service.service.dataservice;

import cn.springcloud.study.sc.user.service.service.fallback.UserClientFallback;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

/**
 * feign调用数据服务
 * Created by yepeng on 2018/11/26.
 */
@FeignClient(name = "sc-data-service", fallback = UserClientFallback.class)
public interface DataService {
    @RequestMapping(value = "/getDefaultUser", method = RequestMethod.GET)
    public String getDefaultUser();

    @RequestMapping(value = "/getContextUserId", method = RequestMethod.GET)
    public String getContextUserId();
}
