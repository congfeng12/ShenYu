using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemManage : MonoBehaviour
{
    //背包管理
    public BagManage bagManage;
    //用户信息
    public User player;
    //背包信息
    public Inventory userbag;
    //初级道行书
    public Item item_1;
    //中级道行书
    public Item item_2;
    //高级道行书
    public Item item_3;
    //道具使用
    public void useItem(ItemAttribute itemAttribute)
    {

        //根据属性编号进行物品的使用
        switch (itemAttribute.AttributeId)
        {
            case "100001":
                //增加120体力
                player.power += 120;
                break;
            case "100002":
                //增加1000道行
                player.exp += 1000;
                break;
            case "100003":
                //增加20000道行
                player.exp += 20000;
                break;
            case "100004":
                //增加1000000道行
                player.exp += 1000000;
                break;
            case "100005":
                //修炼速度缩短5秒
                player.time -= 5;
                player.xy_Num += 1;
                break;
            case "100006":
                //修行进度+1000
                player.practiceExp += 1000;
                player.qy_Num += 1;
                break;
            case "100007":
                //血量+50000
                player.eq_HP = 50000;
                break;
            case "100008":
                //攻击+200
                player.eq_aggressivity = 200;
                break;
            case "100009":
                //暴击+20%
                player.eq_crit = 20.0f;
                break;
            case "100010":
                //闪避+20%
                player.eq_sidestep = 20.0f;
                break;
            case "100011":
                //攻击+100
                player.eq_aggressivity = 100;
                break;
            case "100012":
                //血量+20000
                player.eq_HP = 20000;
                break;
            case "100013":
                //暴击+10%
                player.eq_crit = 10.0f;
                break;
            case "100014":
                //闪避+10%
                player.eq_sidestep = 10.0f;
                break;
            case "100015":
                //血量+10000
                player.eq_HP = 10000;
                break;
            case "100016":
                //暴击+5%
                player.eq_crit = 5.0f;
                break;
            case "100017":
                //攻击+50
                player.eq_aggressivity = 50;
                break;
            case "100018":
                //生命+1000
                player.eq_HP = 1000;
                break;
            case "100019":
                //攻击+10
                player.eq_aggressivity = 10;
                break;
            case "100020":
                //增加100点技能点
                player.skillPoints += 100;
                break;
            case "100021":
                //增加1000点技能点
                player.skillPoints += 1000;
                break;
            case "100022":
                //增加50000点技能点
                player.skillPoints += 50000;
                break;
            case "100023":
                //获得10个纠缠星辰
                player.stars += 10;
                break;
            case "100024":
                //获得200个扫荡币
                player.vouchers += 200;
                break;
            case "100025":
                //获取1200个体力
                player.power += 1200;
                break;
            case "100026":
                //获得20个初级道行书
                bagManage.addItemToPlayerBag(userbag, item_1, 20);
                break;
            case "100027":
                //10个中级道行书
                bagManage.addItemToPlayerBag(userbag, item_2, 10);
                break;
            case "100028":
                //5个高级道行书
                bagManage.addItemToPlayerBag(userbag, item_3, 5);
                break;
            case "100029":
                //获得60000000金币
                player.gold += 60000000;
                break;
        }
    }
}
