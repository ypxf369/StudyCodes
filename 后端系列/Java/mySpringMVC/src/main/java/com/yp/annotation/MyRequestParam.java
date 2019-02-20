package com.yp.annotation;

import java.lang.annotation.*;

/**
 * Created by yepeng on 2019/02/20.
 */
@Target(ElementType.PARAMETER)
@Retention(RetentionPolicy.RUNTIME)
@Documented
public @interface MyRequestParam {
    String value();
}
