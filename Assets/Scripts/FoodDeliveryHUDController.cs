using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HealthyLife {

    public class FoodDeliveryHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
    
        #region Private properties

        [SerializeField] private Canvas _foodDeliveryHUDCanvas;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private ActivityHUDController _activityHUDController;

        [SerializeField] TextMeshProUGUI _foodDeliveryDescriptionText;
        [SerializeField] TextMeshProUGUI _friedChickenDescriptionText;
        [SerializeField] TextMeshProUGUI _pizzaDescriptionText;
        [SerializeField] TextMeshProUGUI _hamburgerDescriptionText;

        #endregion

        [SerializeField] JunkFood friedChicken = new JunkFood("Fried chicken", 3, 40, 4, 20);
        [SerializeField] JunkFood pizza = new JunkFood("Pizza", 4, 50, 10, 40);
        [SerializeField] JunkFood hamburger = new JunkFood("Hamburger", 3, 60, 18, 55);

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowFoodDeliveryHUDCanvas() {
            /*
            if(_gameplayManager.TimePerMinute > 1380) {
                Debug.Log("No tiene suficeinte tiempo");
                return;
            }*/
            
            _foodDeliveryHUDCanvas.enabled = true;
        }

        private void HideFoodDeliveryHUDCanvas() {
            _foodDeliveryHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void PointerExitButton() {
            _foodDeliveryDescriptionText.enabled = true;
            _friedChickenDescriptionText.enabled = false;
            _pizzaDescriptionText.enabled = false;
            _hamburgerDescriptionText.enabled = false;
        }

        public void PointerEnterFriedChickenButton() {
            _foodDeliveryDescriptionText.enabled = false;
            _friedChickenDescriptionText.enabled = true;
        }

        public void PointerEnterPizzaButton() {
            _foodDeliveryDescriptionText.enabled = false;
            _pizzaDescriptionText.enabled = true;
        }

        public void PointerEnterHamburgerButton() {
            _foodDeliveryDescriptionText.enabled = false;
            _hamburgerDescriptionText.enabled = true;
        }

        public void OnClicFriedChickenButton() {
            _gameplayManager.StartFoodDeliveryActivity(friedChicken);
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _activityHUDController.HideFoodDeliveryButton();
            HideFoodDeliveryHUDCanvas();
        }

        public void OnClicPizzaButton() {
            _gameplayManager.StartFoodDeliveryActivity(pizza);
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _activityHUDController.HideFoodDeliveryButton();
            HideFoodDeliveryHUDCanvas();
        }

        public void OnClicHamburgerButton() {
            _gameplayManager.StartFoodDeliveryActivity(hamburger);
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _activityHUDController.HideFoodDeliveryButton();
            HideFoodDeliveryHUDCanvas();
        }

        public void OnClicCloseButton() {
            HideFoodDeliveryHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowDeliveryFoodHUDEvent += ShowFoodDeliveryHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowDeliveryFoodHUDEvent -= ShowFoodDeliveryHUDCanvas;
        }

        #endregion
    }
}
