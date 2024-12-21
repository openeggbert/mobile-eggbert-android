using System;
using System.IO;

namespace Xna.Framework.GamerServices
{
    internal class TrialMode
    {
        private static DateTime trialStartTime;

        public static void InitializeTrialMode()
        {
            // Assuming trial mode starts when the game is launched
            trialStartTime = DateTime.Now;
        }

        public static bool IsTrialModeExpired()
        {
            return IsTrialMode7DaysLimitExpired() || IsTrialMode10MinutesLimitExpired();
        }
        private static bool IsTrialMode10MinutesLimitExpired()
        {
            // Example: Trial expires after 10 minutes
            var expired = (DateTime.Now - trialStartTime).TotalMinutes > 10;
            return expired;
        }
        private static bool IsTrialMode7DaysLimitExpired()
        {
            // Save trial expiration status to a file or settings
            const string TRIAL_END_TIME_TXT = "trialEndTime.txt";
            var trialEndTime = File.Exists(TRIAL_END_TIME_TXT) ? DateTime.Parse(File.ReadAllText(TRIAL_END_TIME_TXT)) : DateTime.MinValue;

            var expired = trialEndTime != DateTime.MinValue && DateTime.Now > trialEndTime;
            if (expired)
            {
                return true;  // Trial period is over
            }

            // Example of setting trial end time (e.g., 7 days from now)
            if (!File.Exists(TRIAL_END_TIME_TXT))
            {
                File.WriteAllText(TRIAL_END_TIME_TXT, DateTime.Now.AddDays(7).ToString());
            }

            return false;  // Trial period still active
        }
        private static int trialModeEnabled = -1;
        public static bool IsTrialModeEnabled()
        {
            if (trialModeEnabled == 1)
            {
                return true;
            }

            if (trialModeEnabled == 0)
            {
                return false;
            }

            const string TRIAL_MODE_ENABLED_TXT = "trialModeEnabled.txt";
            var trialModeEnabledString = File.Exists(TRIAL_MODE_ENABLED_TXT) ? File.ReadAllText(TRIAL_MODE_ENABLED_TXT) : "0";
            var trialModeEnabledLocal = trialModeEnabledString.Equals("1");
            trialModeEnabled = trialModeEnabledLocal ? 1 : 0;

            return trialModeEnabledLocal;
        }


    }

}