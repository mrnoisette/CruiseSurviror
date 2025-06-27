using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject {

    public int Health;
    public int Xp;
    public int Strenght;
    public int MoveSpeed;

}
