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
    class Patches
    {
        [HarmonyPatch(typeof(Mercenary), ("GetStarvMult"))]
        [HarmonyPostfix]
        static void decreaseHungerMultiplier(ref float __result)
        {
            __result = __result * 0.01f;
        }

        [HarmonyPatch(typeof(StarvationEffect), ("ProcessActionPoint"))]
        [HarmonyPostfix]
        static void transformCurrentLevelToFloat(StarvationEffect __instance, ref float num)
        {
            Traverse.Create(__instance).Property("CurrentLevel").SetValue(((float)__instance.Delta + num) * __instance.Mult);
        }
    }
}
