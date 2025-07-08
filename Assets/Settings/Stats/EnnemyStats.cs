using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyStats", menuName = "Scriptable Objects/EnnemyStats")]
public class EnnemyStats : ScriptableObject {

    public int Health;
    public int Strength;
    public int MoveSpeed;
    public float AttackSpeed;
    public float AttackRange;

}
