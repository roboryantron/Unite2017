// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System;
using UnityEngine;

namespace RoboRyanTron.Unite2017.Variables
{
    public class KeyboardMover : MonoBehaviour
    {
        [Serializable]
        public class MoveAxis
        {
            public KeyCode Positive;
            public KeyCode Negative;

            public MoveAxis(KeyCode positive, KeyCode negative)
            {
                Positive = positive;
                Negative = negative;
            }

            public static implicit operator float(MoveAxis axis)
            {
                return (Input.GetKey(axis.Positive)
                    ? 1.0f : 0.0f) -
                    (Input.GetKey(axis.Negative)
                    ? 1.0f : 0.0f);
            }
        }

        public FloatVariable MoveRate;
        public MoveAxis Horizontal = new MoveAxis(KeyCode.D, KeyCode.A);
        public MoveAxis Vertical = new MoveAxis(KeyCode.W, KeyCode.S);

        private void Update()
        {
            Vector3 moveNormal = new Vector3(Horizontal, Vertical, 0.0f).normalized;

            transform.position += moveNormal*Time.deltaTime*MoveRate.Value;
        }
    }
}