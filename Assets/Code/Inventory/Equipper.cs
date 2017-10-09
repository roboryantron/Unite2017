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
	public class Equipper : MonoBehaviour
	{
		public Inventory Inventory;
		private List<GameObject> items = new List<GameObject>();

		private void OnEnable()
		{
			Refresh ();
		}

		public void Refresh()
		{
			for(int i = 0; i < items.Count; i++)
			{
				Destroy (items [i].gameObject);
			}
			items.Clear ();
			for(int i = 0; i < Inventory.InventoryState.OwnedItem.Count; i++)
			{
				GameObject item = Instantiate (Inventory.InventoryState.OwnedItem [i].Prefab);
				item.transform.parent = transform;
				item.transform.localPosition = Vector3.zero;
				item.transform.localRotation = Quaternion.identity;
				items.Add (item);
			}
		}
	}
}