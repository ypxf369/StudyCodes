package cn.springcloud.study.common.context;

/**
 * Created by yepeng on 2018/11/26.
 */
public class HystrixThreadLocal {
    public static ThreadLocal<String> threadLocal = new ThreadLocal<>();
}
