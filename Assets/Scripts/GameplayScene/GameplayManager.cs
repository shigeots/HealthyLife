using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class GameplayManager : MonoBehaviour {

        #region Private properties

        [SerializeField] private CalendarHUDController _calendarHUDController;
        [SerializeField] private GameStatsHUDController _gameStatsHUDController;
        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private DeliveryManCharacterController _deliveryManCharacterController;
    
        [SerializeField] private Weekday _currentWeekday = Weekday.Monday;
        [SerializeField] private List<Weekday> _weekdays = new List<Weekday>();
        [SerializeField] private int _day = 1;
        [SerializeField] private int _weekdaysListPosition = 0;
        [SerializeField] private int _hour;
        [SerializeField] private int _min;
        [SerializeField] private int _timePerMinute;
        [SerializeField] private int _happiness = 100;
        [SerializeField] private int _money = 100;
        [SerializeField] private int _weight = 80;
        [SerializeField] private int _energyForToday = 100;
        [SerializeField] private int _energyForNextDay = 0;
        [SerializeField] private Food _foodForEat = null;
        [SerializeField] private bool _thereAreFood = false;
        [SerializeField] private bool _orderedFoodDelivery = false;
        [SerializeField] private int _waitingTimeForDelivery = 0;
        [SerializeField] private List<Ingredient> _fridge;

        #endregion

        #region Internal properties

        [SerializeField] internal int amountOfOnion = 0;
        [SerializeField] internal int amountOfTomato = 0;
        [SerializeField] internal int amountOfLettuce = 0;
        [SerializeField] internal int amountOfChicken = 0;
        [SerializeField] internal int amountOfFish = 0;

        #endregion

        #region Getter and setter

        public Weekday CurrentWeekday { get => _currentWeekday; set => _currentWeekday = value; }
        public int Day { get => _day; set => _day = value; }
        public int WeekdaysListPosition { get => _weekdaysListPosition; set => _weekdaysListPosition = value; }
        public int Hour { get => _hour; set => _hour = value; }
        public int Min { get => _min; set => _min = value; }
        public int TimePerMinute { get => _timePerMinute; set => _timePerMinute = value; }
        public int Happiness { get => _happiness; set => _happiness = value; }
        public int Money { get => _money; set => _money = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public int EnergyForToday { get => _energyForToday; set => _energyForToday = value; }
        public int EnergyForNextDay { get => _energyForNextDay; set => _energyForNextDay = value; }
        public bool ThereAreFood { get => _thereAreFood; set => _thereAreFood = value; }
        public Food FoodForEat { get => _foodForEat; set => _foodForEat = value; }
        public bool OrderedFoodDelivery { get => _orderedFoodDelivery; set => _orderedFoodDelivery = value; }
        public int WaitingTimeForDelivery { get => _waitingTimeForDelivery; set => _waitingTimeForDelivery = value; }
        public List<Ingredient> Fridge { get => _fridge; set => _fridge = value; }

        #endregion

        #region Main methods

        private void Awake() {
            _weekdays.Add(Weekday.Monday);
            _weekdays.Add(Weekday.Tuesday);
            _weekdays.Add(Weekday.Wednesday);
            _weekdays.Add(Weekday.Thursday);
            _weekdays.Add(Weekday.Friday);
            _weekdays.Add(Weekday.Saturday);
            _weekdays.Add(Weekday.Sunday);

            FoodForEat = null;
/*
            _fridge.Add(new Ingredient("Onion",2));
            _fridge.Add(new Ingredient("Onion",2));
            _fridge.Add(new Ingredient("Lettuce",3));
            _fridge.Add(new Ingredient("Chicken",18));
            _fridge.Add(new Ingredient("Fish",22));
            _fridge.Add(new Ingredient("Fish",22));
*/
            ChangeTheTimeTo7();
        }

        private void Start() {
            AssignLanguage();
        }

        #endregion

        #region Private methods

        private void NextDay() {
            Day++;

            Lean.Localization.LeanLocalization.SetToken("DAYNUMBERTOKEN", Day.ToString(), false);
        }

        private void NextWeekdays() {

            WeekdaysListPosition++;

            if(WeekdaysListPosition == 7) {
                WeekdaysListPosition = 0;
            }

            CurrentWeekday = _weekdays[WeekdaysListPosition];

        }

        internal void CalculateHourAndMinute() {
            Hour = TimePerMinute / 60;
            Min = TimePerMinute % 60;
        }

        private void WakeUp() {
            NextDay();
            ChangeTheTimeTo7();
        }

        private void ChangeTheTimeTo7() {
            TimePerMinute = 420;

            CalculateHourAndMinute();
        }

        private void IncreaseMoreMinutes(int minutes) {
            TimePerMinute += minutes;

            if(OrderedFoodDelivery) {
                ReduceWaitingTimeForDelivery(minutes);
            }
            
            CalculateHourAndMinute();
        }

        private void ReduceWaitingTimeForDelivery(int minutes) {

            WaitingTimeForDelivery -= minutes;
            
            if(WaitingTimeForDelivery <= 0) {
                _deliveryManCharacterController.GoToTheOuterDoor();
            }
        }

        private void IncreaseMoney(int money) {
            Money += money;

            Lean.Localization.LeanLocalization.SetToken("MONEYTOKEN", Money.ToString(), false);
        }

        private void DecreaseMoney(int money) {

            if(Money < money) {
                Debug.Log("Dinero insuficiente.");
                return;
            }

            Money -= money;
            Lean.Localization.LeanLocalization.SetToken("MONEYTOKEN", Money.ToString(), false);
        }

        private void IncreaseHappiness(int happiness) {
            Happiness += happiness;

            if(Happiness > 100) {
                Happiness = 100;
            }

            Lean.Localization.LeanLocalization.SetToken("HAPPINESSTOKEN", Happiness.ToString(), false);
        }

        private void DecreaseHappiness(int happiness) {

            if(Happiness < happiness) {
                Debug.Log("Felicidad insuficiente");
                return;
            }
            
            Happiness -= happiness;
            Lean.Localization.LeanLocalization.SetToken("HAPPINESSTOKEN", Happiness.ToString(), false);
        }

        private void IncreaseWeight(int weight) {
            Weight += weight;
            Lean.Localization.LeanLocalization.SetToken("WEIGHTTOKEN", Weight.ToString(), false);
        }

        private void DecreaseWeight(int weight) {

            if(Weight < weight) {
                Debug.Log("no puede perder mas peso");
                return;
            }
            
            Weight -= weight;
            Lean.Localization.LeanLocalization.SetToken("WEIGHTTOKEN", Weight.ToString(), false);
        }

        private void IncreaseEnergyForNextDay(int energy) {
            EnergyForNextDay += energy;

            if(EnergyForNextDay > 100) {
                EnergyForNextDay = 100;
            }

            Lean.Localization.LeanLocalization.SetToken("ENERGYTOMORROWTOKEN", EnergyForNextDay.ToString(), false);
        }

        private void DecreaseEnergyForToday(int energy) {

            if(EnergyForToday < energy) {
                Debug.Log("energia insuficiente");
                return;
            }
            
            EnergyForToday -= energy;
            Lean.Localization.LeanLocalization.SetToken("ENERGYTODAYTOKEN", EnergyForToday.ToString(), false);
        }

        private void ResetEnergy() {
            EnergyForToday = EnergyForNextDay;
            EnergyForNextDay = 0;

            Lean.Localization.LeanLocalization.SetToken("ENERGYTODAYTOKEN", EnergyForToday.ToString(), false);
            Lean.Localization.LeanLocalization.SetToken("ENERGYTOMORROWTOKEN", EnergyForNextDay.ToString(), false);
        }

        private void RemoveIngredientsFromTheFridge(HealthyFood healthyFood) {

            foreach(Ingredient foodIngredient in healthyFood.Ingredients) {

                var foodToEliminate = _fridge.FirstOrDefault(x => x.Name == foodIngredient.Name);

                if(foodToEliminate != null) {
                    _fridge.Remove(foodToEliminate);
                }
            }
        }

        private void AssignLanguage() {
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll(PlayerPrefsUtil.GetLanguage());
        }

        #endregion

        #region Internal methods

        internal string GetTime() {
            string hour = Hour.ToString("00");
            string min = Min.ToString("00");
            return string.Format ("{00}:{01}", hour, min);
        }

        internal void StartWorkActivity(int happiness, int energyForToday, int time, int money) {
            DecreaseHappiness(happiness);
            DecreaseEnergyForToday(energyForToday);
            IncreaseMoreMinutes(time);
            IncreaseMoney(money);
        }

        internal void StartCheckFridgeActivity() {
            //_playerCharacterController.GoToTheFridge();
            
        }

        internal void StartWatchTV30MinutesActivity() {
            IncreaseHappiness(2);
            IncreaseMoreMinutes(30);
        }

        internal void StartWatchTV1HourActivity() {
            IncreaseHappiness(4);
            IncreaseMoreMinutes(60);
        }

        internal void StartWatchTV2HoursActivity() {
            IncreaseHappiness(8);
            IncreaseMoreMinutes(120);
        }

        internal void StartEatActivity() {
            IncreaseMoreMinutes(20);

            IncreaseEnergyForNextDay(FoodForEat.Energy);
            IncreaseHappiness(FoodForEat.Happiness);
            IncreaseWeight(FoodForEat.Weight);

            ThereAreFood = false;
            OrderedFoodDelivery = false;


            /*
            Type type = FoodForEat.GetType();

            if(type.Equals(typeof(JunkFood))) {
                
            }
            if(type.Equals(typeof(HealthyFood))) {
                
            }*/

        }

        internal void StartSleepActivity() {
            NextDay();
            NextWeekdays();
            ResetEnergy();
            ChangeTheTimeTo7();

        }

        internal void StartCookActivity(HealthyFood healthyFood) {
            IncreaseMoreMinutes(healthyFood.PreparationTime);
            RemoveIngredientsFromTheFridge(healthyFood);
            _foodForEat = healthyFood;
            ThereAreFood = true;
        }

        internal void StartExerciseActivity() {
            DecreaseEnergyForToday(25);
            IncreaseMoreMinutes(120);
            DecreaseWeight(3);
            DecreaseHappiness(10);
        }

        internal void StartShoppingActivity(List<Ingredient> ingredients, int cost) {
            //_playerCharacterController.GoToTheInnerDoor();
            AddIngredientsToTheFridge(ingredients);
            DecreaseMoney(cost);
            DecreaseEnergyForToday(10);
            IncreaseMoreMinutes(60);
        }

        internal void StartGoParttingActivity() {
            IncreaseHappiness(50);
            DecreaseEnergyForToday(25);
            IncreaseMoreMinutes(480);
            DecreaseMoney(160);
        }

        internal void StartFoodDeliveryActivity(JunkFood junkFood) {
            OrderedFoodDelivery = true;
            WaitingTimeForDelivery = 120;
            _foodForEat = junkFood;
            DecreaseMoney(junkFood.Cost);
        }

        internal void CheckFridge() {

            amountOfOnion = 0;
            amountOfTomato = 0;
            amountOfLettuce = 0;
            amountOfChicken = 0;
            amountOfFish = 0;

            foreach(var ingredient in Fridge) {
                if(ingredient.Name == "Onion") {
                    amountOfOnion++;
                }
                if(ingredient.Name == "Tomato") {
                    amountOfTomato++;
                }
                if(ingredient.Name == "Lettuce") {
                    amountOfLettuce++;
                }
                if(ingredient.Name == "Chicken") {
                    amountOfChicken++;
                }
                if(ingredient.Name == "Fish") {
                    amountOfFish++;
                }
            }

            Lean.Localization.LeanLocalization.SetToken("AMOUNTONIONTOKEN", amountOfOnion.ToString(), false);
            Lean.Localization.LeanLocalization.SetToken("AMOUNTTOMATOTOKEN", amountOfTomato.ToString(), false);
            Lean.Localization.LeanLocalization.SetToken("AMOUNTLETTUCETOKEN", amountOfLettuce.ToString(), false);
            Lean.Localization.LeanLocalization.SetToken("AMOUNTCHICKENTOKEN", amountOfChicken.ToString(), false);
            Lean.Localization.LeanLocalization.SetToken("AMOUNTFISHTOKEN", amountOfFish.ToString(), false);
        }

        internal void AddIngredientsToTheFridge(List<Ingredient> newIngredients) {
            foreach(var newIngredient in newIngredients) {
                Fridge.Add(newIngredient);
            }
        }

        #endregion
    }
}
