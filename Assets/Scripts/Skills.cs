using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{

    //攻击技能等级
    public Text skll1_level_text;
    //攻击技能提升数据
    public Text skll1_data_text;
    //攻击技能升级需要技能点数
    public Text skll1_point_text;

    //生命技能等级
    public Text skll2_level_text;
    //生命技能提升数据
    public Text skll2_data_text;
    //生命技能升级需要技能点数
    public Text skll2_point_text;

    //防御技能等级
    public Text skll3_level_text;
    //防御技能提升数据
    public Text skll3_data_text;
    //防御技能升级需要技能点数
    public Text skll3_point_text;

    //暴击技能等级
    public Text skll4_level_text;
    //暴击技能提升数据
    public Text skll4_data_text;
    //暴击技能升级需要技能点数
    public Text skll4_point_text;

    //闪避技能等级
    public Text skll5_level_text;
    //闪避技能提升数据
    public Text skll5_data_text;
    //闪避技能升级需要技能点数
    public Text skll5_point_text;

    //角色剩余技能点数
    public Text skll_point_text;

    //角色信息
    public User player;

    //刷新页面信息
    public void Update()
    {
        flashSkillPoints();
    }

    private void flashSkillPoints()
    {

        //攻击技能等级
        skll1_level_text.text = "等级：" + player.skill1_level;
        //攻击技能提升数据
        skll1_data_text.text = "+" + player.skill1_data;
        //攻击技能升级需要技能点数
        skll1_point_text.text = Math.Pow((player.skill1_level + 1), 2) * 500 + "";

        //生命技能等级
        skll2_level_text.text = "等级：" + player.skill2_level;
        //生命技能提升数据
        skll2_data_text.text = "+" + player.skill2_data;
        //生命技能升级需要技能点数
        skll2_point_text.text = Math.Pow((player.skill2_level + 1), 2) * 500 + "";

        //防御技能等级
        skll3_level_text.text = "等级：" + player.skill3_level;
        //防御技能提升数据
        skll3_data_text.text = "+" + player.skill3_data;
        //防御技能升级需要技能点数
        skll3_point_text.text = Math.Pow((player.skill3_level + 1), 2) * 500 + "";

        //暴击技能等级
        skll4_level_text.text = "等级：" + player.skill4_level;
        //暴击技能提升数据
        skll4_data_text.text = "+" + player.skill4_data + "%";
        //暴击技能升级需要技能点数
        skll4_point_text.text = Math.Pow((player.skill4_level + 1), 2) * 500 + "";

        //闪避技能等级
        skll5_level_text.text = "等级：" + player.skill5_level;
        //闪避技能提升数据
        skll5_data_text.text = "+" + player.skill5_data + "%";
        //闪避技能升级需要技能点数
        skll5_point_text.text = Math.Pow((player.skill5_level + 1), 2) * 500 + "";

        //角色剩余技能点数
        skll_point_text.text = player.skillPoints + "";
    }

    //升级攻击等级
    public void UpAggressivity()
    {
        //判断技能点数是否足够
        if (player.skillPoints > ((long)Math.Pow((player.skill1_level + 1), 2) * 500) && player.skill1_level < 1000 )
        {
            //减少技能点数
            player.skillPoints -= (long)Math.Pow(player.skill1_level + 1, 2) * 500;
            //提升技能等级
            player.skill1_level += 1;
            //增加属性
            player.skill1_data = player.skill1_level * 20;
        }
    }

    //升级生命等级
    public void UpHP()
    {
        //判断技能点数是否足够
        if (player.skillPoints > ((long)Math.Pow((player.skill2_level + 1), 2) * 500) && player.skill2_level < 1000)
        {
            player.skillPoints -= (long)Math.Pow(player.skill2_level + 1, 2) * 500;
            //提升技能等级
            player.skill2_level += 1;
            //增加属性
            player.skill2_data = player.skill2_level * 100;
        }
    }

    //升级防御等级
    public void UpDefense()
    {
        //判断技能点数是否足够
        if (player.skillPoints > ((long)Math.Pow((player.skill3_level + 1), 2) * 500) && player.skill3_level < 1000)
        {
            player.skillPoints -= (long)Math.Pow(player.skill3_level + 1, 2) * 500;
            //提升技能等级
            player.skill3_level += 1;
            //增加属性
            player.skill3_data = player.skill3_level * 2;
        }
    }

    //升级暴击等级
    public void UpCrit()
    {
        //判断技能点数是否足够
        if (player.skillPoints > ((long)Math.Pow((player.skill4_level + 1), 2) * 500) && player.skill4_level < 100)
        {
            player.skillPoints -= (long)Math.Pow(player.skill4_level + 1, 2) * 500;
            //提升技能等级
            player.skill4_level += 1;
            //增加属性
            player.skill4_data = player.skill4_level * 0.3f;
        }
    }

    //升级闪避等级
    public void UpSidestep()
    {
        //判断技能点数是否足够
        if (player.skillPoints > ((long)Math.Pow((player.skill5_level + 1), 2) * 500) && player.skill5_level < 100)
        {
            player.skillPoints -= (long)Math.Pow(player.skill5_level + 1, 2) * 500;
            //提升技能等级
            player.skill5_level += 1;
            //增加属性
            player.skill5_data = player.skill5_level * 0.1f;
        }
    }
}
