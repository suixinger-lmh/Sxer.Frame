using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sxer.Frame
{
    //组件新增一个异步初始化，一个非异步初始化
    /// <summary>
    /// 框架组件通用基类
    /// </summary>
    public abstract class GA_ComponentBase : MonoBehaviour
    {
        /// <summary>
        /// 所有组件公用
        /// </summary>
        public static bool isInFrame = false;

        public bool isInitDone = false;

        /// <summary>
        /// 组件是否需要异步初始化
        /// </summary>
        public bool needAsyncInit = false;

        /// <summary>
        /// 组件初始化
        /// </summary>
        public IEnumerator GA_InitComponentBase(UnityAction<bool> callBcak) {

            GA_Init();
            yield return StartCoroutine(GA_InitAsync());
            isInitDone = true;
            if (callBcak != null)
            {
                callBcak(needAsyncInit);
            }
        }
        /// <summary>
        /// 组件初始化，非异步(初始化方法只需重写一个即可，否则默认为异步方法)
        /// </summary>
        public virtual void GA_Init() {
        }

        public virtual IEnumerator GA_InitAsync() {
            yield return null;
        }
        public abstract void GA_Start();
        public abstract void GA_End();

    
        /// <summary>
        /// 组件并入框架
        /// </summary>
        /// <param name="isIn"></param>
        public void GA_SetInFrame(bool isIn)
        {
            isInFrame = isIn;
        }
    }
    //这里继承逻辑：
    //逻辑上来讲，应该是通用类继承单例类，但是这样一来，就变成了所有组件只有一个单例；(实际需要的是
    //所有组件每个都有一个单例)
    //单例类先继承通用类，能够通用管理各个单例
    //（也可以通过接口实现通用管理）
    public abstract class GAComponentSingleton<T> : GA_ComponentBase where T : GAComponentSingleton<T>
    {
        protected static T instance = null;
        public static T GetInstance
        {
            get
            {
                if (!isInFrame)
                {
                    return instance;
                }
                else
                {
                    Sxer.Tool.DebugLogger.DebugLog_Error("请通过框架获取组件！");
                    return null;
                }
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
