public static class CombatCalculator {
    public static int CalculateMeleeDamage(Player attacker, Weapon weapon) {
        return (int)((attacker.Attack * 2.2) + 
                     (weapon.BaseDamage * 3) + 
                     (attacker.Level / 4.5) + 
                     (attacker.Skills[weapon.SkillType] * 1.7));
    }

    public static int CalculateSpellDamage(Player caster, Spell spell) {
        return (int)((spell.BasePower * 1.8) + 
                    (caster.MagicLevel * 2.5) + 
                    (caster.Level / 5));
    }
}