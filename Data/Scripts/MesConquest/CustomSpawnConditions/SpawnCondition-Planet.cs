using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRageMath;
using Sandbox.ModAPI;
using VRage.Utils;
using VRage.Game;

namespace MesConquest
{
    class SpawnCondition_Planet
    {
        public static bool Evaluate(string spawnGroup, string spawnConditions, string spawnType, Vector3D spawnLocation)
        {
            if (MyAPIGateway.Session?.Player != null)
            {
                MyAPIGateway.Utilities.ShowNotification($"spawnGroup: {spawnGroup}", 20000, MyFontEnum.White);
                MyAPIGateway.Utilities.ShowNotification($"spawnConditions: {spawnConditions}", 20000, MyFontEnum.White);
                MyAPIGateway.Utilities.ShowNotification($"spawnType: {spawnType}", 20000, MyFontEnum.White);
                MyAPIGateway.Utilities.ShowNotification($"spawnLocation: {spawnLocation}", 20000, MyFontEnum.White);
            }

            MyLog.Default.WriteLineAndConsole($"spawnGroup: {spawnGroup}");
            MyLog.Default.WriteLineAndConsole($"spawnConditions: {spawnConditions}");
            MyLog.Default.WriteLineAndConsole($"spawnType: {spawnType}");
            MyLog.Default.WriteLineAndConsole($"spawnLocation: {spawnLocation}");

            return true;
        }
	}
}
