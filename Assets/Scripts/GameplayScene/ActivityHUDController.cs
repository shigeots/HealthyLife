using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class ActivityHUDController : MonoBehaviour {

        #region Private properties

        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private DeliveryManCharacterController _deliveryManCharacterController;
        [SerializeField] private WarningMessageHUDController _warningMessageHUDController;

        [SerializeField] private GameObject _foodDeliveryButton;
        [SerializeField] private GameObject _pickUpDeliveryButton;

        private const string _warningNoFoodTranslation = "WarningNoFood";
        private const string _warningThereFoodOrDeliveryTranslation = "WarningThereFoodOrDelivery";
        private const string _warningOrderNoArrivedTranslation =  "WarningOrderNoArrived";
        private const string _warningNoWorkWeekendsTranslation =  "WarningNoWorkWeekends";
        private const string _warningEnergyTranslation = "WarningEnergy";
        private const string _warningMoneyTranslation = "WarningMoney";
        private const string _warningHappinessTranslation = "WarningHappiness";
        private const string _warningTooLateTranslation = "WarningTooLate";
        

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
            if(_gameplayManager.CurrentWeekday == Weekday.Saturday || _gameplayManager.CurrentWeekday == Weekday.Sunday ) {
                _warningMessageHUDController.ShowWarningMessage(_warningNoWorkWeekendsTranslation);
                return;
            }
            if(_gameplayManager.TimePerMinute > 840) {
                _warningMessageHUDController.ShowWarningMessage(_warningTooLateTranslation);
                return;
            }
            if(_gameplayManager.EnergyForToday < 30) {
                _warningMessageHUDController.ShowWarningMessage(_warningEnergyTranslation);
                return;
            }
            if(_gameplayManager.Happiness < 20) {
                _warningMessageHUDController.ShowWarningMessage(_warningHappinessTranslation);
                return;
            }

            _playerCharacterController.AssignShowWorkHUDEvent();
            _playerCharacterController.GoToTheInnerDoor();
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
                _warningMessageHUDController.ShowWarningMessage(_warningNoFoodTranslation);
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
                _warningMessageHUDController.ShowWarningMessage(_warningThereFoodOrDeliveryTranslation);
            }
        }

        public void OnClickExerciseButton() {
            if(_gameplayManager.TimePerMinute > 1320) {
                _warningMessageHUDController.ShowWarningMessage(_warningTooLateTranslation);
                return;
            }
            if(_gameplayManager.EnergyForToday < 25) {
                _warningMessageHUDController.ShowWarningMessage(_warningEnergyTranslation);
                return;
            }
            if(_gameplayManager.Happiness < 10) {
                _warningMessageHUDController.ShowWarningMessage(_warningHappinessTranslation);
                return;
            }

            _playerCharacterController.AssignShowExerciseHUDEvent();
            _playerCharacterController.GoToTheInnerDoor();
            //_gameplayManager.StartExerciseActivity();
        }

        public void OnClickGoShoppingButton() {
            if(_gameplayManager.TimePerMinute > 1380) {
                _warningMessageHUDController.ShowWarningMessage(_warningTooLateTranslation);
                return;
            }
            if(_gameplayManager.EnergyForToday < 10) {
                _warningMessageHUDController.ShowWarningMessage(_warningEnergyTranslation);
                return;
            }

            //_gameplayManager.StartShopActivity();
            _playerCharacterController.AssignShowShoppingHUDEvent();
            _playerCharacterController.GoToTheInnerDoor();
        }

        public void OnClickGoPartingButton() {
            if(_gameplayManager.TimePerMinute > 1140) {
                _warningMessageHUDController.ShowWarningMessage(_warningTooLateTranslation);
                return;
            }
            if(_gameplayManager.Money < 100) {
                _warningMessageHUDController.ShowWarningMessage(_warningMoneyTranslation);
                return;
            }
            if(_gameplayManager.EnergyForToday < 10) {
                _warningMessageHUDController.ShowWarningMessage(_warningEnergyTranslation);
                return;
            }

            _playerCharacterController.AssignShowPartingHUDEvent();
            _playerCharacterController.GoToTheInnerDoor();
            //_gameplayManager.StartGoParttingActivity();
        }

        public void OnClickFoodDelivieryButton() {
            
            if(!_gameplayManager.ThereAreFood && !_gameplayManager.OrderedFoodDelivery) {
                _playerCharacterController.AssignShowFoodDeliveryHUDEvent();
                _playerCharacterController.GoToTheInnerDoor();
            } else {
                _warningMessageHUDController.ShowWarningMessage(_warningThereFoodOrDeliveryTranslation);
            }
            

            //_gameplayManager.StartGoParttingActivity();
        }

        public void OnClickPickUpDeliveryButton() {
            
            if(_deliveryManCharacterController.DeliveryArrived) {
                _playerCharacterController.AssignShowPickUpDeliveryHUDEvent();
                _playerCharacterController.GoToTheInnerDoor();
                _gameplayManager.OrderedFoodDelivery = false;
            } else {
                _warningMessageHUDController.ShowWarningMessage(_warningOrderNoArrivedTranslation);
            }
            

            //_gameplayManager.StartGoParttingActivity();
        }

        #endregion

    }
}
