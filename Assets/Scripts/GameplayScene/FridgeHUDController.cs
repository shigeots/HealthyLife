using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HealthyLife {

    public class FridgeHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents  {

        #region Private properties

        [SerializeField] private Canvas _fridgeHUDCanvas;
        [SerializeField] private GameObject _fridgeHUDPanel;
        [SerializeField] private GameObject _fridgeDescriptionGameObject;
        [SerializeField] private GameplayManager _gameplayManager;

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

        private void ShowFridgeHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = true;
            _fridgeDescriptionGameObject.SetActive(true);
            _fridgeHUDCanvas.enabled = true;
            _fridgeHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideFridgeHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = false;
            _fridgeDescriptionGameObject.SetActive(false);
            _fridgeHUDPanel.transform.DOScale(0, 0.5f);
            //_fridgeHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicCloseButton() {
            HideFridgeHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowFridgeHUDEvent += ShowFridgeHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowFridgeHUDEvent -= ShowFridgeHUDCanvas;
        }

        #endregion

    }
}
