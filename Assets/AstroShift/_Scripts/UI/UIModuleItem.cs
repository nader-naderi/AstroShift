using UnityEngine;
using UnityEngine.UI;

namespace AstroShift
{
    public class UIModuleItem : UIDraggable
    {
        [SerializeField] Image modulePortraite;
        [SerializeField] ModuleData data;
        public void Init(ModuleData data)
        {
            this.data = data;
            modulePortraite.sprite = data.iconSprite;
        }

        public void OnClickBtn()
        {
            // Initialize DnD

        }
    }
}
