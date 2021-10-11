using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class EatHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
        
        #region Private properties

        [SerializeField] private Canvas _eatHUDCanvas;

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

        private void ShowEatHUDCavas() {
            _eatHUDCanvas.enabled = true;
        }

        private void HideEatHUDCavas() {
            _eatHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicNoButton() {
            HideEatHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowEatHUDEvent += ShowEatHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowEatHUDEvent -= ShowEatHUDCavas;
        }

        #endregion
    }
}