using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class EatHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
        
        #region Private properties

        [SerializeField] private Canvas _eatHUDCanvas;
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

        private void ShowEatHUDCanvas() {
            if(_gameplayManager.TimePerMinute > 1420) {
                Debug.Log("No tiene suficeinte tiempo");
                return;
            }
            if(!_gameplayManager.ThereAreFood) {
                Debug.Log("no tiene comida");
                return;
            }

            _eatHUDCanvas.enabled = true;
        }

        private void HideEatHUDCanvas() {
            _eatHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartEatActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayEatSound();
            HideEatHUDCanvas();
        }

        public void OnClicNoButton() {
            HideEatHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowEatHUDEvent += ShowEatHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowEatHUDEvent -= ShowEatHUDCanvas;
        }

        #endregion
    }
}
