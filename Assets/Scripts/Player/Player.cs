using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerStats Stats;
    [SerializeField] public Animator Animator;

    void Start()
    {
        // Copie pour ne pas écrire dans le fichier
        Stats = Instantiate(Stats);
    }

    void Update()
    {
        if (Stats.Health <= 0)
        {
            Mourrir();
        }
    }

    private void Mourrir()
    {
        Animator.SetBool("isDead", true);

#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}