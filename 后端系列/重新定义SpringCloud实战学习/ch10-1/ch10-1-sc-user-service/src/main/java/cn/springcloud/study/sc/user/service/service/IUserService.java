package cn.springcloud.study.sc.user.service.service;

import java.util.List;

/**
 * Created by yepeng on 2018/11/26.
 */
public interface IUserService {
    public String getDefaultUser();
    public String getContextUserId();
    public List<String> getProviderData();
}
