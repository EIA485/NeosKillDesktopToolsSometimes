using HarmonyLib;
using NeosModLoader;
using System.Reflection;
using System.Threading.Tasks;
using FrooxEngine;


namespace KillDesktopToolsSometimes
{
    public class KillDesktopToolsSometimes : NeosMod
    {
        public override string Name => "KillDesktopToolsSometimes";
        public override string Author => "eia485";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/EIA485/NeosKillDesktopToolsSometimes/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.KillDesktopToolsSometimes");
            Debug(Assembly.GetExecutingAssembly().FullName);
            harmony.PatchAll();

        }
		
		[HarmonyPatch(typeof(CommonTool), "SpawnAndEquip")]
        class KillDesktopToolsSometimesPatch
        {
            public static bool Prefix(ref Task __result, CommonTool __instance)
            {
                if (__instance?.ActiveToolTip?.GetType() == typeof(TooltipMultiplexer))
                {
                    __result = new TaskCompletionSource<bool>().Task;
                    return false;
                }
                else
                {
                    return true;
                }
                

            }
        
        }
    }
}
