using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlowerHunger.Patches
{
    [HarmonyPatch(typeof(StarvationEffect), "ProcessActionPoint")]
    class Patches
    {
        [HarmonyPrefix]
        static void saveInitialCurrentLevel(StarvationEffect __instance, out int __state)
        {
            __state = __instance.CurrentLevel;
            Console.WriteLine($"Level of Hunger in Prefix is equal to: {__state}");
        }

        [HarmonyPostfix]
        static void transformCurrentLevelToFloat(StarvationEffect __instance, int __state)
        {

            float hungerRateMultiplier = SlowerHunger.HungerRateMultiplier.Value; // Use the configurable value
            int oldHungerLevel = __state;
            int actualHungerLevel = Mathf.RoundToInt(oldHungerLevel - ( (oldHungerLevel - __instance.CurrentLevel) * hungerRateMultiplier));

            Console.WriteLine($"Level of Hunger in Postfix is equal to: {__instance.CurrentLevel}, while the actual hunger level should be {actualHungerLevel}");

            if( actualHungerLevel >= oldHungerLevel) 
            {
                actualHungerLevel--;
            }

            Traverse.Create(__instance).Property("CurrentLevel").SetValue(actualHungerLevel);

            //Traverse.Create(__instance).Property("CurrentLevel").SetValue(Mathf.RoundToInt(__instance.CurrentLevel + ((__instance.CurrentLevel - __state)*0.01f)));
        }
    }
}
