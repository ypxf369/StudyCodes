package com.company.proxy.dynamicProxy;

import com.company.proxy.staticProxy.ByteClassLoader;

import javax.tools.*;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.OutputStream;
import java.lang.reflect.Constructor;
import java.lang.reflect.Method;
import java.lang.reflect.Parameter;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;
import java.net.URLClassLoader;
import java.util.Arrays;

/**
 * Created by yepeng on 2019/03/19.
 */
public class DynamicProxy {
    public static Object newInstance(Object target) {
        /**
         * public class UserDaoPowerProxy implements UserDao {
         *     private UserDaoImpl userDao;
         *
         *     public UserDaoPowerProxy(UserDaoImpl userDao) {
         *         this.userDao = userDao;
         *     }
         *
         *     @Override
         *     public void getUser() {
         *         System.out.println("检查该用户的查询权限");
         *         userDao.getUser();
         *         System.out.println("用户查询完成");
         *     }
         * }
         */
        Object instance = null;
        Class<?> clazz = target.getClass();
        String packageName = "com.yp";//clazz.getPackageName();
        String className = "$Proxy";
        Class<?> targetInterface = clazz.getInterfaces()[0];
        StringBuilder sb = new StringBuilder();
        // 导入包
        sb.append("package ").append(packageName).append(";");
        // 创建类的格式
        sb.append("public class ").append(className).append(" implements ").append(targetInterface.getName()).append("{");
        // 声明目标类字段
        sb.append("private ").append(clazz.getName()).append(" target;");
        // 定义构造函数
        sb.append("public ").append(className).append("(").append(clazz.getName()).append(" target){this.target=target;}");
        // 执行目标方法
        // 实现接口方法
        Method[] methods = targetInterface.getMethods();
        for (Method method : methods) {
            // 判断方法是否有参数
            Parameter[] parameters = method.getParameters();
            String[] paramStr = new String[parameters.length];
            String[] paramValue = new String[parameters.length];
            for (int i = 0; i < paramStr.length; i++) {
                Parameter p = parameters[i];
                paramStr[i] = p.getType().getName() + " " + p.getName();
                paramValue[i] = p.getName();
            }

            sb.append("@Override public ").append(method.getReturnType().getName()).append(" ").append(method.getName()).append("(").append(String.join(",", paramStr)).append("){");
            if (!method.getReturnType().getSimpleName().equals("void")) {
                sb.append("return ");
            }
            sb.append("target.").append(method.getName()).append("(").append(String.join(",", paramValue)).append(");}");

        }
        sb.append("}");
        try {
            File file = new File("E:/com/yp/$Proxy.java");
            FileWriter fileWriter = new FileWriter(file);
            fileWriter.write(sb.toString());
            fileWriter.flush();
            fileWriter.close();


            // 将.java文件编译为class文件
            JavaCompiler compiler = ToolProvider.getSystemJavaCompiler();
            StandardJavaFileManager fileManager = compiler.getStandardFileManager(null, null, null);
            Iterable<? extends JavaFileObject> units = fileManager.getJavaFileObjects(file);
            //Iterable<? extends JavaFileObject> units = fileManager.getJavaFileObjectsFromStrings(Arrays.asList(sb.toString()));

            JavaCompiler.CompilationTask task = compiler.getTask(null, fileManager, null, null, null, units);
            task.call();
            fileManager.close();
            //读取class文件创建对象
            URLClassLoader classLoader = new URLClassLoader(new URL[]{new URL("file:E:/")});
            //ByteClassLoader classLoader = new ByteClassLoader();
            Class<?> cl = classLoader.loadClass("com.yp.$Proxy");
            Constructor<?> constructor = cl.getDeclaredConstructor(clazz);
            instance = constructor.newInstance(target);
        } catch (Exception e) {
            e.printStackTrace();
        }


        return instance;
    }

}
