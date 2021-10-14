using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class PickUpDeliveryHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
        
        #region Private properties

        [SerializeField] private Canvas _pickUpDeliveryHUDCanvas;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private ActivityHUDController _activityHUDController;
        [SerializeField] private DeliveryManCharacterController _deliveryManCharacterController;

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

        private void ShowPickUpDeliveryHUDCanvas() {
            _pickUpDeliveryHUDCanvas.enabled = true;
        }

        private void HidePickUpDeliveryHUDCanvas() {
            _pickUpDeliveryHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void OnClicCloseButton() {
            HidePickUpDeliveryHUDCanvas();
            _gameplayManager.ThereAreFood = true;
            _activityHUDController.ShowFoodDeliveryButton();
            _deliveryManCharacterController.GoToTheOutOfCameraPoint();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowPickUpDeliveryHUDEvent += ShowPickUpDeliveryHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowPickUpDeliveryHUDEvent -= ShowPickUpDeliveryHUDCanvas;
        }

        #endregion
    }
}
