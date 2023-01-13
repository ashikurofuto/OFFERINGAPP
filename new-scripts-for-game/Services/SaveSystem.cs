using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : IGameService
{
    private string filepath;
    private BinaryFormatter formatter;
    private SurrogateSelector selector;
    private Vector3SerializationSurrogate v3Surrogate;

    public SaveSystem()
    {
        filepath = Application.persistentDataPath + "saves/GameSave.offeringData";
        InitFormatter();
    }

    private void InitFormatter()
    {
        formatter = new BinaryFormatter();
        selector = new SurrogateSelector();
        v3Surrogate = new Vector3SerializationSurrogate();
        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3Surrogate);
        formatter.SurrogateSelector = selector;
    }


    public object Load(object saveDataByDeafault)
    {
        if (!File.Exists(filepath))
        {
            if (saveDataByDeafault != null)
                Save(saveDataByDeafault);
            return saveDataByDeafault; 
        }
        var file = File.Open(filepath, FileMode.Open);
        var savedData = formatter.Deserialize(file);
        file.Close();
        return savedData;

    }
    public void Save(object saveData)
    {
        var file = File.Create(filepath);
        formatter.Serialize(file, saveData);
        file.Close();
    }

}
