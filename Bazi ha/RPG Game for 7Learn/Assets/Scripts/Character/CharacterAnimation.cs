using UnityEngine;

public enum CharacterState { Idle, Run, Attack, Dead }

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private CharacterState state;
    [SerializeField] private Animator anim;

    public bool run;
    public bool attack;
    public bool isDead;

    private void Update()
    {
        anim.SetBool("Run", run);
        anim.SetBool("Attack", attack);
        anim.SetBool("isDead", isDead);
    }
}
