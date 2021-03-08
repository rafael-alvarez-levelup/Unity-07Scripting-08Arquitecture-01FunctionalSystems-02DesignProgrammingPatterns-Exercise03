using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour, ISubject<LevelArgs>
{
    private int currentLevel = 1;

    private readonly List<IObserver<LevelArgs>> observers = new List<IObserver<LevelArgs>>();

    private void Start()
    {
        Notify();
    }

    public void IncrementLevel()
    {
        currentLevel++;

        Notify();
    }

    public void Add(IObserver<LevelArgs> observer)
    {
        observers.Add(observer);
    }

    public void Remove(IObserver<LevelArgs> observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(new LevelArgs(currentLevel));
        }
    }
}