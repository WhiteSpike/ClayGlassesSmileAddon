using BepInEx;
using HarmonyLib;
using ClayGlassesSmileAddon.Utils;
using BepInEx.Logging;
namespace ClayGlassesSmileAddon
{
    [BepInPlugin(PluginMetadata.PLUGIN_GUID,PluginMetadata.PLUGIN_NAME,PluginMetadata.PLUGIN_VERSION)]
    [BepInDependency(MoreShipUpgrades.Misc.Metadata.GUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("MagicWesley.WesleysInteriorTools", BepInDependency.DependencyFlags.HardDependency)]
    internal class ClayGlassesSmileAddon : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginMetadata.PLUGIN_GUID);
        internal ManualLogSource logger;

        internal static ClayGlassesSmileAddon Instance { get; set; }

        private void Awake()
        {
            logger = base.Logger;
            if (Instance == null)
            {
                Instance = this;
            }
            harmony.PatchAll();
            logger.LogInfo($"Plugin {PluginMetadata.PLUGIN_NAME} {PluginMetadata.PLUGIN_VERSION} is loaded!");
        }
    }
}
