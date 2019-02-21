package com.company;

import javax.lang.model.element.VariableElement;
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        //method();
        //method2();
        MyThread2 thread2 = new MyThread2();
        new Thread(thread2).start();
    }

    private static void method2() {
        MyThread myThread = new MyThread();
        myThread.setName("张三");
        myThread.start();
        MyThread myThread1 = new MyThread();
        myThread1.setName("李四");
        myThread1.start();
    }

    private static void method() {
        int[] arr = {1, 2, 3, 46, 123, 5, 76, 8};
        int max = MyArray.getMax(arr);
        System.out.println("数组中最大的元素为：" + max);
        int index = MyArray.getIndex(arr, 123);
        System.out.println("给定值在数组中的索引为：" + index);
    }

}

