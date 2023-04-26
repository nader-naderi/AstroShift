using UnityEngine;
using System.Collections;

namespace AstroShift
{
    [System.Serializable]
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] int maxHealth = 100;
        [SerializeField] Stat damage;
        [SerializeField] Stat armor;
        [SerializeField] Stat intellect;
        [SerializeField] Stat healingRate;

        [SerializeField] Stat criticalChance;
        [SerializeField] Stat criticalDamage;
        [SerializeField] Stat dodgeChance;
        
        private EquipmentsController equipmentsController;

        public int CurrentHealth { get; private set; }
        public bool IsDead { get => CurrentHealth <= 0; }
        public Stat Damage { get => damage; }
        public Stat Armor { get => armor; }
        public Stat HealingRate { get => healingRate; }
        public Stat Intellect { get => intellect; }
        public Stat CriticalChance { get => criticalChance; }
        public Stat CriticalDamage { get => criticalDamage; }
        public int CurrentLevel { get; private set; } = 1;
        public Stat DodgeChance { get => dodgeChance; }

        public void Awake()
        {
            CurrentHealth = maxHealth;
            equipmentsController.onEquipmentChanged += OnEquipmentChanged;
        }

        void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
        {
            if (newItem)
            {
                armor.AddModifier(newItem.armorModifier);
                damage.AddModifier(newItem.damageModifier);
            }

            if(oldItem)
            {
                armor.RemoveModifier(oldItem.armorModifier);
                damage.RemoveModifier(oldItem.damageModifier);
            }
        }

        public int TakeDamage(int damage)
        {
            damage -= armor.Value;
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            CurrentHealth -= damage;
            
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
            return damage;
        }

        public void AddHealth(int healthAmount)
        {
            CurrentHealth += healthAmount;

            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
        }

        public void Heal(float percentage)
        {
            CurrentHealth = (int)(CurrentHealth / percentage);
        }

        public void LevelUp()
        {
            CurrentLevel++;
            maxHealth = (int)(maxHealth * 1.05f);
            damage.AddModifier(2);
            armor.AddModifier(2);
            intellect.AddModifier(2);
            healingRate.AddModifier(2);
            criticalChance.AddModifier(2);
            criticalDamage.AddModifier(2);
        }

        public void SetLevel(int level)
        {
            CurrentLevel = level;
        }

        public override string ToString()
        {
            return  "Max Health : " + maxHealth +
                    "\nLevel : " + CurrentLevel +
                    "\nDamage : " + damage.Value +
                    "\nArmor : " + armor.Value +
                    "\nIntellect : " + intellect.Value +
                    "\nHealingRate : " + healingRate.Value +
                    "\nCritical Chance : " + criticalChance.Value +
                    "\nCritical Damage : " + criticalDamage.Value;
        }
    }
}