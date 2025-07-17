using UnityEngine;

public class PowerUp_Manager : MonoBehaviour {

    [SerializeField] private Player _player;

    public void AméliorerSepll(GameObject powerUpPrefab) {

        if (!powerUpPrefab.activeSelf) { // On le débloque
            powerUpPrefab.SetActive(true);
        } else { // Sinon on l'améliore
            if (powerUpPrefab.GetComponent<Aura_Upgrade>() != null) { // Aura
                var aura = powerUpPrefab.GetComponent<Aura_Upgrade>();
                aura.Degat += 1f;
                aura.AttackSpeed -= 0.1f;

            } else if (powerUpPrefab.GetComponent<Tir_Upgrade>() != null) { // Tir
                var tir = powerUpPrefab.GetComponent<Tir_Upgrade>();
                tir.FrequenceTir -= 0.1f;
            } else if (powerUpPrefab.GetComponent<Mine_Upgrade>() != null) { // Bombe
                var bombe = powerUpPrefab.GetComponent<Mine_Upgrade>();
                bombe.FrequenceSpawn -= 1f;
            }
        }

    }

    public void FermerMenu() {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
