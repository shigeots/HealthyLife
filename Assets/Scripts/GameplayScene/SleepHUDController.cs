using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class SleepHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _sleepHUDCanvas;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;

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
        }

        private void HideSleepHUDCanvas() {
            _sleepHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartSleepActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
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
