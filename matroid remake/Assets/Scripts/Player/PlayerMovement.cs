﻿using UnityEngine;
using UnityEngine.Utilities;
using System.Collections.Generic;

//Serialização para que você possa modificar as variáveis ​​no editor
[System.Serializable]
public class MovementStats
{

    #region Movement Vector Values
    [Tooltip("Você deve definir este vetor sem valores negativos, pois a velocidade máxima negativa é calculada automaticamente.")]
    public Vector2 maximalVelocity = Vector2.one * 16;

    //Vetor usado como 'MiddleMan' que armazena os valores de CurrentVelocity.
    private Vector2 ActVelocity { get; set; }

    public Vector2 CurrentVelocity
    {
        //Note:Não retorne CurrentVelocity, pois isso causa um estouro de pilha.
        get { return ActVelocity; }
        set
        {// Aplica o valor primeiro
            ActVelocity = value;
            // Fixa o valor com base em maximalVelocity
            #region Clamping
            float tmpX = ActVelocity.x;
            float tmpY = ActVelocity.y;

            float maxVelX = maximalVelocity.x + ActMoveSpeed;
            float maxVelY = maximalVelocity.y + jumpHeight;

            tmpX = Mathf.Clamp(tmpX, -maxVelX, maxVelX);
            tmpY = Mathf.Clamp(tmpY, -maxVelY, maxVelY);

            //Define o valor e ActVelocity com os valores fixados.
            value = ActVelocity = new Vector2(tmpX, tmpY);
            #endregion
        }
    }

    //Este vetor determina para qual direção o jogador irá pular (horizontalmente) ao pular na parede.
    [HideInInspector] public Vector2 lastWallPos;
    #endregion

    #region Keys
    // Chaves usadas para interagir
    public KeyCode leftKey = KeyCode.LeftArrow, 
        rightKey = KeyCode.RightArrow, 
        jumpKey = KeyCode.Z;
    #endregion

    [Space]

    #region Movement Speed Vars
    //Velocidade de movimento horizontal
    [Rename("Velocidade de movimento")]public float moveSpeed = 1;

    //A velocidade de movimento do jogador será aumentada temporariamente ao pular de uma parede por wallSpeedAdd.
    [Rename("velocidade horzontal do pula da parede")]public float wallSpeedAdd = 2;

    // Cada inteiro nesta lista será adicionado ao float dinâmico ActMoveSpeed ​​por meio de ActMoveSpeedFunc ().
    // Se você deseja adicionar ou remover inteiros desta lista, use o método públic void ChangeMoveSpeedAdditions (int / list valueAdd, bool add).
    [HideInInspector] private List<float> moveSpeedAdditions = new List<float>();

    /// <summary>
    /// Adiciona um valor int para <see cref="moveSpeedAdditions"/>, que modifica o movimento do jogador.
    /// </summary>
    /// <param name="valueAdd">Valor interno a adicionar.</param>
    /// <param name="add">Se for falso, ele removerá o int da lista em vez de adicioná-lo.</param>
    public void ChangeMoveSpeedAdditions(float valueAdd, bool add = true)
    {
        if (add)
        {
            moveSpeedAdditions.Add(valueAdd);
        }
        else
        {
            moveSpeedAdditions.Remove(valueAdd);
        }
    }

    /// <summary>
    ///Adiciona uma lista de valores int para <see cref="moveSpeedAdditions"/>, que modifica o movimento do jogador.
    /// </summary>
    /// <param name="valueAdd">Valor interno a adicionar.</param>
    /// <param name="add">Se for falso, ele removerá o int da lista em vez de adicioná-lo.</param>
    public void ChangeMoveSpeedAdditions(List<float> valueAdd, bool add = true)
    {
        if (add) moveSpeedAdditions.AddRange(valueAdd);
        else
        {
            foreach (int i in valueAdd)
            {
                moveSpeedAdditions.Remove(i);
            }
        }
    }

    private float ActMoveSpeedFunc()
    {
        float tmp = moveSpeed;

        //Pega todos os inteiros da lista moveSpeedAdditions e os aplica ao valor retornado.
        foreach (int i in moveSpeedAdditions)
        {
            tmp += i;
        }

        return tmp;
    }

    /// <summary>
    /// Velocidade de movimento do jogador.
    /// </summary>
    public float ActMoveSpeed { get { return ActMoveSpeedFunc(); } }
    #endregion

    #region Slide Down Wall Vars
    [Header("Determina a velocidade com que o jogador desliza pelas paredes.")]
    public float slideDownSpeed = 1;

    /// <summary>
    /// USED ONLY BY <see cref="ActSlideDownSpeed"/>.
    /// </summary>
    /// <returns></returns>
    public float ActSlideDownSpeedFunc()
    {
        float tmp = slideDownSpeed;
        tmp *= Time.smoothDeltaTime;

        return tmp;
    }

    /// <summary>
    /// Determina a velocidade com que o jogador deslizará das paredes.
    /// </summary>
    /// <returns></returns>
    public float ActSlideDownSpeed { get { return ActSlideDownSpeedFunc(); } set { slideDownSpeed = value; } }
    #endregion

    #region Jump Vars
    //Altura do salto por salto
    public float jumpHeight = 16;

    //Vezes que o jogador pode pular antes / sem bater no chão.
    public int jumpAmount = 1;

    //Usado para o número de saltos com base em jumpAmount.
    //[HideInInspector] public int currentJumps;

    /// <summary>
    /// (ONLY USED BY <see cref="ActJumpHeight"/>)
    /// </summary>
    /// <returns></returns>
    private float ActJumpHeightFunc()
    {
        float tmp = jumpHeight;

        return tmp;
    }

    /// <summary>
    /// A altura de salto do jogador.
    /// </summary>
    public float ActJumpHeight { get { return ActJumpHeightFunc(); } set { jumpHeight = value; } }

    /// <summary>
    /// (ONLY USED BY <see cref="ActCanJump"/>)
    /// </summary>
    /// <returns></returns>
    //private bool ActCanJumpFunc()
    //{
       // bool tmp = false;

        //Se o jogador não saltou a quantidade máxima de vezes, ele retornará verdadeiro
       // if (currentJumps < jumpAmount && canJump && canMove) tmp = true;

      //  return tmp;
   // }

    /// <summary>
    ///Verifica se o jogador pode pular.
    /// </summary>
   // public bool ActCanJump
    //{
    //    get { return ActCanJumpFunc(); }
    //}

    /// <summary>
    /// Verifica se o jogador pode pular de uma parede. (USED ONLY BY <see cref="ActCanWallJump"/>)
    /// </summary>
    /// <returns></returns>
    private bool ActCanWallJumpFunc()
    {
        bool tmp = false;

        if (canWallJump  && !isWallJumping) tmp = true;

        return tmp;
    }

    /// <summary>
    /// Verifica se o jogador consegue pular.
    /// </summary>
    public bool ActCanWallJump { get { return ActCanWallJumpFunc(); } }

    /// <summary>
    /// Incrementa o <see cref="currentJumps"/> valor por 1.
    /// </summary>
    //public void Jump() { currentJumps++; }

    /// <summary>
    /// Reinicia<see cref="currentJumps"/> valor para 0.
    /// </summary>
    //public void ResetJump() { currentJumps = 0; }
    #endregion

    #region Other Vars
    [Header("Determina se o jogador pode se mover (principalmente para uso cinematográfico).")]
    public bool canMove = true;

    [Header("Determina se o jogador pode pular (para uso cinematográfico ou debuffs).")]
    public bool canJump = true;

    [Header("Determina se o jogador pode pular na parede.")]
    public bool canWallJump = true;

    //Checks if the player is walljumping.
    [HideInInspector] public bool isWallJumping;

    //Checks if player is touching the ground.
    [HideInInspector] public bool isGrounded;

    /// <summary>
    /// (ONLY USED BY <see cref="ActCanMove"/>)
    /// </summary>
    /// <returns></returns>
    private bool ActCanMoveFunc()
    {
        bool tmp = false;

        if (canMove && !isWallJumping && moveSpeed > 0) tmp = true;

        return tmp;
    }

    /// <summary>
    /// Determina se o jogador pode se mover.
    /// </summary>
    public bool ActCanMove { get { return ActCanMoveFunc(); } }

   // public void ConsumeAllJumps()
    //{
    //    currentJumps = jumpAmount;
   // }

    #endregion
}

[RequireComponent(typeof(Rigidbody2D), typeof(GeneralPlayerScript))]
public class PlayerMovement : MonoBehaviour {
    
    [HideInInspector] public GeneralPlayerScript gps;
    [Header("Estatísticas de velocidade de movimento.")]
    public MovementStats ms;
    //para definir o lado do idle  toda vez que for para a esquerda ele ira mudar para true assim trocando o lado do sprite no idle 
    public bool estado = false; 
    public enum State
    {
        //O estado muda quando: O player está inativo.
        idle,

        //O estado muda quando: O jogador está se movendo.
        move,

        //O estado muda quando: O jogador está em uma parede.
        wall,

        //O estado muda quando: O player está no ar.
        fall,
    }

    [Header("Você não deve alterar este valor por meio do inspetor,")]
    [Space(-10)]
    [Header("é usado apenas para visualização do estado do jogador.")]
    [Rename("Estado de movimento atual")] public State state;
    //private void OnValidate(){ state = State.idle; }

    //Método pular.
    public delegate void PlayerJump();
    public PlayerJump playerJump;

    // Use isto para inicialização
    void Start() {
        gps = GetComponent<GeneralPlayerScript>() ?? null;
        if (gps == null)
        {
            Destroy(this);
            Debug.Log("Não foi possível encontrar GeneralPlayerScript em " + gameObject.name + ", " + name + " agora foi removido.");
            return;
        }
    }

    /// <summary>
    /// Calcula para qual direção o jogador se moverá com base na entrada.
    /// </summary>
    /// <returns></returns>
    public float DirectionGetter()
    {
        /* A direção funciona da seguinte maneira:
         * Se a direção for igual a 0, o player é considerado inativo.
         * Se a direção for igual a 1, o jogador se moverá para a direita.
         * se a direção for igual a -1, o jogador se moverá para a esquerda.
         * (Usado pelo método MovePlayer.)
         */
        float tmp = 0;
        if (Input.GetKey(ms.leftKey) && Input.GetKey(ms.rightKey)) { tmp = 0; }
        else if (Input.GetKey(ms.leftKey)) { tmp = -1; }
        else if (Input.GetKey(ms.rightKey)) { tmp = 1; }
        else { tmp = 0; }

        return tmp;
    }

    // A atualização é chamada uma vez por quadro
    private void Update() {
        //Calcula a direção em que o jogador se moverá. (Com base em entrada)
        float direction = DirectionGetter();

        //Método de chamadas que gerencia o movimento do jogador através da flutuação de direção.
        MovePlayer(direction);

        if (Input.GetKeyDown(ms.jumpKey) && playerJump != null)
        {
            playerJump();
        }
    }

    private void FixedUpdate()
    {
        //Define o Vector2 CurrentVelocity que gerencia a velocidade do corpo.
        ms.CurrentVelocity = new Vector2(ms.CurrentVelocity.x, ms.CurrentVelocity.y);

        //Aplica-se ao corpo 
        gps.rb.velocity = ms.CurrentVelocity;

        //Isso dá o efeito "Deslizar para baixo" nas paredes.
        if (state == State.wall) transform.Translate(Vector2.down * ms.ActSlideDownSpeed);
    }

    /// <summary>
    /// Verifica qual método deve ser adicionado e / ou removido do  playerJump.
    /// </summary>
    private void PlayerJumpCheck()
    {
        if (state == State.wall)
        {
            

           // Adiciona WallJump e remove GroundJump do playerJump.
            if (!ContainsMethod("Wall")) playerJump += WallJump;
            if (ContainsMethod("Ground")) playerJump -= GroundJump;
        }
        else
        {
            //O oposto para qualquer outra situação
            if (ContainsMethod("Wall")) playerJump -= WallJump;
            if (!ContainsMethod("Ground")) playerJump += GroundJump;
        }
    }

    /// <summary>
    /// Verifica se playerJump contém um método de salto.
    /// </summary>
    /// <param name="which">0 = <see cref="GroundJump"/>, 1 = <see cref="WallJump"/></param>
    /// <returns></returns>
    private bool ContainsMethod(int which)
    {
        bool tmp = false;
        if (playerJump == null) return false;

        //Verifica cada método em playerJump e verifica se o método corresponde.
        foreach (PlayerJump method in playerJump.GetInvocationList())
        {
            if ((method == WallJump && which == 1) || (method == GroundJump && which == 0)) tmp = true;
        }

        return tmp;
    }

    private bool ContainsMethod(string name)
    {
        //Define int para ContainsMethod (int) com base em um valor de string.
        int setter = 0;
        if (name.Contains("Wall")) setter = 1;

        return ContainsMethod(setter);
    }

    private void WallJump()
    {
        if (!ms.ActCanWallJump)
            return;

        //Determina a direção para a qual o jogador irá pular (horizontal)
        float dir = 1;
        if (ms.lastWallPos.x < 0) dir = -1;

        //Define a velocidade (velocidade máxima do Counts Movement Stats sem ignorá-la).
        Vector2 setter = new Vector2(ms.ActMoveSpeed * dir * ms.maximalVelocity.x, ms.ActJumpHeight);

        //Impede o jogador de se mover para evitar o salto instantâneo da parede.
        ms.isWallJumping = true;

        //Aplica a velocidade.
        SetVelocity(setter, false);

        //Adiciona ao contador de pulos.
       // ms.Jump();
        float direction = DirectionGetter();
        if (direction == 1)
        {
            bool wexit = true;
            gps.ac.PlayAnimation(6);
            if (wexit != false) {
                //Reproduz animação de salto na parede

                gps.ac.PlayAnimation(4); }
        }
        if (direction == -1)
        {
            bool wexit = true;
            gps.ac.PlayAnimation(11);

            if (wexit != false)
            {
                //Reproduz animação de salto na parede para o outro lado
                gps.ac.PlayAnimation(7);
            }
        } 

        //Define isWallJumping de volta para false para tornar o jogador capaz de se mover novamente.
        Invoke("ResetWallJump", 0.1f);
    }

    //Define isWallJumping como false, o que permite que o jogador se mova novamente.
    void ResetWallJump()
    {
        ms.isWallJumping = false;
    }

    /// <summary>
    /// Método que faz o jogador pular do chão.
    /// </summary>
    private void GroundJump()
    {
        //if (!ms.ActCanJump)
           // return;
        float direction = DirectionGetter();
        if (Input.GetKey(ms.leftKey) && Input.GetKey(ms.jumpKey))
        {
            gps.ac.PlayAnimation(13);
        }
        if (Input.GetKey(ms.rightKey) && Input.GetKey(ms.jumpKey))
        {
            gps.ac.PlayAnimation(12);
        }
            //Reproduz animação de salto ao solo.
            if ( direction== 1)
        {
            gps.ac.PlayAnimation(2);
        }
        if (direction == -1)
        {
            gps.ac.PlayAnimation(9);
        }

        //Define a velocidade de salto do jogador.
        Vector2 jumpVel = new Vector2(ms.CurrentVelocity.x, ms.ActJumpHeight);

        //Passa o JumpVel para SetVelocity para modificar a velocidade do jogador.
        SetVelocity(jumpVel, false);

        //Adiciona ao contador de pulos.
        //ms.Jump();
    }

    /// <summary>
    /// Método de manipulação do movimento horizontal do jogador.
    /// </summary>
    /// <param name="direction">0 = idle, -1 = left, 1 = right.</param>
    public void MovePlayer(float direction)
    {
        if (!ms.ActCanMove)
            return;

        //0 define o player para um estado ocioso (se possível).
        if (direction == 0)
        {
            SetPlayerIdle();
            return;
        }
        if(direction == 1)
        {
            estado = false;
            State moveState = State.move;
            ChangeState(moveState);

            //Joga animação de movimento
            if (state == moveState) gps.ac.PlayAnimation(1);
        }
        if(direction == -1)
        {
            estado = true;
            State moveState = State.move;
            ChangeState(moveState);

            if (state == moveState) gps.ac.PlayAnimation(5); }

        

        direction = Mathf.Clamp(direction, -1, 1);


        //Chama o "flip" do player em GeneralPlayerScript
        // gps.RotatePlayer(direction);

        //Aplica a velocidade na qual o jogador se moverá
        float directSpeed = ms.ActMoveSpeed * direction;

        //Velocidade usada para mover o jogador.
        Vector2 moveVelocity = new Vector2(directSpeed, gps.rb.velocity.y);

        //Aplica moveVelocity ao corpo rígido do jogador pelo método SetVelocity.
        SetVelocity(moveVelocity, false);
    }

    private void SetPlayerIdle()
    {
        ChangeState(State.idle);

        //Define a velocidade x do jogador em 0 para evitar qualquer patinação no gelo.
        SetVelocity(new Vector2(0, gps.rb.velocity.y), false);
        float tmp1 = 0;
        

        if (state == State.idle)
        {

            if (estado == false)
            {
                gps.ac.PlayAnimation(0);
                //if (tmp1 == -1) if (state == moveState) gps.ac.PlayAnimation(10);
            }
            else if (estado != false)
            {
                gps.ac.PlayAnimation(10);
            }
        }
    



        
    }

    /// <summary>
    /// Checks if <see cref="ChangeState(State)"/> pode mudar de estado. (ONLY USED BY <see cref="ChangeState(State)"/>)
    /// </summary>
    /// <param name="stateToGive">State to check.</param>
    /// <returns></returns>
    private bool CanChangeState(State stateToGive)
    {
        bool tmp = false;
        if ((state != stateToGive))
        {
            switch(stateToGive)
            {
                //Usado para evitar o estado inativo constante.
                case State.idle:
                    if (state == State.move || state == State.fall && ms.isGrounded)
                        tmp = true;
                    break;
                //Usado para evitar o estado de movimento constante.
                case State.move:
                    if (state == State.idle || ms.isGrounded)
                        tmp = true;
                    break;
                case State.wall:
                //Nota: Você pode cancelar o comentário se não quiser que o jogador salte na parede quando estiver no chão.
                //if (!ms.isGrounded) tmp = true;
                //break;
                default: tmp = true; break;
            }
        }
        if (tmp) PlayerJumpCheck();
        return tmp;
    }

    /// <summary>
    /// Muda o estado de <see cref="state"/> se ainda não estiver definido.
    /// </summary>
    /// <param name="stateToGive">Estado para mudar para.</param>
    private void ChangeState(State stateToGive)
    {
        if (!CanChangeState(stateToGive))
            return;
        
        state = stateToGive;
    }

    /// <summary>
    /// Define o vetor usado para aplicar velocidade ao jogador.
    /// </summary>
    /// <param name="velocityToGive">Velocidade para aplicar.</param>
    /// <param name="additive">Se verdadeiro, a velocidade será adicionada ao vetor em vez de definir / substituir.</param>
    public void SetVelocity(Vector2 velocityToGive, bool additive)
    {
        if (additive) velocityToGive = new Vector2(velocityToGive.x + ms.CurrentVelocity.x, velocityToGive.y + ms.CurrentVelocity.y);

        ms.CurrentVelocity = velocityToGive;
    }

    /// <summary>
    ///A colisão de chamadas insere o código com base no tipo de colisão. (Chamado principalmente por MovementDetection nos coletores do jogador)
    /// </summary>
    /// <param name="col">Collision type.</param>
    public void CollisionDetection_Enter(CollisionType col)
    {
        switch (col)
        {
            case CollisionType.Ground:
                GroundEnter();
                break;
            case CollisionType.Wall:
                WallEnter();
                break;
        }

        //Define o tipo de salto a ser aplicado ao  playerJump.
        PlayerJumpCheck();
    }

    /// <summary>
    /// Chama o código de saída de colisão com base no tipo de colisão. (Chamado principalmente por MovementDetection nos coletores do jogador)
    /// </summary>
    /// <param name="col">Collision type.</param>
    public void CollisionDetection_Exit(CollisionType col)
    {
        switch (col)
        {
            case CollisionType.Ground:
                GroundExit();
                break;
            case CollisionType.Wall:
                WallExit();
                break;
        }

        //Isso consome um salto ao sair da colisão. (Isto é para tornar o jogador capaz de pular no ar quando não estiver pulando e
        // caindo de um penhasco (por exemplo)).
        //ms.Jump();

        //Define o tipo de salto a ser aplicado ao delegado playerJump.
        PlayerJumpCheck();
    }

    //Todos os métodos de colisão chamados por CollisionDetection_ (Exit / Enter).
    #region Collision Methods

    /// <summary>
    /// Chamado quando o jogador colide com o colisor de solo.
    /// </summary>
    void GroundEnter()
    {
        //Define o bool verificando se o jogador está tocando o solo.
        ms.isGrounded = true;

        //Muda o estado para inativo (se o player estiver se movendo, ele mudará automaticamente para o estado de movimento).
        ChangeState(State.idle);

        //Redefine o contador de saltos para 0 para permitir que o jogador salte.
       // ms.ResetJump();

        //Remove o aumento de velocidade horizontal temporário ao pular de uma parede.
        ms.ChangeMoveSpeedAdditions(ms.wallSpeedAdd, false);
    }

    /// <summary>
    /// Chamado quando o jogador sai de uma colisão com o colisor de solo.
    /// </summary>
    void GroundExit()
    {
        //Define o bool verificando se o jogador está tocando o solo.
        ms.isGrounded = false;

        //Muda de estado para cair
        ChangeState(State.fall);




//Reproduz a animação do salto, mas serve para evitar que o jogador reproduza a animação em execução
         //no ar ao cair de um penhasco.
         //O método de salto também reproduz esta animação. 
       gps.ac.PlayAnimation(2);
    }

    /// <summary>
    /// Chamado quando o colisor principal colide com o mapa.
    /// </summary>
    void WallEnter()
    {
        //Define uma referência para fins de desempenho.
        State wallState = State.wall;

        //Muda de estado para parede
        ChangeState(wallState);

        //Reinicia o contador de saltos para permitir ao jogador saltar.
       // ms.ResetJump();

        //Reproduz a animação de fixação na parede (se possível)
        if (state == wallState)
        {
            float direction = DirectionGetter();

            if (direction == 1)   gps.ac.PlayAnimation(3);
        

        if (direction == -1) gps.ac.PlayAnimation(8);
        
            


        }
        //Remove o aumento de velocidade horizontal temporário ao pular de uma parede.
        ms.ChangeMoveSpeedAdditions(ms.wallSpeedAdd, false);

    }

    /// <summary>
    /// Chamado quando o colisor principal sai de uma colisão com o mapa.
    /// </summary>
    void WallExit()
    {
        State fallState = State.fall;
        //Mudanças de estado vão cair. (A animação de salto de parede é reproduzida no método wallJump no delegado playerJump).
        ChangeState(fallState);

        //Reproduz animação apenas se o jogador não estiver aterrado (Não reproduz se o jogador estiver na parede e ao mesmo tempo no chão).
        if (state == fallState) gps.ac.PlayAnimation(4);

        //Adiciona o aumento de velocidade horizontal temporário ao pular de uma parede.
        ms.ChangeMoveSpeedAdditions(ms.wallSpeedAdd);
    }
    #endregion
}