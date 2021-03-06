﻿using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using JetBrains.Annotations;
using UnityEditor;

namespace Tonny.Common.AssetLoader
{
    public static class LoadUtility
    {
        #region Simulate
        public const string UiPanelOutputPath = "prefab/ui/panel";
        public const string UiAtlasOutputPath = "prefab/ui/atlas";
        public const string AudioOutputPath = "prefab/audio";
        public const string CharacterOutputPath = "prefab/character/player";
        public const string NpcOutputPath = "prefab/character/npc";
        public const string MonsterOutputPath = "prefab/character/monster";
        public const string FxOutputPath = "prefab/fx";
        #endregion

        #region AssetBundle
        public const string AssetBundleOutputPath = "AssetBundles";
        #endregion

        public static string GetPlatformName()
        {
#if UNITY_EDITOR
            return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
            return GetPlatformForAssetBundles(Application.platform);
#endif
        }

#if UNITY_EDITOR
        private static string GetPlatformForAssetBundles(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return "Android";
                case BuildTarget.iOS:
                    return "iOS";
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    return "Windows";
                case BuildTarget.StandaloneOSXIntel:
                case BuildTarget.StandaloneOSXIntel64:
                case BuildTarget.StandaloneOSXUniversal:
                    return "Mac";
                default:
                    return "";
            }
        }
#endif

        private static string GetPlatformForAssetBundles(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "iOS";
                case RuntimePlatform.WindowsPlayer:
                    return "Windows";
                case RuntimePlatform.OSXPlayer:
                    return "Mac";
                default:
                    return "";
            }
        }

        public static string GetStreamingAssetsPath()
        {
            string assetPath = "";
            if (Application.isEditor)
            {
                assetPath = "file://" + System.Environment.CurrentDirectory.Replace("\\", "/");
            }
            else if (Application.isWebPlayer)
            {
                assetPath = System.IO.Path.GetDirectoryName(Application.absoluteURL).Replace("\\", "/") +
                            "/StreamingAssets";
            }
            else if (Application.isMobilePlatform || Application.isConsolePlatform)
            {
                assetPath = Application.streamingAssetsPath;
            }
            else
            {
                assetPath = Application.streamingAssetsPath;
            }
            return assetPath;
        }

        public static string GetBundleBaseURL()
        {
            return "";
        }
    }
}


