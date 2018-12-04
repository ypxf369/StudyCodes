package cn.springcloid.study.gateway.filter;

/**
 * Created by yepeng on 2018/12/04.
 */
public class PermissionException extends RuntimeException {
    private static final long serialVersionUID = 1L;
    public PermissionException(String msg) {
        super(msg);
    }
}
