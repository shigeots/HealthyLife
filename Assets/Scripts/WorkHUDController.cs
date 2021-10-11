using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HealthyLife {

    public class WorkHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _workHUDCanvas;

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

        private void ShowWorkHUDCavas() {
            _workHUDCanvas.enabled = true;
        }

        private void HideWorkHUDCavas() {
            _workHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicNoButton() {
            HideWorkHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowWorkHUDEvent += ShowWorkHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowWorkHUDEvent -= ShowWorkHUDCavas;
        }

        #endregion
    }
}
