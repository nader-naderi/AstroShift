using UnityEngine;

namespace NDRGameTemplate
{
    public static class InputManager
    {
        public static KeyCode[] lookKeyes = new KeyCode[] 
        { KeyCode.Q, KeyCode.E, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.None, KeyCode.None, };
        public static KeyCode[] moveKeyes;
        public static KeyCode[] combatKeyes;
        public static KeyCode[] interactKeyes;
        public static KeyCode[] multiplayerKeyes;
    }
}
