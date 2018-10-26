package com.yepeng.spring.boot.test.service.mapper.impl;

import com.yepeng.spring.boot.test.entity.User;
import com.yepeng.spring.boot.test.service.mapper.UserMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.jdbc.support.GeneratedKeyHolder;
import org.springframework.stereotype.Repository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;

/**
 * Created by yepeng on 2018/10/25.
 */
@Repository
public class UserImpl implements UserMapper {
    @Autowired
    private JdbcTemplate template;

    @Override
    public int createUser(String name, String password) {
        String sql = "insert into blog.t_user(name,password) values(?,MD5(?))";
        var keyHolder = new GeneratedKeyHolder();
        template.update(new PreparedStatementCreator() {
            @Override
            public PreparedStatement createPreparedStatement(Connection connection) throws SQLException {
                var ps = connection.prepareStatement(sql,Statement.RETURN_GENERATED_KEYS);
                ps.setString(1, name);
                ps.setString(2, password);
                return ps;
            }
        }, keyHolder);

       return keyHolder.getKey().intValue();
    }

    @Override
    public User getUserById(Integer id) {
        List<User> userList = template.query("select * from blog.t_user where id=?", new Object[]{id}, new BeanPropertyRowMapper(User.class));
        if (userList != null && userList.size() > 0) {
            User user = userList.get(0);
            return user;
        } else {
            return null;
        }
    }

    @Override
    public void updateUserById(Integer id, String name) {
        int i = template.update("update blog.t_user set name =? where id=?", name, id);
        System.out.println(i);
    }

    @Override
    public void deleteUserById(Integer id) {
        int i = template.update("delete from blog.t_user where id=?", id);
        System.out.println(i);
    }
}
