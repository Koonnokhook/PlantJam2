using UnityEngine;

namespace PlantJamNamespace
{
    public class GamePauseManager : MonoBehaviour
    {
        private bool isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
