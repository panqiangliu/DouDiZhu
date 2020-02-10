using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{

    public int baseScore; //底分
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
        go.transform.localPosition = Vector2.zero;
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
        GameObject bgPanel = Instantiate(Resources.Load("Prefabs/BackgroundPanel")as GameObject);
        bgPanel.transform.SetParent(root);
        bgPanel.transform.localPosition = Vector3.zero;
        bgPanel.transform.SetAsFirstSibling();
        bgPanel.name=bgPanel.transform.name.Replace("(Clone)","");

        //记录玩家数据
        GameObject scene = Instantiate(Resources.Load("Prefabs/ScenePanel") as GameObject);
        scene.transform.SetParent(root);
        scene.transform.localPosition = Vector3.zero;
        GameObject player = scene.transform.Find("Player").gameObject;
        HandCards playerCard = player.AddComponent<HandCards>();
        playerCard.cType = CharacterType.Player;
        player.AddComponent<PlayCard>();

        //生成电脑玩家1 数据
        GameObject computerOne = scene.transform.Find("ComputerOne").gameObject;
        HandCards computerOneCard = computerOne.AddComponent<HandCards>();
        computerOneCard.cType = CharacterType.ComputerOne;
        computerOne.AddComponent<SimpleSmartCard>();
        computerOne.transform.Find("Text_Notice").gameObject.SetActive(false);

        //生成电脑玩家2 数据
        GameObject computerTwo = scene.transform.Find("ComputerTwo").gameObject;
        HandCards computerTwoCard = computerTwo.AddComponent<HandCards>();
        computerTwoCard.cType = CharacterType.ComputerTwo;
        computerTwo.AddComponent<SimpleSmartCard>();
        computerTwo.transform.Find("Text_Notice").gameObject.SetActive(false);

        GameObject desk = scene.transform.Find("Desk").gameObject;
        desk.transform.Find("Text_Notice").gameObject.SetActive(false);

        if(!info.Exists)
        {
            playerCard.Integration = 1000;
            computerOneCard.Integration = 1000;
            computerTwoCard.Integration =1000;
        }
        else
        {
            GameData data = GetDataWithoutBOM(fileName);

            playerCard.Integration = data.playerIntegration;
            computerOneCard.Integration = data.computerOneIntegration;
            computerTwoCard.Integration = data.computerTwoIntegration;
        }
        GameCtrl.UpdateIntegration(CharacterType.Player);
        GameCtrl.UpdateIntegration(CharacterType.ComputerOne);
        GameCtrl.UpdateIntegration(CharacterType.ComputerTwo);
    }

    private static void UpdateIntegration(CharacterType type)
    {
        int integration = GameObject.Find(type.ToString()).gameObject.GetComponent<HandCards>().Integration;
        GameObject obj = GameObject.Find(type.ToString()).transform.Find("Text_Score").gameObject;
        obj.GetComponent<Text>().text = "积分:" + integration;
    }

    /// <summary>
    /// 跳过utf-8 xml BOM的方法
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private GameData GetDataWithoutBOM(string fileName)
    {
        GameData data = new GameData();
        Stream stream = new FileStream(fileName + @"\data.json", FileMode.Open, FileAccess.Read, FileShare.None);
        StreamReader reader = new StreamReader(stream,true);//true 跳过bom

        XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
        data = xmlSerializer.Deserialize(reader) as GameData;
        reader.Close();

        return data;
    }
}
