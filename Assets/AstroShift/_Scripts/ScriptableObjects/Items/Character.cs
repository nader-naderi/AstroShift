using UnityEngine;

namespace AstroShift
{
    public enum ClassType { Human, Monster }
    [CreateAssetMenu(fileName = "Character", menuName = "SOE/Characters/Character", order = 0)]
    public class Character : Item
    {
        public ClassType classType;
        public string description;

        [Space(10), Header("Stats Properties")]
        [Tooltip("Normal Base Level."), Range(1, 100)] public int startingLevel = 1;
        [Tooltip("Normal Base damage."), Range(0, 100)] public int dealingDamage = 5;
        [Tooltip("Normal Base Intellect."), Range(0, 100)] public int baseIntellect = 5;
        [Tooltip("Normal Base Armor."), Range(0, 100)] public int baseArmor = 5;

        [Tooltip("Chance of getting critical Damage"), Range(0, 100)] public int criticalChance = 10;
        [Tooltip("Amount of doing critical Damage"), Range(0, 100)] public int criticalDamage = 10;
        [Tooltip("Nromal Attack Per second."), Range(0, 5)] public float attackRate = 1f;
        [Tooltip("Nromal Attack Per second."), Range(0, 100)] public int dodgeChance = 30;

        public float DodgeDamagePercent { get => (dodgeChance) * 0.01f; }
        public float CriticalDamagePercent { get => (criticalDamage) * 0.01f; }
        public float CriticalChancePercent { get => (criticalChance) * 0.01f; }
    }
}