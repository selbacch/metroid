using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Utilities
{
    public static class Utilities
    {

        /// <summary>
        ///Move a em direção a b com base na velocidade, acelerando quanto mais os dois vetores estão separados.
        /// </summary>
        /// <param name="a">Posição atual.</param>
        /// <param name="b">TPosição alvo.</param>
        /// <param name="speed"> Velocidade de viagem.</param>
        /// <param name="acceleration">Taxa de aceleração de velocidade por distância.</param>
        /// <returns><see cref="Vector2"/></returns>
        public static Vector2 MoveTowardsAccelerated(Vector2 a, Vector2 b, float speed, float acceleration)
        {
            float accTmp = acceleration * Vector2.Distance(a, b);
            float actSpeed = speed + accTmp;
            Vector2 move = Vector2.MoveTowards(a, b, actSpeed);

            return move;
        }

        public static Vector2 MoveTowardsAccelerated(Transform a, Transform b, float speed, float acceleration)
        {
            Vector2 move = MoveTowardsAccelerated(a.position, b.position, speed, acceleration);

            return move;
        }

        /// <summary>
        /// Move a para b pela velocidade.
        /// </summary>
        /// <param name="a">Valor atual.</param>
        /// <param name="b">Valor alvo.</param>
        /// <param name="speed">Velocidade pela qual a se moverá em direção a b.</param>
        /// <returns></returns>
        public static float MoveTowards(float a, float b, float speed)
        {
            float tmp = 0;
            Vector2 x1 = new Vector2(a, 0), x2 = new Vector2(b, 0);
            Vector2 x3 = Vector2.MoveTowards(x1, x2, speed);

            tmp = x3.x;

            return tmp;
        }

        /// <summary>
        /// Verifies if <see cref="NumberToApproximate"/> is approximately <see cref="NumberToCompare"/> by <see cref="approximation"/>
        /// </summary>
        /// <param name="NumberToApproximate">Número para aproximar.</param>
        /// <param name="NumberToCompare">Número para comparar.</param>
        /// <param name="approximation">Número para julgar / comparar.</param>
        /// <returns> Verdadeiro se o valor de retorno for maior do que -aproximação e menor que a aproximaçãon.</returns>
        public static bool IsApproximate(float NumberToApproximate, float NumberToCompare, float approximation)
        {
            bool tmp = false;
            float tmpPos = NumberToApproximate - NumberToCompare;
            if (tmpPos < approximation && tmpPos > -approximation) tmp = true;

            return tmp;
        }
    }
}