package com.company;

/**
 * Created by yepeng on 2019/03/16.
 */
public class EnumSingleton {
    private EnumSingleton() {
    }

    public static EnumSingleton getInstance() {
        return EnumHolder.INSTANCE.instance;
    }

    private enum EnumHolder {
        //常量，在加载的时候实例化一次
        INSTANCE;
        private EnumSingleton instance;

        EnumHolder() {
            this.instance = new EnumSingleton();
        }

//        private EnumSingleton instance() {
//            return instance;
//        }
    }

    public static void main(String[] args){
        for (int i = 0; i < 10; i++) {
            new Thread(()->{
                System.out.println(EnumSingleton.getInstance());
            }).start();
        }
    }
}
