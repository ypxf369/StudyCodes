package com.yp.core.controller;

import com.yp.annotation.MyController;
import com.yp.annotation.MyRequestMapping;
import com.yp.annotation.MyRequestParam;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Created by yepeng on 2019/02/20.
 */
@MyController
@MyRequestMapping("/test")
public class TestController {

    @MyRequestMapping("/doTest")
    public void test1(HttpServletRequest request, HttpServletResponse response, @MyRequestParam("param") String param) {
        System.out.println(param);
        try {
            response.getWriter().write("doTest method success! param:" + param);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @MyRequestMapping("doTest2")
    public void test2(HttpServletRequest request, HttpServletResponse response) {
        try {
            response.getWriter().println("doTest2 method success!");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
