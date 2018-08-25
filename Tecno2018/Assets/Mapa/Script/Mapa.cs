using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour {

    public static Dictionary<string, GameObject> map;

    public static GameObject Up(int i,int j, int dis)
    {
        return map[i.ToString() + "_" + (j + dis).ToString()];
    }

    public static GameObject Down(int i, int j, int dis)
    {
        return map[i.ToString() + "_" + (j - dis).ToString()];
    }

    public static GameObject Right(int i, int j, int dis)
    {
        return map[(i+1).ToString() + "_" + (j).ToString()];
    }

    public static GameObject Left(int i, int j, int dis)
    {
        return map[(i - 1).ToString() + "_" + (j).ToString()];
    }
}
