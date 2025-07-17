using System;
using UnityEngine;

public class Popup_Manager : MonoBehaviour {

    [SerializeField] private GameObject _popup_GameOver;
    [SerializeField] private GameObject _popup_LevelUp;

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
            _popup_GameOver.gameObject.SetActive(true);
        }

    }

    public void LevelUp(object sender, EventArgs e) {
        _popup_LevelUp.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
