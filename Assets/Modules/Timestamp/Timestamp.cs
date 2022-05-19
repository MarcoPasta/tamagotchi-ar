using System;
using System.Globalization;
using UnityEngine;

namespace Modules.Timestamp
{
    /// <summary>
    /// This class is used to store and retrieve the player's last time played.
    /// </summary>
    public class Timestamp : MonoBehaviour
    {
        /// <summary>
        /// Saves the time the player quits at in the PlayerPrefs as a string.
        /// </summary>
        public static void Save()
        {
            DateTime now = DateTime.Now;
            PlayerPrefs.SetString("quit_at", Convert.ToString(now, new CultureInfo("de-DE")));
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Loads the last played time as a string.
        /// </summary>
        /// <returns></returns>
        private static string Load()
        {
            string defaultValue = Convert.ToString(DateTime.Now, new CultureInfo("de-DE"));
            return PlayerPrefs.GetString("quit_at", defaultValue);
        }

        /// <summary>
        /// Parses the difference between now and last time played as minutes.
        /// </summary>
        /// <returns></returns>
        public static int GetDifferenceInMinutes()
        {
            DateTime now = DateTime.Now;
            DateTime lastTimePlayed = DateTime.Parse(Load(), new CultureInfo("de-DE"));

            TimeSpan difference = now.Subtract(lastTimePlayed);
            return difference.Minutes;
        }
    }
}