package cn.springcloud.study.ch6_1_clientservice.service;

import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
import org.springframework.stereotype.Service;

/**
 * Created by yepeng on 2018/11/20.
 */
@Service
public class UserService {
    @HystrixCommand(fallbackMethod = "defaultUser")
    public String getUser(String username) throws Exception {
        if (username.equals("spring")) {
            return "this is real user";
        } else {
            throw new Exception();
        }
    }

    public String defaultUser(String username) {
        return "该用户不存在" + username;
    }
}
