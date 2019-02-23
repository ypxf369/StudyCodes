package com.yp.sqlSession;

/**
 * Created by yepeng on 2019/02/23.
 */
public interface Excutor {
    <T> T query(String statement, Object parameter);
}
