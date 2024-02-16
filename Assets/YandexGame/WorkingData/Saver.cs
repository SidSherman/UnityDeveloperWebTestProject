using TMPro;
using UnityEngine;

namespace YG
{
    public class Saver : MonoBehaviour
    {
        [SerializeField] GameManager _gameManager;

        private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
        private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

        private void Awake()
        {
            if (YandexGame.SDKEnabled)
                GetLoad();
        }

        public void Save()
        {
            
            YandexGame.savesData.score = _gameManager.CurrentScore;
            YandexGame.SaveProgress();
        }

        public void Load() => YandexGame.LoadProgress();

        public void GetLoad()
        {
            _gameManager.CurrentScore = YandexGame.savesData.score;
            _gameManager.UpdateUI();
        }

        public void DeleteSaves()
        {
            YandexGame.ResetSaveProgress();
            _gameManager.UpdateUI();
        }
    }
}