using UnityEngine;
using System.Collections;

namespace NDRUtil
{
    public class FaceTheCamera : MonoBehaviour
    {
        [SerializeField]
        protected Transform cam;

        void Start()
        {
            if (!cam)
                cam = Camera.main.transform;
        }

        void LateUpdate()
        {
            if (!cam) return;

            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}