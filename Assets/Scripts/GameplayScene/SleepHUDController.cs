using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HealthyLife {

    public class SleepHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _sleepHUDCanvas;
        [SerializeField] private GameObject _sleepHUDPanel;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private PlayerCharacterController _playerCharacterController;

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

        private void ShowSleepHUDCanvas() {
            _sleepHUDCanvas.enabled = true;
            _sleepHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideSleepHUDCanvas() {
            //_sleepHUDCanvas.enabled = false;
            _sleepHUDPanel.transform.DOScale(0, 0.5f);
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartSleepActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayWakeUpSound();
            HideSleepHUDCanvas();
        }

        public void OnClicNoButton() {
            HideSleepHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowSleepHUDEvent += ShowSleepHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowSleepHUDEvent -= ShowSleepHUDCanvas;
        }

        #endregion
    }
}
