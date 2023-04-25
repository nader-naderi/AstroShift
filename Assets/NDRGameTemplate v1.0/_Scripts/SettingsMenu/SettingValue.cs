using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    [RequireComponent(typeof(Text))]
    public class SettingValue : MonoBehaviour
    {
        [SerializeField]
        Text value;

        private void Awake()
        {
            if (!value)
                value = GetComponent<Text>();
        }

        public void UpdateValue(float valueF)
        {
            value.text = (valueF * 100f).ToString("F0") + "%";
        }
    }

}