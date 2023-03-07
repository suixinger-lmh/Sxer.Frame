using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sxer.Frame.Func.Process.InitGoSceneProcess
{
    public class InitGoSceneProcessBase : MonoBehaviour, IBaseInitTemplate
    {

        public string afterInitLoadSceneName;
        public bool initState = false;

        #region Interface
        public virtual void Init() {
            initState = true;
        }
        #endregion
    }
}

