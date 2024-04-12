using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDied : MonoBehaviour
{
    [SerializeField] private UnityEvent KillEnemy;

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
            Died();
            
            KillEnemy?.Invoke();
        }
        else if (collider2D.CompareTag("Player"))
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