using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
   private static readonly int Die = Animator.StringToHash("Die");
   private Animator _animator;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   public void PlayDie() => 
      _animator.SetTrigger(Die);
}