using System.Collections.Generic;
using UnityEngine;

public class HealBehaviour : MonoBehaviour, IHeal, ISubject<HealArgs>
{
    [SerializeField] private int healing;

    private readonly List<IObserver<HealArgs>> observers = new List<IObserver<HealArgs>>();

    public void Heal()
    {
        Notify();
    }

    public void Add(IObserver<HealArgs> observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver<HealArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(new HealArgs(healing));
        }
    }
}