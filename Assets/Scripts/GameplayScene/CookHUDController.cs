using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace HealthyLife {

    public class CookHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _cookHUDCanvas;
        [SerializeField] private GameObject _cookHUDPanel;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private ActivityHUDController _activityHUDController;
        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private WarningMessageHUDController _warningMessageHUDController;

        [SerializeField] TextMeshProUGUI _cookDescriptionText;
        [SerializeField] TextMeshProUGUI _saladDescriptionText;
        [SerializeField] TextMeshProUGUI _panSearedChickenDescriptionText;
        [SerializeField] TextMeshProUGUI _panSearedFishDescriptionText;

        private const string _warningIngredientsTranslation = "WarningIngredients";

        #endregion

        #region Internal properties
        
        [SerializeField] internal HealthyFood salad;
        [SerializeField] internal HealthyFood panSearedChicken;
        [SerializeField] internal HealthyFood panSearedFish;

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void Start() {
            SetHealthyFoodToCook();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowCookHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = true;
            _cookHUDCanvas.enabled = true;
            _cookHUDPanel.transform.DOScale(1, 0.6f).SetEase(Ease.OutBack);
        }

        private void HideCookHUDCanvas() {
            _gameplayManager.ActivityHUDShowed = false;
            _cookHUDPanel.transform.DOScale(0, 0.5f);
            //_cookHUDCanvas.enabled = false;
        }

        private bool CheckTheIngredients(HealthyFood healthyFood) {

            var compareList = healthyFood.Ingredients.Intersect(_gameplayManager.Fridge, new IngredientNameComparer()).ToList();

            if(healthyFood.Ingredients.Count() == compareList.Count()) {
                return true;
            }
            return false;
        }

        private void SetHealthyFoodToCook() {
            salad = new HealthyFood("Salad", 0, 15, 0, 20, new List<Ingredient>() {
                new Ingredient("Onion", 2),
                new Ingredient("Tomato", 5),
                new Ingredient("Lettuce", 3)
            });

            panSearedChicken = new HealthyFood("Pan-seared chicken", 0, 25, 5, 30, new List<Ingredient>() {
                new Ingredient("Chicken", 18)
            });

            panSearedFish = new HealthyFood("Pan-seared fish", 0, 30, 10, 30, new List<Ingredient>() {
                new Ingredient("Fish", 22)
            });
        }

        #endregion

        #region Public methods

        public void PointerExitButton() {
            _cookDescriptionText.enabled = true;
            _saladDescriptionText.enabled = false;
            _panSearedChickenDescriptionText.enabled = false;
            _panSearedFishDescriptionText.enabled = false;
        }

        public void PointerEnterSaladButton() {
            _cookDescriptionText.enabled = false;
            _saladDescriptionText.enabled = true;
        }

        public void PointerEnterPanSearedChickenButton() {
            _cookDescriptionText.enabled = false;
            _panSearedChickenDescriptionText.enabled = true;
        }

        public void PointerEnterPanSearedFishButton() {
            _cookDescriptionText.enabled = false;
            _panSearedFishDescriptionText.enabled = true;
        }

        public void OnClicSaladButton() {

            bool hasTheIngredients = CheckTheIngredients(salad);

            if(hasTheIngredients) {
                _gameplayManager.StartCookActivity(salad);
                _calendarHUDController.UpdateCalendarHUD();
                _gameStatsHUDController.UpdateGameStatsHUD();
                _playerCharacterController.PlayCookSound();
                HideCookHUDCanvas();
            } else {
                _warningMessageHUDController.ShowWarningMessage(_warningIngredientsTranslation);
            }
            
        }

        public void OnClicPanSearedChickenButton() {
            
            bool hasTheIngredients = CheckTheIngredients(panSearedChicken);

            if(hasTheIngredients) {
                _gameplayManager.StartCookActivity(panSearedChicken);
                _calendarHUDController.UpdateCalendarHUD();
                _gameStatsHUDController.UpdateGameStatsHUD();
                _playerCharacterController.PlayCookSound();
                HideCookHUDCanvas();
            } else {
                _warningMessageHUDController.ShowWarningMessage(_warningIngredientsTranslation);
            }
        }

        public void OnClicPanSearedFishButton() {

            bool hasTheIngredients = CheckTheIngredients(panSearedFish);

            if(hasTheIngredients) {
                _gameplayManager.StartCookActivity(panSearedFish);
                _calendarHUDController.UpdateCalendarHUD();
                _gameStatsHUDController.UpdateGameStatsHUD();
                _playerCharacterController.PlayCookSound();
                HideCookHUDCanvas();
            } else {
                _warningMessageHUDController.ShowWarningMessage(_warningIngredientsTranslation);
            }
        }

        public void OnClicCloseButton() {
            HideCookHUDCanvas();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowCookHUDEvent += ShowCookHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowCookHUDEvent -= ShowCookHUDCanvas;
        }

        #endregion
    }
}
