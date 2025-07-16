using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int Degat = 2;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ennemy")) { // Ennemy touché
            Debug.Log("ENNEMY TOUCHE !!!!!!!!!!!!!!!!");

            // On applique les dégats à l'ennemy
            other.GetComponent<Ennemy>().Stats.Health -= Degat;
            Destroy(gameObject);

        }
    }

}
