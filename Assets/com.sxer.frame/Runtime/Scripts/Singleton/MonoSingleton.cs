using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sxer.Frame
{
    /// <summary>
    /// 基于Mono的单例实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T instance = null;
        public static T GetInstance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 单例初始化(生成单例)
        /// </summary>
        public virtual void Awake()
        {

            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {   
                Destroy(this.gameObject);
                return;
            }
        }
    }
}

