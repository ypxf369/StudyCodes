using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class Singleton
    {
        //定义私有构造函数，使外界不能创建该类的实例
        private Singleton()
        {

        }

        //定义一个私有静态变量来保存类的实例
        private static Singleton _instance;

        /// <summary>
        /// 定义共有方法提供一个全局访问点，同事也可以定义共有属性提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            //如果类的实例不存在则创建，否则直接返回
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public class DoubleLockSingleton
    {
        //定义私有构造函数，使外界不能创建该类的实例
        private DoubleLockSingleton()
        {

        }

        //定义一个私有静态变量来保存类的实例
        private static DoubleLockSingleton _instance;

        //定义一个标识确保线程同步
        private static readonly object Locker = new object();

        /// <summary>
        /// 定义共有方法提供一个全局访问点，同事也可以定义共有属性提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static DoubleLockSingleton GetInstance()
        {
            //当第一个线程运行到这里时，此时会对locker对象加锁
            //当第二个线程运行该方法时，首先检测到locker对象为加锁状态，该线程就会挂起等待第一个线程解锁
            //lock语句运行完之后（即线程运行完之后）会对该对象解锁
            if (_instance == null)
            {
                lock (Locker)
                {
                    if (_instance == null)
                    {
                        //如果类的实例不存在则创建，否则直接返回
                        _instance = new DoubleLockSingleton();
                    }
                }
            }
            return _instance;
        }
    }
}
