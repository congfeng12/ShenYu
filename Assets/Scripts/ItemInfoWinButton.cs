using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoWinButton : MonoBehaviour
{
    //需要处理的道具
    public Item shuowitem;
    //背包信息
    public Inventory userbag;
    //物品详情组件
    public BagManage bagManage;
    //详情页面物品数量
    public Text itemInfoWinNum;

    //删除一个物品
    public void delItem()
    {
        int num = shuowitem.itemNum;
        if (num == 1)
        {
            for (int i = 0; i < userbag.list.Count; i++)
            {
                if (userbag.list[i] == shuowitem)
                {
                    userbag.list.Remove(userbag.list[i]);
                }
            }
            //防止背包总数量减少增加一个空位置
            userbag.list.Add(null);
            //当该物品从背包移除则需要将详情页面关闭
            bagManage.itemInfoWin.SetActive(false);
        }
        if (num > 1)
        {
            num -= 1;
            shuowitem.itemNum = num;
            itemInfoWinNum.text = shuowitem.itemNum + "";
        }
        bagManage.RefrensgItem();
    }

    //使用一个物品
    public void useItem()
    {
        //根据属性数量判断是否可以使用
        if (shuowitem.itemAttribute.Count > 0)
        {
            //道具属性增加
            for (int i = 0; i < shuowitem.itemAttribute.Count; i++)
            {
                UseItemManage.useItem(shuowitem.itemAttribute[i]);
            }
            //删除一个物品
            delItem();
        }
    }
}