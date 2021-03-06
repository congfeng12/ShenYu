﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用户信息
[CreateAssetMenu(fileName = "New User", menuName = "Inventory/New User")]
public class User : ScriptableObject
{
    //用户等级
    public int level;
    //用户道行
    public long exp;
    //用户攻击
    public int aggressivity;
    //用户生命
    public int HP;
    //用户防御
    public int defense;
    //用户暴击率
    public float crit;
    //用户闪避
    public float sidestep;
    //钻石数量
    public long DIA;
    //金币数量
    public long gold;
    //体力
    public int power;
    //纠缠星辰
    public int stars;
    //扫荡币
    public int vouchers;
    //技能点数
    public long skillPoints;
    //修炼速度
    public float time;
    //修炼进度
    public int practiceExp;
    //最后修炼时间点
    public string lasttime;
    //每日签到确认日期
    public string signTime;
    //妖魂图片
    public Sprite eqItem;
    //属性编号 1-攻击；2-生命；3-防御；4-暴击；5-闪避
    public int eq_aggressivity;
    public int eq_HP;
    public int eq_defense;
    public float eq_crit;
    public float eq_sidestep;
    //玄云决使用次数限制（100008）
    public int xy_Limit_Num = 6;
    //玄云决使用次数（100008）
    public int xy_Num;
    //青云密典使用次数限制（100009）
    public int qy_Limit_Num = 6;
    //青云密典使用次数（100009）
    public int qy_Num;
    //攻击技能等级
    public int skill1_level;
    public int skill1_data;
    //生命技能等级
    public int skill2_level;
    public int skill2_data;
    //防御技能等级
    public int skill3_level;
    public int skill3_data;
    //暴击技能等级
    public int skill4_level;
    public float skill4_data;
    //闪避技能等级
    public int skill5_level;
    public float skill5_data;
}