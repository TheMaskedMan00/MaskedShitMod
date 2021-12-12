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
using Shit_Movement;
using Shit_UserUtils;
using UnityEngine.XR;

namespace ShitMov
{
	// Token: 0x02000029 RID: 41
	internal class Flying
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x0000A1BC File Offset: 0x000083BC
		internal static void Height_adjust()
		{
			bool isPresent = XRDevice.isPresent;
			if (isPresent)
			{
				bool flag = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f;
				if (flag)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position - new Vector3(0f, Movement.FlySpeed * Time.deltaTime, 0f);
				}
				bool flag2 = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f;
				if (flag2)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, Movement.FlySpeed * Time.deltaTime, 0f);
				}
				bool flag3 = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") < 0f;
				if (flag3)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * -1f * Movement.FlySpeed * Time.deltaTime;
				}
				bool flag4 = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") > 0f;
				if (flag4)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * Movement.FlySpeed * Time.deltaTime;
				}
				bool flag5 = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") < 0f;
				if (flag5)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * -1f * Movement.FlySpeed * Time.deltaTime;
				}
				bool flag6 = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") > 0f;
				if (flag6)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * Movement.FlySpeed * Time.deltaTime;
				}
			}
			else
			{
				bool key = Input.GetKey(KeyCode.Q);
				if (key)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position - new Vector3(0f, Movement.FlySpeed * Time.deltaTime, 0f);
				}
				bool key2 = Input.GetKey(KeyCode.E);
				if (key2)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, Movement.FlySpeed * Time.deltaTime, 0f);
				}
				bool key3 = Input.GetKey(KeyCode.W);
				if (key3)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * Movement.FlySpeed * Time.deltaTime;
				}
				bool key4 = Input.GetKey(KeyCode.A);
				if (key4)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * -1f * Movement.FlySpeed * Time.deltaTime;
				}
				bool key5 = Input.GetKey(KeyCode.S);
				if (key5)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * -1f * Movement.FlySpeed * Time.deltaTime;
				}
				bool key6 = Input.GetKey(KeyCode.D);
				if (key6)
				{
					VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * Movement.FlySpeed * Time.deltaTime;
				}
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000A5D8 File Offset: 0x000087D8
		internal static void Noclip()
		{
			bool noClip = Movement.NoClip;
			if (noClip)
			{
				Physics.gravity = new Vector3(0f, 0f, 0f);
			}
			else
			{
				Physics.gravity = new Vector3(0f, -9.81f, 0f);
			}
			bool enabled = UserUtils.GetLocalPlayer().GetComponent<Collider>().enabled;
			if (enabled)
			{
				UserUtils.GetLocalPlayer().GetComponent<Collider>().enabled = false;
			}
			else
			{
				UserUtils.GetLocalPlayer().GetComponent<Collider>().enabled = true;
			}
		}
	}
}
