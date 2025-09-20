using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.Networking;

public class SaveController : MonoBehaviour
{
    string path;
    public GameObject flowerPrefab;
    public GameObject grassPrefab;
    public GameObject treePrefab;
    public GameObject housePrefab;
    public GameObject woodenShedPrefab;
    public GameObject laundryPrefab;
    public GameObject mountainPrefab;
    public GameObject skyPrefab;

    void Start()
    {
        path = Application.persistentDataPath + "/fase.json";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadOnline());
        }
    }

    void Save()
    {

        Flower[] flowers = FindObjectsByType<Flower>(FindObjectsSortMode.None);
        List<FlowerData> flowerDataList = new List<FlowerData>();
        foreach (Flower flower in flowers)
        {
            flowerDataList.Add(AdapterData.GetFlowerData(flower));
        }

        Grass[] grasses = FindObjectsByType<Grass>(FindObjectsSortMode.None);
        List<GrassData> grassDataList = new List<GrassData>();
        foreach (Grass grass in grasses)
        {
            grassDataList.Add(AdapterData.GetGrassData(grass));
        }

        Tree[] trees = FindObjectsByType<Tree>(FindObjectsSortMode.None);
        List<TreeData> treeDataList = new List<TreeData>();
        foreach (Tree tree in trees)
        {
            treeDataList.Add(AdapterData.GetTreeData(tree));
        }


        House house = FindFirstObjectByType<House>();
        HouseData houseData = null;
        if (house != null)
        {
            houseData = AdapterData.GetHouseData(house);
        }

        WoodenShed shed = FindFirstObjectByType<WoodenShed>();
        WoodenShedData shedData = null;
        if (shed != null)
        {
            shedData = AdapterData.GetWoodenShedData(shed);
        }

        Laundry laundry = FindFirstObjectByType<Laundry>();
        LaundryData laundryData = null;
        if (laundry != null)
        {
            laundryData = AdapterData.GetLaundryData(laundry);
        }

        Mountain mountain = FindFirstObjectByType<Mountain>();
        MountainData mountainData = null;
        if (mountain != null)
        {
            mountainData = AdapterData.GetMountainData(mountain);
        }

        Sky sky = FindFirstObjectByType<Sky>();
        SkyData skyData = null;
        if (sky != null)
        {
            skyData = AdapterData.GetSkyData(sky);
        }

        SceneData sceneData = new SceneData();
        sceneData.flowers = flowerDataList.ToArray();
        sceneData.grasses = grassDataList.ToArray();
        sceneData.trees = treeDataList.ToArray();
        sceneData.house = houseData;
        sceneData.woodenShed = shedData;
        sceneData.laundry = laundryData;
        sceneData.mountain = mountainData;
        sceneData.sky = skyData;

        string json = JsonUtility.ToJson(sceneData);
        File.WriteAllText(path, json);

        Debug.Log($"Cena salva em: {path}");
    }

    public void Load()
    {
        string json = File.ReadAllText(path);

        SceneData sceneData = JsonUtility.FromJson<SceneData>(json);

        foreach (FlowerData flower in sceneData.flowers)
        {
            if (flowerPrefab != null)
            {
                GameObject go = Instantiate(flowerPrefab, flower.pos, Quaternion.Euler(flower.rot));
                go.transform.localScale = flower.scale;
            }
        }

        foreach (GrassData grass in sceneData.grasses)
        {
            if (grassPrefab != null)
            {
                GameObject go = Instantiate(grassPrefab, grass.pos, Quaternion.Euler(grass.rot));
                go.transform.localScale = grass.scale;
            }
        }

        foreach (TreeData tree in sceneData.trees)
        {
            if (treePrefab != null)
            {
                GameObject go = Instantiate(treePrefab, tree.pos, Quaternion.Euler(tree.rot));
                go.transform.localScale = tree.scale;
            }
        }

        if (skyPrefab != null && sceneData.sky != null)
        {
            GameObject go = Instantiate(skyPrefab, sceneData.sky.pos, Quaternion.Euler(sceneData.sky.rot));
            go.transform.localScale = sceneData.sky.scale;
        }

        if (housePrefab != null && sceneData.house != null)
        {
            GameObject go = Instantiate(housePrefab, sceneData.house.pos, Quaternion.Euler(sceneData.house.rot));
            go.transform.localScale = sceneData.house.scale;
        }

        if (woodenShedPrefab != null && sceneData.woodenShed != null)
        {
            GameObject go = Instantiate(woodenShedPrefab, sceneData.woodenShed.pos, Quaternion.Euler(sceneData.woodenShed.rot));
            go.transform.localScale = sceneData.woodenShed.scale;
        }

        if (laundryPrefab != null && sceneData.laundry != null)
        {
            GameObject go = Instantiate(laundryPrefab, sceneData.laundry.pos, Quaternion.Euler(sceneData.laundry.rot));
            go.transform.localScale = sceneData.laundry.scale;
        }

        if (mountainPrefab != null && sceneData.mountain != null)
        {
            GameObject go = Instantiate(mountainPrefab, sceneData.mountain.pos, Quaternion.Euler(sceneData.mountain.rot));
            go.transform.localScale = sceneData.mountain.scale;
        }
    }

    public IEnumerator LoadOnline()
    {
        string url = "https://raw.githubusercontent.com/Pedro-HFelix/PERSISTENCIABACK/refs/heads/main/SceneData.json";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Erro ao carregar LoadOnline: " + request.error);
            yield break;
        }

        string json = request.downloadHandler.text;

        SceneData sceneData = JsonUtility.FromJson<SceneData>(json);

        foreach (FlowerData flower in sceneData.flowers)
        {
            if (flowerPrefab != null)
            {
                GameObject go = Instantiate(flowerPrefab, flower.pos, Quaternion.Euler(flower.rot));
                go.transform.localScale = flower.scale;
            }
        }

        foreach (GrassData grass in sceneData.grasses)
        {
            if (grassPrefab != null)
            {
                GameObject go = Instantiate(grassPrefab, grass.pos, Quaternion.Euler(grass.rot));
                go.transform.localScale = grass.scale;
            }
        }

        foreach (TreeData tree in sceneData.trees)
        {
            if (treePrefab != null)
            {
                GameObject go = Instantiate(treePrefab, tree.pos, Quaternion.Euler(tree.rot));
                go.transform.localScale = tree.scale;
            }
        }

        if (skyPrefab != null && sceneData.sky != null)
        {
            GameObject go = Instantiate(skyPrefab, sceneData.sky.pos, Quaternion.Euler(sceneData.sky.rot));
            go.transform.localScale = sceneData.sky.scale;
        }

        if (housePrefab != null && sceneData.house != null)
        {
            GameObject go = Instantiate(housePrefab, sceneData.house.pos, Quaternion.Euler(sceneData.house.rot));
            go.transform.localScale = sceneData.house.scale;
        }

        if (woodenShedPrefab != null && sceneData.woodenShed != null)
        {
            GameObject go = Instantiate(woodenShedPrefab, sceneData.woodenShed.pos, Quaternion.Euler(sceneData.woodenShed.rot));
            go.transform.localScale = sceneData.woodenShed.scale;
        }

        if (laundryPrefab != null && sceneData.laundry != null)
        {
            GameObject go = Instantiate(laundryPrefab, sceneData.laundry.pos, Quaternion.Euler(sceneData.laundry.rot));
            go.transform.localScale = sceneData.laundry.scale;
        }

        if (mountainPrefab != null && sceneData.mountain != null)
        {
            GameObject go = Instantiate(mountainPrefab, sceneData.mountain.pos, Quaternion.Euler(sceneData.mountain.rot));
            go.transform.localScale = sceneData.mountain.scale;
        }
    }
}
