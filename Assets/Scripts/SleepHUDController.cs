using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class SleepHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _sleepHUDCanvas;

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

        private void ShowSleepHUDCavas() {
            _sleepHUDCanvas.enabled = true;
        }

        private void HideSleepHUDCavas() {
            _sleepHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicNoButton() {
            HideSleepHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowSleepHUDEvent += ShowSleepHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowSleepHUDEvent -= ShowSleepHUDCavas;
        }

        #endregion
    }
}
