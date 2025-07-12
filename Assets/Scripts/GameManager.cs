using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _tabEnnemy; // Skeletons, tentacles, etc.
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
        if (_tabEnnemy.Length == 0 || _player == null)
            return;

        // Prefab aléatoire parmis ceux dispo 
        GameObject selectedEnemy = _tabEnnemy[Random.Range(0, _tabEnnemy.Length)];

        // Position aléatoire autour du player (entre les min et max)
        Vector2 direction = Random.insideUnitCircle.normalized;
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPosition = _player.transform.position + new Vector3(direction.x, 0f, direction.y) * distance;

        spawnPosition.y = 0f;

        // Instance de l'ennemy
        Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
    }
}
