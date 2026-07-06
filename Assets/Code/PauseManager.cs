using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Image darkBackground; // 어두운 배경 이미지를 연결합니다.
    public Text pauseText;

    private bool isPaused = false;

    private void Start()
    {
        ResumeGame();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseText.text = "계속하기";

            
            AudioManager.instance.EffectBgm(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseText.text = "일시정지";

            
            AudioManager.instance.EffectBgm(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseText.text = "일시정지";

        
        
    }
}


