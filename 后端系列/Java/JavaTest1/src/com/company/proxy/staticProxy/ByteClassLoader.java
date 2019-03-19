package com.company.proxy.staticProxy;

import java.security.AccessController;
import java.security.PrivilegedExceptionAction;

/**
 * Created by yepeng on 2019/03/19.
 */
public class ByteClassLoader extends ClassLoader {
    private byte[] bytes;

    public ByteClassLoader(byte[] bytes) {
        this.bytes = bytes;
    }

    @Override
    protected Class<?> findClass(String name) throws ClassNotFoundException {
        final Class<?> result;
        try {
            result = AccessController.doPrivileged(
                    new PrivilegedExceptionAction<>() {
                        public Class<?> run() {
                            return defineClass(name, bytes, 0, bytes.length);
                        }
                    });
        } catch (java.security.PrivilegedActionException pae) {
            throw (ClassNotFoundException) pae.getException();
        }
        if (result == null) {
            throw new ClassNotFoundException(name);
        }
        return result;
    }
}
