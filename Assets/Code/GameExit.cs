using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        // "StartMenu" æ¿¿∏∑Œ µπæ∆∞©¥œ¥Ÿ.
        SceneManager.LoadScene(0);
    }
}
