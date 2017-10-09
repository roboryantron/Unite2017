// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Audio;

namespace RoboRyanTron.Unite2017.Variables
{
    public class AudioVolumeSetter : MonoBehaviour
    {
        public AudioMixer Mixer;
        public string ParameterName = "";
        public FloatVariable Variable;

        private void Update()
        {
            float dB = Variable.Value > 0.0f ?
                20.0f * Mathf.Log10(Variable.Value) : 
                -80.0f;

            Mixer.SetFloat(ParameterName, dB);
        }
    }
}