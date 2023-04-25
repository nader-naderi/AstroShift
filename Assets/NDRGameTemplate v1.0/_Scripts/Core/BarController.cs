using UnityEngine;
using System.Collections;

namespace NDR2ndAutoBattler
{
    public class BarController : MonoBehaviour
    {
        [SerializeField] Color originalColor;
        [SerializeField] Color criticalColor;
        [SerializeField] float criticalValue = 0.2f;
        [SerializeField] float changeColorSpeed = 0.5f;
        [SerializeField] SpriteRenderer barFiller;
        [SerializeField] Transform barPivot;
        private Color currentColor;
        private new Transform camera;

        public void Init(Transform camera)
        {
            this.camera = camera;
        }

        void Start()
        {
            currentColor = originalColor;
            barFiller.color = currentColor;
        }

        void Update()
        {
            if (!camera) return;

            transform.LookAt(camera);
        }

        public bool UpdateBar(float percent)
        {
            percent = Mathf.Clamp(percent, 0, 1);
            barPivot.localScale = new Vector3(percent, 1, 1);
            if(percent <= criticalValue)
            {
                barFiller.color = Color.Lerp(barFiller.color, criticalColor, Time.deltaTime * changeColorSpeed);
            }

            return percent >= 1;
        }
    }
}