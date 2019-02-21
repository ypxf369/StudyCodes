package com.yp.service;

import com.yp.service.bean.Product;

/**
 * Created by yepeng on 2019/02/21.
 */
public class ProductService implements IProductService {

    public Product queryById(long id) {
        Product product = new Product();
        product.setId(id);
        product.setName("ypxf369");
        product.setPrice(1.0);
        return product;
    }
}
