using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HealthyLife {

    public class PlateTilemapController : MonoBehaviour {

        #region Private properties

        [SerializeField] private GameplayManager _gameplayManager;

        [SerializeField] private TilemapRenderer _plateTilemapRenderer;

        #endregion

        #region Main methods

        private void Update() {
            if(_gameplayManager.ThereAreFood) {
                ShowPlateTilemap();
            } else {
                HidePlateTilemap();
            }
        }

        #endregion

        #region Internal methods

        internal void ShowPlateTilemap() {
            _plateTilemapRenderer.enabled = true;
        }

        internal void HidePlateTilemap() {
            _plateTilemapRenderer.enabled = false;
        }

        #endregion
    }
}
