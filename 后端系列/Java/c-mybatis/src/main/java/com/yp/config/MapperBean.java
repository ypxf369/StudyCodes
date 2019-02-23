package com.yp.config;

import java.util.List;

/**
 * Created by yepeng on 2019/02/23.
 */
public class MapperBean {
    /**
     * 接口名
     */
    private String interfaceName;
    /**
     * 接口下所有的方法
     */
    private List<Function>list;

    public String getInterfaceName() {
        return interfaceName;
    }

    public void setInterfaceName(String interfaceName) {
        this.interfaceName = interfaceName;
    }

    public List<Function> getList() {
        return list;
    }

    public void setList(List<Function> list) {
        this.list = list;
    }
}
