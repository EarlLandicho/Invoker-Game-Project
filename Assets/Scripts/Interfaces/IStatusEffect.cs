public interface IStatusEffect
{
    void BecomePoisoned();

    void BecomeOiled();

    void BecomeBurned();

    void TickHealing(float healAmount, float healDuration);

    void Dispel();
}