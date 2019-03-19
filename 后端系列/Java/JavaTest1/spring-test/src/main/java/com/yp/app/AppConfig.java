package com.yp.app;

import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.EnableAspectJAutoProxy;

/**
 * Created by yepeng on 2019/03/18.
 */
@Configuration
@ComponentScan("com")
@EnableAspectJAutoProxy
public class AppConfig {
}
