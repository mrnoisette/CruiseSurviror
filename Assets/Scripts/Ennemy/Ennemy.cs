using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public EnnemyStats Stats;

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
        
        transform.position += Time.deltaTime * Stats.MoveSpeed * direction.normalized;  
        
        var distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance <= Stats.Range)
        {
            Attaquer();
        }
        
    }

    private void Attaquer()
    {
        _player.Stats.Health -= Stats.Strenght;
    }
    
}