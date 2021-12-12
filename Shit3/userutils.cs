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

namespace Shit_UserUtils
{
	// Token: 0x02000437 RID: 1079
	internal class UserUtils
	{
		internal static GameObject[] GetAllGameObjects()
		{
			return SceneManager.GetActiveScene().GetRootGameObjects();
		}
		internal static GameObject GetLocalPlayer()
		{
			foreach (GameObject gameObject in UserUtils.GetAllGameObjects())
			{
				bool flag = gameObject.name.StartsWith("VRCPlayer[Local]");
				if (flag)
				{
					return gameObject;
				}
			}
			return new GameObject();
		}


	}
}



