package com.yp.server1.myTransaction.aspect;

import com.yp.server1.myTransaction.annotation.MyTransactional;
import com.yp.server1.myTransaction.transactional.MyTransaction;
import com.yp.server1.myTransaction.transactional.MyTransactionManager;
import com.yp.server1.myTransaction.transactional.TransactionType;
import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.Signature;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.reflect.MethodSignature;
import org.springframework.core.Ordered;
import org.springframework.stereotype.Component;

import java.lang.annotation.Annotation;
import java.lang.reflect.Method;

/**
 * Created by yepeng on 2019/04/12.
 */
@Aspect
@Component
public class MyTransactionalAspect implements Ordered {
    @Around("@annotation(com.yp.server1.myTransaction.annotation.MyTransactional)")
    public void around(ProceedingJoinPoint joinPoint) {
        MethodSignature signature = (MethodSignature) joinPoint.getSignature();
        Method method = signature.getMethod();
        MyTransactional annotation = method.getAnnotation(MyTransactional.class);

        String groupId = "";
        if (annotation.isStart()) {
            // create group
            groupId = MyTransactionManager.createTransactionGroup();

        } else if (annotation.isEnd()) {
            // commit or rollback

        }
        MyTransaction transcation = MyTransactionManager.createTranscation(groupId);
        try {
            joinPoint.proceed();
            // 正常
            MyTransactionManager.addTransaction(transcation, TransactionType.COMMIT, annotation.isEnd());
        } catch (Throwable throwable) {
            // 回滚
            MyTransactionManager.addTransaction(transcation, TransactionType.ROllBACK, true);
            throwable.printStackTrace();
        }
    }

    @Override
    public int getOrder() {
        return 10000;
    }
}
