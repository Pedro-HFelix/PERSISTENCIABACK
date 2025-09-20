using UnityEngine;
using System;

public class AdapterData
{
    // FLOWER
    public static void GetFlower(FlowerData data, ref Flower flower)
    {
        flower.transform.position = data.pos;
        flower.transform.rotation = Quaternion.Euler(data.rot);
        flower.transform.localScale = data.scale;
    }

    public static FlowerData GetFlowerData(Flower flower)
    {
        FlowerData data = new FlowerData();
        data.pos = flower.transform.position;
        data.rot = flower.transform.rotation.eulerAngles;
        data.scale = flower.transform.localScale;
        return data;
    }

    // GRASS
    public static void GetGrass(GrassData data, ref Grass grass)
    {
        grass.transform.position = data.pos;
        grass.transform.rotation = Quaternion.Euler(data.rot);
        grass.transform.localScale = data.scale;
    }

    public static GrassData GetGrassData(Grass grass)
    {
        GrassData data = new GrassData();
        data.pos = grass.transform.position;
        data.rot = grass.transform.rotation.eulerAngles;
        data.scale = grass.transform.localScale;
        return data;
    }

    // HOUSE
    public static void GetHouse(HouseData data, ref House house)
    {
        house.transform.position = data.pos;
        house.transform.rotation = Quaternion.Euler(data.rot);
        house.transform.localScale = data.scale;
    }

    public static HouseData GetHouseData(House house)
    {
        HouseData data = new HouseData();
        data.pos = house.transform.position;
        data.rot = house.transform.rotation.eulerAngles;
        data.scale = house.transform.localScale;
        return data;
    }

    // TREE
    public static void GetTree(TreeData data, ref Tree tree)
    {
        tree.transform.position = data.pos;
        tree.transform.rotation = Quaternion.Euler(data.rot);
        tree.transform.localScale = data.scale;
    }

    public static TreeData GetTreeData(Tree tree)
    {
        TreeData data = new TreeData();
        data.pos = tree.transform.position;
        data.rot = tree.transform.rotation.eulerAngles;
        data.scale = tree.transform.localScale;
        return data;
    }

    // WOODEN SHED
    public static void GetWoodenShed(WoodenShedData data, ref WoodenShed shed)
    {
        shed.transform.position = data.pos;
        shed.transform.rotation = Quaternion.Euler(data.rot);
        shed.transform.localScale = data.scale;
    }

    public static WoodenShedData GetWoodenShedData(WoodenShed shed)
    {
        WoodenShedData data = new WoodenShedData();
        data.pos = shed.transform.position;
        data.rot = shed.transform.rotation.eulerAngles;
        data.scale = shed.transform.localScale;
        return data;
    }

    // LAUNDRY
    public static void GetLaundry(LaundryData data, ref Laundry laundry)
    {
        laundry.transform.position = data.pos;
        laundry.transform.rotation = Quaternion.Euler(data.rot);
        laundry.transform.localScale = data.scale;
    }

    public static LaundryData GetLaundryData(Laundry laundry)
    {
        LaundryData data = new LaundryData();
        data.pos = laundry.transform.position;
        data.rot = laundry.transform.rotation.eulerAngles;
        data.scale = laundry.transform.localScale;
        return data;
    }

    // MOUNTAIN
    public static void GetMountain(MountainData data, ref Mountain mountain)
    {
        mountain.transform.position = data.pos;
        mountain.transform.rotation = Quaternion.Euler(data.rot);
        mountain.transform.localScale = data.scale;
    }

    public static MountainData GetMountainData(Mountain mountain)
    {
        MountainData data = new MountainData();
        data.pos = mountain.transform.position;
        data.rot = mountain.transform.rotation.eulerAngles;
        data.scale = mountain.transform.localScale;
        return data;
    }

    public static void GetSky(SkyData data, ref Sky sky)
    {
        sky.transform.position = data.pos;
        sky.transform.rotation = Quaternion.Euler(data.rot);
        sky.transform.localScale = data.scale;
    }

    public static SkyData GetSkyData(Sky sky)
    {
        SkyData data = new SkyData();
        data.pos = sky.transform.position;
        data.rot = sky.transform.rotation.eulerAngles;
        data.scale = sky.transform.localScale;
        return data;
    }
}

[System.Serializable]
public class SkyData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}

[System.Serializable]
public class FlowerData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}


[System.Serializable]
public class GrassData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}

[System.Serializable]
public class HouseData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}

[System.Serializable]
public class TreeData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}

[System.Serializable]
public class WoodenShedData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}

[System.Serializable]
public class LaundryData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}

[System.Serializable]
public class MountainData
{
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}



[System.Serializable]
public class SceneData
{
    public FlowerData[] flowers;
    public GrassData[] grasses;
    public HouseData house;
    public TreeData[] trees;
    public WoodenShedData woodenShed;
    public LaundryData laundry;
    public MountainData mountain;
    public SkyData sky;
}
