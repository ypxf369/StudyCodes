package cn.springcloud.study.common.context;

import org.springframework.web.context.request.RequestAttributes;
import org.springframework.web.context.request.RequestContextHolder;

import java.util.concurrent.Callable;

/**
 * Created by yepeng on 2018/11/26.
 */
public class HystrixThreadCallable<T> implements Callable<T> {

    private final RequestAttributes requestAttributes;
    private final Callable<T> delegate;
    private String params;

    public HystrixThreadCallable(Callable<T> callable, RequestAttributes requestAttributes,String params) {
        this.delegate = callable;
        this.requestAttributes = requestAttributes;
        this.params = params;
    }
    @Override
    public T call() throws Exception {
        try {
            RequestContextHolder.setRequestAttributes(requestAttributes);
            HystrixThreadLocal.threadLocal.set(params);
            return delegate.call();
        } finally {
            RequestContextHolder.resetRequestAttributes();
            HystrixThreadLocal.threadLocal.remove();
        }
    }
}
