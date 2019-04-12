package com.yp.server1;

import com.yp.server1.myTransaction.annotation.MyTransactional;
import com.yp.server1.myTransaction.util.HttpClient;
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
    @MyTransactional(isStart = true)
    public void test(){
        demoDao.insert(UUID.randomUUID().toString(), "server1");
        HttpClient.get("http://localhost:8082/server2/test");
        int a=1/0;
    }

}
