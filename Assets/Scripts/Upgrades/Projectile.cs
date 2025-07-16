using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int Degat = 2;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ennemy")) { // Ennemy touch�
            Debug.Log("ENNEMY TOUCHE !!!!!!!!!!!!!!!!");

            // On applique les d�gats � l'ennemy
            other.GetComponent<Ennemy>().Stats.Health -= Degat;
            Destroy(gameObject);

        }
    }

}
