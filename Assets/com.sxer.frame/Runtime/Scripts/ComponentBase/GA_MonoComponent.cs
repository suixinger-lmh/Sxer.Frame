using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sxer.Frame
{
    /// <summary>
    /// 基于Mono和单例的框架组件
    /// </summary>
    public abstract class GA_MonoComponent<T>: MonoSingleton<GA_MonoComponent<T>> where T : GA_MonoComponent<T>
    {

        protected new static T instance = null;
        /// <summary>
        /// 替换单例方法，加入判断是否在框架逻辑
        /// </summary>
        public new static T GetInstance
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

        private static bool isInFrame = false;
        public bool IsInFrame
        {
            get => isInFrame; set => isInFrame = value;
        }


        public abstract void GA_Init();
        public abstract void GA_Start();
        public abstract void GA_End();
    }

 
}

