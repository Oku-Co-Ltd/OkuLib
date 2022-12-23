using Harmony;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Oku.Utils;
using UnityEngine;
using TMPro;

namespace Oku
{
    public class OkuLib_Main : VTOLMOD
    {
        public static OkuLib_Main Instance;
        
        // This method is run once, when the Mod Loader is done initializing this game object
        public override void ModLoaded()
        {
            Instance = this;

            OkuLog.Info("OkuLib core has initialized, loading pilot prefab");

            OkuLibConst.AssetBundleAbsPath = Path.Combine(
                Instance.ModFolder,
                "bundles",
                OkuConstDefs.AssetBundleName);

            // 1. load the asset bundle into memory
            OkuLibConst.OkuLibAb = FileLoader.GetAssetBundleAsGameObject(OkuLibConst.AssetBundleAbsPath);

            if (OkuLibConst.OkuLibAb == null)
            {
                OkuLog.Error($"Could not load asset bundle at path '{OkuLibConst.AssetBundleAbsPath}'");
                enabled = false;
                return;
            }
            // 2. get pilot prefab, as a sanity check
            try
            {
                OkuLibConst.PilotPrefabInstance = OkuConstDefs.GetPilotPrefab();
            }
            catch (Exception ex)
            {
                OkuLog.Error("Could not load pilot prefab from asset bundle.");
                Debug.LogException(ex);

                OkuLibConst.OkuLibAb.Unload(true);

                enabled = false;
                return;
            }

            if (OkuLibConst.PilotPrefabInstance == null)
            {
                OkuLog.Error("OkuConstDefs.GetPilotPrefab() returned null, meaning it couldn't find the prefab.");

                OkuLibConst.OkuLibAb.Unload(true);

                enabled = false;
                return;
            }
            
            // 3. success
            OkuLog.Info("OkuLib successfully loaded!");
            
            VTOLAPI.SceneLoaded += SceneLoaded;
            base.ModLoaded();
        }

        /// <summary>
        /// This function is called every time a scene is loaded. This behaviour is defined in the <c>Awake()</c> call time step.
        /// </summary>
        private static void SceneLoaded(VTOLScenes scene)
        {
            switch (scene)
            {
                case VTOLScenes.VehicleConfiguration:
                case VTOLScenes.SplashScene:
                case VTOLScenes.SamplerScene:
                case VTOLScenes.ReadyRoom:
                case VTOLScenes.MeshTerrain:
                case VTOLScenes.LoadingScene:
                case VTOLScenes.OpenWater:
                case VTOLScenes.Akutan:
                case VTOLScenes.VTEditMenu:
                case VTOLScenes.VTEditLoadingScene:
                case VTOLScenes.VTMapEditMenu:
                case VTOLScenes.CustomMapBase:
                case VTOLScenes.CommRadioTest:
                case VTOLScenes.ShaderVariantsScene:
                case VTOLScenes.CustomMapBase_OverCloud:
                case VTOLScenes.LocalizationScene:
                default:
                    break;
            }
        }
        internal static class OkuLibConst
        {
            internal static string AssetBundleAbsPath;

            internal static AssetBundle OkuLibAb;

            internal static GameObject PilotPrefabInstance;
        }
    }
}
