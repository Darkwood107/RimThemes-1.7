using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using Verse;
using Verse.Sound;
using HarmonyLib;

namespace aRandomKiwi.RimThemes
{
    [HarmonyPatch(typeof(GUI), "DrawTexture", new Type[] { typeof(Rect), typeof(Texture) }), StaticConstructorOnStartup]
    class GUI_DrawTexture_Patch
    {
        static Color prevColor;

        [HarmonyPrefix]
        static bool Prefix(Rect position, Texture image, out bool __state)
        {
            __state = false;
            if (!(Themes.initialized && Themes.vanillaThemeSaved) || !LoaderGM.reachedMainMenu)
                return true;

            try
            {
                Color prev = GUI.color;
                prevColor = prev;
                __state = true;
                GUI.color = ColorsSubstitution.getTextureSubstitutionColor(prev);
               // GUI.DrawTexture(position, image, ScaleMode.StretchToFill);
                //GUI.color = prev;
                //return false;
                return true;
            }
            catch (Exception e)
            {
                Themes.LogError("GUI.DrawTexture patch failed : " + e.Message);
                return true;
            }
        }

        [HarmonyPostfix]
        static void Postfix(Rect position, Texture image, bool __state)
        {
            //1.7 fix: restore only what the prefix saved (was restoring default(Color) = transparent)
            if (__state)
                GUI.color = prevColor;
        }
    }
}
