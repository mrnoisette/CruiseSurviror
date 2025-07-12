using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UI_Ennemy : MonoBehaviour {

    [SerializeField] private Ennemy _ennemy;
    [SerializeField] private Transform _camera;
    [SerializeField] private Slider _slider_Health;

    void Start() {
        _slider_Health.maxValue = _ennemy.Stats.Health;
    }

    void LateUpdate() {
        transform.LookAt(_camera);
        _slider_Health.value = _ennemy.Stats.Health;
    }

}
