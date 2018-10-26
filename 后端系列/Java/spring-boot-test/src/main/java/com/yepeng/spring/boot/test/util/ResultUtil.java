package com.yepeng.spring.boot.test.util;

import com.yepeng.spring.boot.test.model.ExceptionEnum;
import com.yepeng.spring.boot.test.model.Result;

/**
 * Created by yepeng on 2018/10/26.
 */
public class ResultUtil {
    public static <T> Result<T> success(T data) {
        Result<T> result = new Result<>();
        result.setStatus(0);
        result.setMsg("success");
        result.setData(data);
        return result;
    }

    public static Result success() {
        return success(null);
    }

    public static Result error(Integer code, String msg) {
        Result result = new Result();
        result.setStatus(code);
        result.setMsg(msg);
        result.setData(null);
        return result;
    }

    public static Result error(ExceptionEnum exceptionEnum) {
        Result result = new Result();
        result.setStatus(exceptionEnum.getCode());
        result.setMsg(exceptionEnum.getMsg());
        result.setData(null);
        return result;
    }
}
