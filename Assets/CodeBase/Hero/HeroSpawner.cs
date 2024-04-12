using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroSpawner : MonoBehaviour
    {
        [SerializeField] private HeroInput _hero;

        private void Awake()
        {
            Instantiate(_hero);
        }

        private void Start()
        {
            _hero.transform.position = transform.position;
        }
    }
}