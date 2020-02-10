using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
	Library = 0,
	Player=1,
	ComputerOne = 2,
	ComputerTwo = 3,
	Desk = 4 
}

public enum Identity
{
	Farmer,
	Landlord
}


[SerializeField]
public class GameData
{   
	public int playerIntegration;
    public int computerOneIntegration;
    public int computerTwoIntegration;
}