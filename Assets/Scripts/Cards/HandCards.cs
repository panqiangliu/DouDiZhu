using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class HandCards : MonoBehaviour {
    public CharacterType cType;
	public List<Card> library;
	private Identity identity;
	private int multiples; //玩家倍数
	private int integration; //积分

    // Use this for initialization
    void Start () 
	{
		multiples = 1;
		identity = Identity.Farmer;
		library =  new List<Card>();
	}
	
	/// <summary>
	/// 积分
	/// </summary>
	/// <value></value>
	public int Integration
	{ 
		get{return integration;}
		set{integration = value;}
	}

	/// <summary>
	/// 玩家倍数
	/// </summary>
	/// <value></value>
	public int Multiples
	{
		get{return multiples;}
		set{multiples = value;}
	}
	
	/// <summary>
	/// 玩家手牌数量
	/// </summary>
	/// <value></value>
	public int CardsCount
	{
		get { return library.Count; }
	}

	/// <summary>
	/// 获得玩家的身份
	/// </summary>
	/// <value></value>
	public Identity AccessIdentity
	{
		set{identity = value;}
		get{return identity;}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
