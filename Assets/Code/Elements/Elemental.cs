// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace RoboRyanTron.Unite2017.Elements
{
    public class Elemental : MonoBehaviour
    {
        [Tooltip("Element represented by this elemental.")]
        public AttackElement Element;

        [Tooltip("Text to fill in with the element name.")]
        public Text Label;

        private void OnEnable()
        {
            if(Label != null)
                Label.text = Element.name;
        }

        private void OnTriggerEnter(Collider other)
        {
            Elemental e = other.gameObject.GetComponent<Elemental>();
            if (e != null)
            {
                if (e.Element.DefeatedElements.Contains(Element))
                    Destroy(gameObject);
            }
        }
    }
}