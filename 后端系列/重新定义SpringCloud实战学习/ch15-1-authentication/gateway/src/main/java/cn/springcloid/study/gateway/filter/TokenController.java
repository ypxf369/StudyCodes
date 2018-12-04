package cn.springcloid.study.gateway.filter;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/12/04.
 */
@RestController
public class TokenController {
    @GetMapping("/getToken/{name}")
    public String get(@PathVariable("name") String name) {
        return JwtUtil.generateToken(name);
    }
}
