// 1.7: RuntimeAudioClipLoader removed, AudioClip.LoadFromFile is used instead
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace aRandomKiwi.RimThemes
{
    public class AudioGrain_ClipTheme : AudioGrain_Clip
    {
        [NoTranslate]
        public string themeClipPath = string.Empty;

        [DebuggerHidden]
        public override IEnumerable<ResolvedGrain> GetResolvedGrains()
        {
            AudioClip clip = null;
            //Specific treatment depending on the platform
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                clip = winLoadAudio(this.themeClipPath);
            }
            else
            {
                try
                {
                    clip = linuxLoadAudio(this.themeClipPath);
                }
                catch (Exception e)
                {
                    Themes.LogMsg("Unable resolve grain : " + e.Message);
                }
            }
            if (clip != null)
            {
                yield return new ResolvedGrain_Clip(clip);
            }
            else
            {
                Log.Error("Grain couldn't resolve: Clip not found at " + this.clipPath);
            }
        }

        static public AudioClip winLoadAudio(string themeClipPath)
        {
            try
            {
                // 1.7 (Waylith): engine decides streaming itself (AudioBackend.ShouldStream)
                AudioClip clip = AudioClip.LoadFromFile(themeClipPath);
                if (clip != null)
                    clip.name = Path.GetFileNameWithoutExtension(themeClipPath);
                return clip;
            }
            catch (Exception e)
            {
                Themes.LogMsg("winLoadAudio failed : " + e.Message);
                return null;
            }
        }

        /*
         * 1.7: Unity's WWW class may be missing from the Waylith Unity shim. The game's own clip loader
         * (AudioClip.LoadFromFile) is used on every platform instead.
         */
        static public AudioClip linuxLoadAudio(string themeClipPath)
        {
            return winLoadAudio(themeClipPath);
        }

        private static bool ShouldStreamAudioClipFromPath(string absPath)
        {
            if (!File.Exists(absPath))
            {
                return false;
            }
            FileInfo fileInfo = new FileInfo(absPath);
            return fileInfo.Length > 307200L;
        }
    }
}