using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ProjectileLigneDroite : MonoBehaviour
{
    // ────────────────────────── RÉGLAGES DE DÉPLACEMENT ─────────────────────
    [Header("Déplacement")]
    public float vitesse = 40f;
    public float porteeMax = 120f;

    // ────────────────────────── RÉGLAGES DE COMBAT ─────────────────────────
    [Header("Combat")]
    public int degats = 10;

    // ────────────────────────── VARIABLES INTERNES ─────────────────────────
    private Vector3 positionDepart;
    // ────────────────────────── MÉTHODES UNITY ─────────────────────────────
    private void Start() => positionDepart = transform.position;
    private void Update()
    {
        // Avance en ligne droite
        transform.position += transform.forward * vitesse * Time.deltaTime;

        // Détruit l’objet
        if (Vector3.Distance(positionDepart, transform.position) >= porteeMax)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") ||
            other.GetComponent<ProjectileLigneDroite>() != null)
            return;

        // Applique les dégâts si on touche un ennemi
        if (other.CompareTag("Ennemy"))
        {
            Ennemy ennemi = other.GetComponent<Ennemy>();
            if (ennemi != null) ennemi.Stats.Health -= degats;
        }

        Destroy(gameObject);
    }
}