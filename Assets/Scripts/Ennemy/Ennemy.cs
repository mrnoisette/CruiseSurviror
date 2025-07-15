using UnityEngine;

public class Ennemy : MonoBehaviour {
    public EnnemyStats Stats;

    [SerializeField] private Animator _animator;
    public Player Player;
    [SerializeField] private GameObject _collectableXp;

    void Start() {
        Stats = Instantiate(Stats);
    }

    void Update() {
        // Vecteur de déplacement vers le joueur 
        Vector3 direction = Player.transform.position - transform.position;

        // Vers où regarder
        transform.rotation = Quaternion.LookRotation(direction);

        var distance = Vector3.Distance(transform.position, Player.transform.position);

        // Déplacement
        if (distance > Stats.AttackRange) {
            _animator.SetBool("isMoving", true);
            transform.position += Time.deltaTime * Stats.MoveSpeed * direction.normalized;
        } else {
            Attaquer();
        }

        _animator.SetBool("isAttacking", _lastAttackTime > Time.time);

        if (Stats.Health <= 0) { // Mourrir
            _animator.SetBool("isDead", true);
        }

    }

    // Se déclenche à la fin de l'annimation de mort
    public void Event_Mort() {
        SpawnCollectableXp();
        Destroy(gameObject);
    }

    private float _lastAttackTime = 0f;
    private void Attaquer() {
        if (Time.time < _lastAttackTime) {
            // Limite la fréquence d'attaque
            return;
        }
        _lastAttackTime = Time.time + Stats.AttackSpeed;

        _animator.SetBool("isAttacking", true);
        Player.Health -= Stats.Strength;
    }

    // Fais spawn une orbe d'XP à sa mort
    private void SpawnCollectableXp() {
        Vector3 spawnPosition = transform.position + Vector3.up * 0.8f;
        Quaternion rotation = _collectableXp.transform.rotation;
        var xp = Instantiate(_collectableXp, spawnPosition, rotation);
    }


}