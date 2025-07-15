using UnityEngine;

public class TireurJoueur1 : MonoBehaviour
{
    // ────────────────────────── RÉFÉRENCES ────────────────────────────────
    [Header("Références")]
    [SerializeField] private Transform  pointTirDroit;    
    [SerializeField] private GameObject prefabProjectile;  

    // ────────────────────────── RÉGLAGES ─────────────────────────────────
    [Header("Cadence & Position")]
    public float intervalleTir = 1f;
    public float decalageSpawn = 0.5f;

    // ────────────────────────── MÉTHODES UNITY ───────────────────────────
    private void Start()
    {
        // Premier tir immédiat, puis répétition toutes les « intervalleTir » secondes
        InvokeRepeating(nameof(Tirer), 0f, intervalleTir);
    }
    
    private void Tirer()
    {
        if (!prefabProjectile || !pointTirDroit) return;
        Vector3 positionSpawn = pointTirDroit.position + pointTirDroit.forward * decalageSpawn;
        GameObject projectile = Instantiate(prefabProjectile, positionSpawn, pointTirDroit.rotation);

        // Ignore la collision initiale entre le projectile et le joueur
        if (projectile.TryGetComponent(out Collider colliderProj))
        {
            foreach (Collider colliderJoueur in GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(colliderProj, colliderJoueur);
            }
        }
    }
}