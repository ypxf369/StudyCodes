package com.yp.mapper;

import com.yp.bean.User;

import java.util.List;

/**
 * Created by yepeng on 2019/02/23.
 */
public interface UserMapper {
    User getUserById(String id);
    List<User> getAll();
}
