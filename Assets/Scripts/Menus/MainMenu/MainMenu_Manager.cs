using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour {

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public AudioClip _bruhSound;

    public void LancerJeu() {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitterJeu() {

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

    public void PlayBruhSound() {
        _audioSource.PlayOneShot(_bruhSound);
    }
}
