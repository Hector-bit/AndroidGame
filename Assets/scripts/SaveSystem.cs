using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel (Victory levelPassed){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "levelPassed.fun");
        FileStream stream = new FileStream(path, FileMode.Create);

        Stats data = new Stats(levelPassed);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveControlLevelSelection (ControlLevelSelection temp){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "temp.fun");
        FileStream stream = new FileStream(path, FileMode.Create);

        StatsLevel data = new StatsLevel(temp);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Stats LoadLevel (){
        string path = Path.Combine(Application.persistentDataPath, "levelPassed.fun");
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

    public static StatsLevel LoadControlLevelSelection (){
        string path = Path.Combine(Application.persistentDataPath, "temp.fun");
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StatsLevel data = formatter.Deserialize(stream) as StatsLevel;
            stream.Close();

            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}