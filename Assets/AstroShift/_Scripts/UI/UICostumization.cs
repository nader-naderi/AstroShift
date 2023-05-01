using System.Security.Cryptography;

using UnityEngine;
using UnityEngine.UI;

namespace AstroShift
{
    public class UICostumization : MonoBehaviour
    {
        [SerializeField] private GameObject[] modulePanels;

        private int currentModuleIndex = 1;
        private int previousModuleIndex = 0;

        public GameObject CurrentModulePanel { get => modulePanels[currentModuleIndex]; }
        public GameObject PreviousModulePanel { get => modulePanels[previousModuleIndex]; }

        private void Start()
        {
            ActivateModulePanel();
        }

        public void OnClickModuleGroupBtn(int moduleIndex)
        {
            ActivateModulePanel(moduleIndex);
        }

        public void OnClickModuleItem()
        {
            // TODO:
            // Create the Module Object
            // Start the Drag n Drop Phase
            // Can Attach the Module on the Space Ship
            // On Mosue Right Click Trash it
        }

        public void OnClickConfirmToPlay()
        {
            // Confirmation to Accept the Changes
        }

        public void ActivateModulePanel(int moduleIndex = -1)
        {
            previousModuleIndex = currentModuleIndex;
            currentModuleIndex = moduleIndex;

            if (moduleIndex == -1)
            {
                for (int i = 0; i < modulePanels.Length; i++)
                    modulePanels[i].SetActive(false);

                return;
            }

            if (IsToggle())
                CurrentModulePanel.SetActive(!CurrentModulePanel.activeSelf);
            else
                for (int i = 0; i < modulePanels.Length; i++)
                    modulePanels[i].SetActive(i == moduleIndex);
        }

        private bool IsToggle()
        {
            Debug.Log("AA");
            return previousModuleIndex == currentModuleIndex;
        }
    }

    public class UIModuleGroupBtn : MonoBehaviour
    {
        [SerializeField] private Image groupPortraite;
        [SerializeField] private ItemData[] modules;
        [SerializeField] Transform panelGroup;

        public void OnClickBtn()
        {

        }
    }
}
