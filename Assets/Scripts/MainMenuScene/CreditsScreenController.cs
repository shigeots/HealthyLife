using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class CreditsScreenController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
        #region Private properties

        [SerializeField] private Canvas _creditsScreenCanvas;

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

        private void ShowCreditsScreen() {
            _creditsScreenCanvas.enabled = true;
        }

        private void HideCreditsScreen() {
            _creditsScreenCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClickReturnButton() {
            HideCreditsScreen();
            EventObserver.ShowMainMenuScreenEvent();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowCreditsScreenEvent += ShowCreditsScreen;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowCreditsScreenEvent -= ShowCreditsScreen;
        }

        #endregion
    }
}
