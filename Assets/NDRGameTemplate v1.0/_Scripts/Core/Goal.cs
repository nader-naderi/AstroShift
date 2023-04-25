using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NDRGameTemplate
{
    public class Goal : MonoBehaviour
    {
        //public delegate void GoalReachedHandler();
        //public static event GoalReachedHandler OnGoalReached;

        public static System.Action OnGoalReached;  

        private void OnTriggerEnter(Collider other)
        {
            if (OnGoalReached != null)
                OnGoalReached();
        }
    }
}
