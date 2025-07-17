using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Manager : MonoBehaviour
{
    public void Retour_Menu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitterJeu() {

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
