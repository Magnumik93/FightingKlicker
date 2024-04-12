using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class ButoonInput : UnityEngine.MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _pauseBtn;

        private int _score;

        private void Start() =>
            _score = 0;

        public void StartOn()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void PauseOn()
        {
            if (_score == 0)
            {
                _score = 1;
                
                Instantiate(_pausePanel);
                Time.timeScale = 0;
            }
        }

        public void PauseOff()
        {
            if (_score == 1)
            {
                Time.timeScale = 1;

                Destroy(GameObject.FindWithTag("Pouse"));

                _score = 0;
            }

        }

        public void RestartOn()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void MenuOn()
        {
            SceneManager.LoadScene(0);
        }

        public void ExitOn()
        {
            Application.Quit();
        }
    }
}