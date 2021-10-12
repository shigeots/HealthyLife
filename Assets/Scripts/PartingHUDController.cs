using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class PartingHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _partingHUDCanvas;
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

        private void ShowPartingHUDCavas() {
            if(_gameplayManager.TimePerMinute > 960) {
                Debug.Log("No tiene suficeinte tiempo");
                return;
            }
            if(_gameplayManager.EnergyForToday < 25) {
                Debug.Log("no tiene energia suficiente");
                return;
            }
            if(_gameplayManager.Money < 160) {
                Debug.Log("no tiene dinero suficiente");
                return;
            }
            
            _partingHUDCanvas.enabled = true;
        }

        private void HidePartingHUDCavas() {
            _partingHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartGoParttingActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            HidePartingHUDCavas();
        }

        public void OnClicNoButton() {
            HidePartingHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowPartingHUDEvent += ShowPartingHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowPartingHUDEvent -= ShowPartingHUDCavas;
        }

        #endregion
    }
}
