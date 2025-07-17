using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
    [SerializeField] private Player _player;

    [SerializeField] private Slider _slider_Health;
    [SerializeField] private Slider _slider_XP;
    [SerializeField] private TextMeshProUGUI _txt_Level;
    [SerializeField] private TextMeshProUGUI _txt_Chrono;

    void Start() {
        _slider_Health.maxValue = _player.Health;
        _slider_XP.maxValue = 1 + (_player.Level * 2);
    }

    private void LateUpdate() {
        _slider_Health.value = _player.Health;
        _txt_Level.text = $"Level : {_player.Level}";

        GererXP();

        _txt_Chrono.text = Math.Round(Time.timeSinceLevelLoad, 2).ToString();
    }

    private void GererXP() {
        _slider_XP.value = _player.Xp;

        if (_player.Xp >= _slider_XP.maxValue) { // A atteint le niveau sup

            // Level up
            _player.Level += 1;

            _slider_XP.maxValue = 1 + (_player.Level * 2);

            _player.Xp = 0;
            _slider_XP.value = _player.Xp;

        }

    }

}