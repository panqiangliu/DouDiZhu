using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameCtrl gameCtrl;
    void Awake()
    {
        transform.Find("Easy").gameObject.GetComponent<Button>().onClick.AddListener(StartEsayGame);
        transform.Find("Normal").gameObject.GetComponent<Button>().onClick.AddListener(StartNormalGame);
        gameCtrl = GameObject.Find("GameController").GetComponent<GameCtrl>();
    }


    private void StartEsayGame()
    {
        gameCtrl.InitInteraction();
        gameCtrl.InitScene();
        Destroy(this.gameObject);
    }

    private void StartNormalGame()
    {
        throw new NotImplementedException();
    }


}
