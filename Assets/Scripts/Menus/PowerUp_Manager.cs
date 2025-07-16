using UnityEngine;

public class PowerUp_Manager : MonoBehaviour {

    [SerializeField] private Player _player;

    public void AméliorerSepll(GameObject powerUpPrefab) {

        if (!powerUpPrefab.activeSelf) { // On le débloque
            powerUpPrefab.SetActive(true);
        } else { // Sinon on l'améliore

        }

    }

    public void FermerMenu() {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
