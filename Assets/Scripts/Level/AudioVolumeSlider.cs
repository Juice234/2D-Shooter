using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Start()
    {
        // Initialize the slider value with the current audio volume
        volumeSlider.value = audioSource.volume;

        // Adjusting the slider changes the volume
        volumeSlider.onValueChanged.AddListener(SetAudioVolume);
    }

    public void SetAudioVolume(float volume)
    {   
        // Source of the sound
        audioSource.volume = volume;
    }
}
