using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HealthyLife {

    public class HowToPlayScreenController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _howToPlayScreenCanvas;
        [SerializeField] private TextMeshProUGUI _objectiveDescriptionText;
        [SerializeField] private TextMeshProUGUI _activitiesDescriptionText;
        [SerializeField] private TextMeshProUGUI _resourcesDescriptionText;

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
            OnClickObjectiveButton();
            _howToPlayScreenCanvas.enabled = true;
        }

        private void HideHowToPlayScreen() {
            _howToPlayScreenCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClickObjectiveButton() {
            _objectiveDescriptionText.enabled = true;
            _activitiesDescriptionText.enabled = false;
            _resourcesDescriptionText.enabled = false;
        }
        public void OnClickActivitiesButton() {
            _objectiveDescriptionText.enabled = false;
            _activitiesDescriptionText.enabled = true;
            _resourcesDescriptionText.enabled = false;
        }
        public void OnClickResourcesButton() {
            _objectiveDescriptionText.enabled = false;
            _activitiesDescriptionText.enabled = false;
            _resourcesDescriptionText.enabled = true;
        }

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
