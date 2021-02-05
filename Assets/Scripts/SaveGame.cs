using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    //背包信息
    public Inventory userbag;
    //角色信息
    public User player;
    //商城信息
    public Shop shop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //保存或读取游戏
    public void beginGame()
    {
        //检测是否有文件夹
        if (!Directory.Exists(Application.persistentDataPath + "/Game_Save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game_Save");
        }
        //Debug.Log(Application.persistentDataPath + "/Game_Save");
        //存档序列化
        BinaryFormatter formatter = new BinaryFormatter();
        //用户信息存档
        if (!File.Exists(Application.persistentDataPath + "/Game_Save" + "/player_save.save"))
        {
            //首次登录
            //更新最后修炼时间点
            player.lasttime = DateTime.Now.ToString();
            //创建存档
            FileStream player_save = File.Create(Application.persistentDataPath + "/Game_Save" + "/player_save.save");
            //数据转化为json格式
            var json = JsonUtility.ToJson(player);
            //将数据存进存档文件
            formatter.Serialize(player_save, json);
            //释放资源
            player_save.Close();
        }
        else
        {
            //非第一次登录
            //读取文件
            FileStream player_save = File.Open(Application.persistentDataPath + "/Game_Save" + "/player_save.save", FileMode.Open);
            //存档写回
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(player_save), player);
            //释放资源
            player_save.Close();
        }
        //背包信息存档
        if (!File.Exists(Application.persistentDataPath + "/Game_Save" + "/bag_save.save"))
        {
            //创建存档
            FileStream bag_save = File.Create(Application.persistentDataPath + "/Game_Save" + "/bag_save.save");
            //数据转化为json格式
            var json = JsonUtility.ToJson(userbag);
            //将数据存进存档文件
            formatter.Serialize(bag_save, json);
            //释放资源
            bag_save.Close();
        }
        else
        {

            //读取文件
            FileStream bag_save = File.Open(Application.persistentDataPath + "/Game_Save" + "/bag_save.save", FileMode.Open);
            //存档写回
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(bag_save), userbag);
            //释放资源
            bag_save.Close();
            //非第一次登录
            string item_string = PlayerPrefs.GetString("items");
            string[] itemArray = item_string.Split(',');
            if (itemArray[0] != "")
            {
                for (int i = 0; i < itemArray.Length; i++)
                {
                    userbag.list[i].itemNum = int.Parse(itemArray[i]);
                }
            }
        }
        //商城信息
        if (!File.Exists(Application.persistentDataPath + "/Game_Save" + "/shop_save.save"))
        {
            //首次登录
            //创建存档
            FileStream shop_save = File.Create(Application.persistentDataPath + "/Game_Save" + "/shop_save.save");
            //数据转化为json格式
            var json = JsonUtility.ToJson(shop);
            //将数据存进存档文件
            formatter.Serialize(shop_save, json);
            //释放资源
            shop_save.Close();
        }
        else
        {
            //非第一次登录
            //读取文件
            FileStream shop_save = File.Open(Application.persistentDataPath + "/Game_Save" + "/shop_save.save", FileMode.Open);
            //存档写回
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(shop_save), shop);
            //释放资源
            shop_save.Close();
        }
    }


    public void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //读取文件
        //创建存档
        FileStream player_save = File.Create(Application.persistentDataPath + "/Game_Save" + "/player_save.save");
        //数据转化为json格式
        var json = JsonUtility.ToJson(player);
        //将数据存进存档文件
        formatter.Serialize(player_save, json);
        //释放资源
        player_save.Close();

        string item_string = "";
        //首次登录
        for (int i = 0; i < userbag.list.Count; i++)
        {
            item_string += "" + userbag.list[i].itemNum;
            if (i < userbag.list.Count - 1)
            {
                item_string += ",";
            }
        }
        //Debug.Log(item_string);
        PlayerPrefs.SetString("items", item_string);
        //创建存档
        FileStream bag_save = File.Create(Application.persistentDataPath + "/Game_Save" + "/bag_save.save");
        //数据转化为json格式
        var json1 = JsonUtility.ToJson(userbag);
        //将数据存进存档文件
        formatter.Serialize(bag_save, json1);
        //释放资源
        bag_save.Close();

        //创建存档
        FileStream shop_save = File.Create(Application.persistentDataPath + "/Game_Save" + "/shop_save.save");
        //数据转化为json格式
        var json2 = JsonUtility.ToJson(shop);
        //将数据存进存档文件
        formatter.Serialize(shop_save, json2);
        //释放资源
        shop_save.Close();
    }

    //退出游戏
    public void quite()
    {
        Application.Quit();
    }

}
