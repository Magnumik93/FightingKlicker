using UnityEngine;

namespace CodeBase.Hero.Axe
{
    public class AxeSpawner : MonoBehaviour
    {
        [SerializeField] private AxeThrow _axe;
        [SerializeField] private HeroInput _hero;
        
        private Vector3 _spawnPos;
        
        private void Start()
        {
            _spawnPos = transform.position;
        }

        public void SpawnAxe()
        {
            if (_hero.Move > 0)
            {
                _spawnPos.x = 2.9f;
                transform.position = new Vector3(_spawnPos.x, _spawnPos.y, 0);
            }  
            else if (_hero.Move < 0)
            {
                _spawnPos.x = -2.9f;
                transform.position = new Vector3(_spawnPos.x, _spawnPos.y, 0);
            }  
            Instantiate(_axe, transform.position, Quaternion.identity);
        }
    }
}