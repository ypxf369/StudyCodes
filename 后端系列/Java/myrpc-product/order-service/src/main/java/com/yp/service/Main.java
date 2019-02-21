package com.yp.service;

import com.yp.service.bean.Product;

import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;
import java.net.Socket;

/**
 * Created by yepeng on 2019/02/21.
 */
public class Main {
    public static void main(String[] args) {
        //订单系统调用商品服务
        IProductService productService = (IProductService)rpc(IProductService.class);
        Product product = productService.queryById(100);
        System.out.println(product);

    }

    public static Object rpc(final Class clazz) {
        return Proxy.newProxyInstance(clazz.getClassLoader(), new Class[]{clazz}, new InvocationHandler() {
            public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {

                Socket socket = new Socket("127.0.0.1", 8888);

                //我们想远程调用那个类的那个方法，并传递给这个方法什么参数
                // 注意我们只知道Product Api，并不知道Product Api在Product的实现
                String apiClassName = clazz.getName();
                String methodName = method.getName();
                Class<?>[] parameterTypes = method.getParameterTypes();

                ObjectOutputStream objectOutputStream = new ObjectOutputStream(socket.getOutputStream());
                objectOutputStream.writeUTF(apiClassName);
                objectOutputStream.writeUTF(methodName);
                objectOutputStream.writeObject(parameterTypes);
                objectOutputStream.writeObject(args);
                objectOutputStream.flush();

                ObjectInputStream objectInputStream = new ObjectInputStream(socket.getInputStream());
                Object object = objectInputStream.readObject();
                objectInputStream.close();
                objectOutputStream.close();

                socket.close();
                return object;
            }
        });
    }
}
