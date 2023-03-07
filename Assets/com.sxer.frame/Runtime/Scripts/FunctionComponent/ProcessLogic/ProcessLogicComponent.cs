using Sxer.Frame.Func.Process.XMLProcess;
using Sxer.Frame.Func.Process.InitGoSceneProcess;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sxer.Frame.Func.Process
{
    public class ProcessLogicComponent : GAComponentSingleton<ProcessLogicComponent>
    {
        #region over

        public override void GA_Init()
        {
            base.GA_Init();

            Init();
        }

        //开始流程
        public override void GA_Start()
        {
            if(logicInstance!=null)
                logicInstance.ProcessStart();
        }

        public override void GA_End()
        {
           
        }

        #endregion


        public LogicType processLogicType = LogicType.XMLProcess;
         

        [HideInInspector]
        public LogicBase logicInstance;

        public void Init()
        {
            switch (processLogicType)
            {
                case LogicType.XMLProcess:
                    logicInstance = GetComponentInChildren<XMLProcessLogic>();
                    break;
                case LogicType.InitGoSceneProcess:
                    logicInstance = GetComponentInChildren<InitGoSceneProcessLogic>();
                    break;
                default:
                    break;
            }

            if (logicInstance != null)
                logicInstance.ProcessInit();

            //isInFrame = false;
            //FrameEntrance.Instance.Event.AddEventListener(CoreEventId.ProcessInited, (a) =>
            //{
            //    FrameEntrance.Instance.Process.StartProcess();
            //});
        }

     
    }



    public enum LogicType
    {
        //xml配置流程逻辑
        XMLProcess = 1,
        //初始化+场景 流程逻辑全部交给场景
        InitGoSceneProcess = 2,
    }


}

