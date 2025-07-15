using UnityEngine;

public class PowerUp_Manager : MonoBehaviour {

    [SerializeField] private Player _player;
    //[SerializeField] private GameObject _menu_LevelUp;

    /// <summary>
    /// Equipe ou améliore un spell via son prefab.
    /// </summary>
    /// <param name="powerUpPrefab"></param>
    public void AméliorerSepll(GameObject powerUpPrefab) {

        if (!powerUpPrefab.activeSelf) { // On débloque le spell
            powerUpPrefab.SetActive(true);

        } else { // On l'améliore

        }

        // Fermer le menu des power-ups

    }

    public void FermerMenu() {
        gameObject.SetActive(false);
    }

}
