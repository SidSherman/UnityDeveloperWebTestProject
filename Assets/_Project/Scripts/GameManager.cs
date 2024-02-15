using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _currentScore;
    [SerializeField] YG.Saver _saver;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] YG.LeaderboardYG _leaderboard;
    [SerializeField] YG.YandexGame _yandexGame;

    public int CurrentScore { get => _currentScore; set => _currentScore = value; }

    void Start()
    {
        Load();
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(_scoreText)
        {
            _scoreText.text = string.Empty;
            _scoreText.text = _currentScore.ToString();
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
        if(_leaderboard)
        {
            _leaderboard.gameObject.SetActive(!_leaderboard.gameObject.activeInHierarchy);
        }
    }
}


