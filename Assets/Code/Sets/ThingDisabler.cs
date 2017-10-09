// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

namespace RoboRyanTron.Unite2017.Sets
{
    public class ThingDisabler : MonoBehaviour
    {
        public ThingRuntimeSet Set;

        public void DisableAll()
        {
            // Loop backwards since the list may change when disabling
            for (int i = Set.Items.Count-1; i >= 0; i--)
            {
                Set.Items[i].gameObject.SetActive(false);
            }
        }

        public void DisableRandom()
        {
            int index = Random.Range(0, Set.Items.Count);
            Set.Items[index].gameObject.SetActive(false);
        }
    }
}