using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace HealthyLife {

    public class WorkHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _workHUDCanvas;
        [SerializeField] private GameObject _workHUDPanel;
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

        private void ShowWorkHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = true;
            _workHUDCanvas.enabled = true;
            _workHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideWorkHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = false;
            _workHUDPanel.transform.DOScale(0, 0.5f);
            //_workHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartWorkActivity(30, 30, 600, 80);
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayInnerDoorSound();
            HideWorkHUDCanvas();
        }

        public void OnClicNoButton() {
            HideWorkHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowWorkHUDEvent += ShowWorkHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowWorkHUDEvent -= ShowWorkHUDCanvas;
        }

        #endregion
    }
}
