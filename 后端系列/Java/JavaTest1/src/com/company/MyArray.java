package com.company;


/**
 * 数组工具类
 */
public class MyArray {
    private MyArray() {
    }

    /**
     * @Description: 获取数组中最大的元素
     * @Param: arr
     * @return: int
     * @Author: yepeng
     * @Date:
     */
    public static int getMax(int[] arr) {
        int max = 0;
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] > max) {
                max = arr[i];
            }
        }
        return max;
    }
    /**
    * @Description: 获取给定值在数组中的索引
    * @Param:  arr，a
    * @return:  给定值得索引
    * @Author: yepeng
    * @Date:
    */
    public static int getIndex(int[] arr, int a) {
        int index = -1;
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] == a) {
                index = i;
            }
        }
        return index;
    }
}
