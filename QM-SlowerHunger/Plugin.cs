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

namespace SlowerHunger
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class SlowerHunger : BaseUnityPlugin
    {
        private const string modGUID = "Eliijahh.SlowerHunger";
        private const string modName = "Slower Hunger";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static SlowerHunger Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The Slower Hunger mod has awakened.");

            harmony.PatchAll();
        }
    }
}
