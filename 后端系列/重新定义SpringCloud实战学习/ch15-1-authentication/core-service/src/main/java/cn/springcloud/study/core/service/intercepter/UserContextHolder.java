package cn.springcloud.study.core.service.intercepter;

import cn.springcloud.study.core.service.vo.User;

/**
 * 用户上下文持有对象
 * Created by yepeng on 2018/12/04.
 */
public class UserContextHolder {
    public static ThreadLocal<User> context = new ThreadLocal<>();

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
