using UnityEngine;

//物品属性
[CreateAssetMenu(fileName ="New Attribute", menuName = "Inventory/New Attribute")]
public class ItemAttribute : ScriptableObject
{
    //属性编号
    public string AttributeId;
    //属性描述
    public string AttributeInfo;
}
