package com.company.juc;

/**
 * Created by yepeng on 2019/04/09.
 */
public class Test {
    private static Test d = new Test();
    private SubClass t = new SubClass();

    static {
        System.out.println(3);
    }

    public Test() {
        System.out.println(4);
    }

    public static void main(String[] args) {
        System.out.println("Hello");
    }
}

class SuperClass {
    static {
        System.out.println("ddddd");
    }
    SuperClass() {
        System.out.println("构造SuperClass");
    }
}

class SubClass extends SuperClass {
    static {
        System.out.println(1);
    }

    public SubClass() {
        System.out.println(2);
    }
}
