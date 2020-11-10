using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]
//道具
public class Item : ScriptableObject
{
    //物品编号
    public string itemId;
    //物品名称
    public string itemName;
    //物品图片
    public Sprite itemImage;
    //物品类型 - 0道具，1妖魂
    public int itemType;
    //物品等级
    public int itemLevel;
    //物品是否支持堆叠
    public bool isStack;
    //物品数量
    public int itemNum;
    //物品描述
    [TextArea]
    public string itemInfo;
    //物品属性
    public List<ItemAttribute> itemAttribute = new List<ItemAttribute>();
}
