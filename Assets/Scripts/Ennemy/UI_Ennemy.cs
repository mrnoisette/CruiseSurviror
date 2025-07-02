using UnityEngine;

public class UI_Ennemy : MonoBehaviour {

    [SerializeField] private Transform _cible;

    void Update() {
        transform.LookAt(_cible);
    }
}
