using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SlowerHunger.Patches;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;

namespace SlowerHunger
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class SlowerHunger : BaseUnityPlugin
    {
        private const string modGUID = "Eliijahh.SlowerHunger";
        private const string modName = "Slower Hunger";
        private const string modVersion = "1.0.0.0";

        public static ConfigEntry<float> HungerRateMultiplier;
        private readonly Harmony harmony = new Harmony(modGUID);

        private static SlowerHunger Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            HungerRateMultiplier = Config.Bind("General", "HungerRateMultiplier", 0.5f, "The multiplier to increase or reduce the hunger rate");

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The Slower Hunger mod has awakened.");

            harmony.PatchAll();
        }
    }
}
