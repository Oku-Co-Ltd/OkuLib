using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Oku
{
    internal static class FileLoader
    {
        //PUBLIC LOADING METHODS
        //Thanks Baan/GentleLeviathan!!!!
        public static AssetBundle GetAssetBundleAsGameObject(string path)
        {
            //Debug.Log("AssetBundleLoader: Attempting to load AssetBundle...");
            try
            {
                var bundle = AssetBundle.LoadFromFile(path);
                //Debug.Log("AssetBundleLoader: Success.");
                return bundle;
            }
            catch (Exception)
            {
                //Debug.Log("AssetBundleLoader: Couldn't load AssetBundle from path: '" + path + "'. Exception details: e: " + e.Message);
                return null;
            }
        }
        public static GameObject GetPrefabAsGameObject(AssetBundle bundleLoad, string name)
        {
            //Debug.Log("AssetBundleLoader: Attempting to retrieve: '" + name + "' as type: 'GameObject'" + " from " + bundleLoad);
            try
            {
                var temp = bundleLoad.LoadAsset(name, typeof(GameObject));
                //Debug.Log("AssetBundleLoader: Success.");
                return (GameObject)temp;
            }
            catch (Exception e)
            {
                //Debug.Log("AssetBundleLoader: Couldn't retrieve GameObject from AssetBundle.");
                return null;
            }

        }
        public static ScriptableObject GetPrefabAsScriptableObject(AssetBundle bundleLoad, string name)
        {
            //Debug.Log("AssetBundleLoader: Attempting to retrieve: '" + name + "' as type: 'Scriptable'" + " from " + bundleLoad);
            try
            {
                var temp = bundleLoad.LoadAsset(name, typeof(ScriptableObject));
                //Debug.Log("AssetBundleLoader: Success.");
                return (ScriptableObject)temp;
            }
            catch (Exception e)
            {
                //Debug.Log("AssetBundleLoader: Couldn't retrieve GameObject from AssetBundle.");
                return null;
            }

        }
        public static BuiltInCampaigns GetPrefabAsBICampaigns(AssetBundle bundleLoad, string name)
        {
            BuiltInCampaigns result;
            try
            {
                UnityEngine.Object @object = bundleLoad.LoadAsset(name, typeof(BuiltInCampaigns));
                result = (BuiltInCampaigns)@object;
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        public static PlayerVehicle GetPrefabAsPlayerVehicle(AssetBundle bundleLoad, string name)
        {
            PlayerVehicle result;
            try
            {
                UnityEngine.Object @object = bundleLoad.LoadAsset(name, typeof(PlayerVehicle));
                result = (PlayerVehicle)@object;
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
    }
}
