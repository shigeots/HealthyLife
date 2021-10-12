using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class ActivityHUDController : MonoBehaviour {

        #region Private properties

        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private PlayerCharacterController _playerCharacterController;

        #endregion

        #region Public methods

        public void OnClicWorkButton() {
            if(_gameplayManager.Happiness >= 20 && _gameplayManager.EnergyForToday >= 30) {
                _playerCharacterController.AssignShowWorkHUDEvent();
                _playerCharacterController.GoToTheInnerDoor();
            } else {
                Debug.Log("Felicidad o energia insuficiente");
            }
        }

        public void OnClicCheckFridgeButton() {
            _gameplayManager.StartCheckFridgeActivity();
        }

        public void OnClicWatchTVButton() {
            _playerCharacterController.AssignShowWatchTVHUDEvent();
            _playerCharacterController.GoToTheTelevision();

            //_gameplayManager.StartWatchTVActivity();
        }

        public void OnClickEatButton() {
            if(_gameplayManager.ThereAreFood) {
                _playerCharacterController.AssignShowEatHUDEvent();
                _playerCharacterController.GoToTheTable();
                //_gameplayManager.StartEatActivity();
            } else {
                Debug.Log("No hay comida");
            }
        }

        public void OnClickSleepButton() {
            _playerCharacterController.AssignShowSleepHUDEvent();
            _playerCharacterController.GoToTheBed();
            //_gameplayManager.StartSleepActivity();
        }

        public void OnClickCookButton() {
            _gameplayManager.StartCookActivity();
        }

        public void OnClickExerciseButton() {
            _playerCharacterController.AssignShowExerciseHUDEvent();
            _playerCharacterController.GoToTheInnerDoor();
            //_gameplayManager.StartExerciseActivity();
        }

        public void OnClickGoShoppingButton() {
            _gameplayManager.StartShopActivity();
        }

        public void OnClickGoPartingButton() {
            if(_gameplayManager.Money >= 160) {
                _playerCharacterController.AssignShowPartingHUDEvent();
                _playerCharacterController.GoToTheInnerDoor();
            }
            /*
            if(_gameplayManager.CurrentWeekday == Weekday.Saturday && _gameplayManager.CurrentWeekday == Weekday.Sunday) {
                
            } else {
                Debug.Log("No es fin de semana o ");
            }
            */
            //_gameplayManager.StartGoParttingActivity();
        }

        #endregion

    }
}
