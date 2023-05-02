using System.Security.Cryptography;

using UnityEngine;

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

        private bool FindAndAttach(Module module)
        {
            // Find all attachment nodes on the spaceship
            ModuleAttachmentNode[] attachmentNodes = GetComponentsInChildren<ModuleAttachmentNode>();

            // No attachment node was found for the module
            return false;
        }

        public void OnClickModuleItem()
        {
            // TODO:
            // Create the Module Object
            // Start the Drag n Drop Phase
            // Can Attach the Module on the Space Ship
            // On Mosue Right Click Trash it

            // Instantiate the module prefab
            //Module newModule = Instantiate(modulePrefab);

            //// Set the parent of the new module to the spaceship
            //newModule.transform.SetParent(transform);

            //// Attach the new module to a nearby attachment node on the spaceship
            //if (FindAndAttach(newModule))
            //{
            //    Debug.Log("Module attached!");
            //}
            //else
            //{
            //    // If the module couldn't be attached, destroy it
            //    Destroy(newModule.gameObject);
            //}
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
            return previousModuleIndex == currentModuleIndex;
        }
    }
}
