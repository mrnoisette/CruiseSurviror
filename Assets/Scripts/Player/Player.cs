using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator Animator;

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
        if (Health <= 0) {
            Mourrir();
        }
    }

    private void Mourrir() {
        Animator.SetBool("isDead", true);
    }
}