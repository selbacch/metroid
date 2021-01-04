using UnityEngine;

public class GeneralPlayerScript : MonoBehaviour {

    [HideInInspector] public bool isRight;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public PlayerMovement pm;
    [HideInInspector] public AnimationController ac;
    public Animator CAnimation;

    // Use isto para inicialização
    void Start () {
        rb = GetComponent<Rigidbody2D>() ?? null;
        pm = GetComponent<PlayerMovement>() ?? null;
        ac = GetComponent<AnimationController>() ?? null;
        CAnimation = GetComponent<Animator>();



    }

    public void RotatePlayer(float dir)
    {
        //Se o jogador for virado para a direita e se mover para a esquerda e vice-versa, o eixo Y do jogador será girado em 180 fazendo um "flip"
        if ((isRight && dir < 0) || (!isRight && dir > 0))
        {


            transform.Rotate(0, 180, 0);

            //Define isRight para o oposto do que era.
            isRight = !isRight;
        }
    }
}
