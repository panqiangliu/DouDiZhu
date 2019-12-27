using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{

    public int baseScore; //底粉
    public int multiples; //全场倍数
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
        InitManu();
    }

    public int Multiples
    {
        set { multiples *= value; }
        get { return multiples; }
    }

    /// <summary>
    /// 初始化面板显示
    /// </summary>
    public void InitManu()
    {
        GameObject go = Resources.Load("Prefabs/StartPanel") as GameObject;
        if (go != null)
        {
            Transform startView = Instantiate(go).transform;
            startView.SetParent(root);
            //RectTransform rt =  startView.GetComponent<RectTransform>();
            //rt.SetInsetAndSizeFromParentEdge()
            //rt.anchorMin = new Vector2(0, 0);
            //rt.anchorMax = new Vector2(1, 1);

            startView.localPosition = Vector3.zero;
        }
    }

}
