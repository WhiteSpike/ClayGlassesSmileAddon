using HarmonyLib;
using System.Collections.Generic;
using WesleysInteriorTools.EnemyAiChanges;
using MoreShipUpgrades.Misc.Util;
using System.Reflection;
using MoreShipUpgrades.UpgradeComponents.TierUpgrades.Enemies;

namespace ClayGlassesSmileAddon.Patches
{
    [HarmonyPatch(typeof(DiscmanVariant))]
    internal static class DiscmanVariantPatcher
    {
        [HarmonyPatch(nameof(DiscmanVariant.SetCurrentVisibility))]
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> SetCurrentVisibilityTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            int index = 0;

            FieldInfo MinVanishDistance = typeof(DiscmanVariant).GetField(nameof(DiscmanVariant.MinVanishDistance), BindingFlags.Instance | BindingFlags.Public);
            MethodInfo IncreaseVisibility = typeof(ClayGlasses).GetMethod(nameof(ClayGlasses.GetAdditionalMaximumDistance), BindingFlags.Static | BindingFlags.Public);

            Tools.FindField(ref index, ref codes, findField: MinVanishDistance, addCode: IncreaseVisibility, errorMessage: "Could not find first instance of MinVanishDistance");
            Tools.FindField(ref index, ref codes, findField: MinVanishDistance, addCode: IncreaseVisibility, errorMessage: "Could not find second instance of MinVanishDistance");

            return codes;
        }
    }
}
