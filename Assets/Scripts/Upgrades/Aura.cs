using UnityEngine;

public class Aura : MonoBehaviour {

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _requin_Prefab;
    public float Diametre;
    public float Degat;
    public float NbRequin;

    void Start() {
        float degreEnCours = 0f;

        // Instancier les requins autour du joueur
        for (int i = 0; i < NbRequin; i++) {

            // Position équidistante
            Vector3 position = new Vector3(Mathf.Cos(degreEnCours * Mathf.Deg2Rad) * Diametre, 1, Mathf.Sin(degreEnCours * Mathf.Deg2Rad) * Diametre);

            degreEnCours += 360 / NbRequin;

            // Instanciate en enfant du player
            var instanceRequin = Instantiate(_requin_Prefab, _player.transform);
            instanceRequin.transform.position = position;
        }
    }

    void Update() {

        // TODO : 
        // Rotation des requins autour du joueur
        // Rotation des requins autour de l'axe (la tete doit suivre l'axe)
        // Infliger des dégats au tag 'Ennemy'

    }
}