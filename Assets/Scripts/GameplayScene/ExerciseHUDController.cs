using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HealthyLife {

    public class ExerciseHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _exerciseHUDCanvas;
        [SerializeField] private GameObject _exerciseHUDPanel;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private PlayerCharacterController _playerCharacterController;

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
            DOTween.Init();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowExerciseHUDCanvas() {
            if(_gameplayManager.TimePerMinute > 1320) {
                Debug.Log("No tiene suficeinte tiempo");
                return;
            }
            if(_gameplayManager.EnergyForToday < 30) {
                Debug.Log("no tiene energia suficiente");
                return;
            }
            
            _exerciseHUDCanvas.enabled = true;
            _exerciseHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideExerciseHUDCanvas() {
            _exerciseHUDPanel.transform.DOScale(0, 0.5f);
            //_exerciseHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartExerciseActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayInnerDoorSound();
            HideExerciseHUDCanvas();
        }

        public void OnClicNoButton() {
            HideExerciseHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowExerciseHUDEvent += ShowExerciseHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowExerciseHUDEvent -= ShowExerciseHUDCanvas;
        }

        #endregion
    }
}
