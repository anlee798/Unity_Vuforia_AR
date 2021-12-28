using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    private Camera arCamera;

    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScreenClick()
    {
        //截图命名
        System.DateTime now = System.DateTime.Now;
        string times = now.ToString();
        times = times.Trim();
        times = times.Replace("/","-");

        string fileName = "ARScreenShot" + times + ".png";

        if(Application.platform == RuntimePlatform.Android)
        {
            /*
            //带UI截屏
            //this.GetComponentInChildren<Image>().enabled = false;
            //this.GetComponentInChildren<Text>().enabled = false;

            //第四个参数 是否使用映射
            Texture2D texture = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,false);
            texture.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);
            texture.Apply();

            byte[] bytes = texture.EncodeToPNG();

            string destinaton = "/sdcard/DCIM/Screenshots";

            if (!Directory.Exists(destinaton))
            {
                Directory.CreateDirectory(destinaton);
            }

            string pathSave = destinaton + "/" + fileName;
            File.WriteAllBytes(pathSave, bytes);

            //this.GetComponentInChildren<Image>().enabled = true;
            //this.GetComponentInChildren<Text>().enabled = true;
            */


            //不包含UI截屏
            RenderTexture rt = new RenderTexture(Screen.width,Screen.height,1);
            arCamera.targetTexture = rt;
            arCamera.Render();

            RenderTexture.active = rt;

            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();

            arCamera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);

            byte[] bytes = texture.EncodeToPNG();

            string destinaton = "/sdcard/DCIM/Screenshots";

            if (!Directory.Exists(destinaton))
            {
                Directory.CreateDirectory(destinaton);
            }

            string pathSave = destinaton + "/" + fileName;
            File.WriteAllBytes(pathSave, bytes);
        }
    }
}
