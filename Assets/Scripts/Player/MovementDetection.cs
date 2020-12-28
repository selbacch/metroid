using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetection : MonoBehaviour {

    //Usado para limitar a quantidade de verificações feitas por OnCollisionStay.
    bool checkedCol;

    //Determina qual colisor tocou.
    public CollisionType collisionType;

    GeneralPlayerScript gps;

    private void Awake()
    {
        gps = GetComponentInParent<GeneralPlayerScript>() ?? null;
    }

    /// <summary>
    /// Verifica se a colisão é adequada com base na camada.
    /// </summary>
    /// <param name="collision">Colisão para check.</param>
    /// <returns></returns>
    bool CheckForCollision(Collider2D collision)
    {

        bool tmp = false;

        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
            tmp = true;

        return tmp;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Verifica se a colisão já foi avaliada / calculada e verifica se a colisão é um mapa.
        if (!checkedCol && CheckForCollision(collision.collider))
        {
            //Obtém a posição do vetor do primeiro contato (usada para definir a lastWallPosition).
            ContactPoint2D contact = collision.contacts[0];

            //se o colisor for o colisor de parede, será definido.
            if (collisionType == CollisionType.Wall)gps.pm.ms.lastWallPos = contact.normal;

            // Ativa o método de entrada de colisão com base no tipo de colisão.
            gps.pm.CollisionDetection_Enter(collisionType);

            //Se a colisão do mapa for inviável, o jogador não será capaz de pular dele.
            //if (collision.gameObject.layer == 9 && collisionType == CollisionType.enemy) GetComponent<Health>(). DamagePlayer();;

            //Define CHECKCol como true para evitar cálculos múltiplos desnecessários.
            checkedCol = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Verifica se a colisão é um mapa.
        if (CheckForCollision(collision.collider))
        {
            //Ativa o método de saída de colisão
            gps.pm.CollisionDetection_Exit(collisionType);

            //Define CHECKCol como false para que o script possa usar OnCollisionStay novamente.
            checkedCol = false;
        }
    }
}
