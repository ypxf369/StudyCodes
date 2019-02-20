package com.yepeng.spring.boot.test;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.scheduling.annotation.EnableScheduling;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

@SpringBootApplication
@MapperScan(basePackages = "com.yepeng")
@EnableScheduling
public class SpringBootTestApplication {

    public static void main(String[] args) {

        SpringApplication.run(SpringBootTestApplication.class, args);

//        List<String> listStr=new ArrayList<>();
//        List<Object> listObj=new ArrayList<>();
//        test(listStr);
//        test(listObj);
//        //listObj=listStr
//        List<?> listWen=new ArrayList<>();
//        listWen=listStr;
//        listWen=listObj;
//        listWen.add(null);
//        if(listStr instanceof List){
//
//        }
//        if(listStr instanceof List<?>){
//
//        }
//
//        Object[] objArray=new Long[1];
//        objArray[0]="aa";

        //List<Object> list = new ArrayList<Long>();
        //list.add("aaa");

    }

    public static void test(List list){

    }
}
