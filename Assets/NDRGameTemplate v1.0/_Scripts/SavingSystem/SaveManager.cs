using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace NDRGameTemplate
{
    public static class SaveManager
    {
        private static string path = "/NDRGameTemplate v1.0/Resources/Saves";
        private static string fileName = "savedGame";
        private static string ext = ".sg";

        public static void SaveGameData()
        {
            // PlayerPrefs.SetInt("FurthestLevel", PlaySessionManager.instance.FurthestLevel);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Create(Application.dataPath + path + fileName + ext);
            bf.Serialize(fileStream, PlaySessionManager.instance.FurthestLevel);
            fileStream.Close();
        }

        public static void LoadGameData()
        {
            // PlaySessionManager.instance.FurthestLevel = PlayerPrefs.GetInt("FurthestLevel");
            if(File.Exists(Application.dataPath + path + fileName + ext))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(Application.dataPath + path + fileName + ext, FileMode.Open);
                PlaySessionManager.instance.FurthestLevel = (int)formatter.Deserialize(file);
                file.Close();
            }
            else
            {
                PlaySessionManager.instance.FurthestLevel = 0;
            }
        }

        public static void ClearSaves()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("All of the saves deleted.");
        }

        public static void SaveSetting(string label, float value)
        {
            PlayerPrefs.SetFloat(label, value);
        }

        public static void SaveSetting(string label, int value)
        {
            PlayerPrefs.SetInt(label, value);
        }
        public static void SaveSetting(string label, string value)
        {
            PlayerPrefs.SetString(label, value);
        }

        public static float LoadSettingF(string label) => PlayerPrefs.GetFloat(label);
        public static int LoadSetting(string label) => PlayerPrefs.GetInt(label);
        public static string LoadSettingString(string label) => PlayerPrefs.GetString(label);
        public static string LoadSettingString(string label, string defaultValue) => PlayerPrefs.GetString(label, defaultValue);
    }
}
