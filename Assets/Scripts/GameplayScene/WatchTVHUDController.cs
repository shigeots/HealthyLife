using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace HealthyLife {

    public class WatchTVHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents  {

        #region Private properties

        [SerializeField] private Canvas _watchTVHUDCanvas;
        [SerializeField] private GameObject _watchTVHUDPanel;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private WarningMessageHUDController _warningMessageHUDController;

        [SerializeField] private TextMeshProUGUI _watchTVDescriptionText;
        [SerializeField] private TextMeshProUGUI _30minutesDescriptionText;
        [SerializeField] private TextMeshProUGUI _1hourDescriptionText;
        [SerializeField] private TextMeshProUGUI _2hoursDescriptionText;

        private const string _warningTooLateTranslation = "WarningTooLate";

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowWatchTVHUDCanvas() { 
            _gameplayManager.ActivityHUDShowed = true;
            _watchTVHUDCanvas.enabled = true;
            _watchTVHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideWatchTVHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = false;
            _watchTVHUDPanel.transform.DOScale(0, 0.5f);
            //_watchTVHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void PointerExitButton() {
            _watchTVDescriptionText.enabled = true;
            _30minutesDescriptionText.enabled = false;
            _1hourDescriptionText.enabled = false;
            _2hoursDescriptionText.enabled = false;
        }

        public void PointerEnter30MinutesButton() {
            _watchTVDescriptionText.enabled = false;
            _30minutesDescriptionText.enabled = true;
        }

        public void PointerEnter1HourButton() {
            _watchTVDescriptionText.enabled = false;
            _1hourDescriptionText.enabled = true;
        }

        public void PointerEnter2HoursButton() {
            _watchTVDescriptionText.enabled = false;
            _2hoursDescriptionText.enabled = true;
        }

        public void OnClic30MinutesButton() {
            if(_gameplayManager.TimePerMinute > 1410) {
                _warningMessageHUDController.ShowWarningMessage(_warningTooLateTranslation);
                return;
            }

            _gameplayManager.StartWatchTV30MinutesActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayTVOnSound();
            HideWatchTVHUDCanvas();
        }

        public void OnClic1HourButton() {
            if(_gameplayManager.TimePerMinute > 1380) {
                _warningMessageHUDController.ShowWarningMessage(_warningTooLateTranslation);
                return;
            }

            _gameplayManager.StartWatchTV1HourActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayTVOnSound();
            HideWatchTVHUDCanvas();
        }

        public void OnClic2HoursButton() {
            if(_gameplayManager.TimePerMinute > 1320) {
                _warningMessageHUDController.ShowWarningMessage(_warningTooLateTranslation);
                return;
            }

            _gameplayManager.StartWatchTV2HoursActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayTVOnSound();
            HideWatchTVHUDCanvas();
        }

        public void OnClicCloseButton() {
            HideWatchTVHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowWatchTVHUDEvent += ShowWatchTVHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowWatchTVHUDEvent -= ShowWatchTVHUDCanvas;
        }

        #endregion

    }
}
