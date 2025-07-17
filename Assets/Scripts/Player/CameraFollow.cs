using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform _player;
    public Vector3 Offset = new Vector3(0, 10, -5);

    void Update() {

        // La caméra suit la position du joueur
        transform.position = _player.position + Offset;

        // Freeze la rotation
        transform.rotation = Quaternion.Euler(45, 0, 0);
    }
}
