using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class HowToPlayScreenController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _howToPlayScreenCanvas;

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

        private void ShowHowToPlayScreen() {
            _howToPlayScreenCanvas.enabled = true;
        }

        private void HideHowToPlayScreen() {
            _howToPlayScreenCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClickReturnButton() {
            HideHowToPlayScreen();
            EventObserver.ShowMainMenuScreenEvent();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowHowToPlayScreenEvent += ShowHowToPlayScreen;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowHowToPlayScreenEvent -= ShowHowToPlayScreen;
        }

        #endregion

    }
}
