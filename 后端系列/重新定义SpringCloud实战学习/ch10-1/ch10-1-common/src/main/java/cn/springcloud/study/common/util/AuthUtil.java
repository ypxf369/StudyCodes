package cn.springcloud.study.common.util;

import cn.springcloud.study.common.vo.User;
import org.apache.commons.lang.StringUtils;

import javax.servlet.http.HttpServletResponse;

/**
 * Created by yepeng on 2018/11/26.
 */
public class AuthUtil {
    public static boolean authUser(User user, HttpServletResponse respone) throws Exception{
        if(StringUtils.isEmpty(user.getUserId())) {
            return false;
        }else {
            return true;
        }
    }
}
