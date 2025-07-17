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

        // On applique à la vélocité du joueur (normalisée car ca allait plus vite en diagonale)
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();

        _rigidbody.linearVelocity = direction * Player.MoveSpeed;

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

}
