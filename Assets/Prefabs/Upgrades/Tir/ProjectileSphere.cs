using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ProjectileChercheur : MonoBehaviour {

    public float vitesse = 30f;
    public float vitesseRotation = 720f;
    public float porteeMax = 120f;

    public int degats = 10;

    private Vector3 positionDepart;
    private Transform cibleActuelle;

    private void Start() {
        positionDepart = transform.position;
        cibleActuelle = TrouverEnnemiLePlusProche();

        // S’oriente instantanément vers la cible trouvée si elle existe
        if (cibleActuelle) transform.LookAt(cibleActuelle);
    }

    private void Update() {
        // Si la cible disparaît (morte ou détruite), on en cherche une autre
        if (cibleActuelle == null)
            cibleActuelle = TrouverEnnemiLePlusProche();

        // Tourner progressivement vers la cible
        if (cibleActuelle != null) {
            Vector3 direction = (cibleActuelle.position - transform.position).normalized;
            float pasRotation = vitesseRotation * Mathf.Deg2Rad * Time.deltaTime;

            Vector3 dirModifiee = Vector3.RotateTowards(transform.forward, direction, pasRotation, 0f);
            transform.rotation = Quaternion.LookRotation(dirModifiee);
        }

        // Avancer
        transform.position += transform.forward * vitesse * Time.deltaTime;

        // Détruire si la portée maximale est atteinte
        if (Vector3.Distance(positionDepart, transform.position) >= porteeMax)
            Destroy(gameObject);
    }

    private Transform TrouverEnnemiLePlusProche() {
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag("Ennemy");

        Transform ennemiPlusProche = null;
        float distanceMinCarree = float.MaxValue;
        Vector3 position = transform.position;

        foreach (GameObject go in ennemis) {
            float distanceCarree = (go.transform.position - position).sqrMagnitude;
            if (distanceCarree < distanceMinCarree) {
                distanceMinCarree = distanceCarree;
                ennemiPlusProche = go.transform;
            }
        }
        return ennemiPlusProche;
    }

    private void OnTriggerEnter(Collider other) {
        // Ignore le joueur et les autres projectiles chercheurs
        if (other.CompareTag("Player") || other.GetComponent<ProjectileChercheur>() != null)
            return;

        // Applique les dégâts si on touche un ennemi
        if (other.CompareTag("Ennemy")) {
            Ennemy ennemi = other.GetComponent<Ennemy>();
            if (ennemi != null) ennemi.Stats.Health -= degats;
        }

        Destroy(gameObject);
    }
}
