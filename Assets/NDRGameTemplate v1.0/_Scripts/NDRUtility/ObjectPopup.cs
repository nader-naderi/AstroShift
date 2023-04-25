using UnityEngine;
using System.Collections;
using TMPro;

namespace NDRUtil
{
    public class ObjectPopup : FaceTheCamera
    {
        [SerializeField] float activateDuration = 2f;
        [SerializeField] float speedTolerance = 0.8f;
        [SerializeField] float colorTolerance = 0.1f;
        [SerializeField] TextMeshPro textMesh;
        private float timer = 0;
        private Vector3 originalPos;

        void Awake()
        {
            originalPos = transform.position;

            timer = activateDuration + 1;
        }

        void Update()
        {
            if (timer >= activateDuration)
                return;

            timer += Time.deltaTime;

            transform.Translate(Vector3.up * speedTolerance * activateDuration * Time.deltaTime);

            textMesh.color = Color.Lerp(textMesh.color, new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0),
                Time.deltaTime * colorTolerance * activateDuration);

            if (timer >= activateDuration)
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
        }

        public void Init(Transform lookAt)
        {
            cam = lookAt;
        }

        public void Init(string message, Vector3 origin, bool criticalDamage = false)
        {
            transform.position = origin;
            timer = 0;
            textMesh.text = message;
            textMesh.color = criticalDamage ? Color.red : Color.white;
        }

        public void Init(string message, Vector3 origin)
        {
            transform.position = origin;
            timer = 0;
            textMesh.text = message;
        }

    }
}