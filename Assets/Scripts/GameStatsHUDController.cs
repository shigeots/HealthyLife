using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HealthyLife {

    public class GameStatsHUDController : MonoBehaviour {

        #region Private properties

        [SerializeField] private GameObject _moneyText;
        [SerializeField] private GameObject _happinessText;
        [SerializeField] private GameObject _energyForTodayText;
        [SerializeField] private GameObject _energyForNextDayText;
        [SerializeField] private GameObject _weightText;

        #endregion

        #region Main methods

        private void Start() {
            UpdateGameStatsHUD();
        }

        #endregion

        #region Internal methods

        internal void UpdateGameStatsHUD() {
            _moneyText.SetActive(false);
            _happinessText.SetActive(false);
            _energyForNextDayText.SetActive(false);
            _energyForTodayText.SetActive(false);
            _weightText.SetActive(false);

            _moneyText.SetActive(true);
            _happinessText.SetActive(true);
            _energyForNextDayText.SetActive(true);
            _energyForTodayText.SetActive(true);
            _weightText.SetActive(true);
        }

        #endregion
    }
}
