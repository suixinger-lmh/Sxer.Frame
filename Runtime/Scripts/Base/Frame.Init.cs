using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sxer.Frame
{
    public partial class Frame
    {
        public enum FrameState
        {
            InitError = -2,
            NULL = -1,
            /// <summary>
            /// 框架激活
            /// </summary>
            Alive = 0,
            /// <summary>
            /// 刚自动创建的框架(需要初始化等操作）
            /// </summary>
            NeedInit = 1,
            /// <summary>
            /// 正在初始化
            /// </summary>
            Initializing = 2,
            InitDone = 3
        }

        /// <summary>
        /// 框架预制件,用于自动加载,注意将需要的组件放入预制件下，否则将无法调用
        /// </summary>
        public static string PrefabPath = "Sxer_FramePrefab/Sxer_Frame";
        public static FrameState m_State = FrameState.NULL;

        private void DoFrameInit()
        {
            switch (m_State)
            {
                case FrameState.Alive://框架作为初始启动，从自身找组件
                    //获取并添加组件
                    foreach (var comp in GetComponentsInChildren<GA_ComponentBase>())
                    {
                        AddGA_Component(comp);
                    }

                    break;
                case FrameState.NeedInit://框架作为半路启动，从环境找组件
                    foreach (var comp in FindObjectsOfType<GA_ComponentBase>())
                    {
                        AddGA_Component(comp);
                    }
                    break;
              
                default:
                    m_State = FrameState.InitError;
                    Sxer.Tool.DebugLogger.DebugLog_Error("框架初始化失败！");
                    return;
            }


            m_State = FrameState.Initializing;
            //框架组件初始化
            GA_ComponentInit();

            
            StartCoroutine(WaitingInit());
        }
        private IEnumerator WaitingInit()
        {
            DateTime nowTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            while (m_State != FrameState.InitDone)
            {
                yield return null;
                endTime = DateTime.Now;
            }
            Sxer.Tool.DebugLogger.DebugLog_("框架组件初始化时间:"+nowTime.ToLongTimeString() + "///" + endTime.ToLongTimeString());

            InitFinishedDo();
        }



       


    }
}

