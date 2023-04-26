using UnityEngine;
using UnityEngine.UI;

namespace AstroShift
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] private Image icon;

        private Item item;

        public void Init(Sprite sprite, Item item)
        {
            icon.enabled = sprite;
            icon.sprite = sprite;
            this.item = item;
        }

        public void OnClickBtn()
        {
            if (!item)
                return;

            item.Use(GameManager.Instance.Player);
        }
    }
}
