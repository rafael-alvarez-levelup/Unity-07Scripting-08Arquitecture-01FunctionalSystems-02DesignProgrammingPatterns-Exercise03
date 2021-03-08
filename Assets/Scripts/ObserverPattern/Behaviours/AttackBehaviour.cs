using System.Collections.Generic;
using UnityEngine;

// TODO: Serialize Animator and SetTrigger("Attack")

public class AttackBehaviour : MonoBehaviour, IAttack, ISubject<AttackArgs>
{
    [SerializeField] private int damage;

    private readonly List<IObserver<AttackArgs>> observers = new List<IObserver<AttackArgs>>();

    public void Attack()
    {
        Notify();
    }

    public void Add(IObserver<AttackArgs> observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver<AttackArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(new AttackArgs(damage));
        }
    }
}