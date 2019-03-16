package com.company.collections;

import java.util.HashMap;

/**
 * Created by yepeng on 2019/03/13.
 */
public class MyHashMapTest {
    public static void main(String[] args) {
        MyHashMap<String, String> map = new MyHashMap<>();

        map.put("aa11", "123aaa");
        map.put("bb", "123bbb");
        map.put("aa19", "dddaaa");
        System.out.println(map.get("aa19"));
//        for(int i=0;i<20;i++){
//            System.out.println(String.format("%s的hashcode为%s",i,("aa"+i).hashCode()%8));
//        }
    }
}
