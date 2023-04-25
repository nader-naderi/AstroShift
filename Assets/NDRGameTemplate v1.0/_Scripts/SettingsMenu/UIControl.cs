using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    public class UIControl : MonoBehaviour
    {
        [SerializeField] protected Text mainTxt;
        [SerializeField] protected string[] items;
        public int currentValue { get; set; } = 0;

        protected virtual void Start()
        {
            mainTxt.text = items[currentValue];
        }

        public virtual void Init(string[] items)
        {
            this.items = items;
        }

        public virtual int OnClick_Interact()
        {
            currentValue ++;
            if (currentValue >= items.Length)
                currentValue = 0;

            mainTxt.text = items[currentValue];

            return currentValue;
        }

        public virtual string GetCurrentItem() => items[currentValue];
    }

}