using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class InteractionPanel : MonoBehaviour 
{
	private GameObject deal;
    private GameObject play;
    private GameObject disard;
    private GameObject grab;
    private GameObject disgrab;
    private GameCtrl controller;
	private void Awake() 
	{
	    deal = gameObject.transform.Find("DealBtn").gameObject;
        play = gameObject.transform.Find("PlayBtn").gameObject;
        disard = gameObject.transform.Find("DiscardBtn").gameObject;
        grab = gameObject.transform.Find("GrabBtn").gameObject;
        disgrab = gameObject.transform.Find("DisgrabBtn").gameObject;
        controller = GameObject.Find("GameController").GetComponent<GameCtrl>();

        deal.GetComponent<Button>().onClick.AddListener(DealCallBack);
        play.GetComponent<Button>().onClick.AddListener(PlayCallBack);
        disard.GetComponent<Button>().onClick.AddListener(DiscardCallBack);
        grab.GetComponent<Button>().onClick.AddListener(GrabLordCallBack);
        disgrab.GetComponent<Button>().onClick.AddListener(DisgrabLordCallBack);	
	
        OrderController.Instance.activeButton+=ActiveCardButton;

        play.SetActive(false);
        disard.SetActive(false);
        grab.SetActive(false);
        disgrab.SetActive(false);
    }

    private void DisgrabLordCallBack()
    {
        throw new NotImplementedException();
    }

    private void GrabLordCallBack()
    {
        throw new NotImplementedException();
    }

    private void DiscardCallBack()
    {
        throw new NotImplementedException();
    }

    private void PlayCallBack()
    {
        throw new NotImplementedException();
    }

    private void DealCallBack()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 激活出牌按钮
    /// </summary>
    /// <param name="canReject"></param>
    void ActiveCardButton(bool canReject)
    {

    }
}
