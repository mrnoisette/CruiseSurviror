using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator Animator;
    [SerializeField] private Rigidbody _rigidbody;
    public EventHandler Event_LevelUp;

    public int Health;

    private int _level;
    public int Level {
        get { return _level; }
        set {
            if (_level != value) {
                _level = value;
                Event_LevelUp?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public int Xp;
    public int MoveSpeed;

    void Update() {

        Mouvement();

        if (Health <= 0) {
            Mourrir();
        }
    }

    private void Mouvement() {
        bool isMoving = EnDeplacement();

        // Animations
        Animator.SetBool("isMoving", EnDeplacement());

        // Regard
        if (isMoving) {
            transform.rotation = Quaternion.LookRotation(_rigidbody.linearVelocity);
        }

        // On applique à la vélocité du joueur (normalisée car ca allait plus vite en diagonale)
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize();

        _rigidbody.linearVelocity = direction * MoveSpeed;
    }

    private bool EnDeplacement() {
        if (_rigidbody.linearVelocity.sqrMagnitude > 0.1) {
            return true;
        } else {
            return false;
        }
    }

    private void Mourrir() {
        Animator.SetBool("isDead", true);
    }
}