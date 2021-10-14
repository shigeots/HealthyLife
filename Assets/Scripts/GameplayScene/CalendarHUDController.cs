using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HealthyLife {

    public class CalendarHUDController : MonoBehaviour {

        #region  Private properties

        [SerializeField] private GameplayManager _gameplayManager;

        [SerializeField] private Canvas CalendarHUDCanvas;
        [SerializeField] private GameObject _dayText;
        [SerializeField] private TextMeshProUGUI _mondayText;
        [SerializeField] private TextMeshProUGUI _tuesdayText;
        [SerializeField] private TextMeshProUGUI _wednesdayText;
        [SerializeField] private TextMeshProUGUI _thursdayText;
        [SerializeField] private TextMeshProUGUI _fridayText;
        [SerializeField] private TextMeshProUGUI _saturdayText;
        [SerializeField] private TextMeshProUGUI _sundayText;
        [SerializeField] private TextMeshProUGUI _timeText;

        #endregion

        #region Main methods

        private void Start() {
            UpdateCalendarHUD();
        }

        #endregion

        #region Private methods

        private void ShowDayText() {
            _dayText.SetActive(false);
            _dayText.SetActive(true);
        }

        private void ShowWeekdayText() {
            if(_gameplayManager.CurrentWeekday == Weekday.Monday) {
                _mondayText.enabled = true;
                _tuesdayText.enabled = false;
                _wednesdayText.enabled = false;
                _thursdayText.enabled = false;
                _fridayText.enabled = false;
                _saturdayText.enabled = false;
                _sundayText.enabled = false;
            }
            if(_gameplayManager.CurrentWeekday == Weekday.Tuesday) {
                _mondayText.enabled = false;
                _tuesdayText.enabled = true;
                _wednesdayText.enabled = false;
                _thursdayText.enabled = false;
                _fridayText.enabled = false;
                _saturdayText.enabled = false;
                _sundayText.enabled = false;
            }
            if(_gameplayManager.CurrentWeekday == Weekday.Wednesday) {
                _mondayText.enabled = false;
                _tuesdayText.enabled = false;
                _wednesdayText.enabled = true;
                _thursdayText.enabled = false;
                _fridayText.enabled = false;
                _saturdayText.enabled = false;
                _sundayText.enabled = false;
            }
            if(_gameplayManager.CurrentWeekday == Weekday.Thursday) {
                _mondayText.enabled = false;
                _tuesdayText.enabled = false;
                _wednesdayText.enabled = false;
                _thursdayText.enabled = true;
                _fridayText.enabled = false;
                _saturdayText.enabled = false;
                _sundayText.enabled = false;
            }
            if(_gameplayManager.CurrentWeekday == Weekday.Friday) {
                _mondayText.enabled = false;
                _tuesdayText.enabled = false;
                _wednesdayText.enabled = false;
                _thursdayText.enabled = false;
                _fridayText.enabled = true;
                _saturdayText.enabled = false;
                _sundayText.enabled = false;
            }
            if(_gameplayManager.CurrentWeekday == Weekday.Saturday) {
                _mondayText.enabled = false;
                _tuesdayText.enabled = false;
                _wednesdayText.enabled = false;
                _thursdayText.enabled = false;
                _fridayText.enabled = false;
                _saturdayText.enabled = true;
                _sundayText.enabled = false;
            }
            if(_gameplayManager.CurrentWeekday == Weekday.Sunday) {
                _mondayText.enabled = false;
                _tuesdayText.enabled = false;
                _wednesdayText.enabled = false;
                _thursdayText.enabled = false;
                _fridayText.enabled = false;
                _saturdayText.enabled = false;
                _sundayText.enabled = true;
            }
        }

        private void ShowTimeText() {
            _timeText.text = _gameplayManager.GetTime();
        }

        private void UpdateCanvas() {
            CalendarHUDCanvas.enabled = false;
            CalendarHUDCanvas.enabled = true;
        }

        #endregion

        internal void UpdateCalendarHUD() {
            ShowDayText();
            ShowWeekdayText();
            ShowTimeText();
        }
    }
}
