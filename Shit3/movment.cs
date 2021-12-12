using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using MelonLoader;
using UIExpansionKit;
using Shit;
using UIExpansionKit.API;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.SDKBase;
using Harmony;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Runtime;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine.Events;
using VRC;
using UnityEngine.SceneManagement;
using ShitMov;

namespace Shit_Movement
{
	// Token: 0x02000442 RID: 1090
	internal class Movement : MelonMod
	{
		public override void OnUpdate()
		{
			if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.G))
			{
				MelonLogger.Msg("You just pressed Control G");
				bool fly = Movement.Fly;
				if (fly)
				{
					Physics.gravity = new Vector3(0f, -9.81f, 0f);
					Movement.Fly = false;
				}
				Movement.NoClip = !Movement.NoClip;
				flying.noclip();
				Networking.LocalPlayer.UseLegacyLocomotion();

			}
			if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F))
			{
				MelonLogger.Msg("You just pressed Control F");
				Movement.Fly = true;
				bool noClip = Movement.NoClip;
				if (!noClip)
				{
					Physics.gravity = new Vector3(0f, 0f, 0f);
					Networking.LocalPlayer.UseLegacyLocomotion();

				}

			}
		}

	

		// Token: 0x040003BB RID: 955
		public static bool Fly = false;

		// Token: 0x040003BC RID: 956
		public static bool NoClip = false;

		// Token: 0x040003BD RID: 957
		public static bool Speed = false;

		// Token: 0x040003BE RID: 958
		public static bool Jump = false;

		// Token: 0x040003BF RID: 959
		public static float RunSpeed = 16f;

		// Token: 0x040003C0 RID: 960
		public static float WalkSpeed = 8f;

		// Token: 0x040003C1 RID: 961
		public static float JumpPower = 8f;

		// Token: 0x040003C2 RID: 962
		public static float FlySpeed = 6f;
	}
}