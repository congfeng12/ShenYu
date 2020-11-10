using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //设置固定分辨率 60HZ 720*1280分辨率
        Screen.SetResolution(1280, 720, true, 60);
        //读取存档
    }

    // Update is called once per frame
    void Update()
    {

    }
    //场景跳转函数
    public void Click_Back() { 
        StartCoroutine(Load());
    }

    IEnumerator Load() { 
        AsyncOperation op = SceneManager.LoadSceneAsync("Scenes/MainScene");
        yield return new WaitForEndOfFrame();
        op.allowSceneActivation = true;
    }
    //退出游戏
    public void QuitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    //读取存档

}
