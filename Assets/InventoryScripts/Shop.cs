using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Inventory/New Shop")]
public class Shop : ScriptableObject
{
    //物品存单（总共16个道具）
    public List<Item> itemList = new List<Item>();
    //货币类型 1-金币；2-水晶
    public List<int> type = new List<int>();
    //价格
    public List<int> price = new List<int>();
    //是否限购 0-不限购；1-限购；
    public List<int> isRestricted = new List<int>();
    //限购数量
    public List<int> restricted = new List<int>();
}
