// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RoboRyanTron.Unite2017.Inventory
{
	[CreateAssetMenu]
	public class Inventory : ScriptableObject
	{
		public InventoryItem[] Items = new InventoryItem[0];
		public Serializer Serializer;

		private Dictionary<string, InventoryItem> guidToItem = new Dictionary<string, InventoryItem> ();
		public InventoryState InventoryState;

		public UnityEvent OnInventoryChanged;

		private void OnEnable()
		{
			guidToItem.Clear ();
			for(int i = 0; i < Items.Length; i++)
			{
				guidToItem.Add (Items [i].GUID, Items [i]);
			}

			InventoryState.OwnedItem.Clear ();
			InventoryState.set.Clear ();
			for(int i = 0; i < InventoryState.OwnedGUIDS.Count; i++)
			{
				InventoryState.set.Add(InventoryState.OwnedGUIDS[i]);
				InventoryState.OwnedItem.Add (guidToItem [InventoryState.OwnedGUIDS [i]]);
			}
		}

		public void Save()
		{
			Serializer.Serialize ("inventory", InventoryState);
		}

		public void Load()
		{
			Serializer.Deserialize<InventoryState>("inventory", InventoryState);

			InventoryState.OwnedItem.Clear ();
			InventoryState.set.Clear ();
			for(int i = 0; i < InventoryState.OwnedGUIDS.Count; i++)
			{
				InventoryState.set.Add(InventoryState.OwnedGUIDS[i]);
				InventoryState.OwnedItem.Add (guidToItem [InventoryState.OwnedGUIDS [i]]);
			}
			OnInventoryChanged.Invoke ();
		}

		public void GiveItem(InventoryItem item)
		{
			if (InventoryState.set.Add(item.GUID))
			{
				InventoryState.OwnedGUIDS.Add(item.GUID);
				InventoryState.OwnedItem.Add(item);
			}
			OnInventoryChanged.Invoke ();
		}

		public void RemoveItem(InventoryItem item)
		{
			if (InventoryState.set.Remove(item.GUID))
			{
				InventoryState.OwnedGUIDS.Remove(item.GUID);
				InventoryState.OwnedItem.Remove(item);
			}
			OnInventoryChanged.Invoke ();
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			FindItems();
			InventoryState state = UnityEditor.AssetDatabase.LoadAssetAtPath<InventoryState>(UnityEditor.AssetDatabase.GetAssetPath(this));
			if (state == null) 
			{
				state = ScriptableObject.CreateInstance<InventoryState> ();
				state.name = "InventoryState";
				UnityEditor.AssetDatabase.AddObjectToAsset (state, this);
				UnityEditor.AssetDatabase.SaveAssets ();
			}
			InventoryState = state;
		}

		[ContextMenu("Populate Items")]
		private void FindItems()
		{
			string[] guids = UnityEditor.AssetDatabase.FindAssets ("t:" + typeof(InventoryItem).Name);
			Items = new InventoryItem[guids.Length];
			for(int i = 0; i < guids.Length; i++)
			{
				string path = UnityEditor.AssetDatabase.GUIDToAssetPath (guids [i]);
				InventoryItem item = UnityEditor.AssetDatabase.LoadAssetAtPath<InventoryItem> (path);
				Items[i] = item;
				item.GUID = guids [i];
				UnityEditor.EditorUtility.SetDirty(this);
			}
		}
#endif
	}
}