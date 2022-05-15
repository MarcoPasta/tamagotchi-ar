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
            // TODO: save datetime as unix timestamp
            string now = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            PlayerPrefs.SetString("quit_at", now);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Loads the last played time as a string.
        /// </summary>
        /// <returns></returns>
        private static string Load()
        {
            return PlayerPrefs.GetString("quit_at", DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Parses the difference between now and last time played as minutes.
        /// </summary>
        /// <returns></returns>
        public static int GetDifferenceInMinutes()
        {
            DateTime now = DateTime.Now;
            long lastTimePlayed = Convert.ToInt64(Load());
            DateTime lastTimePlayedAsDate = DateTime.FromBinary(lastTimePlayed);

            TimeSpan difference = now.Subtract(lastTimePlayedAsDate);
            return difference.Minutes;
        }
    }
}