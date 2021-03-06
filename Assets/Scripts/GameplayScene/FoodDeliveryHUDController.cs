using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace HealthyLife {

    public class FoodDeliveryHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
    
        #region Private properties

        [SerializeField] private Canvas _foodDeliveryHUDCanvas;
        [SerializeField] private GameObject _foodDeliveryHUDPanel;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private ActivityHUDController _activityHUDController;
        [SerializeField] private WarningMessageHUDController _warningMessageHUDController;

        [SerializeField] TextMeshProUGUI _foodDeliveryDescriptionText;
        [SerializeField] TextMeshProUGUI _friedChickenDescriptionText;
        [SerializeField] TextMeshProUGUI _pizzaDescriptionText;
        [SerializeField] TextMeshProUGUI _hamburgerDescriptionText;

        #endregion

        [SerializeField] JunkFood friedChicken = new JunkFood("Fried chicken", 3, 40, 4, 25);
        [SerializeField] JunkFood pizza = new JunkFood("Pizza", 4, 50, 10, 40);
        [SerializeField] JunkFood hamburger = new JunkFood("Hamburger", 3, 60, 18, 55);

        private const string _warningMoneyTranslation = "WarningMoney";

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
            
            _gameplayManager.ActivityHUDShowed = true;
            _foodDeliveryHUDCanvas.enabled = true;
            _foodDeliveryHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideFoodDeliveryHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = false;
            _foodDeliveryHUDPanel.transform.DOScale(0, 0.5f);
            //_foodDeliveryHUDCanvas.enabled = false;
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
            if(_gameplayManager.Money < friedChicken.Cost) {
                _warningMessageHUDController.ShowWarningMessage(_warningMoneyTranslation);
                return;
            }

            _gameplayManager.StartFoodDeliveryActivity(friedChicken);
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _activityHUDController.HideFoodDeliveryButton();
            HideFoodDeliveryHUDCanvas();
        }

        public void OnClicPizzaButton() {
            if(_gameplayManager.Money < pizza.Cost) {
                _warningMessageHUDController.ShowWarningMessage(_warningMoneyTranslation);
                return;
            }
            
            _gameplayManager.StartFoodDeliveryActivity(pizza);
            _calendarHUDController.UpdateCalendarHUD();
            _gameStatsHUDController.UpdateGameStatsHUD();
            _activityHUDController.HideFoodDeliveryButton();
            HideFoodDeliveryHUDCanvas();
        }

        public void OnClicHamburgerButton() {
            if(_gameplayManager.Money < hamburger.Cost) {
                _warningMessageHUDController.ShowWarningMessage(_warningMoneyTranslation);
                return;
            }
            
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
