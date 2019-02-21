package com.yp.service;

import com.yp.service.bean.Product;

/**
 * Created by yepeng on 2019/02/21.
 * 商品查询api接口
 */
public interface IProductService {
    Product queryById(long id);
}
