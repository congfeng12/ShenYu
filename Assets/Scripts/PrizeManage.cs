using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeManage : MonoBehaviour
{
    public BagManage bagManage;
    //背包信息
    public Inventory userbag;
    //角色信息
    public User player;
    //道具模版
    public PrizeProp prizeProp;
    //物品展示控件
    public GameObject slotGrid;
    //星辰页面展示
    public Text starstext;
    //物品等级图片
    public Sprite level_1;
    public Sprite level_2;
    public Sprite level_3;
    public Sprite level_4;
    //奖励道具
    public List<Item> itemList = new List<Item>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        starstext.text = player.stars + "";
    }

    public void prize()
    {
        if (10 <= player.stars) {
            player.stars -= 10;
            //清空
            for (int i = 0; i < slotGrid.transform.childCount; i++)
            {
                Destroy(slotGrid.transform.GetChild(i).gameObject);
            }
            //抽奖
            RefrensgItem();
        }
    }


    //创建物品
    private void CreateNewItem(Item item)
    {
        PrizeProp newprop = Instantiate(prizeProp, slotGrid.transform.position, Quaternion.identity);
        newprop.gameObject.transform.SetParent(slotGrid.transform);
        newprop.slotItem = item;
        newprop.slotImage.sprite = item.itemImage;
        //等级背景
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
        //数量
        newprop.slotNum.text = "1";
        //获取道具
        bagManage.addItemToPlayerBag(userbag, item, 1);
    }

    //刷新物品
    public void RefrensgItem()
    {
        for (int i = 0; i < 12; i++)
        {
            int j_1 = Random.Range(1, 100);
            if (j_1 >= 50)
            {
                int j_2 = Random.Range(1, 100);
                //
                if (j_2 <= 50)
                {
                    int j_3 = Random.Range(4, 6);
                    //4 5
                    CreateNewItem(itemList[j_3]);
                }
                if (j_2 >= 51 && j_2 <= 85)
                {
                    int j_3 = Random.Range(6, 8);
                    //6 7
                    CreateNewItem(itemList[j_3]);
                }
                if (j_2 >= 86 && j_2 <= 95)
                {
                    int j_3 = Random.Range(8, 13);
                    //8 9 10 11 12
                    CreateNewItem(itemList[j_3]);
                }
                if (j_2 >= 96)
                {
                    int j_3 = Random.Range(13, 17);
                    //13 14 15 16
                    CreateNewItem(itemList[j_3]);
                }
            }
            else
            {
                int j_3 = Random.Range(0, 4);
                //0 1 2 3
                CreateNewItem(itemList[j_3]);
            }
        }
    }

}
