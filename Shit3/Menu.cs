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




[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(ShitUi), "Masked's Shit Mod", "1.1.4", "Masked", "none")]

namespace Shit
{
    public class ShitUi : MelonMod
    {
        public static void Items()
        { 
                VRC.SDKBase.VRC_Pickup[] array = Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>().ToArray<VRC.SDKBase.VRC_Pickup>();
                for (int i = 0; i < array.Length; i++)
                {
                    bool flag = array[i].gameObject;
                    if (flag)
                    {
                        Networking.LocalPlayer.TakeOwnership(array[i].gameObject);
                        array[i].transform.localPosition = new Vector3(0f, 0.3f, 0f);
                        Transform transform = array[i].transform;
                        transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 0.1f, 0f);
                    }
                }

            }
        private static bool fly;
        private static bool isInVR = false;
        private static VRCPlayer LocalPlayer;
        private static Vector3 oldGravity;
        private static bool noclip;
        private static bool blockedKeyInput = false;
        private static IEnumerator BlockKeyInput()
        {
            blockedKeyInput = true;
            yield return new WaitForSeconds(3f);
            blockedKeyInput = false;
        }


        public override void OnUpdate()
        {
            if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.G))
            {

                MelonLogger.Msg("You just pressed Control G");
                if (!noclip)
                {
                    var Colliders = Resources.FindObjectsOfTypeAll<Collider>();
                    noclip = true;
                    foreach (Collider collider in Colliders)
                        if (collider.name.Contains("VRCPlayer"))
                            collider.enabled = true;
                }
                else
                {
                    var Colliders = Resources.FindObjectsOfTypeAll<Collider>();
                    noclip = false;
                    foreach (Collider collider in Colliders)
                        if (collider.name.Contains("VRCPlayer"))
                            collider.enabled = true;
                }
            }
            if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F))
            {
                MelonLogger.Msg("You just pressed Control F");
                if (!fly)
                {
                    fly = true;
                    LocalPlayer = VRCPlayer.field_Internal_Static_VRCPlayer_0;
                    isInVR = LocalPlayer.prop_VRCPlayerApi_0.IsUserInVR();
                    oldGravity = Physics.gravity;
                    Physics.gravity = (Vector3.zero);
                    Networking.LocalPlayer.UseLegacyLocomotion();
                }
                else
                {
                    fly = false;
                    Physics.gravity = oldGravity;
                }
            }
            if (fly)
            {
                VRCPlayer LocalPlayer = VRCPlayer.field_Internal_Static_VRCPlayer_0;
                float FlySpeed = 5;
                if (isInVR)
                {
                    if (Math.Abs(Input.GetAxis("Vertical")) != 0f)
                        LocalPlayer.transform.position += LocalPlayer.transform.forward * FlySpeed * Time.deltaTime * Input.GetAxis("Vertical");
                    if (Math.Abs(Input.GetAxis("Horizontal")) != 0f)
                        LocalPlayer.transform.position += LocalPlayer.transform.right * FlySpeed * Time.deltaTime * Input.GetAxis("Horizontal");
                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
                        LocalPlayer.transform.position += LocalPlayer.transform.up * FlySpeed * Time.deltaTime * Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical");
                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
                        LocalPlayer.transform.position += LocalPlayer.transform.up * FlySpeed * Time.deltaTime * Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical");
                }
                else
                {
                    bool key = Input.GetKey(KeyCode.Q);
                    if (key)
                    {
                        VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position - new Vector3(0f, FlySpeed * Time.deltaTime, 0f);
                    }
                    bool key2 = Input.GetKey(KeyCode.E);
                    if (key2)
                    {
                        VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, FlySpeed * Time.deltaTime, 0f);
                    }
                    bool key3 = Input.GetKey(KeyCode.W);
                    if (key3)
                    {
                        VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * FlySpeed * Time.deltaTime;
                    }
                    bool key4 = Input.GetKey(KeyCode.A);
                    if (key4)
                    {
                        VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * -1f * FlySpeed * Time.deltaTime;
                    }
                    bool key5 = Input.GetKey(KeyCode.S);
                    if (key5)
                    {
                        VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.forward * -1f * FlySpeed * Time.deltaTime;
                    }
                    bool key6 = Input.GetKey(KeyCode.D);
                    if (key6)
                    {
                        VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.right * FlySpeed * Time.deltaTime;
                    }
                }
            }
            if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.J))
            {
                Networking.LocalPlayer.SetJumpImpulse(3f);
                MelonLogger.Msg("You just pressed Control J");
            }
            if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.K))
            {
                Networking.LocalPlayer.SetJumpImpulse(3f);
                MelonLogger.Msg("You just pressed Control K");
                Items();
            }


        } 
        }

        // Token: 0x040003BB RID: 955

    }
    class Menu
    {
        //dosent work but too lazy to remove
        static bool runOnce_start, runOnce;
        public static void InitUi()
        {
            try
            {
                ExpansionKitApi.GetExpandedMenu(ExpandedMenu.QuickMenu).AddSimpleButton("Waypoints", () =>
                {
                    if (!runOnce_start)
                    {
                        MelonLogger.Msg("Setting up Menus");
                        TheMenu();
                        runOnce_start = true;
                    }
                    else if (runOnce_start)
                    {

                    }
                });
            }
            catch (Exception e) { MelonLogger.Error("UIXMenu:\n" + e.ToString()); }
        
        }

        private static void TheMenu()
        {

            MelonLogger.Error("hi");
            MelonLogger.Error("aa");
            ExpansionKitApi.GetExpandedMenu(ExpandedMenu.UserQuickMenu).AddSimpleButton("Jump", () => Networking.LocalPlayer.SetJumpImpulse(3f));
            //ExpansionKitApi.GetExpandedMenu(ExpandedMenu.UserQuickMenu).AddSimpleButton("Jump2", () => Networking.LocalPlayer.SetJumpImpulse(3f));
            //ExpansionKitApi.GetExpandedMenu(ExpandedMenu.UserQuickMenu).AddSimpleButton("Jump3", () => MelonLogger.Msg("You just pressed a button"));
        }

}


    

       

    

