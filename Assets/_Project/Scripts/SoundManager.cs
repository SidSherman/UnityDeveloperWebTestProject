using Plugins.Audio.Core;
using UnityEngine;


public class SoundManager : AudioPauseHandler
{
    [SerializeField] private SourceAudio _audioSource;
    [SerializeField] private SourceAudio _musicSource;
    [SerializeField] private bool _sloudPlayMusic;
    [SerializeField] private string _musicKey;
    private bool _isPlaying = true;

    public bool SloudPlayMusic { get => _sloudPlayMusic; set => _sloudPlayMusic = value; }
    public string MusicKey { get => _musicKey; set => _musicKey = value; }
    public SourceAudio MusicSource { get => _musicSource; set => _musicSource = value; }
    public SourceAudio AudioSource { get => _audioSource; set => _audioSource = value; }

    private void Start()
    {
        if(SloudPlayMusic)
        {
            PlaySound(_musicKey);
        }
    }

    public void PlaySound(string audioKey)
    {
        AudioSource.Play(audioKey);
    }

    public void PlayOneShot(string audioKey)
    {
        AudioSource.PlayOneShot(audioKey);
    }
    
    public void ToggleSound()
    {
        if(_isPlaying)
        {
            Instance.PauseAudio();
            Debug.Log("Звук выключен");
        }
        else
        {
            Instance.UnpauseAudio();
            Debug.Log("Звук включен");
        }
        _isPlaying = !_isPlaying;
       
    }
}
