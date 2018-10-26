package com.yepeng.spring.boot.test.controller;

import com.yepeng.spring.boot.test.entity.User;
import com.yepeng.spring.boot.test.model.ExceptionEnum;
import com.yepeng.spring.boot.test.model.ExceptionHandle;
import com.yepeng.spring.boot.test.model.Result;
import com.yepeng.spring.boot.test.util.ResultUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by yepeng on 2018/10/26.
 */
@RequestMapping("result")
@RestController
public class ResultController {
    @Autowired
    private ExceptionHandle exceptionHandle;

    @PostMapping("getResult")
    public Result getResult(@RequestParam("name") String name, @RequestParam("password") String password) {
        Result result = null;
        try {
            if (name.equals("aaa")) {
                result = ResultUtil.success(new User());
            } else if (name.equals("abc")) {
                result = ResultUtil.error(ExceptionEnum.USER_NOT_FOUND);
            } else {
                int i = 1 / 0;
            }
        } catch (Exception ex) {
            result = exceptionHandle.exceptionGet(ex);
        }
        return result;
    }
}
