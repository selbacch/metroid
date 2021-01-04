using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Utilities;

[System.Serializable]
public struct Constraints
{
    /// <summary>
    ///  Se verdadeiro, o objeto não será capaz de ir abaixo <see cref="MaxNegativePosition"/> ou acima <see cref="MaxPositivePosition"/>.
    /// </summary>
    public bool IsConstrained;
    public Vector2 MaxNegativePosition;
    public Vector2 MaxPositivePosition;
}

public class ConstantFollowScript : MonoBehaviour {

    [Header("Posição desejada para alcançar.")]
    public Transform target;

    public Constraints constraints;
    // Autoexplicativo, lol
    public float speed;

    [Header("Define a taxa de aceleração por distância para velocidade.")]
    public float accelerationSpeed;

    [Header("Se for falso, o accelerationSpeed ​​será ignorado.")]
    public bool accelerates = true;

    [Header("Se for falso, o objeto irá parar de se mover em direção ao alvo.")]
    public bool canMove = true;

    [Header("Se verdadeiro, a posição Z do objeto permanecerá na posição Z fixa ")]
    public bool fixedZPosition = true;

    [Rename("Posição Z fixa")]public float fixedZPos = -1;

    //Usado para verificar se o objeto pode se mover com base nas condições abaixo. (USADO SOMENTE POR ActCanFollow BOOL).
    private bool ActCanFollowFunc()
    {
        bool tmp = false;
        if (target != null && canMove) tmp = true;

        return tmp;
    }

    //Verifica se o objeto pode seguir o destino, retornando ActCanFollowFunc.
    protected bool ActCanFollow { get { return ActCanFollowFunc(); } }

	void Start () {
        // Se o alvo não foi definido, o objeto atual se tornará o alvo.
        if (target == null)
        {
            target = transform;
        }
	}
	
	void FixedUpdate () {
        OnFixed();
	}

    public virtual void OnFixed()
    {
        FollowTarget();
    }

    /// <summary>
    ///Segue a corrente <see cref="target"/>
    /// </summary>
    protected void FollowTarget()
    {
        //Se as condições não forem atendidas, o método será retornado.
        if (!ActCanFollow)
            return;

        Vector3 movement = Utilities.MoveTowardsAccelerated(transform, target, speed, accelerationSpeed * Time.smoothDeltaTime);
        // Dois flutuadores que serão fixados e como os valores do vetor.
        float clampedX = movement.x;
        float clampedY = movement.y;

        //Armazena a posição z para o bool fixedZPosition.
        float zPos = movement.z;

        // Fixa ambos os valores se IsConstained for true.


        if (constraints.IsConstrained)
        {
            clampedX = Mathf.Clamp(clampedX, constraints.MaxNegativePosition.x, constraints.MaxPositivePosition.x);
            clampedY = Mathf.Clamp(clampedY, constraints.MaxNegativePosition.y, constraints.MaxPositivePosition.y);
        }

        // Se verdadeiro, zPos será alterado para fixedZPos para fazer uma posição z fixa.
        if (fixedZPosition) { zPos = fixedZPos; }

        // Re-armazena todos os valores calculados para o vetor passado.
        movement = new Vector3(clampedX, clampedY, zPos);
        // Passa o vetor de movimento para a transformação do objeto.
        transform.position = movement;
    }

   




}
