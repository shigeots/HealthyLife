using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class FridgeHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents  {

        #region Private properties

        [SerializeField] private Canvas _fridgeHUDCanvas;
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
            _fridgeDescriptionGameObject.SetActive(true);
            _fridgeHUDCanvas.enabled = true;
        }

        private void HideFridgeHUDCanvas() {
            _fridgeDescriptionGameObject.SetActive(false);
            _fridgeHUDCanvas.enabled = false;
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
