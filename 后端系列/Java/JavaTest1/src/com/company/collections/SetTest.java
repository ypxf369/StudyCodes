package com.company.collections;

import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;
import java.util.SortedSet;

/**
 * Created by yepeng on 2019/02/25.
 */
public class SetTest {
    public static void main(String[] args){
        Set<Integer> sets=new HashSet<>();//Set不保证存储于插入顺序的关系。
        sets.add(99);
        sets.add(3);
        sets.add(1);
        sets.add(2);
        sets.add(4);
        sets.add(2);
        sets.add(4);
        Iterator<Integer> iterator = sets.iterator();
        while (iterator.hasNext()){
            System.out.println(iterator.next());
        }
        System.out.println("");
    }
}
