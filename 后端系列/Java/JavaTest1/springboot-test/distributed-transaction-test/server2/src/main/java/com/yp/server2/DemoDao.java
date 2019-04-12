package com.yp.server2;

import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;

import java.util.UUID;

/**
 * Created by yepeng on 2019/04/11.
 */
@Mapper
public interface DemoDao {
    @Insert("insert into t_stock(stock_id,num) values(#{stockId},3)")
    void insert(@Param("stockId") String orderId);
}
