package com.yp.server2;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.UUID;

/**
 * Created by yepeng on 2019/04/11.
 */
@Service
public class DemoService {
    @Autowired
    private DemoDao demoDao;

    @Transactional
    public void test(){
        demoDao.insert(UUID.randomUUID().toString());
    }
}
