using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManage : MonoBehaviour
{
    //物品
    public Prop propPrefab;
    //物品等级图片
    public Sprite level_1;
    public Sprite level_2;
    public Sprite level_3;
    public Sprite level_4;
    //物品展示控件
    public GameObject slotGrid;
    //背包信息
    public Inventory userbag;

    // Start is called before the first frame update
    public void Start()
    {

    }

    //背包创建物品
    private void CreateNewItem(Item item)
    {
        Prop newprop = Instantiate(propPrefab, slotGrid.transform.position, Quaternion.identity);
        newprop.gameObject.transform.SetParent(slotGrid.transform);
        newprop.slotItem = item;
        newprop.slotImage.sprite = item.itemImage;
        switch (item.itemLevel)
        {
            case 1:
                newprop.backImage.sprite = level_1;
                break;
            case 2:
                newprop.backImage.sprite = level_2;
                break;
            case 3:
                newprop.backImage.sprite = level_3;
                break;
            case 4:
                newprop.backImage.sprite = level_4;
                break;
        }
        newprop.slotNum.text = item.itemNum.ToString();
    }

    //刷新背包物品
    public void RefrensgItem()
    {
        for (int i = 0; i < slotGrid.transform.childCount; i++)
        {
            if (slotGrid.transform.childCount == 0)
                break;
            Destroy(slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < userbag.list.Count; i++)
        {
            if (userbag.list[i] != null)
            {
                CreateNewItem(userbag.list[i]);
            }
        }

    }

    //将物品信息放置在物品详情窗口中
    public void openSlotInfo(Item item)
    {

        //    if (bagManage.itemTitle.text != item.itenmname && bagManage.itemTitle.text != "null")
        //    {
        //        if (bagManage.iteminfowin.activeSelf == false)
        //        {
        //            openItenWindows();
        //        }

        //        bagManage.itemTitle = ItemLevelmanager.getItemTextLevel(bagManage.itemTitle, item.itemLevel);
        //        bagManage.itemTitle.text = item.itenmname;
        //        bagManage.iteminfo.text = item.itemInfor;
        //        clear_attribute_space();
        //        add_attributes(item);
        //    }
        //    else if (bagManage.itemTitle.text != item.itenmname && bagManage.itemTitle.text == "null")
        //    {
        //        Debug.Log(3);
        //        openItenWindows();
        //        bagManage.itemTitle = ItemLevelmanager.getItemTextLevel(bagManage.itemTitle, item.itemLevel);
        //        bagManage.itemTitle.text = item.itenmname;
        //        bagManage.iteminfo.text = item.itemInfor;
        //        clear_attribute_space();
        //        add_attributes(item);
        //    }
        //    else
        //    {
        //        Debug.Log(4);
        //        openItenWindows();
        //    }
        //    //给详情按钮赋值
        //    bagManage.itemdelbutton.shuowitem = item;
        //    bagManage.itemuserbutton.shuowitem = item;
    }
}