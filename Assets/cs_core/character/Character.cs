//------------------------------------------------------------------------------
// Character.cs
// GVSU capstone
// Abstract class for playable and nonplayable charaters to implement. 
// Jonathan Powers
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour{
	public int Level{ get; set;}
	public int Health{ get; set;}
	public float Speed{ get; set;}
	public int XP{ get; set;}
	public string CharName{ get; set;}
    public ArrayList abilities;

	//Need to create inventory and ability classes
	//Inventory inventory = new Inventory ();
	//Ability ability = new Ability ();
}