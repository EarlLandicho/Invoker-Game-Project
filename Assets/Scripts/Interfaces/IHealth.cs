public interface IHealth
{
    void TakeDamage(float damage, bool isStatusEffectDamage = false);

    void TakeHealing(float healAmount);

    //used when FlashWhenDamaged script is attached
    void FlashWhenDamaged();
}