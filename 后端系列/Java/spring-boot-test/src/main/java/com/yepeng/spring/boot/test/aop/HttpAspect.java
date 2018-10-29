package com.yepeng.spring.boot.test.aop;

import com.yepeng.spring.boot.test.model.ExceptionHandle;
import com.yepeng.spring.boot.test.model.Result;
import org.apache.commons.lang3.StringUtils;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.web.context.request.RequestContextHolder;
import org.springframework.web.context.request.ServletRequestAttributes;

import javax.servlet.http.HttpServletRequest;

/**
 * Created by yepeng on 2018/10/26.
 */
@Aspect
@Component
public class HttpAspect {
    private final static Logger LOGGER = LoggerFactory.getLogger(HttpAspect.class);

    @Autowired
    private ExceptionHandle exceptionHandle;

    @Pointcut("execution(public * com.yepeng.spring.boot.test.controller.*.*(..))")
    public void log() {
        //todo:
    }

    @Before("log()")
    public void doBefore(JoinPoint joinPoint) {
        ServletRequestAttributes attributes = (ServletRequestAttributes) RequestContextHolder.getRequestAttributes();
        HttpServletRequest request = attributes.getRequest();

        //url
        LOGGER.info("url={}", request.getRequestURL());
        //method
        LOGGER.info("method={}", request.getMethod());
        //ip
        LOGGER.info("ip={}", request.getRemoteAddr());
        //class_method
        LOGGER.info("class_method={}", joinPoint.getSignature().getDeclaringTypeName() + "," + joinPoint.getSignature().getName());
        //args[]
        LOGGER.info("args={}", StringUtils.join(joinPoint.getArgs(),","));
    }

    @Around("log()")
    public Object doAround(ProceedingJoinPoint proceedingJoinPoint) throws Throwable {
        Result result = null;
        try {

        } catch (Exception ex) {
            return exceptionHandle.exceptionGet(ex);
        }
        if (result == null) {
            return proceedingJoinPoint.proceed();
        } else {
            return result;
        }
    }

    //打印输出结果
    @AfterReturning(pointcut = "log()", returning = "object")
    public void doAfterReturing(Object object) {
        if(object!=null){
            LOGGER.info("response={}", object.toString());
        }
    }
}
