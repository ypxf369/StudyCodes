package com.yp.annotation;

import java.lang.annotation.*;

/**
 * Created by yepeng on 2019/02/20.
 */
@Target(ElementType.TYPE)
@Retention(RetentionPolicy.RUNTIME)
@Documented
public @interface MyController {
    /**
     * 表示给controller注册别名
     */
    String value() default "";
}
