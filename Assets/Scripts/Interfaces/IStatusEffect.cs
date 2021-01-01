public interface IStatusEffect
{
    void BecomePoisoned();

    void BecomeOiled();

    void BecomeBurned();

    void BecomeStunned();

    void TickHealing(float healAmount, float healDuration);

    void Dispel();

    void BecomeInvulnerable();

    void BecomeVulnerable();
}