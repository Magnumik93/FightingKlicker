using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimator : UnityEngine.MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Attack = Animator.StringToHash("Attack");

        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayDeath() =>
            _animator.SetTrigger(Die);

        public void PlayAttack() =>
            _animator.SetTrigger(Attack);
    }
}