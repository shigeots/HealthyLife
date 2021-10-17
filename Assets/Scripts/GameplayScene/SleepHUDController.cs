using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace HealthyLife {

    public class SleepHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _sleepHUDCanvas;
        [SerializeField] private GameObject _sleepHUDPanel;
        [SerializeField] private GameObject _blackPanel;
        [SerializeField] private CanvasGroup _blackPanelCanvasGroup;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private TextMeshProUGUI _dayText;

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void Start() {
            ShowFirstBlackPanel();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowSleepHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = true;
            _sleepHUDCanvas.enabled = true;
            _sleepHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideSleepHUDCanvas() {
            //_sleepHUDCanvas.enabled = false;
            _gameplayManager.ActivityHUDShowed = false;
            _sleepHUDPanel.transform.DOScale(0, 0.5f);
        }

        private void ShowBlackPanel() {
            _blackPanel.SetActive(true);
            _dayText.text = (_gameplayManager.Day + 1).ToString();
            _blackPanelCanvasGroup.DOFade(1, 0f).OnStepComplete(() => HideBlackPanel());
        }

        private void ShowFirstBlackPanel() {
            _blackPanel.SetActive(true);
            _dayText.text = _gameplayManager.Day.ToString();
            _blackPanelCanvasGroup.DOFade(1, 0f).OnStepComplete(() => HideBlackPanel());
        }

        private void HideBlackPanel() {
            _blackPanelCanvasGroup.DOFade(0, 1.4f).SetDelay(0.4f);
        }

        #endregion

        #region Public methods

        public void OnClicYesButton() {
            if(_gameplayManager.Day < 14) {
                ShowBlackPanel();
                _playerCharacterController.PlayWakeUpSound();
            }

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
