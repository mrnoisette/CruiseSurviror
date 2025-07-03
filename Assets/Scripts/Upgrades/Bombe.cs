using System;
using UnityEngine;

public class Bombe : MonoBehaviour {

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _bombe_Prefab;

    public float DiametreExplosion;
    public float Degat;
    public float Frequence; 

    void Start() {
        var instanceRequin = Instantiate(_bombe_Prefab, _player.transform);
    }

    void Update() {

    }
}
