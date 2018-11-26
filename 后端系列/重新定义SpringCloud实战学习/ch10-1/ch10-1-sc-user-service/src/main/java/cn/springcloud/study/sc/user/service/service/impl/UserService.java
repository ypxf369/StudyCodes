package cn.springcloud.study.sc.user.service.service.impl;

import cn.springcloud.study.sc.user.service.service.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.web.client.RestTemplate;

import java.util.List;

/**
 * Created by yepeng on 2018/11/26.
 */
@Component
public class UserService implements IUserService {
    @Autowired
    private IUserService userService;

    @Autowired
    private RestTemplate restTemplate;

    @Override
    public String getDefaultUser() {
        return userService.getDefaultUser();
    }

    @Override
    public String getContextUserId() {
        return userService.getContextUserId();
    }

    @Override
    public List<String> getProviderData() {
        List<String> result = restTemplate.getForObject("http://sc-data-service/getProviderData", List.class);
        return result;
    }
}
