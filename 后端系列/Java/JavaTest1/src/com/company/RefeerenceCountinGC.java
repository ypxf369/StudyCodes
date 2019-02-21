
package com.company;

/**
 * Created by yepeng on 2019/02/05.
 */
public class RefeerenceCountinGC {
    public static void main(String[] args){
        testGC();
    }
    public Object instance =null;

    private static final int _1MB=1024*2014;

    /**
     * 这个成员属性的唯一意义就是占点内存，以便能在GC日志中看秦楚是否被回收过
     */
    private byte[] bigSize=new byte[2*_1MB];

    public static void testGC(){
        RefeerenceCountinGC objA=new RefeerenceCountinGC();
        RefeerenceCountinGC objB=new RefeerenceCountinGC();
        objA.instance=objB;
        objB.instance=objA;

        objA=null;
        objB=null;

        //假设在这行发生GC，objA和objB是否能被回收？
        System.gc();
    }
}
