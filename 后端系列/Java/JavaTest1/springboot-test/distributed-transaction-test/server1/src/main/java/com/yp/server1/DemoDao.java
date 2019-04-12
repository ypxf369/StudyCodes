package com.yp.server1;

import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;

import java.util.UUID;

/**
 * Created by yepeng on 2019/04/11.
 */
@Mapper
public interface DemoDao {
    @Insert("insert into t_order(order_id,order_name) values(#{order_id},#{order_name})")
    void insert(@Param("order_id") String orderId, @Param("order_name") String name);
}
