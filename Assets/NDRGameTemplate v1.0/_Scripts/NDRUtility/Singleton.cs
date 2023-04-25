using UnityEngine;

namespace NDRUtil
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get { return instance; }
        }

        public static bool IsInitialized
        { get { return instance != null; } }    

        protected virtual void Awake()
        {
            if (instance == null)
                instance = this as T;
        }

        protected virtual void OnDestroy()
        {
            if(instance == this)
                instance = null;    
        }
    }
}
