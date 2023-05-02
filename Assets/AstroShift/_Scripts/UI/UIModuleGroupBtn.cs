using System.Collections.Generic;

using UnityEditorInternal.Profiling.Memory.Experimental;

using UnityEngine;
using UnityEngine.UI;

namespace AstroShift
{
    public class UIModuleGroupBtn : MonoBehaviour
    {
        [SerializeField] private UIModuleItem moduleUIItemPrefab;
        [SerializeField] private ModuleData[] datas;
        [SerializeField] Transform panelGroup;

        private List<UIModuleItem> currentInstantiatedItems = new List<UIModuleItem>();
        private void Awake()
        {
            CreateModuleItems();
        }
        private void Start()
        {
        }

        private void CreateModuleItems()
        {
            for (int i = 0; i < datas.Length; i++)
            {
                UIModuleItem newItem = Instantiate(moduleUIItemPrefab);
                newItem.Init(datas[i]);
                newItem.transform.SetParent(panelGroup);
                currentInstantiatedItems.Add(newItem);
            }
        }
        public void OnClickBtn()
        {

        }
    }
}
