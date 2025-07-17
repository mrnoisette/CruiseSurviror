using UnityEngine;

public class Tir_Upgrade : MonoBehaviour {

    [SerializeField] private Player _player;
     public GameObject _projectile_Prefab;

    public float FrequenceTir = 0.4f;
    public float VitesseProjectile = 10f;

    private float _lastAttackTime = 0f;
    void Update() {

        if (Time.time < _lastAttackTime) {
            // Limite la fréquence de tir
            return;
        }
        _lastAttackTime = Time.time + FrequenceTir;

        Vector3 spawn = _player.transform.position + _player.transform.forward * 1;
        var projectile = Instantiate(_projectile_Prefab, spawn, transform.rotation);

        projectile.GetComponent<Rigidbody>().linearVelocity = _player.transform.forward * VitesseProjectile;
    }


   
}
