using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public EnnemyStats Stats;

    [SerializeField] Animator _animator;

    [SerializeField] private Player _player;

    void Start()
    {
        Stats = Instantiate(Stats);
    }

    void Update()
    {
        // On a la direction (vers où aller)
        Vector3 direction = _player.transform.position - transform.position;

        // Vers où regarder
        transform.rotation = Quaternion.LookRotation(direction);

        var distance = Vector3.Distance(transform.position, _player.transform.position);

        // Déplacement
        if (distance > Stats.AttackRange)
        {
            _animator.SetBool("isMoving", true);
            transform.position += Time.deltaTime * Stats.MoveSpeed * direction.normalized;
        }
        else // Attack
        {
            Attaquer();
        }

        _animator.SetBool("isAttacking", _lastAttackTime > Time.time);
    }


    private float _lastAttackTime = 0f;
    private void Attaquer()
    {
        if (_lastAttackTime > Time.time)
        {
            // Limite la fréquence d'attaque
            return;
        }

        _lastAttackTime = Time.time + Stats.AttackRange;

        _animator.SetBool("isAttacking", true);
        _player.Stats.Health -= Stats.Strength;
    }

}