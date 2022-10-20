using Sxer.Frame.Func;
using Sxer.Frame.Func.Process;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sxer.Frame
{
    public partial class Frame : MonoBehaviour
    {
        private void Start()
        {
            m_State = FrameState.Alive;
            DoFrameInit();
        }

        //组件初始化完成后执行
        public void InitFinishedDo()
        {
            ///////////////////////////////////////////////////////设备参数

            ///////////////////////////////////////////////////////配置文件

            ///////////////////////////////////////////////////////Unity设置

            //限制帧率
            //Application.targetFrameRate = 60;
            //Application.runInBackground = true;
            //Screen.SetResolution(4800, 1080, true);

            ///////////////////////////////////////////////////////框架逻辑




            //框架开始跑逻辑
            Frame.GetInstance.GetGA_Component<ProcessLogicComponent>().GA_Start();

            ////////////////////////////////////////////////////////////////////////
        }


        

        private void Update()
        {
           

        }

        bool isshowwindow = false;
        private void OnGUI()
        {
           
   
        }

        private void OnApplicationQuit()
        {
           
        }

        private void OnDestroy()
        {
            GA_ComponentEnd();
        }
    }
}

