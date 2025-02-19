using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MineController : MonoBehaviour
{
    [SerializeField] Material gold;
    [SerializeField] Material silver;
    [SerializeField] Material copper;
    [SerializeField] Material iron;

    static System.Random random = new System.Random();

    List<int> minesToSave = new List<int>();

    void colorMine()
    {
        Material[] materials = new Material[]{gold, silver, copper, iron};

        foreach (IMine mine in GetComponentsInChildren<IMine>())
        {
            List<Material> mt = new List<Material>();

            mine.TryGetComponent(out MeshRenderer renderer);
            int colorMineRandom = random.Next(0, 3);

            for(int i = 0;i < renderer.materials.Length;i++)
            {
                mt.Add(materials[colorMineRandom]);
            }
            minesToSave.Add(colorMineRandom);
            renderer.SetMaterials(mt);
        }


    }
    string path;

    void Start(){
        path = Path.GetFullPath("./");
        /*if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }*/
        colorMine();
    }

    void ParseFromJson()
    {
        Material[] materials = new Material[]{gold, silver, copper, iron};

        string data = FileUtilities.LoadFile("json.json");
        List<int> mt = (JsonHelper.FromJson<int>(data)).ToList<int>();
        Debug.Log(data);
        int counter = 0;

        foreach (IMine mine in GetComponentsInChildren<IMine>())
        {
            List<Material> material = new List<Material>();

            mine.TryGetComponent(out MeshRenderer renderer);
            int colorMine = mt[counter];

            for(int i = 0;i < renderer.materials.Length;i++)
            {
                material.Add(materials[0]);
            }
            renderer.SetMaterials(material);
            counter++;
        }
    }


}
enum MineType{
    Gold,
    Silver,
    Iron,
    Copper
}
public static class JsonHelper {
    public static string ToJson<T>(T[] array) {
        List<T> wrapper = new List<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }


    public static T[] FromJson<T>(string json) {
        List<T> wrapper = JsonUtility.FromJson<List<T>>(json);
        return wrapper.Items;
    }


    [Serializable]
    private class List<T> {
        public T[] Items;
    }
}