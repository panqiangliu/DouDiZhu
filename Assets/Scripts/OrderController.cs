using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CardEvent(bool arg);

public class OrderController
{

	private static OrderController instance;
	public  CardEvent smartCard;
	public  CardEvent activeButton;
	public static OrderController Instance
	{
		get
		{
			if(instance==null)
			{
				instance = new OrderController();
			}
			return instance;
		}
	}
}
