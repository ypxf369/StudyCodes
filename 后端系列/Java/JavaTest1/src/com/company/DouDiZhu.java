package com.company;

import javax.sql.rowset.FilteredRowSet;
import java.net.ServerSocket;
import java.util.ArrayList;
import java.util.Collections;

public class DouDiZhu {
    public static void main(String[] args) {
        faPai();
    }

    public static void faPai() {
        //定义花色
        String[] huaSe = {"黑桃", "红桃", "方块", "梅花"};
        //定义排的数字
        String[] num = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        //定义牌的容器
        ArrayList<String> container = new ArrayList<String>();
        //将排放到牌盒中
        for (int i = 0; i < huaSe.length; i++) {
            for (int j = 0; j < num.length; j++) {
                container.add(huaSe[i] + num[j]);
            }
        }
        //int len=container.size();
        //System.out.println(len);
        //System.out.println(container);
        container.add("大王");
        container.add("小王");

        //洗牌
        Collections.shuffle(container);

        //定义玩家
        ArrayList<String> 林志玲 = new ArrayList<String>();
        ArrayList<String> 苍老师 = new ArrayList<>();
        ArrayList<String> 舒淇 = new ArrayList<>();
        //发牌
        for (int i = 0; i < container.size()-3; i++) {
            if (i % 3 == 0) {
                林志玲.add(container.get(i));
            } else if (i % 3 == 1) {
                苍老师.add(container.get(i));
            } else if (i % 3 == 2) {
                舒淇.add(container.get(i));
            }
        }
        System.out.println("林志玲：" + 林志玲);
        System.out.println("苍老师：" + 苍老师);
        System.out.println("舒淇：" + 舒淇);
        //底牌
//        System.out.println("底牌："+container.get(container.size()-1));
//        System.out.println("底牌："+container.get(container.size()-2));
//        System.out.println("底牌："+container.get(container.size()-3));
        for (int i=container.size()-3;i<container.size();i++){
            System.out.println("底牌："+container.get(i));
        }
    }
}
