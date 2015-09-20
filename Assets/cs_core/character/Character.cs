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
	int level{ get; set;}
	int health{ get; set;}
	float speed{ get; set;}
	int xp{ get; set;}
	string charName{ get; set;}
	//Need to create inventory and ability classes
	//Inventory inventory = new Inventory ();
	//Ability ability = new Ability ();
}