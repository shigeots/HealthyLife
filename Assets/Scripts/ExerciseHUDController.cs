using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class ExerciseHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _exerciseHUDCanvas;

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

        private void ShowExerciseHUDCavas() {
            _exerciseHUDCanvas.enabled = true;
        }

        private void HideExerciseHUDCavas() {
            _exerciseHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicNoButton() {
            HideExerciseHUDCavas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowExerciseHUDEvent += ShowExerciseHUDCavas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowExerciseHUDEvent -= ShowExerciseHUDCavas;
        }

        #endregion
    }
}
