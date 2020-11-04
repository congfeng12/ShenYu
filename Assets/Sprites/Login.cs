using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
}
