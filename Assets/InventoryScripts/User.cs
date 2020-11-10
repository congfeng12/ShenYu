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
    public int exp;
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
    public int DIA;
    //金币数量
    public int gold;
    //技能点数
    public int skillPoints;
    //修炼速度
    public float time;
    //修炼进度
    public int practiceExp;
    //每日签到确认日期
    public string signTime;
    //妖魂
    public Item equip;
}
