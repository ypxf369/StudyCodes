package cn.springcloud.study.config.client.config;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;

/**
 * Created by yepeng on 2018/11/29.
 */
@Component
@ConfigurationProperties(prefix = "cn.springcloud.study")
public class ConfigInfoProperties {
    private String config;

    public String getConfig() {
        return config;
    }

    public void setConfig(String config) {
        this.config = config;
    }
}
