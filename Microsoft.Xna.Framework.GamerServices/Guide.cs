using System.Diagnostics;

namespace Microsoft.Xna.Framework.GamerServices
{
    public static class Guide
    {
        public static void Show(PlayerIndex playerIndex)
        {
            Debug.Write("The Market Place should now be shown.");
        }
        public static bool IsTrialMode { get; set; }
    }
}
