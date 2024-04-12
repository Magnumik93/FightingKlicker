using System;
using UnityEngine;

public class ObjectScore : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _score = 5;

    public static event Action<int> OnChanged;

    public void Active() => 
        OnChanged?.Invoke(_score);
}