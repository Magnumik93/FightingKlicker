using System;
using UnityEngine;
using UnityEngine.Events;

public class ScareCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> ScoreChanged;

    private static int _scoreCollected;

    private void OnDisable()
    {
        ObjectScore.OnChanged -= ObjectScore_OnChanged;
    }

    private void OnEnable()
    {
        ObjectScore.OnChanged += ObjectScore_OnChanged;
    }

    private void ObjectScore_OnChanged(int value)
    {
        _scoreCollected += value;
        ScoreChanged.Invoke(_scoreCollected);
    }

    private void Start()
    {
        _scoreCollected = 0;
        ScoreChanged.Invoke(_scoreCollected);
    }
}