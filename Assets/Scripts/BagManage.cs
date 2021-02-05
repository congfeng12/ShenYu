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
    //物品详情组件
    public GameObject itemInfoWin;
    //物品详情标题
    public Text itemInfoWinTitle;
    //物品详情图标
    public Image itemInfoWinImage;
    //物品详情内容
    public Text itemInfoWinInfo;
    //详情页面物品数量
    public Text itemInfoWinNum;
    //道具详情页按钮
    public ItemInfoWinButton itemInfoWinButton;
    //物品删除按钮
    //物品使用按钮
    //音效文件
    public AudioSource buttonsource;
    //角色信息
    public User player;
    //金币显示组件
    public Text Goldtext;
    //钻石显示组件
    public Text DIAtext;

    // Start is called before the first frame update
    public void Start()
    {
        //初始化金币和钻石显示
        flashDIA_Glod();
    }

    public void Update()
    {
        //刷新金币和钻石
        flashDIA_Glod();
    }

    private void OnEnable()
    {
        //刷新背包道具
        RefrensgItem();
    }

    //刷新金币和钻石数量
    private void flashDIA_Glod()
    {
        Goldtext.text = player.gold + "";
        DIAtext.text = player.DIA + "";
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
        newprop.button.onClick.RemoveAllListeners();
        newprop.button.onClick.AddListener(() => showItemInfo(newprop));
    }

    //显示物品详情
    private void showItemInfo(Prop prop)
    {
        //播放按钮音效
        buttonsource.Play();
        //将物品信息放入物品详情窗口
        itemInfoWinTitle.text = prop.slotItem.itemName;
        itemInfoWinImage.sprite = prop.slotImage.sprite;
        itemInfoWinInfo.text = prop.slotItem.itemInfo;
        itemInfoWinNum.text = prop.slotItem.itemNum + "";
        //展示页面按钮赋值
        itemInfoWinButton.shuowitem = prop.slotItem;
        //显示物品详细窗口
        itemInfoWin.SetActive(true);
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

    //道具增加到背包
    public void addItemToPlayerBag(Inventory userbag, Item thisitem, int num)
    {
        if (!userbag.list.Contains(thisitem))
        {
            userbag.list.Add(thisitem);
            if (num > 1)
            {
                thisitem.itemNum += num - 1;
            }
        }
        else
        {
            thisitem.itemNum += num;
        }
        //RefrensgItem();
    }
}