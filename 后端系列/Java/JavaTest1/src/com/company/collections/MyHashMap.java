package com.company.collections;


/**
 * Created by yepeng on 2019/03/13.
 */
public class MyHashMap<K, V> {
    private int size = 0;
    private static final int CAPCITY = 8;
    private Node[] table;

    public MyHashMap() {
        this.table = new Node[CAPCITY];
    }

    public int size() {
        return size;
    }

    public V get(K key) {
        int hash = key.hashCode();
        int index = hash % CAPCITY;
        Node<K, V> node = table[index];
        for (K k = node.k; node!=null; node = node.next) {
            if (k == key) {
                return node.v;
            }
        }

        return null;
    }

    public V put(K key, V value) {
        int hash = key.hashCode();
        int index = hash % CAPCITY;

        Node<K, V> node = table[index];
        addEntry(key, value, index);
        if (node != null) {
            return node.v;
        }

        return null;
    }

    private void addEntry(K key, V value, int index) {
        Node<K, V> node = new Node<>(key, value, table[index]);
        table[index] = node;
        size++;
    }

    static class Node<K, V> {
        private K k;
        private V v;
        private Node<K, V> next;

        public Node(K k, V v, Node next) {
            this.k = k;
            this.v = v;
            this.next = next;
        }

        public K getK() {
            return k;
        }

        public void setK(K k) {
            this.k = k;
        }

        public V getV() {
            return v;
        }

        public void setV(V v) {
            this.v = v;
        }

        public Node getNext() {
            return next;
        }

        public void setNext(Node next) {
            this.next = next;
        }
    }
}
