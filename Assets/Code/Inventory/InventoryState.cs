// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace RoboRyanTron.Unite2017.Inventory
{
	public class InventoryState : ScriptableObject
	{
		public List<string> OwnedGUIDS = new List<string> ();
		public HashSet<string> set = new HashSet<string>();
		//[System.NonSerialized]
		public List<InventoryItem> OwnedItem = new List<InventoryItem>();
	}
}