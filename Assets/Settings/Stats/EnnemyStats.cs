using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyStats", menuName = "Scriptable Objects/EnnemyStats")]
public class EnnemyStats : ScriptableObject {

    public int Health;
    public int Strenght;
    public int MoveSpeed;
    public float Range;

}
