using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HealthyLife {

    public class PartingHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _partingHUDCanvas;
        [SerializeField] private GameObject _partingHUDPanel;
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

        private void ShowPartingHUDCanvas() {

            _gameplayManager.ActivityHUDShowed = true;
            _partingHUDCanvas.enabled = true;
            _partingHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HidePartingHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = false;
            _partingHUDPanel.transform.DOScale(0, 0.5f);
            //_partingHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            _gameplayManager.StartGoParttingActivity();
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _playerCharacterController.PlayInnerDoorSound();
            HidePartingHUDCanvas();
        }

        public void OnClicNoButton() {
            HidePartingHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowPartingHUDEvent += ShowPartingHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowPartingHUDEvent -= ShowPartingHUDCanvas;
        }

        #endregion
    }
}
