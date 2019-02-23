package com.yp.sqlSession;

import com.yp.bean.User;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

/**
 * Created by yepeng on 2019/02/23.
 */
public class MyExcutor implements Excutor {

    private MyConfiguration configuration = new MyConfiguration();

    @Override
    public <T> T query(String sql, Object parameter) {
        Connection connection = getConnection();
        ResultSet set = null;
        PreparedStatement pre = null;
        try {
            pre = connection.prepareStatement(sql);

            //设置参数
            pre.setString(1, parameter.toString());
            set = pre.executeQuery();


            User user = new User();

            //遍历结果集
            while (set.next()) {
                user.setId(set.getString(1));
                user.setUsername(set.getString(2));
                user.setPassword(set.getString(3));
            }
            return (T) user;
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                if (set != null) {
                    set.close();
                }
                if (pre != null) {
                    pre.close();
                }
                if (connection != null) {
                    connection.close();
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return null;
    }

    private Connection getConnection() {
        try {
            Connection connection = configuration.build("config.xml");
            return connection;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}
