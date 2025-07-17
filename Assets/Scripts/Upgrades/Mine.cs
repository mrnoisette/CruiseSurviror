using Unity.VisualScripting;
using UnityEngine;

public class Mine : MonoBehaviour {

    public float Degat = 10;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundEffect;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ennemy")) { // Ennemy touch�

            // On applique les d�gats � l'ennemy
            other.GetComponent<Ennemy>().Stats.Health -= (int)Degat;

            // On joue l'audio
            _audioSource.PlayOneShot(_soundEffect);

            // On d�truit le prefab 
            Destroy(gameObject, _soundEffect.length);
        }
    }

  
}
