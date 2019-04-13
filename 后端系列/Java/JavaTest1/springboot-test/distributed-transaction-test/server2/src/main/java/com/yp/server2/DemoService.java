package com.yp.server2;

import com.yp.server2.myTransaction.annotation.MyTransactional;
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
    @MyTransactional(isEnd = true)
    public void test(){
        demoDao.insert(UUID.randomUUID().toString());
    }
}
