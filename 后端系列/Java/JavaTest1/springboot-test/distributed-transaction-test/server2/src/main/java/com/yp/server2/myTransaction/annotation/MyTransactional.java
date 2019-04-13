package com.yp.server2.myTransaction.annotation;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * Created by yepeng on 2019/04/12.
 */
@Retention(RetentionPolicy.RUNTIME)
@Target({ElementType.METHOD})
public @interface MyTransactional {
    boolean isStart() default false;

    boolean isEnd() default false;
}
