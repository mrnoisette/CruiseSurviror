using Unity.VisualScripting;
using UnityEngine;

public class Mine : MonoBehaviour {

    public float Degat = 10;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundEffect;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ennemy")) { // Ennemy touché

            // On applique les dégats à l'ennemy
            other.GetComponent<Ennemy>().Stats.Health -= (int)Degat;

            // On joue l'audio
            _audioSource.PlayOneShot(_soundEffect);

            // On détruit le prefab 
            Destroy(gameObject, _soundEffect.length);
        }
    }

  
}
