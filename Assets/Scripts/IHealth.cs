using System;

public interface IHealth
{
    public void GetDamage(int damage){}

    private void DieLogic() { }

    public void SuscribeDieEvent(Action action) { }

    public void UnsuscribeDieEvent(Action action) { }
}