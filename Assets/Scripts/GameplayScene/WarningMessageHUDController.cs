using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
using DG.Tweening;

namespace HealthyLife {

    public class WarningMessageHUDController : MonoBehaviour {

        #region Private properties

        [SerializeField] private Canvas _warningMessageHUDCanvas;
        [SerializeField] private LeanLocalizedBehaviour _leanLocalizedBehaviour;

        #endregion

        #region Private methods

        internal void ShowWarningMessage(string translationName) {
            _leanLocalizedBehaviour.TranslationName = translationName;
            _warningMessageHUDCanvas.enabled = true;
            HideWithDelayWarningMessage();
        }

        private void HideWarningMessage() {
            _warningMessageHUDCanvas.enabled = false;
        }

        private void HideWithDelayWarningMessage() {
            Invoke("HideWarningMessage", 8f);
        }

        #endregion

    }
}
