package cn.springcloud.study.sc.data.service.config;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;

/**
 * 配置信息
 * Created by yepeng on 2018/11/26.
 */
@Component
@ConfigurationProperties(prefix = "cn.springcloud.study")
public class DataConfig {
    private String defaultUser;

    public String getDefaultUser() {
        return defaultUser;
    }

    public void setDefaultUser(String defaultUser) {
        this.defaultUser = defaultUser;
    }
}
