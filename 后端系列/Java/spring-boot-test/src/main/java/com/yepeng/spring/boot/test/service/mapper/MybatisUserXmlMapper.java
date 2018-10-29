package com.yepeng.spring.boot.test.service.mapper;

import com.yepeng.spring.boot.test.entity.User;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;

/**
 * Created by yepeng on 2018/10/29.
 */
@Mapper
public interface MybatisUserXmlMapper {
    void createUser(@Param("name") String name, @Param("password") String password);

    User getUserById(@Param("id") Integer id);

    void updateUserById(@Param("id") Integer id, @Param("name") String name);

    void deleteUserById(@Param("id") Integer id);
}
