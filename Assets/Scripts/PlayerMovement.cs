using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Puissance = 10f;
    public float ForceRotation = 50f;
    public float Freinage = 0.98f;

    private Rigidbody _rb_player;

    void Start() {
        _rb_player = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float input_direction = Input.GetAxis("Vertical");
        float input_orientation = Input.GetAxis("Horizontal");

        // Mouvement vers l'avant
        _rb_player.AddForce(transform.forward * input_direction * Puissance, ForceMode.Acceleration);

        // Rotation manuelle (plus fiable que AddTorque)
        if (Mathf.Abs(input_orientation) > 0.1f) {
            Quaternion rotation = Quaternion.Euler(0f, input_orientation * ForceRotation * Time.fixedDeltaTime, 0f);
            _rb_player.MoveRotation(_rb_player.rotation * rotation);
        }
        // test
        // Appliquer un frein l�ger
        _rb_player.linearVelocity *= Freinage;
        _rb_player.angularVelocity *= Freinage;
    }
}
