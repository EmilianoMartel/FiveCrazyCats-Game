using System;

public interface IHealth
{
    private void HandleDamage(int damage){}

    private void DieLogic() { }

    public void SuscribeDieEvent(Action action) { }

    public void UnsuscribeDieEvent(Action action) { }
}