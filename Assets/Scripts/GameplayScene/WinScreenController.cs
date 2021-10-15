using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class WinScreenController : EndGameScreenController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowWinScreenEvent += ShowEndGameScreen;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowWinScreenEvent -= ShowEndGameScreen;
        }

        #endregion
    }
}
