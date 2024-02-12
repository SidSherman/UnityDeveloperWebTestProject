using TMPro;
using UnityEngine;

namespace YG
{
    public class Saver : MonoBehaviour
    {
        [SerializeField] PlayerState _playerState;

        private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
        private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

        private void Awake()
        {
            if (YandexGame.SDKEnabled)
                GetLoad();
        }

        public void Save()
        {

            YandexGame.savesData.score = _playerState.CurrentScore;
            YandexGame.SaveProgress();
        }

        public void Load() => YandexGame.LoadProgress();

        public void GetLoad()
        {
            _playerState.CurrentScore = YandexGame.savesData.score;
        }

        public void DeleteSaves()
        {
            YandexGame.ResetSaveProgress();
        }
    }
}