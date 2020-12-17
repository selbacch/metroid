using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class chuva : MonoBehaviour
{

    [System.Serializable]
    public class configuracoes
    {
        public int maximoDeParticulas = 1000;
        public float alturaDaParticula = 5;
        public float intensidade = 10;
        public float distanciaHorizonte = 3;
        public float tamanhoDaParticula = 0.3f;
        public float velocidadeChuva = 1;
        public AudioClip somChuva;
    }
    [System.Serializable]
    public class configuracoesMaterial
    {
        public Material imagemParticula;
        [Range(0, 1)]
        public float intensidadeMaterial = 0.5f;
    }
    [System.Serializable]
    public class EfeitosChuva
    {
        public bool Neblina = false;
        public Light Luz;
        public Color corNeblina = Color.black;
        [Range(0, 1)]
        public float intensidade = 0.3f;
        public float intensidadeNeblina = 0.05f;
        public float IntensidadeSkyBox = 1;
    }
    public enum RenderMode
    {
        Billboard,
        StretchedBillBoard,
        HorizontalBillBoard,
        VerticalBillBoard,
        None,
    };
    public RenderMode ModoDeRenderizacao;
    public configuracoes configChuva;
    public EfeitosChuva ChuvaEfeitos;
    public configuracoesMaterial configMaterial;
    private bool Chovendo;
    private GameObject objetoChuva;
    private Vector3 posicaoParticula;
    private Vector3 rotacaoParticula;
    float Exposure = 0.5f;
    Color cor;
    void Awake()
    {
        objetoChuva = new GameObject();
        objetoChuva.name = "ParticulaDeChuva";
        objetoChuva.AddComponent(typeof(ParticleSystem));
        posicaoParticula = transform.position;
        objetoChuva.transform.parent = transform;
        posicaoParticula.y = configChuva.alturaDaParticula;
        objetoChuva.transform.position = posicaoParticula;
        rotacaoParticula = new Vector3(90, 0, 0);
        objetoChuva.transform.eulerAngles = rotacaoParticula;
        var p1 = objetoChuva.GetComponent<ParticleSystem>().main;
        p1.maxParticles = configChuva.maximoDeParticulas;
        p1.startSize = configChuva.tamanhoDaParticula;
        p1.simulationSpeed = configChuva.velocidadeChuva;
        var p2 = objetoChuva.GetComponent<ParticleSystem>().emission;
        p2.rateOverTime = configChuva.intensidade;
        var p3 = objetoChuva.GetComponent<ParticleSystem>().shape;
        p3.angle = 0;
        p3.radius = configChuva.distanciaHorizonte;
        ParticleSystemRenderer renderer = (ParticleSystemRenderer)objetoChuva.GetComponent<ParticleSystem>().GetComponent<Renderer>();
        renderer.material = configMaterial.imagemParticula;
        RenderSettings.fogDensity = 0;
        // Material Chuva
        cor = configMaterial.imagemParticula.color;
        cor.a = configMaterial.intensidadeMaterial;
        renderer.renderMode = ParticleSystemRenderMode.Billboard;
        GetComponent<AudioSource>().playOnAwake = true;
        GetComponent<AudioSource>().loop = true;

    }


    void Start()
    {
        ParticleSystemRenderer renderer = (ParticleSystemRenderer)objetoChuva.GetComponent<ParticleSystem>().GetComponent<Renderer>();
        renderer.material.color = cor;
        RenderSettings.fog = ChuvaEfeitos.Neblina;
        RenderSettings.fogColor = ChuvaEfeitos.corNeblina;
        //
        switch (ModoDeRenderizacao)
        {
            case RenderMode.Billboard:
                renderer.renderMode = ParticleSystemRenderMode.Billboard;
                break;
            case RenderMode.StretchedBillBoard:
                renderer.renderMode = ParticleSystemRenderMode.Stretch;
                break;
            case RenderMode.HorizontalBillBoard:
                renderer.renderMode = ParticleSystemRenderMode.HorizontalBillboard;
                break;
            case RenderMode.VerticalBillBoard:
                renderer.renderMode = ParticleSystemRenderMode.VerticalBillboard;
                break;
            case RenderMode.None:
                renderer.renderMode = ParticleSystemRenderMode.None;
                break;
        }
        GetComponent<AudioSource>().PlayOneShot(configChuva.somChuva);
    }
    void Update()
    {
        if (ChuvaEfeitos.Neblina == true)
        {
            RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, ChuvaEfeitos.intensidadeNeblina, 1 * Time.deltaTime);
            ChuvaEfeitos.Luz.intensity = Mathf.Lerp(ChuvaEfeitos.Luz.intensity, ChuvaEfeitos.intensidade, 1 * Time.deltaTime);
            RenderSettings.skybox.SetFloat("_Exposure", Exposure);
            Exposure = Mathf.MoveTowards(Exposure, ChuvaEfeitos.IntensidadeSkyBox, 0.1f * Time.deltaTime);
        }
    }
}