using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;

namespace SDraw
{
    [BepInPlugin("org.stikosek.crabgamecheat", "stikosek crab game cheat", "0.0.0.4")]
    public class Plugin : BasePlugin
    {

        public override void Load()
        {
            // Plugin startup logic
            Log.LogInfo($"Plugin SDRAW is loaded!");
            sdraw.CreateInstance();
        }
        public void LogMsg(string msg)
        {
            Log.LogInfo(msg);
        }
       
    }
}
