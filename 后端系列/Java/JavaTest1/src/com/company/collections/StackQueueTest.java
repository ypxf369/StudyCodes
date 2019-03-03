package com.company.collections;

/**
 * Created by yepeng on 2019/02/26.
 */
public class StackQueueTest {

    class MyStack {

        MyNode top;

        public MyNode peek() {
            if (top != null) {
                return top;
            }
            return null;
        }

        public MyNode pop() {
            if (top != null) {
                MyNode temp = new MyNode(top.value);
                top = top.next;
                return temp;
            }
            return null;
        }

        public void push(MyNode value) {
            if (value != null) {
                //top.next = top;
                //top = temp;
                value.next = top;
                top = value;
            }
        }
    }

    class MyQueue {
        MyNode first, last;

        public MyNode dequeue() {
            if (first == null) {
                return null;
            } else {
                MyNode temp = new MyNode(first.value);
                first = first.next;
                return temp;
            }
        }

        public void enqueue(final MyNode value) {
            if (value != null) {
                if (first == null) {
                    first = value;
                    last = value;
                } else {
                    last.next = value;
                    last = value;
                }
            }
        }
    }

    class MyNode {
        public MyNode(Object value) {
            this.value = value;
            this.next = null;
        }

        public Object value;
        public MyNode next;
    }
}
