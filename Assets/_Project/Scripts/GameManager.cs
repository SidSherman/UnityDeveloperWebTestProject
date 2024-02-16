using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SocialPlatforms.Impl;
using YG;

public class GameManager : MonoBehaviour
{
    private int _currentScore;
    [SerializeField] YG.Saver _saver;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] YG.LeaderboardYG _leaderboard;
    [SerializeField] YG.YandexGame _yandexGame;

    public int CurrentScore { get => _currentScore; set => _currentScore = value; }

    private void OnEnable()
    {
        YG.YandexGame.GetDataEvent += OnGameInit;
        YG.YandexGame.RewardVideoEvent += GetReward;
    }

    private void OnDisable()
    {
        YG.YandexGame.RewardVideoEvent -= GetReward;
        YG.YandexGame.GetDataEvent -= OnGameInit;
    }

    private void Start()
    {
        OnGameInit();
    }

    void OnGameInit()
    {
        Load();
        SetLocale(YG.YandexGame.EnvironmentData.language);
        UpdateUI();
    }

  
    public void UpdateUI()
    {
        if (_scoreText)
        {
            _scoreText.text = string.Empty;
            _scoreText.text = _currentScore.ToString();
        }
    }

    public void SetLocale(string language)
    {
        if (LocalizationSettings.AvailableLocales.GetLocale(language))
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(language);
        }
    }

    public void Save()
    {
        if (_saver)
        {
            _saver.Save();
        }
    }

    public void Load()
    {
        if (_saver)
        {
            _saver.Load();
        }
    }

    public void ChageScore(int score)
    {
        _currentScore += score;

        Save();
        UpdateUI();
    }

    public void DeleteSaves()
    {
        if (_saver)
        {
            _saver.DeleteSaves();
            _saver.Save();
            _saver.Load();
        }
        UpdateUI();
    }

    public void ToggleLeaderboard()
    {
        if (_leaderboard)
        {
            _leaderboard.NewScore(_currentScore);
            _leaderboard.gameObject.SetActive(!_leaderboard.gameObject.activeInHierarchy);
        }
    }

    public void GetReward(int id)
    {
        if(id == 1)
        {
            ChageScore(_currentScore);
        }
    }

}



