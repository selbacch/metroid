using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;

    [SerializeField] private Slider Vmusica;
    [SerializeField] private Slider Vefeito;

    private void Start()
    {
        VolumeBGM();
        VolumeSFX();
    }

    public void VolumeBGM()
    {
        masterMixer.SetFloat("Vmusica", Vmusica.value);
    }

    public void VolumeSFX()
    {
        masterMixer.SetFloat("Vefeito", Vefeito.value);
    }
}