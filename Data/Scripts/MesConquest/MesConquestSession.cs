using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Utils;
using VRageMath;

namespace MesConquest {

	[MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
	public class MesConquestSession : MySessionComponentBase {

		public static bool ModEnabled = true;
		public static bool OfflineDetected = false;
		public static bool SyncWarning = false;
		public bool FinalSetup = false;

		public static string ModVersion = "1.0.0";
		public static int ModVersionValue = 100000000; //Use above value as reference - 3 digits per part (
		public static MesConquestSession Instance;
		public bool _spawnCondition_PlanetRegistered = false;

		public static bool IsServer;
		public static bool IsDedicated;
		public static MESApi MESApi;

		public override void LoadData() {

			Instance = this;

			IsServer = MyAPIGateway.Multiplayer.IsServer;
			IsDedicated = MyAPIGateway.Utilities.IsDedicated;

			if (!IsServer)
				return;

			SetUpdateOrder(MyUpdateOrder.AfterSimulation);

            MESApi = new MESApi();

			
		}

		protected override void UnloadData()
        {
			MESApi.UnregisterListener();
		}

		public override void UpdateAfterSimulation()
		{
            if (!_spawnCondition_PlanetRegistered && MyAPIGateway.Session?.Player != null)
            {
				MyLog.Default.WriteLineAndConsole($"Begin [UpdateAfterSimulation]");

				List<string> spawnGroupBlacklist = new List<string>();
				foreach (var def in MyDefinitionManager.Static.GetEntityComponentDefinitions())
				{
					MyLog.Default.WriteLineAndConsole($"SubtypeName {def.Id.SubtypeId}");
					MyLog.Default.WriteLineAndConsole($"ModName {def.Context.ModName}");
				}

				MyLog.Default.WriteLineAndConsole($"End [UpdateAfterSimulation]");

				MyAPIGateway.Utilities.InvokeOnGameThread(() => SetUpdateOrder(MyUpdateOrder.NoUpdate));
			}

        }

		public void replaceSpawnGroupsAll()
        {
			MyLog.Default.WriteLineAndConsole($"Start replacing spawnGroups");
			List<string> spawnGroupBlacklist = new List<string>();
			foreach (var def in MyDefinitionManager.Static.GetEntityComponentDefinitions())
			{
				MyLog.Default.WriteLineAndConsole($"SubtypeName {def.Id.SubtypeId}");
				MyLog.Default.WriteLineAndConsole($"ModName {def.Context.ModName}");
			}

			MyLog.Default.WriteLineAndConsole($"Finished replacing spawnGroups");
		}

	}
}
