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
using ShitMov;
using Shit_UserUtils;



[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(ShitUi), "Masked's Shit Mod", "1.1.4", "Masked", "none")]

namespace Shit
{
    public class ShitUi : MelonMod
    {

        public override void OnUpdate()
        {
            if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.J))
            {
                Networking.LocalPlayer.SetJumpImpulse(3f);
                MelonLogger.Msg("You just pressed Control J");
            }
            if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.G))
            {
                MelonLogger.Msg("You just pressed Control G");
                bool fly = ShitUi.Fly;
                if (fly)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    ShitUi.Fly = false;
                }
                ShitUi.NoClip = !ShitUi.NoClip;
                Flying.Noclip();
                Networking.LocalPlayer.UseLegacyLocomotion();

            }
            if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.F))
            {
                MelonLogger.Msg("You just pressed Control F");
                ShitUi.Fly = !ShitUi.Fly;
                bool noClip = ShitUi.NoClip;
                if (!noClip)
                {
                    Physics.gravity = new Vector3(0f, 0f, 0f);
                    Networking.LocalPlayer.UseLegacyLocomotion();

    

                }

        } }
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
}
    

       

    

