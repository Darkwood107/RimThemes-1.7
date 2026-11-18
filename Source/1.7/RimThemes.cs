using System;
using HarmonyLib;
using System.Reflection;
using Verse;
using UnityEngine;

namespace aRandomKiwi.RimThemes
{
    [StaticConstructorOnStartup]
    class RimThemes : Mod
    {
        static RimThemes()
        {
            //Add GM of the loader to override the display
            comp = Utils.AttachLoaderGM();
        }

        public static LoaderGM comp;
        public RimThemes(ModContentPack content) : base(content)
        {
            base.GetSettings<Settings>();
            Themes.LogMsg("[RimThemes] Init");
            Utils.currentMod = content;
            Utils.currentModInst = this;

            var inst = new Harmony("rimworld.aRandomKiwi.RimTheme");
            ApplyPatchesSafely(inst);
            Themes.LogMsg("Init Harmony patchs");

            Log.Message(Utils.releaseInfo);
        }

        /*
         * 1.7 (Waylith + Harmony 3): PatchAll() aborts on the first patch that fails
         * (Harmony 3 enforces __instance/__result types, and some Unity calls are now stubs).
         * Patch each class separately so a single broken patch only disables its own feature.
         */
        private static void ApplyPatchesSafely(Harmony inst)
        {
            int ok = 0, failed = 0;
            foreach (Type type in AccessTools.GetTypesFromAssembly(Assembly.GetExecutingAssembly()))
            {
                if (!type.IsDefined(typeof(HarmonyPatch), false))
                    continue;
                try
                {
                    inst.CreateClassProcessor(type).Patch();
                    ok++;
                }
                catch (Exception e)
                {
                    failed++;
                    Log.Warning("[RimThemes] 1.7: patch " + type.FullName + " skipped : " + (e.InnerException ?? e).Message);
                }
            }
            Themes.LogMsg("Harmony patchs applied : " + ok + " ok, " + failed + " skipped");
        }

        public void Save()
        {
            LoadedModManager.GetMod<RimThemes>().GetSettings<Settings>().Write();
        }

        public override string SettingsCategory()
        {
            return "RimThemes";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Settings.DoSettingsWindowContents(inRect);
        }
    }
}