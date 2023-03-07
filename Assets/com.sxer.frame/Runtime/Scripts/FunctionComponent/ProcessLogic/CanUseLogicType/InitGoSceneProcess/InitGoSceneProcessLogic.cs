using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sxer.Frame.Func.Process.InitGoSceneProcess
{
    public class InitGoSceneProcessLogic : LogicBase
    {
        #region override
        public override void ProcessInit()
        {
            base.ProcessInit();

            GetAllInit();//获取
        }
        public override void ProcessStart()
        {
            base.ProcessStart();

            DoInit();//执行初始化  是在框架完成之后
        }
        public override void ProcessUpdate()
        {
            base.ProcessUpdate();
        }
        public override void ProcessEnd()
        {
            base.ProcessEnd();
        }
        #endregion


        public InitGoSceneProcessBase nowUseBase;
        public InitGoSceneProcessBase[] baseInitTemplates;

        int processIndex = 0;
        private void GetAllInit()
        {
            baseInitTemplates = GetComponentsInChildren<InitGoSceneProcessBase>();
            if (baseInitTemplates != null && baseInitTemplates.Length > 0)
            {
                nowUseBase = baseInitTemplates[processIndex];
            }
            else
            {
                Sxer.Tool.DebugLogger.DebugLog_Error("不存在启动逻辑！");
            }
        }

       
        public void DoInit()
        {
            if (nowUseBase != null)
                nowUseBase.Init();
        }


        //逻辑的Update操作
        private void Update()
        {
            //当前流程完成后判断
            if (nowUseBase != null && nowUseBase.initState)
            {
                //流程衔接场景为空
                if(string.IsNullOrEmpty(nowUseBase.afterInitLoadSceneName))
                {
                    processIndex++;//
                    if (processIndex < baseInitTemplates.Length)
                    {
                        //进入下一流程
                        nowUseBase = baseInitTemplates[processIndex];
                        nowUseBase.Init();
                    }
                    else
                    {
                        //提示初始化结束，但未进入场景
                        Sxer.Tool.DebugLogger.DebugLog_Error("未检测到跳转场景！");
                    }
                }
                else//流程后存在启动场景
                {
                    SceneManager.LoadSceneAsync(nowUseBase.afterInitLoadSceneName);
                    //SceneManager.sceneLoaded += (sc, lsm) =>
                    //{
                    //    if (sc.name == afterLoadedScene)
                    //    {
                    //        Sxer_Get.FindGameObject("GA_Frame/UI/BGCanvas/Image").GetComponent<Image>().DOFade(0, 2f);
                    //    }
                    //};
                    //Resources.UnloadUnusedAssets();
                    //System.GC.Collect();
                }
            }
        }




    }

}
