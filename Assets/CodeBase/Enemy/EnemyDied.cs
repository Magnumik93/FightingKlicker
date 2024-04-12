using System;
using System.Collections;
using CodeBase.Hero.Axe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyDied : MonoBehaviour
{
    [SerializeField] private UnityEvent KillEnemy;
    [SerializeField] private Image _imageCurrent;
    [SerializeField] private float _current;

    private EnemyAnimator _animator;
    private EnemyMove _enemyMove;
    private BoxCollider2D _collider2D;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimator>();
        _enemyMove = GetComponent<EnemyMove>();
        _collider2D = GetComponent<BoxCollider2D>();
    }
    

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Axe"))
        {
            _current -= 1;
            if (_current == 0)
            {
                Died();

                KillEnemy?.Invoke();
            }
        }
        if (collider2D.CompareTag("Player"))
        {
            Died();
        }
    }

    private void Died()
    {
        _collider2D.enabled = false;
        _enemyMove.enabled = false;
        _animator.PlayDie();
        StartCoroutine(DestroyTimer());
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}