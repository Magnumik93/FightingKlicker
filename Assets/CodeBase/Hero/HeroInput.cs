using System.Collections;
using CodeBase.Hero.Axe;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroInput : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private HeroAnimator animator;
        [SerializeField] private AxeSpawner axeSpawner;

        public int Move = 1;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.flipX = false;
                Move = 1;
                animator.PlayAttack();
                StartCoroutine(SpawnAxe());
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.flipX = true;
                Move = -1;
                animator.PlayAttack();
                StartCoroutine(SpawnAxe());
            }
        }

        private IEnumerator SpawnAxe()
        {
            yield return null;
            yield return null;
            yield return null;
            axeSpawner.SpawnAxe();
        }
    }
}