using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public static class PlayerPrefsUtil {

        private const string _langugeKeyName = "Language";
        private const string _soundKeyName = "Sound";
        private const string _musicKeyName = "Music";

        private const string _defaultLanguage = "English";
        
        public static void SetLanguage(string language) {
            PlayerPrefs.SetString(_langugeKeyName, language);
        }

        public static string GetLanguage() {
            return PlayerPrefs.GetString(_langugeKeyName, _defaultLanguage);
        }

        public static void SetSound(bool soundOn) {
            if(soundOn) {
                PlayerPrefs.SetInt(_soundKeyName, 1);
            } else {
                PlayerPrefs.SetInt(_soundKeyName, 0);
            }
        }

        public static bool GetSound() {
            if (PlayerPrefs.GetInt(_soundKeyName, 1) == 1) {
                return true;
            } else {
                return false;
            }
        }

        public static void SetMusic(bool musicOn) {
            if(musicOn) {
                PlayerPrefs.SetInt(_musicKeyName, 1);
            } else {
                PlayerPrefs.SetInt(_musicKeyName, 0);
            }
        }

        public static bool GetMusic() {
            if (PlayerPrefs.GetInt(_musicKeyName, 1) == 1) {
                return true;
            } else {
                return false;
            }
        }
    }
}
