using JetBrains.Annotations;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace NDR2ndAutoBattler
{
    public class UIBar : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI percent;
        [SerializeField] protected Image bar;

        private void Awake()
        {
            UpdateBar(0f);
        }

        public virtual void UpdateBar(float percent)
        {
            this.percent.text = percent.ToString("F0") + " %";
            bar.fillAmount = percent * 0.01f;
        }

        public virtual void UpdateBar(int amount, int maxAmount)
        {
            this.percent.text = amount.ToString();
            bar.fillAmount = amount / maxAmount;
        }

        public virtual void UpdateBar(float amount, float maxAmount)
        {
            this.percent.text = amount.ToString("F0");
            bar.fillAmount = amount / maxAmount;
        }
    }
}
