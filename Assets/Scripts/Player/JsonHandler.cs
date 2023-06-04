using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{
    public SavedPositionData data;

    private string file = "savedPosition.txt";

    //Converts the data object into a JSON string , and then calls the WriteToFile() method to save the JSON string to a file.
    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    //Reads the JSON data from the file
    public void Load()
    {
        data = new SavedPositionData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    //Writes the JSON string to a file specified by fileName
    //Creates a new FileStream with the specified path and writes the JSON string using a StreamWriter
    private void WriteToFile(string fileName, string json)
    {
        try
        {
            string path = GetFilePath(fileName);
            FileStream fileStream = new FileStream(path, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }


    }

    //Reads the contents of a file specified by fileName and returns it as a string
    private string ReadFromFile(string fileName)
    {
        try
        {
            string path = GetFilePath(fileName);
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    return json;
                }
            }
        }catch(Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        return "";
        
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

//Store the position of the main character
public class SavedPositionData
{
    public Vector3 position;
    public string sceneName;
    public int health;

    public SavedPositionData()
    {
    }
}
