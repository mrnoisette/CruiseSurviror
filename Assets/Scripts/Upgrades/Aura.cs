using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Aura : MonoBehaviour {

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _requin_Prefab;
    public float Diametre;
    public float Degat;
    public float AttackSpeed = 3f;
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

        AppliquerDegatZone();
    }

    private float _lastAttackTime = 0f;
    private void AppliquerDegatZone() {

        if (Time.time < _lastAttackTime) {
            // Limite la fréquence d'attaque
            return;
        }
        _lastAttackTime = Time.time + AttackSpeed;

        var colliders = Physics.OverlapSphere(transform.position, Diametre);
        foreach (var collider in colliders) {
            if (collider.CompareTag("Ennemy")) { // Ennemy dans la zone

                // On applique les dégats à l'ennemy
                collider.GetComponent<Ennemy>().Stats.Health -= (int)Degat;

                // On rajoute des pv au player
                _player.Stats.Health += (int)Degat;
            }
        }

    }

}