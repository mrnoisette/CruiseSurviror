using UnityEngine;

public class Ennemy : MonoBehaviour {
    public EnnemyStats Stats;

    [SerializeField] Animator _animator;

    [SerializeField] private Player _player;

    void Start() {
        Stats = Instantiate(Stats);
    }

    void Update() {
        // Vecteur de déplacement vers le joueur 
        Vector3 direction = _player.transform.position - transform.position;

        // Vers où regarder
        transform.rotation = Quaternion.LookRotation(direction);

        var distance = Vector3.Distance(transform.position, _player.transform.position);

        // Déplacement
        if (distance > Stats.AttackRange) {
            _animator.SetBool("isMoving", true);
            transform.position += Time.deltaTime * Stats.MoveSpeed * direction.normalized;
        } else // Attack
          {
            Attaquer();
        }

        _animator.SetBool("isAttacking", _lastAttackTime > Time.time);

        if (Stats.Health <= 0) { // Mourrir
            _animator.SetBool("isDead", true);
        }

    }

    public void Event_Mort() {
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
        _player.Stats.Health -= Stats.Strength;
    }

}