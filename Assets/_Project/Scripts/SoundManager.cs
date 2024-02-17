using Plugins.Audio.Core;
using UnityEngine;


public class SoundManager : AudioPauseHandler
{
    [SerializeField] private SourceAudio _audioSource;
    [SerializeField] private SourceAudio _musicSource;
    [SerializeField] private bool _sloudPlayMusic;
    [SerializeField] private string _musicKey;
    
    public static bool _isShouldPlaying = true;

    public bool ShouldPlayMusic { get => _sloudPlayMusic; set => _sloudPlayMusic = value; }
    public string MusicKey { get => _musicKey; set => _musicKey = value; }
    public SourceAudio MusicSource { get => _musicSource; set => _musicSource = value; }
    public SourceAudio AudioSource { get => _audioSource; set => _audioSource = value; }


    private void Start()
    {
        
        if (ShouldPlayMusic)
        {
            PlaySound(_musicKey);
        }
        if(_isShouldPlaying == false)
        {
            MuteSound(false);
        }
    }

    public void PlaySound(string audioKey)
    {
        if (AudioSource)
            AudioSource.Play(audioKey);
    }

    public void PlayOneShot(string audioKey)
    {
        if(AudioSource)
            AudioSource.PlayOneShot(audioKey);
    }
    
    public void ToggleSound()
    {
        if(_isShouldPlaying)
        {
            MuteSound(false);
        }
        else
        {
            UnmuteSound(false);  
        }
    }

    public void MuteSound(bool isAds)
    {
        if(!isAds)
        {
           
            _isShouldPlaying = false;
        }

        if (MusicSource)
            MusicSource.Mute = true;

        if (AudioSource)
            AudioSource.Mute = true;
        Debug.Log("Звук выключен");

    }
    public void UnmuteSound(bool isAds)
    {
        if(!isAds)
        {
            _isShouldPlaying = true;
            if (MusicSource)
                MusicSource.Mute = false;
            if (AudioSource)
                AudioSource.Mute = false;
            //AudioListener.pause = false;
            Debug.Log("Звук включен");
        }
        else
        {
            if(_isShouldPlaying)
            {
                if (MusicSource)
                    MusicSource.Mute = false;
                if (AudioSource)
                    AudioSource.Mute = false;
                //AudioListener.pause = false;
                Debug.Log("Звук включен");
            }
        }
       

    }
}
