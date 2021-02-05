using System;
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
    //签到页面显示日期
    public Text qiandaoText;
    //用户信息
    public User player;
    //修炼界面信息
    public Text expInfo;
    //修炼进度
    public Text practiceExpText;
    //用户信息页面
    public UserInfo userInfo;
    //保存游戏
    public SaveGame savegame;
    //--------修炼技能刷新属性-----------
    //进度条图
    public Image cooldown;
    //倒计时累计
    public float currentTime = 0.0f;
    //倒计时总时长
    public float waitTime = 60.0f;
    //
    // Start is called before the first frame update
    void Start()
    {
        savegame.beginGame();
        //初始化用户信息
        waitTime = player.time;
        //页面信息更新
        flashExpPage();
        flashPracticeExp();
        //计算签到奖励
        CheckInDaily();
        //更新角色中文等级
        userInfo.getLevelName();
    }

    // Update is called once per frame
    void Update()
    {
        //页面信息更新
        flashExpPage();
        flashPracticeExp();
        //挂机修炼
        Practice();
        //更新角色中文等级
        userInfo.getLevelName();
        //刷新时间更新
        waitTime = player.time;
    }

    //计算每日签到
    private void CheckInDaily()
    {
        //计算挂机时间差
        TimeSpan interval = DateTime.Now - Convert.ToDateTime(player.lasttime);
        int unOlineTime = (int)((int)interval.TotalSeconds / player.time);
        if (unOlineTime > 1)
        {
            //增加离线挂机道行
            player.exp += unOlineTime * player.practiceExp;
        }
        //更新最后修炼时间点
        player.lasttime = DateTime.Now.ToString();
        //获取当前日期
        year = DateTime.Now.Year;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;
        //签到奖励操作
        if (!(year + "-" + month + "-" + day).Equals(player.signTime))
        {
            //显示签到奖励获取页面
            qindao.SetActive(true);
            qiandaoText.text = year + "年" + month + "月" + day + "日";
            //获取奖励
            //人物属性奖励获取
            player.gold += 10000;
            player.DIA += 1000;
            player.power += 100;
            //更新角色签到奖励日期
            player.signTime = year + "-" + month + "-" + day;
        }
        else
        {
            //如果已经领取奖励则直接隐藏每日奖励窗口
            qindao.SetActive(false);
        }
        savegame.save();
    }

    //修炼
    private void Practice()
    {
        //检测修炼条满时判断
        if (currentTime < waitTime)
        {
            //刷新进度条
            currentTime += Time.deltaTime;
            cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else
        {
            if (currentTime >= waitTime)
            {
                currentTime = 0.0f;
                cooldown.fillAmount = 0.0f;
                //执行增加道行的操作
                player.exp += player.practiceExp;
                //更新最后修炼时间点
                player.lasttime = DateTime.Now.ToString();
                //保存游戏
                savegame.save();
            }
        }
    }

    //刷新主页显示修炼速度
    private void flashExpPage()
    {
        expInfo.text = player.practiceExp + "道行/" + player.time + "秒";
    }

    //刷新修炼道行
    private void flashPracticeExp()
    {
        practiceExpText.text = player.exp + "/" + Math.Pow(player.level, 2) * 2000 + "道行";
    }
}