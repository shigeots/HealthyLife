using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class GameplayManager : MonoBehaviour {

        #region Private properties

        [SerializeField] private PlayerCharacterController _playerCharacterController;
    
        [SerializeField] private Weekdays _currentWeekday = Weekdays.Monday;
        [SerializeField] private List<Weekdays> _weekdays = new List<Weekdays>();
        [SerializeField] private int _day = 1;
        [SerializeField] private int _weekdaysListPosition = 0;
        [SerializeField] private int _hour;
        [SerializeField] private int _min;
        [SerializeField] private int _timePerMinute;
        [SerializeField] private int _happiness = 100;
        [SerializeField] private int _money = 150;
        [SerializeField] private int _weight = 80;
        [SerializeField] private int _energyForToday = 100;
        [SerializeField] private int _energyForNextDay = 0;
        [SerializeField] private bool _thereAreFood = false;

        #endregion

        #region Getter and setter

        public Weekdays CurrentWeekday { get => _currentWeekday; set => _currentWeekday = value; }
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

        #endregion

        #region Main methods

        private void Start() {
            _weekdays.Add(Weekdays.Monday);
            _weekdays.Add(Weekdays.Tuesday);
            _weekdays.Add(Weekdays.Wednesday);
            _weekdays.Add(Weekdays.Thursday);
            _weekdays.Add(Weekdays.Friday);
            _weekdays.Add(Weekdays.Saturday);
            _weekdays.Add(Weekdays.Sunday);

        }

        #endregion

        #region Private methods

        private void NextDay() {
            Day++;
            NextWeekdays();
            ResetEnergy();
        }

        private void NextWeekdays() {

            WeekdaysListPosition++;

            if(WeekdaysListPosition == 7) {
                WeekdaysListPosition = 0;
            }

            CurrentWeekday = _weekdays[WeekdaysListPosition];

        }

        [ContextMenu("CalculateHourAndMinute")]
        private void CalculateHourAndMinute() {

            Hour = TimePerMinute / 60;
            Min = TimePerMinute % 60;

        }

        [ContextMenu("WakeUp")]
        private void WakeUp() {
            NextDay();
            ChangeTheTimeTo7();
        }

        private void ChangeTheTimeTo7() {
            TimePerMinute = 420;
        }

        private void IncreaseMoreMinutes(int minutes) {
            TimePerMinute += minutes;
        }

        private void IncreaseMoney(int money) {
            Money += money;
        }

        private void DecreaseMoney(int money) {

            if(Money < money) {
                Debug.Log("Dinero insuficiente.");
                return;
            }

            Money -= money;
        }

        private void IncreaseHappiness(int happiness) {
            Happiness += happiness;
        }

        private void DecreaseHappiness(int happiness) {

            if(Happiness < happiness) {
                Debug.Log("Felicidad insuficiente");
                return;
            }
            
            Happiness -= happiness;
        }

        private void IncreaseWeight(int weight) {
            Weight += weight;
        }

        private void DecreaseWeight(int weight) {

            if(Weight < weight) {
                Debug.Log("no puede perder mas peso");
                return;
            }
            
            Weight -= weight;
        }

        private void IncreaseEnergyForNextDay(int energy) {
            EnergyForNextDay += energy;
        }

        private void DecreaseEnergyForToday(int energy) {

            if(EnergyForToday < energy) {
                Debug.Log("energia insuficiente");
                return;
            }
            
            EnergyForToday -= energy;
        }

        private void ResetEnergy() {
            EnergyForToday = EnergyForNextDay;
            EnergyForNextDay = 0;
        }

        #endregion

        #region Internal methods

        internal string GetTime() {
            string hour = Hour.ToString("00");
            string min = Min.ToString("00");
            return string.Format ("{00}:{01}", hour, min);
        }

        internal void StartWorkActivity(int happiness, int energyForToday) {
            _playerCharacterController.GoToTheInnerDoor();
            DecreaseHappiness(happiness);
            DecreaseEnergyForToday(energyForToday);
        }

        internal void StartCheckFridgeActivity() {
            _playerCharacterController.GoToTheFridge();
        }

        internal void StartWatchTVActivity() {
            _playerCharacterController.GoToTheTelevision();
        }

        internal void StartEatActivity() {
            _playerCharacterController.GoToTheTable();
        }

        internal void StartSleepActivity() {
            _playerCharacterController.GoToTheBed();
        }

        internal void StartCookActivity() {
            _playerCharacterController.GoToTheKitchen();
        }

        internal void StartExerciseActivity() {
            _playerCharacterController.GoToTheInnerDoor();
        }

        internal void StartShopActivity() {
            _playerCharacterController.GoToTheInnerDoor();
        }

        internal void StartGoParttingActivity() {
            _playerCharacterController.GoToTheInnerDoor();
        }

        #endregion
    }
}
