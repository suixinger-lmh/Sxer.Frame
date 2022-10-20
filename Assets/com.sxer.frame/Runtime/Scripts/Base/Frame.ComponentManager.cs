using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sxer.Frame
{
    public partial class Frame
    {
        [SerializeField]
        private List<GA_ComponentBase> gA_ComponentBases = new List<GA_ComponentBase>();


 

        /// <summary>
        /// 获取组件，如果是需要异步初始化的组件需要注意是否初始化完成
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetGA_Component<T>() where T : GA_ComponentBase
        {
            T getComp = (T)gA_ComponentBases.Find(p => p.GetType().Equals(typeof(T)));
            if (getComp!=null)
            {
                //异步初始化组件判断是否完成初始化
                if (getComp.needAsyncInit)
                {
                    if (!getComp.isInitDone)
                    {
                        Sxer.Tool.DebugLogger.DebugLog_Error("该异步组件初始化尚未完成！：" + typeof(T).ToString());
                        return null;
                    }
                }


                return getComp;
            }
            else
            {
                Sxer.Tool.DebugLogger.DebugLog_Error("不存在的组件:" + typeof(T).ToString());
                return null;
            }
        }


        public void AddGA_Component(GA_ComponentBase _Component)
        {
            if (_Component == null)
            {
                Sxer.Tool.DebugLogger.DebugLog_("组件为空!");
                return;
            }
            if (gA_ComponentBases.Find(p => p.GetType().Equals(_Component.GetType())))
            {
                Sxer.Tool.DebugLogger.DebugLog_("组件已经存在: " + _Component.GetType().ToString());
                return;
            }
            gA_ComponentBases.Add(_Component);
        }



        /// <summary>
        /// 组件并入框架，并执行初始化
        /// </summary>
        private void GA_ComponentInit()
        {
            foreach(var comp in gA_ComponentBases)
            {
                //组件并入框架
                comp.GA_SetInFrame(true);
                //组件异步判断
                if(comp.GetType().GetMethod("GA_InitAsync").DeclaringType == typeof(GA_ComponentBase))
                {
                    comp.needAsyncInit = false;
                }
                else
                {
                    comp.needAsyncInit =  true;
                }

                //初始化
                StartCoroutine(comp.GA_InitComponentBase(CheckGAComponentInit));
            }
        }

        private void CheckGAComponentInit(bool isAsync)
        {
            if (isAsync)
            {
                if (gA_ComponentBases.FindAll(p => p.needAsyncInit == true).Find(p => p.isInitDone == false))
                    return;

                Sxer.Tool.DebugLogger.DebugLog_("异步初始化完成");
            }
            else
            {
                //非异步的组件初始化完成
                if (gA_ComponentBases.FindAll(p => p.needAsyncInit == false).Find(p => p.isInitDone == false))
                    return;

                Sxer.Tool.DebugLogger.DebugLog_("非异步初始化完成");
            }

            if (gA_ComponentBases.Find(p => p.isInitDone == false))
                return;

            Sxer.Tool.DebugLogger.DebugLog_("框架组件全部初始化完成");
            m_State = FrameState.InitDone;
        }


        private void GA_ComponentEnd()
        {
            foreach (var comp in gA_ComponentBases)
            {
                comp.GA_End();
            }
        }

    }

}
