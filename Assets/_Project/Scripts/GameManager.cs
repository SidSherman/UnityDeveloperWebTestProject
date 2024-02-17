using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _debugText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private YG.LeaderboardYG _leaderboard;
    [SerializeField] private YG.YandexGame _yandexGame;
    [SerializeField] private YG.Saver _saver;
   

    private int _currentScore;

    public int CurrentScore { get => _currentScore; set => _currentScore = value; }

    private void OnEnable()
    {
       // YG.YandexGame.GetDataEvent += OnGameInit;
        YG.YandexGame.RewardVideoEvent += GetReward;

    }

    private void OnDisable()
    {
        YG.YandexGame.RewardVideoEvent -= GetReward;
      //  YG.YandexGame.GetDataEvent -= OnGameInit;
    }

    private void Start()
    {
        OnGameInit();
    }

    private void Update()
    {
        if(_debugText != null)
            DebugText(YG.YandexGame.timerShowAd.ToString());              
    }

    void OnGameInit()
    {
        Load();
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (_leaderboard)
        {
            _leaderboard.NewScore(_currentScore);
            _leaderboard.UpdateLB();

        }

        if (_scoreText)
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

    public void ChangeScore(int score)
    {
        _currentScore += score;
        _currentScore = (int) Mathf.Clamp(_currentScore, 0.0f , _currentScore);
        //check and fix negative value
        if (_currentScore < 0)
        {
            _currentScore = 0;
        }
       
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
        UpdateUI();

        if (_leaderboard)
        {
            _leaderboard.gameObject.SetActive(!_leaderboard.gameObject.activeInHierarchy);
        }
    }

    public void GetReward(int id)
    {
        if(id == 1)
        {
            if(_currentScore != 0)
            {
                ChangeScore(_currentScore);
            }
            else
            {
                ChangeScore(1);
            }
        }
    }


    public void DebugText(string debugText)
    {
        if (_debugText)
        {
            _debugText.text = debugText;
        }
    }

}



