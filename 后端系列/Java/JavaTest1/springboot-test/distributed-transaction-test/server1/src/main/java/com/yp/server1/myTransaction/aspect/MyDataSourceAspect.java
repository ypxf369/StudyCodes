package com.yp.server1.myTransaction.aspect;

import com.yp.server1.myTransaction.connection.MyConnection;
import com.yp.server1.myTransaction.transactional.MyTransactionManager;
import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.stereotype.Component;

import java.sql.Connection;

/**
 * Created by yepeng on 2019/04/12.
 */
@Aspect
@Component
public class MyDataSourceAspect {

    @Around("execution(* javax.sql.DataSource.getConnection(..))")
    public Connection around(ProceedingJoinPoint proceedingJoinPoint) throws Throwable {
        Connection connection = (Connection) proceedingJoinPoint.proceed();// 数据库连接
        if (MyTransactionManager.getCurrent() != null) {
            return new MyConnection(connection, MyTransactionManager.getCurrent());
        } else {
            return (Connection) proceedingJoinPoint.proceed();
        }

    }
}
