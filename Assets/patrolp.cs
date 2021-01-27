using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolp : MonoBehaviour
{public GameObject eumesmo;
    public float Speed = 1;
    public List<Transform> Points;
    public float TargetDistance = 5;
    public bool pat = false;
    public bool hut = false;
    public Transform Target;
    private int _currentTargetIndex;
    private int _currentTargetDirection;
    private Animator CAnimation;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;
    public GameObject tiro;
    public Transform point;
    void Start()
    {
        
    eumesmo.SetActive(false);
    pat = true;
        if (Points.Count < 2)
        {
            Debug.LogError("PatrolEnemy needs at least 2 patrol points!");
            Destroy(this);
            return;
        }
        CAnimation = GetComponent<Animator>();
        _currentTargetIndex = 0;
        _currentTargetDirection = +1;




    }

    bool HasReachedTarget()
    {
        // return transform.position == _currentTarget.position; // NOPE.

        // Take 2
        //return Vector3.Distance(transform.position, _currentTarget.position) < 0.1f; // NOPE. Diferença em Y

        // Take 3 - Funciona, mas não é o ideal
        //Vector3 diffToTarget = transform.position - _currentTarget.position;
        //diffToTarget.y = 0;
        //return diffToTarget.magnitude < 0.1f;

        // Take 4 - Funciona sempre
        return _distanceWantsToMoveThisFrame >= _distanceToTarget;
    }

    void MoveCharacterp(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    void Update()
    {
        if (pat == true && hut==false ) { patrol();   }

        if (hut == true && pat == false)
        {
            
            hunt();
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().curHealth <= 0)
        {
            pat = true;
        }

    }



    void patrol()
    {
        Transform currentTarget = Points[_currentTargetIndex];

        Vector3 direction = currentTarget.position - transform.position;
        direction.x = 0;
        direction.z = 0;
        _distanceToTarget = direction.magnitude;

        direction.Normalize();

        _distanceWantsToMoveThisFrame = Speed * Time.deltaTime;

        // Faz o movimento terminar exatamente em cima do alvo
        float actualMovementThisFrame = Mathf.Min(_distanceToTarget, _distanceWantsToMoveThisFrame);

        MoveCharacterp(actualMovementThisFrame * direction);

        if (HasReachedTarget())
        {
            //_currentTargetIndex = (_currentTargetIndex + 1) % Points.Count;

            _currentTargetIndex += _currentTargetDirection;
            if (_currentTargetIndex == Points.Count - 1 || _currentTargetIndex == 0)
            {

                _currentTargetDirection *= -1;

            }
        }
    }

    void hunt()
    {
        Vector3 direction = Target.position - transform.position;
        direction.x = 0;
        direction.z = 0;
        float distanceToTarget = direction.magnitude;
        
        direction.Normalize();

        // Mas se ja estiver perto demais, na verdade quero fugir.
        // Inverte a direção anterior.
        if (distanceToTarget < TargetDistance)
        {
            direction = -direction;

        }


        if (distanceToTarget == TargetDistance)
        {
            
            CAnimation.SetBool("shot", true);
        }







        // Faz o movimento terminar exatamente em cima do alvo
        float distanceWantsToMoveThisFrame = Speed * Time.deltaTime;
        float actualMovementThisFrame = Mathf.Min(Mathf.Abs(distanceToTarget - TargetDistance), distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);
    }
    void shot() { GameObject CloneTiro = Instantiate(tiro, point.position, point.rotation); }
    void shotoff() { CAnimation.SetBool("shot", false); }


    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hut = true;
            pat = false;
        }



    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hut = false;
            pat = true;
        }



    }

}







