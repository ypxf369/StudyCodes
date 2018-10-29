package com.yepeng.spring.boot.test.service.mapper;

import com.yepeng.spring.boot.test.entity.User;
import org.apache.ibatis.annotations.*;

/**
 * Created by yepeng on 2018/10/26.
 */
@Mapper
public interface MybatisUserMapper {
    @Insert("insert into t_user(name,password) values (#{name},MD5(#{password}))")
    void createUser(@Param("name") String name, @Param("password") String password);

    @Select("select * from t_user where id=#{id}")
    User getUserById(@Param("id") Integer id);

    @Update("update t_user set name=#{name} where id=#{id}")
    void updateUserById(@Param("id") Integer id, @Param("name") String name);

    @Delete("delete from t_user where id=#{id}")
    void deleteUserById(@Param("id") Integer id);
}
