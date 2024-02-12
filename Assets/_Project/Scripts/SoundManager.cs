using Plugins.Audio.Core;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class SoundManager : MonoBehaviour
{
    [SerializeField] private SourceAudio _audioSource;
    [SerializeField] private SourceAudio _musicSource;
    [SerializeField] private bool _sloudPlayMusic;
    [SerializeField] private string _musicKey;

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
        AudioSource.Mute = !AudioSource.Mute;
        
        if (AudioSource.IsPlaying)
        {
            //_source.Pause();
            Debug.Log("Звук выключен");
        }
        else
        {
            //_source.UnPause();
            Debug.Log("Звук включен");
        }
    }



}

/*
[CustomEditor(typeof(SoundManager))]
public class SoundManagerEditor : Editor
{


    override public void OnInspectorGUI()
    {
  
        var soundManager = target as SoundManager;
  
        soundManager.AudioSource = (SourceAudio)EditorGUILayout.ObjectField(soundManager.AudioSource, typeof(SourceAudio), true);

        soundManager.SloudPlayMusic = EditorGUILayout.BeginToggleGroup("Slould Play Music", soundManager.SloudPlayMusic);
        soundManager.MusicSource = (SourceAudio)EditorGUILayout.ObjectField(soundManager.MusicSource, typeof(SourceAudio), true);
        soundManager.MusicKey = EditorGUILayout.TextField("", soundManager.MusicKey);
        EditorGUILayout.EndToggleGroup();

    }
}*/
