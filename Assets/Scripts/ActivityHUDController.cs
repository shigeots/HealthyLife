using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class ActivityHUDController : MonoBehaviour {

        #region Private properties

        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private DeliveryManCharacterController _deliveryManCharacterController;

        [SerializeField] private GameObject _foodDeliveryButton;
        [SerializeField] private GameObject _pickUpDeliveryButton;

        #endregion

        #region Internal methods

        internal void ShowFoodDeliveryButton()
        {
            _foodDeliveryButton.SetActive(true);
            _pickUpDeliveryButton.SetActive(false);
        }

        internal void HideFoodDeliveryButton()
        {
            _foodDeliveryButton.SetActive(false);
            _pickUpDeliveryButton.SetActive(true);
        }

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
            //_gameplayManager.StartCheckFridgeActivity();
            _gameplayManager.CheckFridge();
            _playerCharacterController.AssignShowFridgeHUDEvent();
            _playerCharacterController.GoToTheFridge();
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
            if(!_gameplayManager.ThereAreFood && !_gameplayManager.OrderedFoodDelivery) {
                //_gameplayManager.StartCookActivity();
                _playerCharacterController.AssignShowCookHUDEvent();
                _playerCharacterController.GoToTheKitchen();
            } else {
                Debug.Log("Ya tiene comida en la mesa o pidio delivery");
            }
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

        public void OnClickFoodDelivieryButton() {
            
            if(!_gameplayManager.ThereAreFood && !_gameplayManager.OrderedFoodDelivery) {
                _playerCharacterController.AssignShowFoodDeliveryHUDEvent();
                _playerCharacterController.GoToTheInnerDoor();
            } else {
                Debug.Log("Ya tiene comida en la mesa o pidio delivery");
            }
            

            //_gameplayManager.StartGoParttingActivity();
        }

        public void OnClickPickUpDeliveryButton() {
            
            if(_deliveryManCharacterController.DeliveryArrived) {
                _playerCharacterController.AssignShowPickUpDeliveryHUDEvent();
                _playerCharacterController.GoToTheInnerDoor();
                _gameplayManager.OrderedFoodDelivery = false;
            } else {
                Debug.Log("El pedido aun no ha llegado");
            }
            

            //_gameplayManager.StartGoParttingActivity();
        }

        #endregion

    }
}
