using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HealthyLife {

    public class ShoppingHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _shoppingTVHUDCanvas;
        [SerializeField] private GameplayManager _gameplayManager;
        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;

        [SerializeField] TextMeshProUGUI _onionUnitText;
        [SerializeField] TextMeshProUGUI _lettuceUnitText;
        [SerializeField] TextMeshProUGUI _tomatoUnitText;
        [SerializeField] TextMeshProUGUI _chickenUnitText;
        [SerializeField] TextMeshProUGUI _fishUnitText;
        [SerializeField] TextMeshProUGUI _totalCostValueText;

        [SerializeField] private int _onionUnit = 0;
        [SerializeField] private int _lettuceUnit = 0;
        [SerializeField] private int _tomatoUnit = 0;
        [SerializeField] private int _chickenUnit = 0;
        [SerializeField] private int _fishUnit = 0;

        [SerializeField] private int _totalCost = 0;

        [SerializeField] private List<Ingredient> _ingredientsToBuy;

        #endregion

        #region Internal properties

        [SerializeField] internal Ingredient onion = new Ingredient("Onion", 2);
        [SerializeField] internal Ingredient lettuce = new Ingredient("Lettuce", 3);
        [SerializeField] internal Ingredient tomato = new Ingredient("Tomato", 5);
        [SerializeField] internal Ingredient chicken = new Ingredient("Chicken", 15);
        [SerializeField] internal Ingredient fish = new Ingredient("Fish", 20);

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

        private void ShowShoppingHUDCanvas() {
            _shoppingTVHUDCanvas.enabled = true;
        }

        private void HideShoppingHUDCanvas() {
            _shoppingTVHUDCanvas.enabled = false;
            ResetUnit();
        }

        private void ResetUnit() {
        _onionUnit = 0;
        _lettuceUnit = 0;
        _tomatoUnit = 0;
        _chickenUnit = 0;
        _fishUnit = 0;
        _totalCost = 0;

        _onionUnitText.text = "0";
        _lettuceUnitText.text = "0";
        _tomatoUnitText.text = "0";
        _chickenUnitText.text = "0";
        _fishUnitText.text = "0";
        _totalCostValueText.text = "0";

        _ingredientsToBuy.Clear();
        }

        private void BuyIngredients() {
            while(_onionUnit > 0) {
                _ingredientsToBuy.Add(onion);
                _onionUnit--;
            }
            while(_tomatoUnit > 0) {
                _ingredientsToBuy.Add(tomato);
                _tomatoUnit--;
            }
            while(_lettuceUnit > 0) {
                _ingredientsToBuy.Add(lettuce);
                _lettuceUnit--;
            }
            while(_chickenUnit > 0) {
                _ingredientsToBuy.Add(chicken);
                _chickenUnit--;
            }
            while(_fishUnit > 0) {
                _ingredientsToBuy.Add(fish);
                _fishUnit--;
            }
        }

        #endregion

        #region Public methods

        public void OnClickAddOnionButton() {
            if(_gameplayManager.Money >= (_totalCost + onion.Cost)) {
                _onionUnit++;
                _totalCost += onion.Cost;
                _onionUnitText.text = _onionUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickAddLettuceButton() {
            if(_gameplayManager.Money >= (_totalCost + lettuce.Cost)) {
                _lettuceUnit++;
                _totalCost += lettuce.Cost;
                _lettuceUnitText.text = _lettuceUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickAddTomatoButton() {
            if(_gameplayManager.Money >= (_totalCost + tomato.Cost)) {
                _tomatoUnit++;
                _totalCost += tomato.Cost;
                _tomatoUnitText.text = _tomatoUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickAddChickenButton() {
            if(_gameplayManager.Money >= (_totalCost + chicken.Cost)) {
                _chickenUnit++;
                _totalCost += chicken.Cost;
                _chickenUnitText.text = _chickenUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickAddFishButton() {
            if(_gameplayManager.Money >= (_totalCost + fish.Cost)) {
                _fishUnit++;
                _totalCost += fish.Cost;
                _fishUnitText.text = _fishUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickLessOnionButton() {
            if(_onionUnit > 0) {
                _onionUnit--;
                _totalCost -= onion.Cost;
                _onionUnitText.text = _onionUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickLessLettuceButton() {
            if(_lettuceUnit > 0) {
                _lettuceUnit--;
                _totalCost -= lettuce.Cost;
                _lettuceUnitText.text = _lettuceUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickLessTomatoButton() {
            if(_tomatoUnit > 0) {
                _tomatoUnit--;
                _totalCost -= tomato.Cost;
                _tomatoUnitText.text = _tomatoUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickLessChickenButton() {
            if(_chickenUnit > 0) {
                _chickenUnit--;
                _totalCost -= chicken.Cost;
                _chickenUnitText.text = _chickenUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClickLessFishButton() {
            if(_fishUnit > 0) {
                _fishUnit--;
                _totalCost -= fish.Cost;
                _fishUnitText.text = _fishUnit.ToString();
                _totalCostValueText.text = _totalCost.ToString();
            }
        }

        public void OnClicCloseButton() {
            HideShoppingHUDCanvas();
        }

        public void OnClicBuyButton() {
            if(_totalCost <= _gameplayManager.Money) {
                BuyIngredients();
                _gameplayManager.StartShoppingActivity(_ingredientsToBuy, _totalCost);
                _calendarHUDController.UpdateCalendarHUD();
                _gameStatsHUDController.UpdateGameStatsHUD();
                HideShoppingHUDCanvas();
            } else {
                Debug.Log("No hay dinero");
            }
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowShoppingHUDEvent += ShowShoppingHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowShoppingHUDEvent -= ShowShoppingHUDCanvas;
        }

        #endregion
    }
}
