using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HealthyLife {

    public class GameStatsHUDController : MonoBehaviour {

        #region Private properties

        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private TextMeshProUGUI _happinessText;
        [SerializeField] private TextMeshProUGUI _energyForTodayText;
        [SerializeField] private TextMeshProUGUI _energyForNextDayText;
        [SerializeField] private TextMeshProUGUI _weightText;

        [SerializeField] private GameplayManager _gameplayManager;

        #endregion

        #region Internal methods

        [ContextMenu("update")]
        internal void UpdateGameStats() {
            _moneyText.text = _gameplayManager.Money.ToString();
            _happinessText.text = _gameplayManager.Happiness.ToString();
            _energyForNextDayText.text = _gameplayManager.EnergyForToday.ToString();
            _energyForTodayText.text = _gameplayManager.EnergyForNextDay.ToString();
            _weightText.text = _gameplayManager.Weight.ToString();
        }

        #endregion
    }
}
