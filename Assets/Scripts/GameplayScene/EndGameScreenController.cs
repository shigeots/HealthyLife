using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HealthyLife {
    
    public class EndGameScreenController : MonoBehaviour {

        #region Private properties
        
        [SerializeField] private Canvas _endGameScreenCanvas;

        private const string _gameplaySceneName = "GameplayScene";
        private const string _MainMenuSceneName = "MainMenuScene";

        #endregion

        #region Protected methods

        protected void ShowEndGameScreen() {
            _endGameScreenCanvas.enabled = true;
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
