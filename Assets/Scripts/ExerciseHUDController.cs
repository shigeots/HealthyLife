using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class ExerciseHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _exerciseHUDCanvas;
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

        private void ShowExerciseHUDCavas() {
            if(_gameplayManager.TimePerMinute > 1320) {
                Debug.Log("No tiene suficeinte tiempo");
                return;
            }
            if(_gameplayManager.EnergyForToday < 30) {
                Debug.Log("no tiene energia suficiente");
                return;
            }
            
            _exerciseHUDCanvas.enabled = true;
        }

        private void HideExerciseHUDCavas() {
            _exerciseHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartExerciseActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            HideExerciseHUDCavas();
        }

        public void OnClicNoButton() {
            HideExerciseHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowExerciseHUDEvent += ShowExerciseHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowExerciseHUDEvent -= ShowExerciseHUDCavas;
        }

        #endregion
    }
}
