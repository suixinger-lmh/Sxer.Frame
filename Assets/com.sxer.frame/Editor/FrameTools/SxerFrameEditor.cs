using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace Sxer.Frame.Editor
{
    public class SxerFrameEditor : UnityEditor.Editor
    {

        [MenuItem("Sxer/Frame/Create/生成(选中)启动场景", priority = 0)]
        public static void CreateFrameStartScene()
        {
            string scenePath = string.Format("{0}/Scene/{1}", SxerFrameConfig.SxerFrameRoot, SxerFrameConfig.SceneName);
            Object obj = AssetDatabase.LoadMainAssetAtPath(scenePath);
            if (obj == null)
            {
                //生成文件夹
                CreateFolder(scenePath.Remove(scenePath.LastIndexOf('/')), false);
                //创建并保存场景
                Scene startScene = EditorSceneManager.NewScene(0);
                EditorSceneManager.SaveScene(startScene, scenePath);
                //打开场景
                startScene = EditorSceneManager.OpenScene(scenePath);
                //场景生成预制体(无关联)
                //GameObject framePrefab = Instantiate( Resources.Load(SxerFrameConfig.Res_framePrefab) as GameObject);
                //场景生成预制体(带关联)
                PrefabUtility.InstantiatePrefab(Resources.Load(SxerFrameConfig.Res_framePrefab), startScene);
                EditorSceneManager.MarkSceneDirty(startScene);//标记改动
                Ping(scenePath);
            }
            else
            {
                Debug.Log("启动场景已存在！");
                Ping(obj);
            }
        }

        [MenuItem("Sxer/Frame/Create/生成项目文件夹", priority = 1)]
        public static void CreateProjectFiles()
        {
            CreateFolder("Assets/StreamingAssets");
            CreateFolder("Assets/MainProjectAssetsFile/Animations");
            CreateFolder("Assets/MainProjectAssetsFile/Scripts");
            CreateFolder("Assets/MainProjectAssetsFile/Models");
            CreateFolder("Assets/MainProjectAssetsFile/Prefabs");
            CreateFolder("Assets/MainProjectAssetsFile/UI");
            CreateFolder("Assets/MainProjectAssetsFile/Scenes");
            CreateFolder("Assets/MainProjectAssetsFile/Materials");
            CreateFolder("Assets/MainProjectAssetsFile/Textures");
            CreateFolder("Assets/MainProjectAssetsFile/CreateAssets");
            CreateFolder("Assets/MainProjectAssetsFile/Font");
            CreateFolder("Assets/MainProjectAssetsFile/Animators");
            CreateFolder("Assets/MainProjectAssetsFile/Temp");
            CreateFolder("Assets/MainProjectAssetsFile/Resources");
        }


        [MenuItem("Sxer/Frame/Create/为当前场景生成布局", priority = 2)]
        public static void CreateSceneFrame()
        {
            Scene nowScene = SceneManager.GetActiveScene();
            string tag = "--------";
            new GameObject(string.Format("{0}{1}{2}",tag,"Camera",tag));
            new GameObject(string.Format("{0}{1}{2}", tag, "UI", tag));
            new GameObject(string.Format("{0}{1}{2}", tag, "Environment", tag));
            new GameObject(string.Format("{0}{1}{2}", tag, "Particle", tag));
            new GameObject(string.Format("{0}{1}{2}", tag, "Process", tag));
            EditorSceneManager.MarkSceneDirty(nowScene);
        }


        //创建多级文件夹
        //判断文件夹是否存在
        
        static void CreateFolder(string folderPath,bool needLog = true)
        {
            if (AssetDatabase.IsValidFolder(folderPath))
            {
                if(needLog)
                    Debug.LogError("Folder Already Exist!");
                Ping(folderPath);
            }
            else
            {
                string subname = folderPath.Substring(folderPath.LastIndexOf("/")+1);
                string folderParent = folderPath.Remove(folderPath.LastIndexOf("/"));
                CreateFolder(folderParent,false);
                AssetDatabase.CreateFolder(folderParent, subname);
                Ping(folderPath);
            }
        }

        [MenuItem("Sxer/Frame/test", priority = 10)]
        public static void Test()
        {
            string folderPath = "Assets/StreamingAssets/StreamingAssets";
            //CreateFolder(folderPath);
            //string folderParent = folderPath.Remove(folderPath.LastIndexOf("/"));
            //Debug.Log(folderParent);
            //Ping("Assets");
            //string folderPath = "Assets/StreamingAssets";
            //Debug.LogError(AssetDatabase.LoadMainAssetAtPath(folderPath));
            //Selection.activeObject = obj;
            //EditorGUIUtility.PingObject(obj);
        }


        static void Ping(string path)
        {
            Object obj = AssetDatabase.LoadMainAssetAtPath(path);
            if (obj)
            {
                Selection.activeObject = obj;
                EditorGUIUtility.PingObject(obj);
            }
            else
                Debug.LogError(path + "找不到！");
        }
        static void Ping(Object obj)
        {
            if (obj)
            {
                Selection.activeObject = obj;
                EditorGUIUtility.PingObject(obj);
            }
            else
                Debug.LogError("空对象！");
        }

    }

}
