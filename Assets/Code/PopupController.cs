using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject pausePopup; // �˾� â�� ������ ���� ������Ʈ
    private bool isPaused = false; // ���� �Ͻ� ���� ���� ����
    public Button resumeButton; // �̾��ϱ� ��ư�� ������ ���� ������Ʈ



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f; // ���� �ð��� �Ͻ� ����
            if (pausePopup != null)
            {
                pausePopup.SetActive(true); // �˾� â Ȱ��ȭ
                AudioManager.instance.EffectBgm(true);
            }

            if (resumeButton != null)
            {
                resumeButton.interactable = false; // �̾��ϱ� ��ư ��Ȱ��ȭ
            }
        }
        else
        {
            Time.timeScale = 1f; // ���� �ð��� �ٽ� ����
            if (pausePopup != null)
            {
                pausePopup.SetActive(false); // �˾� â ��Ȱ��ȭ
                AudioManager.instance.EffectBgm(false);
            }

            if (resumeButton != null)
            {
                resumeButton.interactable = true; // �̾��ϱ� ��ư Ȱ��ȭ
            }
        }
    }


    public void ResumeGame()
    {
        TogglePause(); // "���� ����ϱ�" ��ư�� ������ �Ͻ� ���� ����
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // ���� �ð��� �ٽ� ����
        SceneManager.LoadScene("SampleScene"); // ���� �޴� ������ ���ư���
    }
}
