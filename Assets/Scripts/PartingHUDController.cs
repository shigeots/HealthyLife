using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class PartingHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _partingHUDCanvas;

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

        private void ShowPartingHUDCavas() {
            _partingHUDCanvas.enabled = true;
        }

        private void HidePartingHUDCavas() {
            _partingHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicNoButton() {
            HidePartingHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowPartingHUDEvent += ShowPartingHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowPartingHUDEvent -= ShowPartingHUDCavas;
        }

        #endregion
    }
}
