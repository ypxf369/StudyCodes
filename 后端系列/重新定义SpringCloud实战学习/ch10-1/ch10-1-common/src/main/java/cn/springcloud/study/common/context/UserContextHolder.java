package cn.springcloud.study.common.context;

import cn.springcloud.study.common.vo.User;

/**
 * 用户上下文
 * Created by yepeng on 2018/11/26.
 */
public class UserContextHolder {
    public static ThreadLocal<User> context = new ThreadLocal<User>();

    public static User currentUser() {
        return context.get();
    }

    public static void set(User user) {
        context.set(user);
    }

    public static void shutdown() {
        context.remove();
    }
}
