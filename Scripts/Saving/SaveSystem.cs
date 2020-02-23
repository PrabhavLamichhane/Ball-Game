using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

//DEVELOPER : LUKAS TOMASEK

//ALL RIGHTS RESERVED


namespace LukasScripts{

	public class SaveSystem 
	{
        public static void SaveData(SaveManager manager)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.dat";
            FileStream file = new FileStream(path, FileMode.Create);

            try
            {
                PlayerData data = new PlayerData(manager);
                formatter.Serialize(file, data);
            }
            catch(SerializationException e)
            {
                Debug.LogError($"There is issue seriaizing data : {e}");
            }
            finally
            {
                file.Close();
            }
        }	


        public static PlayerData LoadData()
        {

            string path = Application.persistentDataPath + "/player.dat";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.OpenOrCreate);

                PlayerData data = formatter.Deserialize(file) as PlayerData;
                file.Close();

                return data;
            }
            else
            {
                Debug.LogError($"Save File not found at : {path} ");
                return null;
            }
        }
	}

}