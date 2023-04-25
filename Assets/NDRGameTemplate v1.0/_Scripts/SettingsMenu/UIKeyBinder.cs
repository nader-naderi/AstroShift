using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    public class UIKeyBinder : MonoBehaviour
    {
        [SerializeField] protected Text mainTxt;
        [SerializeField] KeyCode keyCode = KeyCode.None;
        [SerializeField] KeyCode defaultKey;
        
        public KeyCode KeyCode { get => keyCode; set => keyCode = value; }
        public KeyCode DefaultKey { get => defaultKey; }

        private void Start()
        {
            Bind(keyCode);
        }

        public void Bind(string keyTxt)
        {
            mainTxt.text = keyTxt;
        }

        public void Bind(KeyCode keyCode)
        {
            this.keyCode = keyCode;
            mainTxt.text = keyCode.ToString();
        }

        public  void SetToDefault()
        {
            Bind(defaultKey);
        }
    }
}
