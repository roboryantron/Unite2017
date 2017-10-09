// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

namespace RoboRyanTron.Unite2017.Inventory
{
	public abstract class Serializer : ScriptableObject
	{
		public abstract void Serialize(object key, object data);
		public abstract T Deserialize<T>(object key, T target);
	}
}