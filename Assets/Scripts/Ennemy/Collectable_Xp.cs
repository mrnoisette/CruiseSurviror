using UnityEngine;

public class Collectable_Xp : MonoBehaviour {

    public int XpGain;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().Xp += XpGain;
            Destroy(gameObject);
        }
    }

}
