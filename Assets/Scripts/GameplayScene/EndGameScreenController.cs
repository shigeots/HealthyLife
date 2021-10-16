using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace HealthyLife {
    
    public class EndGameScreenController : MonoBehaviour {

        #region Private properties
        
        [SerializeField] private Canvas _endGameScreenCanvas;
        [SerializeField] private CanvasGroup _endGameScreenCanvasGroup;

        private const string _gameplaySceneName = "GameplayScene";
        private const string _MainMenuSceneName = "MainMenuScene";

        #endregion

        #region Protected methods

        protected void ShowEndGameScreen() {
            _endGameScreenCanvas.enabled = true;
            _endGameScreenCanvasGroup.DOFade(1, 0.7f);
        }

        #endregion

        #region Public methods

        public void OnClickPlayAgainButton() {
            SceneManager.LoadScene(_gameplaySceneName);
        }

        public void OnClickBackToMainMenu() {
            SceneManager.LoadScene(_MainMenuSceneName);
        }

        #endregion
    }
}
