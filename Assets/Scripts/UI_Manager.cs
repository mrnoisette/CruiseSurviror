using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Slider _slider_Health;
    [SerializeField] private Slider _slider_XP;
    [SerializeField] private TextMeshProUGUI _txt_Level;
    [SerializeField] private TextMeshProUGUI _txt_Chrono;

    void Start()
    {
        _slider_Health.maxValue = _player.Stats.Health;
        _slider_XP.maxValue = 100;
    }

    private void LateUpdate()
    {
        _slider_Health.value = _player.Stats.Health;
        _slider_XP.value = _player.Stats.Xp;
        _txt_Level.text = $"Level : {_player.Stats.Xp}";
        _txt_Chrono.text = Math.Round(Time.timeSinceLevelLoad,2).ToString();
    }
}