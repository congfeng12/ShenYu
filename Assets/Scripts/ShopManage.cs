using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManage : MonoBehaviour
{
    public BagManage bagManage;
    //物品
    public ShopProp propPrefab;
    //商城信息
    public Shop shop;
    //背包信息
    public Inventory userbag;
    //角色信息
    public User player;
    //物品展示控件
    public GameObject slotGrid;
    //物品详情组件
    public GameObject itemInfoWin;
    //音效文件
    public AudioSource buttonsource;
    //金币图片
    public Sprite glod_image;
    //钻石图片
    public Sprite DIA_image;
    //物品详情标题
    public Text itemInfoWinTitle;
    //物品详情内容
    public Text itemInfoWinInfo;
    //金币或者钻石
    public Image image;
    //售价
    public Text num;
    //购买按钮
    public Button buybutton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        //刷新背包道具
        RefrensgItem();
    }

    //显示物品详情
    private void showItemInfo(ShopProp prop)
    {
        //播放按钮音效
        buttonsource.Play();
        //将物品信息放入物品详情窗口
        itemInfoWinTitle.text = prop.slotItem.itemName;
        itemInfoWinInfo.text = prop.slotItem.itemInfo;
        if (prop.type == 1)
        {
            //金币
            image.sprite = glod_image;
        }
        else
        {
            //钻石
            image.sprite = DIA_image;
        }
        num.text = prop.price + "";
        //购买按钮赋值
        buybutton.onClick.RemoveAllListeners();
        buybutton.onClick.AddListener(() => buy(prop));
        //显示物品详细窗口
        itemInfoWin.SetActive(true);
    }

    //购买
    private void buy(ShopProp prop)
    {
        if (prop.type == 1 && player.gold >= prop.price)
        {
            //减金额
            player.gold -= prop.price;
            //增加道具
            bagManage.addItemToPlayerBag(userbag, prop.slotItem, 1);
            itemInfoWin.SetActive(false);
            RefrensgItem();
        }
        if (prop.type == 2 && player.DIA >= prop.price)
        {
            //判断是否限购
            if (prop.isRestricted == 0)
            {
                //不限购 判断金币是否足够
                if (player.DIA >= prop.price)
                {
                    //减金额
                    player.DIA -= prop.price;
                    //增加道具
                    bagManage.addItemToPlayerBag(userbag, prop.slotItem, 1);
                    itemInfoWin.SetActive(false);
                    RefrensgItem();
                }
            }
            else
            {
                if (prop.restricted > 0)
                {
                    //减少限购次数
                    for (int i = 0; i < shop.itemList.Count; i++)
                    {
                        if (shop.itemList[i].itemId.Equals(prop.slotItem.itemId))
                        {
                            shop.restricted[i] -= 1;
                            prop.restricted -= 1;
                        }
                    }
                    //减金额
                    player.DIA -= prop.price;
                    //增加道具
                    bagManage.addItemToPlayerBag(userbag, prop.slotItem, 1);
                    itemInfoWin.SetActive(false);
                    RefrensgItem();
                }
            }
        }
    }

    //背包创建物品
    private void CreateNewItem(Item item, int in_type, int in_price, int in_isRestricted, int in_restricted)
    {
        ShopProp newprop = Instantiate(propPrefab, slotGrid.transform.position, Quaternion.identity);
        newprop.gameObject.transform.SetParent(slotGrid.transform);
        newprop.slotItem = item;
        newprop.slotImage.sprite = item.itemImage;
        newprop.type = in_type;
        newprop.price = in_price;
        newprop.isRestricted = in_isRestricted;
        newprop.restricted = in_restricted;
        newprop.button.onClick.RemoveAllListeners();
        newprop.button.onClick.AddListener(() => showItemInfo(newprop));
    }

    //刷新商城物品
    public void RefrensgItem()
    {
        for (int i = 0; i < slotGrid.transform.childCount; i++)
        {
            if (slotGrid.transform.childCount == 0)
                break;
            Destroy(slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < shop.itemList.Count; i++)
        {
            if (shop.itemList[i] != null)
            {
                CreateNewItem(shop.itemList[i], shop.type[i], shop.price[i], shop.isRestricted[i], shop.restricted[i]);
            }
        }
    }
}