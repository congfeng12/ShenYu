using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //年
    private int year;
    //月
    private int month;
    //日
    private int day;
    //每日奖励页面
    public GameObject qindao;
    //用户信息
    public User player;
    //--------修炼技能刷新属性-----------
    //进度条图
    public Image cooldown;
    //倒计时累计
    public float currentTime = 0.0f;
    //倒计时总时长
    public float waitTime = 0.0f;
    //
    // Start is called before the first frame update
    void Start()
    {
        //初始化用户信息
        waitTime = player.time;
        //计算签到奖励
        CheckInDaily();
    }

    // Update is called once per frame
    void Update()
    {
        //挂机修炼
        Practice();
    }
    //计算每日签到
    public void CheckInDaily() {
        //获取当前日期
        year = System.DateTime.Now.Year;
        month = System.DateTime.Now.Month;
        day = System.DateTime.Now.Day;
        //控制台打印
        Debug.Log(""+ string.Format("{0:D4}/{1:D2}/{2:D2}", year, month, day));
    }
    //挂机修炼
    public void Practice() {
        //检测修炼条满时判断
        if (currentTime < waitTime)
        {
            //刷新进度条
            currentTime += Time.deltaTime;
            cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else {
            if (currentTime >= waitTime)
            {
                currentTime = 0.0f;
                cooldown.fillAmount = 0.0f;
                //执行增加道行的操作
            }
        }
    }
}
