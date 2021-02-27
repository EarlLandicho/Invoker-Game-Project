public interface IHealth
{
    void TakeDamage(float damage, bool isStatusEffectDamage = false);

    void TakeHealing(float healAmount);

    void SetIsInvulnerable(bool isInvulnerable);

    float GetDamageModifier();

    void SetDamageModifierByFactor(float damageModifier, bool isSetting);
}