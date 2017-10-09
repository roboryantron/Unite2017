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
	public class InventoryScreen : MonoBehaviour
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
			buttons = new GameObject[Inventory.Items.Length];
			for (int i = 0; i < Inventory.Items.Length; i++)
			{
				int index = i;
				GameObject b = Instantiate (ButtonTemplate);
				b.SetActive (true);
				b.transform.SetParent(ButtonTemplate.transform.parent, false);
				b.GetComponentInChildren<Text> ().text = Inventory.Items[i].name;
				b.GetComponent<Button> ().onClick.AddListener (
					() => Inventory.GiveItem (Inventory.Items [index]));
				buttons [i] = b;
			}
		}
	}
}