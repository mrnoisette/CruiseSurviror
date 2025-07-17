using UnityEngine;

public class Mine_Upgrade : MonoBehaviour {

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _bombe_Prefab;

    public float FrequenceSpawn;

    private float _spawnTimer;
    void Update() {

        // Spawner
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= FrequenceSpawn) {
            BombSpawner();
            _spawnTimer = 0f;
        }

    }

    private void BombSpawner() {
        Vector3 spawnPosition = _player.transform.position + Vector3.up * 0.2f;
        Quaternion rotation = _bombe_Prefab.transform.rotation; 
        var bombe = Instantiate(_bombe_Prefab, spawnPosition, rotation);
    }

}
