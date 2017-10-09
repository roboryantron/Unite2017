// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

namespace RoboRyanTron.Unite2017.Inventory
{
	[CreateAssetMenu]
	public class LogSerializer : Serializer
	{
		public override void Serialize(object key, object data)
		{
			string json = JsonUtility.ToJson(data);
			Debug.Log (json);
			last = json;
		}

		string last = "";

		public override T Deserialize<T>(object key, T target)
		{
			JsonUtility.FromJsonOverwrite (last, target);
			return target;
		}
	}
}