using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopProp : MonoBehaviour
{
    //物品基础属性
    public Item slotItem;
    //物品图片
    public Image slotImage;
    //货币类型 1-金币；2-水晶
    public int type;
    //价格
    public int price;
    //是否限购 0-不限购；1-限购；
    public int isRestricted;
    //限购数量
    public int restricted;
    //展示物品详情按钮
    public Button button;
}
