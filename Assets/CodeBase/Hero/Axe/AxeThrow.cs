using UnityEngine;

namespace CodeBase.Hero.Axe
{
    public class AxeThrow : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _speedRotation = 2f;
        [SerializeField] private Animator _animator;

        private int _move;
        private Vector3 _spawn;

        private void Start()
        {
            _spawn = transform.position;
            if (_spawn.x >= 0)
            {
                _move = 1;
            }
            else
            {
                _move = -1;
            }

            VectorAnimation(_move);
        }

        private void VectorAnimation(int move) => 
            _animator.SetFloat("Speed", move * _speedRotation);

        private void Update() => 
            transform.position += new Vector3(_move, 0, 0) * _speed * Time.deltaTime;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Enemy"))
            {
                DestroyAxe();
            }

            if (collider2D.CompareTag("Destroy"))
                DestroyAxe();
        }

        private void DestroyAxe()
        {
            Destroy(gameObject);
        }
    }
}