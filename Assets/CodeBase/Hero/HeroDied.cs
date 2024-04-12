using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Hero
{
    public class HeroDied : MonoBehaviour
    {
        [SerializeField] private Sprite[] spriteHp;
        [SerializeField] private HeroAnimator animator;
        [SerializeField] private GameObject panel;

        private HeroInput _input;
        private GameObject _hpBar;
        private Sprite _image;

        private int _count;
        private int _hpLength;

        private void Awake()
        {
            _input = GetComponent<HeroInput>();
            _hpBar = GameObject.FindGameObjectWithTag("HpHero");
        }

        private void Start()
        {
            if (spriteHp.Length > _count)
            {
                _image = spriteHp[_count];
            }

            HpLength();
        }

        private void HpLength()
        {
            _hpLength = spriteHp.Length - 1;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Enemy"))
            {
                ChangeSpriteHp();
            }
        }

        private void ChangeSpriteHp()
        {
            if (_count < _hpLength)
                _count += 1;
            if (_count < _hpLength)
                _image = spriteHp[_count];

            if (_count == _hpLength)
            {
                _image = spriteHp[_count];
                HeroStop();
            }

            _hpBar.GetComponent<Image>().sprite = _image;
        }

        private void HeroStop()
        {
            Debug.Log("Hana");
            _input.enabled = false;
            animator.PlayDeath();
            StartCoroutine(HeroTimer());
        }

        private IEnumerator HeroTimer()
        {
            yield return new WaitForSeconds(1);
            Instantiate(panel);
            Time.timeScale = 0;
        }
    }
}