using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Utilities;

public class CameraManager : ConstantFollowScript {

    // Nota: CameraManager é herdado de ConstantFollowScript.

    // Câmera anexada ao objeto.
    Camera cam;

    [Header("Tamanho ortográfico do alvo.")]
    public float cameraSize = 12;

    [Header("Velocidade na qual a câmera será redimensionada.")]
    [Space(-5)]
    [Header("(Aplica-se apenas ao tamanho da câmera")]
    [Space(-5)]
    [Header("é diferente do tamanho ortográfico)")]
    public float resizeSpeed = 10;

    public bool canResize = true;

    /// <resumo>
    /// Verifica se o tamanho ortográfico da câmera pode ser alterado. (USADO SOMENTE POR <ver cref = "ActCanResize" />)
    /// </summary>
    /// <param name = "aproximationValue"> Usado para evitar um efeito de vibração, desativando o redimensionamento quando próximo ao tamanho alvo </param>
    /// <returns> </returns>
    private bool ActCanResizeFunc(float approximationValue)
    {
        bool tmp = false;
        if (canResize && cam != null && !Utilities.IsApproximate(cam.orthographicSize, cameraSize, approximationValue)) tmp = true;

        return tmp;
    }

    /// <summary>
    /// Returns <see cref="ActCanResizeFunc(float)"/>.
    /// </summary>
    public bool ActCanResize { get { return ActCanResizeFunc(resizeSpeed / 10); } }

    // Use isto para inicialização
    void Start () {
        //Obtém a câmera com uma verificação nula para evitar exceções nulas.
        cam = GetComponent<Camera>() ?? null;
	}

    public override void OnFixed()
    {
        //Mantém todos os outros componentes OnFixed do FollowScript.
        base.OnFixed();

        ResizeCamera();
    }

    private void ResizeCamera()
    {
        if (!ActCanResize)
            return;

        float sizeToGive = Utilities.MoveTowards(cam.orthographicSize, cameraSize, resizeSpeed * Time.smoothDeltaTime);
        cam.orthographicSize = sizeToGive;
    }

}
