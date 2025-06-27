using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] public PlayerStats Stats;

    void Start() { 
        
        // Copie pour ne pas écrire dans le fichier
        Stats = Instantiate(Stats);
    }

}
