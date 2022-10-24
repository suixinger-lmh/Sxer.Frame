using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Sxer.Frame.Func.Process.InitGoSceneProcess
{
    public class DataLoadProcess : MonoBehaviour, IBaseInitTemplate
    {
        public string afterLoadedScene;

        public void Init()
        {
            //////做进入场景前的初始化操作
            //////

            ///进入场景
            SceneManager.LoadScene(afterLoadedScene);
        }
        void OnDestroy()
        {
        }

        void OnApplicationQuit()
        {
        }
    }
}

