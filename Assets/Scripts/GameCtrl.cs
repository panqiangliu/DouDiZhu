using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{

    public int baseScore; //底粉
    private int multiples; //全场倍数
    private Transform root;

    void Awake()
    {
        root = GameObject.Find("UIRoot").transform;
    }

    // Use this for initialization
    void Start()
    {
        multiples = 1;
        baseScore = 100;
        InitMenu();
    }

    public int Multiples
    {
        set { multiples *= value; }
        get { return multiples; }
    }


    /// <summary>
    /// 初始化面板显示
    /// </summary>
    public void InitMenu()
    {
        GameObject go = Resources.Load("Prefabs/StartPanel") as GameObject;
        if (go != null)
        {
            Transform startView = Instantiate(go).transform;
            startView.SetParent(root);
            startView.localPosition = Vector3.zero;
            startView.gameObject.AddComponent<Menu>();
        }
    }

    public void InitInteraction()
    {
        GameObject go =Instantiate(Resources.Load("Prefabs/InteractionPanel")) as GameObject;
        go.transform.SetParent(root);
        go.name = go.name.Replace("(Clone)","");
        go.AddComponent<InteractionPanel>();
    }
    
    /// <summary>
    /// 初始化场景数据在界面中显示出来
    /// </summary>
    public  void InitScene()
    {
        string fileName ="";
        if(Application.platform ==RuntimePlatform.Android)
        {
            fileName = Application.persistentDataPath;
        }
        else
        {
            fileName = Application.dataPath;
        }
        FileInfo info = new FileInfo(fileName+@"\data.json");
        GameObject bgPanel = Instantiate(Resources.Load("BackgroundPanel")as GameObject);
        bgPanel.transform.SetParent(root);
        bgPanel.transform.SetAsFirstSibling();
        bgPanel.name=bgPanel.transform.name.Replace("(Clone)","");

        //记录玩家数据
        GameObject scene = Instantiate(Resources.Load("ScenePanel") as GameObject);
        GameObject player = scene.transform.Find("Player").gameObject;
        HandCards playerCard = player.AddComponent<HandCards>();
        playerCard.cType = CharacterType.Player;
        player.AddComponent<PlayCard>();

        //生成电脑玩家1 数据
        GameObject computerOne = scene.transform.Find("ComputerOne").gameObject;
        HandCards computerOneCard = player.AddComponent<HandCards>();
        computerOneCard.cType = CharacterType.ComputerOne;
        computerOne.AddComponent<SimpleSmartCard>();


    }
}
