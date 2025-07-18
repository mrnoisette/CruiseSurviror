using UnityEngine;

public class Spawner_Manager : MonoBehaviour {

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _ennemy;
    [SerializeField] private float minSpawnDistance = 15f;
    [SerializeField] private float maxSpawnDistance = 30f;
    [SerializeField] private float spawnInterval = 1f;

    private float _spawnTimer;

    void Update() {

        // Spawner
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= spawnInterval) {
            EnnemySpawner();
            _spawnTimer = 0f;
        }

    }

    private void EnnemySpawner() {

        // Position aléatoire autour du player (entre les min et max)
        Vector2 direction = UnityEngine.Random.insideUnitCircle.normalized;
        float distance = UnityEngine.Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPosition = _player.transform.position + new Vector3(direction.x, 0f, direction.y) * distance;

        spawnPosition.y = 0f;

        // Instance de l'ennemy
        var ennemy = Instantiate(_ennemy, spawnPosition, Quaternion.identity);

        // Pour suivre le player
        ennemy.GetComponent<Ennemy>().Player = _player;
    }



}