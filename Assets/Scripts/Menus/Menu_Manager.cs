using System;
using UnityEngine;

public class Menu_Manager : MonoBehaviour {

    [SerializeField] private GameObject _menu_GameOver;
    [SerializeField] private GameObject _menu_LevelUp;

    [SerializeField] private Player _player;

    void Start() {
        _player.Event_LevelUp += LevelUp;
    }

    void Update() {

        // Verif si mort
        VerifPlayerVivant();
    }

    public void VerifPlayerVivant() {
        if (_player.Health <= 0) {
            // Afficher ecran GameOver
            _menu_GameOver.gameObject.SetActive(true);
        }

    }

    public void LevelUp(object sender, EventArgs e) {
        _menu_LevelUp.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
