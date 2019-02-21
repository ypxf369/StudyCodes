package com.company;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by yepeng on 2019/02/05.
 *
 * JVM参数：-Xms20m -Xmx20m -XX:+HeapDumpOnOutOfMemoryError
 */
public class JVMTest {
    static class OOMObject{

    }
    public static void main(String[] args){
        List<OOMObject> list = new ArrayList<>();

        while (true){
            list.add(new OOMObject());
        }
    }
}
