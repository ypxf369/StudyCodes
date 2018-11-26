package cn.springcloud.study.sc.user.service.service.fallback;

import cn.springcloud.study.sc.user.service.service.dataservice.DataService;
import org.springframework.stereotype.Component;

/**
 * Created by yepeng on 2018/11/26.
 */
@Component
public class UserClientFallback implements DataService {
    @Override
    public String getDefaultUser() {
        return new String("get getDefaultUser failed");
    }

    @Override
    public String getContextUserId() {
        return new String("get getContextUserId failed");
    }
}
