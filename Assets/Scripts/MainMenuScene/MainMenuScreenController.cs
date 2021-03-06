using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace HealthyLife {

    public class MainMenuScreenController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
        
        #region Private properties

        [SerializeField] private Canvas _mainMenuScreenCanvas;
        [SerializeField] private AudioMixer _musicAudioMixer;
        [SerializeField] private AudioMixer _soundAudioMixer;

        private const string _gameplaySceneName = "GameplayScene";

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void Start() {
            if(!PlayerPrefsUtil.GetSound()) {
                _soundAudioMixer.SetFloat("SoundVolume", -80);
            }
            if(!PlayerPrefsUtil.GetMusic()) {
                _musicAudioMixer.SetFloat("MusicVolume", -80);
            }
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowMainMenuScreen() {
            _mainMenuScreenCanvas.enabled = true;
        }

        private void HideMainMenuScreen() {
            _mainMenuScreenCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClickPlayButton() {
            SceneManager.LoadScene(_gameplaySceneName);
        }

        public void OnClickHowToPlayButton() {
            HideMainMenuScreen();
            EventObserver.ShowHowToPlayScreenEvent();
        }

        public void OnClickOptionsButton() {
            HideMainMenuScreen();
            EventObserver.ShowOptionsScreenEvent();
        }

        public void OnClickCreditsButton() {
            HideMainMenuScreen();
            EventObserver.ShowCreditsScreenEvent();
        }

        public void OnClickExitGameButton() {
            Application.Quit();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowMainMenuScreenEvent += ShowMainMenuScreen;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowMainMenuScreenEvent -= ShowMainMenuScreen;
        }

        #endregion
    }
}
