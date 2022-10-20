using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sxer.Frame.Func.Process
{
    //框架控制 逻辑流程
    public class LogicBase : MonoBehaviour
    {
        public virtual void ProcessInit() { }//初始化
        public virtual void ProcessStart() { }//开始
        public virtual void ProcessPause() { }//暂停
        public virtual void ProcessUnPause() { }//取消暂停
        public virtual void ProcessEnd() { }//结束
      //  public virtual void ProcessChange(XMLProcessBase) { }
    }
}

