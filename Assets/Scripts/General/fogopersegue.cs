using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogopersegue : MonoBehaviour
{


    public float Speed = 1;
    public Transform Target;


    public float TargetDistance = 5;






    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hunt();
    }




    void hunt()
    {
        Vector3 direction = Target.position - transform.position;
        direction.y = 0;
        float distanceToTarget = direction.magnitude;

        direction.Normalize();



        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);



        void MoveCharacter(Vector3 frameMovement)
        {
            transform.position += frameMovement;
        }
    }
}






