using System.Collections.Generic;

using UnityEngine;

namespace AstroShift
{
    public interface IAutomatonable
    {
        public List<IModule> Modules { get; }
        public bool IsPlayer { get; set; }
        public bool IsOn { get; set; }
        public bool IsBoosting { get; set; }
        public Transform transform { get; }
        void UpdateModules();
        public Vector2 MovementDirection { get; }
        public Vector3 RotateDirection { get; }
        public Rigidbody2D Rigidbody { get; }
    }
}
