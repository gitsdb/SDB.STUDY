using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Others
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class SingleDemo
    {

      
    }

    /// <summary>
    /// 1、普通单例
    /// </summary>
    public class SingletonA
    {
        private static SingletonA _instance = null;
        private SingletonA() { }
        public static SingletonA CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new SingletonA();
            }
            return _instance;
        }
    }


    /// <summary>
    /// 2、线程安全单例
    /// </summary>
    public class SingletonB
    {
        private volatile static SingletonB _instance = null;
        private static readonly object lockHelper = new object();
        private SingletonB() { }
        public static SingletonB CreateInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new SingletonB();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// 3、使用.net特性的支持多线程的单件模式代码
    /// </summary>
    public sealed class SingletonC
    {
        private SingletonC() { }
        public static readonly SingletonC Instance = new SingletonC();
    }

    /// <summary>
    /// 4、使用 C# 2.0 泛型来完成单例模式的重用
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonProvider<T> where T : new()
    {
        SingletonProvider() { }

        public static T Instance
        {
            get { return SingletonCreator.instance; }
        }

        class SingletonCreator
        {
            static SingletonCreator() { }

            internal static readonly T instance = new T();
        }
    }
    /// <summary>
    /// 4、业务类demo
    /// </summary>
    public class TestClass
    {
        private string _createdTimestamp;

        public TestClass()
        {
            _createdTimestamp = DateTime.Now.ToString();
        }

        public void Write()
        {
            Console.WriteLine(_createdTimestamp);
        }
    }
    /// <summary>
    /// 4、范型单例示例
    /// </summary>
    public class demo
    {
        private void dosomething()
        {
            SingletonProvider<TestClass>.Instance.Write();
        }
    }

}
