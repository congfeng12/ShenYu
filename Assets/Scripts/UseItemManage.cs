using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemManage : MonoBehaviour
{
    static UseItemManage useItemManage;
    //背包管理
    public BagManage bagManage;

    //道具使用
    public static void useItem(ItemAttribute itemAttribute) {
        Debug.Log("useItem - AttributeId = " + itemAttribute.AttributeId);
        Debug.Log("useItem - AttributeId = " + itemAttribute.AttributeInfo);
    }

    
}
