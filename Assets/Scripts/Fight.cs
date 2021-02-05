using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    //战斗窗口
    public GameObject fightwin;
    //进度信息
    public Text text;
    //进度条图
    public Image cooldown;
    //倒计时累计
    public float currentTime = 0.0f;
    //倒计时总时长
    public float waitTime = 30.0f;
    //是否跳过战斗
    public bool skip = false;
    //开始战斗计时
    public bool start = false;
    //用户信息
    public User player;
    //背包信息
    public Inventory userbag;
    //背包管理
    public BagManage bagManage;
    //道具列表
    public Item item_1;
    public Item item_2;
    public Item item_3;
    //奖励类型
    private int type = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (true == start)
        {
            Practice();
        }
    }

    //获取金币钻石的战斗
    public void startFight_1()
    {
        if (10 <= player.power)
        {
            //金币钻石奖励
            fightwin.SetActive(true);
            start = true;
            type = 1;
            player.power -= 10;
        }

    }

    //获取技能点的战斗
    public void startFight_2()
    {
        if (10 <= player.power)
        {
            //精粹石等奖励
            fightwin.SetActive(true);
            start = true;
            type = 2;
            player.power -= 10;
        }
    }

    //跳过战斗
    public void skipFight()
    {
        if (0 < player.vouchers)
        {
            player.vouchers -= 1;
            skip = true;
        }

    }

    private void finefight(int in_type)
    {
        if (1 == in_type)
        {
            //金币钻石奖励
            int in_gload = Random.Range(player.level * 10000, player.level * 100000);
            int in_dia = Random.Range(player.level * 100, player.level * 600);
            player.gold += in_gload;
            player.DIA += in_dia;
        }
        if (2 == in_type)
        {
            //技能点道具奖励
            bagManage.addItemToPlayerBag(userbag, item_1, Random.Range(player.level * 50, player.level * 100));

            if (Random.Range(0, 100) > 60)
            {
                bagManage.addItemToPlayerBag(userbag, item_2, Random.Range(player.level * 10, player.level * 50));
            }
            if (Random.Range(0, 100) > 90)
            {
                bagManage.addItemToPlayerBag(userbag, item_3, Random.Range(1, 10));
            }
        }
    }

    //战斗
    private void Practice()
    {
        //检测修炼条满时判断
        if (currentTime < waitTime && false == skip)
        {
            //刷新进度条
            currentTime += Time.deltaTime;
            cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
            text.text = (int)currentTime + "/" + (int)waitTime + "秒";
        }
        else
        {
            if (currentTime >= waitTime && false == skip)
            {
                currentTime = 0.0f;
                cooldown.fillAmount = 0.0f;
                // 战斗结束增加奖励
                finefight(type);
                //初始化参数
                skip = false;
                start = false;
                type = 0;
                text.text = "0/30秒";
                // 隐藏窗口
                fightwin.SetActive(false);
            }
            if (true == skip)
            {
                //跳过战斗
                currentTime = 0.0f;
                cooldown.fillAmount = 0.0f;
                // 战斗结束增加奖励
                finefight(type);
                //初始化参数
                skip = false;
                start = false;
                type = 0;
                text.text = "0/" + (int)waitTime + "秒";
                // 隐藏窗口
                fightwin.SetActive(false);
            }

        }
    }
}
