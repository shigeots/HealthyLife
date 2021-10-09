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
        [SerializeField] private TextMeshProUGUI _weekdayText;
        [SerializeField] private TextMeshProUGUI _timeText;

        #endregion

        #region Private methods

        private void ShowDayText() {
            _dayText.SetActive(false);
            _dayText.SetActive(true);
        }

        private void ShowWeekdayText() {
            _weekdayText.text = _gameplayManager.CurrentWeekday.ToString();
        }

        private void ShowTimeText() {
            _timeText.text = _gameplayManager.GetTime();
        }

        private void UpdateCanvas() {
            CalendarHUDCanvas.enabled = false;
            CalendarHUDCanvas.enabled = true;
        }

        #endregion

        [ContextMenu("asdf")]
        internal void UpdateCalendarHUD() {
            ShowDayText();
            ShowWeekdayText();
            ShowTimeText();
        }
    }
}
