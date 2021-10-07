using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class GameplayManager : MonoBehaviour {

        #region Private properties
    
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
            _day++;
            NextWeekdays();
            ResetEnergy();
        }

        private void NextWeekdays() {

            _weekdaysListPosition++;

            if(_weekdaysListPosition == 7) {
                _weekdaysListPosition = 0;
            }

            _currentWeekday = _weekdays[_weekdaysListPosition];

        }

        [ContextMenu("CalculateHourAndMinute")]
        private void CalculateHourAndMinute() {

            _hour = _timePerMinute / 60;
            _min = _timePerMinute % 60;

        }

        [ContextMenu("WakeUp")]
        private void WakeUp() {
            NextDay();
            ChangeTheTimeTo7();
        }

        private void ChangeTheTimeTo7() {
            _timePerMinute = 420;
        }

        private void IncreaseMoreMinutes(int minutes) {
            _timePerMinute += minutes;
        }

        private void IncreaseMoney(int money) {
            _money += money;
        }

        private void DecreaseMoney(int money) {

            if(_money < money) {
                Debug.Log("Dinero insuficiente.");
                return;
            }

            _money -= money;
        }

        private void IncreaseHappiness(int happiness) {
            _happiness += happiness;
        }

        private void DecreaseHappiness(int happiness) {

            if(_happiness < happiness) {
                Debug.Log("Felicidad insuficiente");
                return;
            }
            
            _happiness -= happiness;
        }

        private void IncreaseWeight(int weight) {
            _weight += weight;
        }

        private void DecreaseWeight(int weight) {

            if(_weight < weight) {
                Debug.Log("no puede perder mas peso");
                return;
            }
            
            _weight -= weight;
        }

        private void IncreaseEnergyForNextDay(int energy) {
            _energyForNextDay += energy;
        }

        private void DecreaseEnergyForToday(int energy) {

            if(_energyForToday < energy) {
                Debug.Log("energia insuficiente");
                return;
            }
            
            _energyForToday -= energy;
        }

        private void ResetEnergy() {
            _energyForToday = _energyForNextDay;
            _energyForNextDay = 0;
        }

        #endregion

        #region Internal methods

        internal int GetDay() {
            return _day;
        }

        internal Weekdays GetWeekday() {
            return _currentWeekday;
        }

        internal string GetTime() {
            string hour = _hour.ToString("00");
            string min = _min.ToString("00");
            return string.Format ("{00}:{01}", hour, min);
        }

        #endregion
    }
}
