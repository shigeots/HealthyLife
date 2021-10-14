using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HealthyLife {

    public class OptionsScreenController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _optionsScreenCanvas;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Toggle _englishToggle;
        [SerializeField] private Toggle _spanishToggle;

        private const string _englishLanguage = "English";
        private const string _spanishLanguage = "Spanish";

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void Start() {
            SetOptionData();
        }

        private void Update() {
            CheckLanguageToggle();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowOptionsScreen() {
            SetOptionData();
            _optionsScreenCanvas.enabled = true;
        }

        private void HideOptionsScreen() {
            SetOptionData();
            _optionsScreenCanvas.enabled = false;
        }

        private void SetOptionData() {

            if(PlayerPrefsUtil.GetSound()) {
                _soundToggle.isOn = true;
            }
            if(PlayerPrefsUtil.GetMusic()) {
                _musicToggle.isOn = true;
            }
            if(PlayerPrefsUtil.GetLanguage() == _spanishLanguage) {
                _spanishToggle.isOn = true;
            } else {
                _englishToggle.isOn = true;
            }
        }

        private void SetConfiguration() {
            if(_soundToggle.isOn == true) {
                PlayerPrefsUtil.SetSound(true);
            } else {
                PlayerPrefsUtil.SetSound(false);
            }
            if(_musicToggle.isOn == true) {
                PlayerPrefsUtil.SetMusic(true);
            } else {
                PlayerPrefsUtil.SetMusic(false);
            }
            if(_englishToggle.isOn == true) {
                PlayerPrefsUtil.SetLanguage(_englishLanguage);
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll(_englishLanguage);
            } else {
                PlayerPrefsUtil.SetLanguage(_spanishLanguage);
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll(_spanishLanguage);
            }
        }

        private void CheckLanguageToggle() {
            if(_englishToggle.isOn == true) {
                _englishToggle.interactable = false;
                _spanishToggle.interactable = true;
            } else {
                _englishToggle.interactable = true;
                _spanishToggle.interactable = false;
            }
        }

        #endregion

        #region Public methods

        public void OnClickChangeButton() {
            SetConfiguration();
            HideOptionsScreen();
            EventObserver.ShowMainMenuScreenEvent();
        }

        public void OnClickReturnButton() {
            HideOptionsScreen();
            EventObserver.ShowMainMenuScreenEvent();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowOptionsScreenEvent += ShowOptionsScreen;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowOptionsScreenEvent -= ShowOptionsScreen;
        }

        #endregion
    }
}
