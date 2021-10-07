using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HealthyLife {

    public class CalendarHUDController : MonoBehaviour {

        #region  Private properties

        [SerializeField] private GameplayManager _gameplayManager;

        [SerializeField] private TextMeshProUGUI _dayText;
        [SerializeField] private TextMeshProUGUI _weekdayText;
        [SerializeField] private TextMeshProUGUI _timeText;

        #endregion

        #region Private methods

        private void ShowDayText() {
            _dayText.text = "Day " + _gameplayManager.Day.ToString();
        }

        private void ShowWeekdayText() {
            _weekdayText.text = _gameplayManager.CurrentWeekday.ToString();
        }

        private void ShowTimeText() {
            _timeText.text = _gameplayManager.GetTime();
        }

        #endregion
    }
}
