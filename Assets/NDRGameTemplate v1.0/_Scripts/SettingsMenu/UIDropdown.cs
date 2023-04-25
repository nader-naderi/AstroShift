using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    public class UIDropdown : MonoBehaviour
    {
        [SerializeField] private Dropdown dropdown;

        public Dropdown Dropdown { get => dropdown; }
    }

}