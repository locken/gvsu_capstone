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
	public abstract int Level{ get; set;}
	public abstract int Health{ get; set;}
	public abstract float Speed{ get; set;}
	public abstract int XP{ get; set;}
	public abstract string CharName{ get; set;}
    public abstract int Magic { get; set; }
    public ArrayList abilities;

	//Need to create inventory and ability classes
	//Inventory inventory = new Inventory ();
	//Ability ability = new Ability ();
}