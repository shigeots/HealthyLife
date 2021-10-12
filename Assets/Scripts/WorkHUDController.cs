using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HealthyLife {

    public class WorkHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _workHUDCanvas;
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

        private void ShowWorkHUDCavas() {
            if(_gameplayManager.TimePerMinute > 840) {
                Debug.Log("No tiene suficeinte tiempo");
                return;
            }
            if(_gameplayManager.EnergyForToday < 30) {
                Debug.Log("no tiene energia suficiente");
                return;
            }
            if(_gameplayManager.Happiness < 20) {
                Debug.Log("no tiene felicidad suficiente");
                return;
            }
            _workHUDCanvas.enabled = true;
        }

        private void HideWorkHUDCavas() {
            _workHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartWorkActivity(20, 30, 600, 80);
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            HideWorkHUDCavas();
        }

        public void OnClicNoButton() {
            HideWorkHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowWorkHUDEvent += ShowWorkHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowWorkHUDEvent -= ShowWorkHUDCavas;
        }

        #endregion
    }
}
