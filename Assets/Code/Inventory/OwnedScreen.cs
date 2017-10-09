// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace RoboRyanTron.Unite2017.Inventory
{
	public class OwnedScreen : MonoBehaviour
	{
		public Inventory Inventory;
		public GameObject ButtonTemplate;

		private GameObject[] buttons = new GameObject[0];

		private void OnEnable()
		{
			Refresh ();
		}

		public void Refresh()
		{
			ButtonTemplate.SetActive (false);
			for (int i = 0; i < buttons.Length; i++)
				Destroy (buttons [i].gameObject);
			buttons = new GameObject[Inventory.InventoryState.OwnedItem.Count];
			for (int i = 0; i < Inventory.InventoryState.OwnedItem.Count; i++)
			{
				int index = i;
				GameObject b = Instantiate (ButtonTemplate);
				b.SetActive (true);
				b.transform.SetParent(ButtonTemplate.transform.parent, false);
				b.GetComponentInChildren<Text> ().text = Inventory.InventoryState.OwnedItem[i].name;
				buttons [i] = b;
				b.GetComponent<Button> ().onClick.AddListener (
					() => Inventory.RemoveItem (Inventory.InventoryState.OwnedItem[index]));
				
			}
		}
	}
}