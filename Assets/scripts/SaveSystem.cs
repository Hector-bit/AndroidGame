using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel (Victory levelPassed){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Stats data = new Stats(levelPassed);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Stats LoadLevel (){
        string path = Application.persistentDataPath + "/Player.fun";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Stats data = formatter.Deserialize(stream) as Stats;
            stream.Close();

            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}