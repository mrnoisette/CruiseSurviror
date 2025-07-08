using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] public Player Player;

    [SerializeField] private Rigidbody _rigidbody;

    void Update() {

        bool isMoving = EnDeplacement();

        // Animations
        Player.Animator.SetBool("isMoving", EnDeplacement());

        // Regard
        if (isMoving) {
            transform.rotation = Quaternion.LookRotation(_rigidbody.linearVelocity);
        }

        // On applique à la vélocité du joueur
        _rigidbody.linearVelocity = new Vector3(
            Player.Stats.MoveSpeed * Input.GetAxis("Horizontal"),
            _rigidbody.linearVelocity.y,
            Player.Stats.MoveSpeed * Input.GetAxis("Vertical")); ;

    }

    /// <summary>
    /// Determine si le joueur est en cours de déplacement.
    /// </summary>
    /// <returns></returns>
    private bool EnDeplacement() {
        if (_rigidbody.linearVelocity.sqrMagnitude > 0.1) {
            return true;
        } else {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectable"))
            Destroy(other.gameObject);
    }
}
