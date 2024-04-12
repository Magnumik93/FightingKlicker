using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.UI
{
    public class ButoonInput : UnityEngine.MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;

        public void StartOn()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
        public void PauseOn()
        {
            Time.timeScale = 0;
            Instantiate(_pausePanel);
        }

        public void PauseOff()
        {
            Time.timeScale = 1;
            Destroy(GameObject.FindWithTag("Pouse"));
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