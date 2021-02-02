using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{
    //角色血量
    public Text hp;
    //攻击
    public Text aggressivity;
    //防御
    public Text defense;
    //暴击
    public Text crit;
    //闪避
    public Text sidestep;
    //道行
    public Text exp;
    //升级需要道行
    public Text upexp;
    //修炼速度
    public Text time;
    //修炼进度
    public Text practiceExp;
    //体力
    public Text power;
    //扫荡币
    public Text vouchers;
    //主页角色等级
    public Text mainUserLevel;
    //角色页面等级
    public Text userPageUserLevel;
    //角色信息
    public User player;
    //页面展示妖魂模块
    public Image eqsprite;
    // Start is called before the first frame update
    void Start()
    {
        //页面角色属性刷新
        flashPage();
    }

    // Update is called once per frame
    void Update()
    {
        //页面角色属性刷新
        initUser();
    }

    //初始化用户信息
    private void initUser()
    {
        //人物信息更新
        flashPage();
    }

    //页面信息更新
    private void flashPage()
    {
        //血量刷新
        hp.text = player.HP + player.skill2_data + player.eq_HP + "";
        //攻击刷新
        aggressivity.text = player.aggressivity + player.skill1_data + player.eq_aggressivity + "";
        //防御刷新
        defense.text = player.defense + player.skill3_data + player.eq_defense + "";
        //暴击刷新
        crit.text = player.crit + player.skill4_data + player.eq_crit + "%";
        //闪避刷新
        sidestep.text = player.sidestep + player.skill5_data + player.eq_sidestep + "%";
        //道行刷新
        exp.text = player.exp + "";
        //升级需要道行
        upexp.text = Math.Pow(player.level, 2) * 2000 + "";
        //刷新修炼速度
        time.text = player.time + "秒获取一次道行";
        //刷新修炼进度
        practiceExp.text = player.practiceExp + "道行/每次";
        //刷新体力
        power.text = player.power + "";
        //刷新扫荡币
        vouchers.text = player.vouchers + "";
        //刷新妖魂图片
        if (null != player.eqItem)
        {
            eqsprite.sprite = player.eqItem;
        }

    }

    //人数属性提升
    private void UpPlayerInfo()
    {
        //提升血量
        player.HP += 400 * player.level;
        //提升攻击
        player.aggressivity += 40 + player.level;
        //防御提升
        player.defense += 5;
        //暴击
        player.crit += 0.1f;
        //闪避
        player.sidestep += 0.05f;
        //等级提升
        player.level += 1;
    }

    //根据余数获取品级
    private string yuShu(int num)
    {
        string levelname = "";

        switch (num % 10)
        {
            case 1:
                levelname = "一品";
                break;
            case 2:
                levelname += "二品";
                break;
            case 3:
                levelname += "三品";
                break;
            case 4:
                levelname += "四品";
                break;
            case 5:
                levelname += "五品";
                break;
            case 6:
                levelname += "六品";
                break;
            case 7:
                levelname += "七品";
                break;
            case 8:
                levelname += "八品";
                break;
            case 9:
                levelname += "九品";
                break;
            case 0:
                levelname += "十品";
                break;
        }
        return levelname;
    }

    //获取等级对应的中文数字
    public void getLevelName()
    {
        string levelname = "";
        //1 - 10
        if (player.level < 11)
        {
            levelname = "练气期" + yuShu(player.level);
        }
        //11 - 20
        if (10 < player.level && player.level < 21)
        {
            levelname = "筑基期" + yuShu(player.level);
        }
        //21 - 30
        if (20 < player.level && player.level < 31)
        {
            levelname = "金丹期" + yuShu(player.level);
        }
        //31 - 40
        if (30 < player.level && player.level < 41)
        {
            levelname = "元婴期" + yuShu(player.level);
        }
        //41 - 50
        if (40 < player.level && player.level < 51)
        {
            levelname = "化神期" + yuShu(player.level);
        }
        //51 - 60
        if (50 < player.level && player.level < 61)
        {
            levelname = "合道期" + yuShu(player.level);
        }
        //61 - 70
        if (60 < player.level && player.level < 71)
        {
            levelname = "地仙期" + yuShu(player.level);
        }
        //71 - 80
        if (70 < player.level && player.level < 81)
        {
            levelname = "天仙期" + yuShu(player.level);
        }
        //81 - 90
        if (80 < player.level && player.level < 91)
        {
            levelname = "金仙期" + yuShu(player.level);
        }
        //91 - 100
        if (90 < player.level && player.level < 101)
        {
            levelname = "准圣期" + yuShu(player.level);
        }
        // > 101
        if (100 < player.level && player.level < 999)
        {
            levelname = "圣玄";
            //初期
            if (100 < player.level && player.level < 325)
            {
                levelname += "初期";
            }
            //中期
            if (324 < player.level && player.level < 548)
            {
                levelname += "中期";
            }
            //后期
            if (547 < player.level && player.level < 774)
            {
                levelname += "后期";
            }
            //巅峰
            if (773 < player.level && player.level < 999)
            {
                levelname += "巅峰期";
            }
        }
        if (player.level >= 999)
        {
            levelname = "无限大道期";
        }
        //赋值
        mainUserLevel.text = levelname;
        userPageUserLevel.text = levelname;
    }

    //升级
    public void LevelUp()
    {
        if (player.exp > Math.Pow(player.level, 2) * 2000 && player.level < 1000)
        {
            player.exp -= (long)Math.Pow(player.level, 2) * 2000;
            UpPlayerInfo();
        }
    }
}