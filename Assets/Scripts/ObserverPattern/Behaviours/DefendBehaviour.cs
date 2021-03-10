using System.Collections.Generic;
using UnityEngine;

public class DefendBehaviour : MonoBehaviour, IDefend, ISubject<DefendArgs>
{
    [SerializeField] private int defence;

    private readonly List<IObserver<DefendArgs>> observers = new List<IObserver<DefendArgs>>();

    public void Defend()
    {
        Notify();
    }

    public void Add(IObserver<DefendArgs> observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver<DefendArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(new DefendArgs(defence));
        }
    }
}