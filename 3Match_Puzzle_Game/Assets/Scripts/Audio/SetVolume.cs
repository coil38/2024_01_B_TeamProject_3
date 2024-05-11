using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer _audioMixer;

    public void SetLevel(float sliderValue)
    {
        _audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }
    
    public void BGMSetLevel(float sliderValue)
    {
        _audioMixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
    }
    
    public void SFXSetLevel(float sliderValue)
    {
        _audioMixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
    }
}
