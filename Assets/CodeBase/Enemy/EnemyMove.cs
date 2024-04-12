using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
   
    private EnemyAnimator _animator;
    private SpriteRenderer _spriteRenderer;
    private int _move = 1;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<EnemyAnimator>();
    }

    private void Start()
    {
        if (transform.position.x > 0)
        {
            _move *= -1;
            _spriteRenderer.flipX = true;
        }
        else
        {
            _move = 1;
            _spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        MoveToHero();
    }

    private void MoveToHero()
    {
        transform.position += new Vector3(_move, 0, 0) * _speed * Time.fixedDeltaTime;
    }
}