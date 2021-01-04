using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridley2 : MonoBehaviour { 
    public float TargetDistance = 5;
public float Speed = 1;
public Transform Target;
 void hunt()
    {

    // Padrão: ir na direção do alvo
    // Padrão: ir na direção do alvo
    Vector3 direction = Target.position - transform.position;
        // direction.y = 0;
        float distanceToTarget = direction.magnitude;
        Debug.Log(direction);
    direction.Normalize();

        // Mas se ja estiver perto demais, na verdade quero fugir.
        // Inverte a direção anterior.
        if (distanceToTarget<TargetDistance)
        {
            direction = -direction;

        }










// Faz o movimento terminar exatamente em cima do alvo
float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

MoveCharacter(actualMovementThisFrame * direction);
    }


    void MoveCharacter(Vector3 frameMovement)
{
    transform.position += frameMovement;
}

    void Update(){
        hunt();


    }
}
