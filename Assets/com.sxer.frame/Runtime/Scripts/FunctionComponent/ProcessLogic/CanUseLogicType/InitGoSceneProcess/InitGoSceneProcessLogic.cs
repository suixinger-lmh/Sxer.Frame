using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public override void ProcessEnd()
        {
            base.ProcessEnd();
        }
        #endregion


        public IBaseInitTemplate nowUseBase;
        public IBaseInitTemplate[] baseInitTemplates;


        private void GetAllInit()
        {
            baseInitTemplates = GetComponentsInChildren<IBaseInitTemplate>();
            if (baseInitTemplates != null && baseInitTemplates.Length > 0)
            {
                nowUseBase = baseInitTemplates[0];
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


    }

}
