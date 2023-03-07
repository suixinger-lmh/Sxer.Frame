using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Sxer.Frame.Func.Process.InitGoSceneProcess
{
    /// <summary>
    /// 功能：进入场景前进行数据加载
    /// </summary>
    public class DataLoadProcess : InitGoSceneProcessBase
    {

        public override void Init()
        {
            Debug.Log("进入");
            base.Init();
        }

        void OnDestroy()
        {
        }

        void OnApplicationQuit()
        {
        }
    }
}

