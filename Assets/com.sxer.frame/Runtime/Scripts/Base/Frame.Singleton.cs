using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sxer.Frame
{
    public partial class Frame
    {
       
        private static int m_Count = 0;
        private static Frame instance = null;
        public static Frame GetInstance
        {
            get
            {
                if (instance == null)
                {
                    m_Count = FindObjectsOfType(typeof(Frame)).Length;
                    if (m_Count != 1)
                    {
                        Sxer.Tool.DebugLogger.DebugLog_Error("请检查并确保场景中有且只有1个 Frame 实例!");
                        if(m_Count == 0)
                        {
                            //生成一个实例
                            m_State = FrameState.NeedInit;
                            instance = (Instantiate(Resources.Load(PrefabPath)) as GameObject).GetComponent<Frame>();
                            //instance = new GameObject("GA_Frame").AddComponent<Frame>();
                            instance.DoFrameInit();
                            Sxer.Tool.DebugLogger.DebugLog_Error("已自动生成一个实例！");
                        }
                        else
                        {
                            Sxer.Tool.DebugLogger.DebugLog_Error("存在多个实例，请检查并重新启动程序！count="+m_Count);
                            return null;
                        }
                    }
                    instance = FindObjectOfType<Frame>();
                }
                m_Count = 1;
                return instance;
            }
        }



        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
      


      

    }
}

