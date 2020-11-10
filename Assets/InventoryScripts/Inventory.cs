using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//清单类型
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
  //物品存单
  public List<Item> list = new List<Item>();
}
