using System;
using System.Collections.Generic;
using UnityEngine;

//Serializa a estrutura para que ela apareça no inspetor.
[Serializable]
public struct CustomAnimation
{
    [Header("Defina-o com o mesmo nome da animação que deseja reproduzir.")]
    public string animationName;
    
    [Space]
    [Tooltip("Este é um identificador adicional para sua animação que pode ser usado em vez de animationName.")]
    public int animationID;

    [Tooltip("Se for falso, a animação não será reproduzida se a mesma animação já tiver sido reproduzida.")]
    public bool repeatable;

    [Tooltip("Usa Debug.Log para passar informações.")]
    public bool debug;
    
    public CustomAnimation(string name, int id, bool _repeatable, bool debugable)
    {
        animationName = name;
        animationID = id;
        repeatable = _repeatable;
        debug = debugable;
    }

    //Isso substitui todos os operadores necessários (== e! =), Bem como GetHashCode e Equals para ter funcionalidade pretendida.
    #region Operator Overloads
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(CustomAnimation a, CustomAnimation b)
    {
        if (a.animationName == b.animationName && a.animationID == b.animationID)
        {
            return true;
        }
        else return false;
    }

    public static bool operator !=(CustomAnimation a, CustomAnimation b)
    {
        if (a.animationName != b.animationName || a.animationID != b.animationID)
        {
            return true;
        }
        else return false;
    }
    #endregion
}

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    //Todas as animações usadas.
    public List<CustomAnimation> Animations = new List<CustomAnimation>();

    //Animador anexado ao objeto.
    Animator anim;

    //Isso armazena a última animação que foi reproduzida no objeto atual.
    [HideInInspector] public CustomAnimation lastAnimationPlayed;

    // Use isto para inicialização
    void Start () {
        anim = GetComponent<Animator>() ?? null;
	}

    void CheckNullException()
    {
        if (anim == null)
        {
            string debugString = "Não foi possível encontrar o animador em" + gameObject.name + ", deletando " + name;
            Debug.LogWarning(debugString);

            Destroy(this);
        }
    }

    /// <summary>
    /// Plays a requested animation.
    /// </summary>
    /// <param name="animation">Animation to play.</param>
    private void PlayAnimation(CustomAnimation animation)
    {
        //Checks if PlayAnimation can be performed.
        CheckNullException();

        //Stores the animation's name into a string.
        string animationN = animation.animationName;

        if (animation == lastAnimationPlayed && !lastAnimationPlayed.repeatable)
        {
            if (lastAnimationPlayed.debug)Debug.Log("Não foi possível reproduzir a animação não repetível " + animation + " ja esta reproduzindo");
            return;
        }
        anim.Play(animationN, 0, 0.0f);

        //Sets the last animation played as the one requested.
        lastAnimationPlayed = animation;
    }

    /// <summary>
    /// Plays a requested animation by animation ID (<see cref="CustomAnimation.animationID"/>)
    /// </summary>
    /// <param name="animation">ID to request by.</param>
    public void PlayAnimation(int animation)
    {
        //Creates a predicate that finds an animation in the Animations list based on ID.
        Predicate<CustomAnimation> animToPlay = delegate (CustomAnimation ca) { return ca.animationID == animation; };
        
        CustomAnimation cusanim = Animations.Find(animToPlay);

        PlayAnimation(cusanim);
    }

    /// <summary>
    /// Plays a requested animation by animation ID (<see cref="CustomAnimation.animationName"/>)
    /// </summary>
    /// <param name="animation">Animation to request by name.</param>
    public void PlayAnimation(string animation)
    {
        //Creates a predicate that finds an animation in the Animations list based on name.
        Predicate<CustomAnimation> animToPlay = delegate (CustomAnimation ca) { return ca.animationName == animation; };

        CustomAnimation cusanim = Animations.Find(animToPlay);

        PlayAnimation(cusanim);
    }
}
