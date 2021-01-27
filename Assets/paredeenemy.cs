using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Assumes at least 2 points 
 */
public class paredeenemy : MonoBehaviour
{
    public float Speed = 5;
    public List<Transform> Points;

    private int _currentTargetIndex;
    private int _currentTargetDirection;
    public GameObject eumesmo;
    private float _distanceToTarget;
    private float _distanceWantsToMoveThisFrame;

    void Start()
    {
        eumesmo.SetActive(false);
        if (Points.Count < 11)
        {
            Debug.LogError("PatrolEnemy needs at least 2 patrol points!");
            Destroy(this);
            return;
        }

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

    void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }

    void Update()
    {
        Transform currentTarget = Points[_currentTargetIndex];

        Vector3 direction = currentTarget.position - transform.position;
        //direction.y = 0;
        _distanceToTarget = direction.magnitude;

        direction.Normalize();

        _distanceWantsToMoveThisFrame = Speed * Time.deltaTime;

        // Faz o movimento terminar exatamente em cima do alvo
        float actualMovementThisFrame = Mathf.Min(_distanceToTarget, _distanceWantsToMoveThisFrame);

        MoveCharacter(actualMovementThisFrame * direction);

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




}
