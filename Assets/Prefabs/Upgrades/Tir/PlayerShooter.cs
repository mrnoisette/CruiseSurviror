using UnityEngine;

public class TireurJoueur : MonoBehaviour
{
    // --- RÉFÉRENCES ---------------------------------------------------------

    [Header("Références")]
    [SerializeField] private Transform pointDeTir;        
    [SerializeField] private GameObject prefabProjectile; 

    // --- RÉGLAGES -----------------------------------------------------------

    [Header("Cadence & Position")]
    public float intervalleTir = 1f;
    
    public float decalageSpawn = 0.5f;

    // -----------------------------------------------------------------------

    private void Start()
    {
        
        InvokeRepeating(nameof(Tirer), 0f, intervalleTir);
    }

  
    private void Tirer()
    {
        
        if (!prefabProjectile || !pointDeTir) return;
        Vector3 positionSpawn = pointDeTir.position + pointDeTir.forward * decalageSpawn;
        GameObject projectile = Instantiate(prefabProjectile, positionSpawn, pointDeTir.rotation);

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