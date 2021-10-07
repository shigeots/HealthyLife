using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class ActivityHUDController : MonoBehaviour {

        #region Private properties

        [SerializeField] private GameplayManager _gameplayManager;

        #endregion

        #region Public methods

        public void OnClicWorkButton() {
            if(_gameplayManager.Happiness > 25 && _gameplayManager.EnergyForToday > 30) {
                _gameplayManager.StartWorkActivity(25, 30);
            } else {
                Debug.Log("Felicidad o energia insuficiente");
            }
        }

        public void OnClicCheckFridgeButton() {
            _gameplayManager.StartCheckFridgeActivity();
        }

        public void OnClicWatchTVButton() {
            _gameplayManager.StartWatchTVActivity();
        }

        public void OnClickEatButton() {
            if(_gameplayManager.ThereAreFood) {
                _gameplayManager.StartEatActivity();
            } else {
                Debug.Log("No hay comida");
            }
        }

        public void OnClickSleepButton() {
            _gameplayManager.StartSleepActivity();
        }

        public void OnClickCookButton() {
            _gameplayManager.StartCookActivity();
        }

        public void OnClickExerciseButton() {
            _gameplayManager.StartExerciseActivity();
        }

        public void OnClickGoShoppingButton() {
            _gameplayManager.StartShopActivity();
        }

        public void OnClickGoPartingButton() {
            _gameplayManager.StartGoParttingActivity();
        }

        #endregion

    }
}
