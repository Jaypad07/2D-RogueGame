using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int mapWidth = 7;
    public int mapHeight = 7;
    public int roomsToGenerate = 12;

    private int roomCount;
    private bool roomsInstantiated;

    private Vector2 firstRoomPos;

    private bool[,] map;
    public GameObject roomPrefab;

    private List<Room> roomObjects = new List<Room>();

    public static Generation Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Generate()
    {
        
    }

    void CheckRoom(int x, int y, int remaining, Vector2 generalDirection, bool firstRoom = false)
    {
        
    }

    void InstantiateRooms()
    {
        
    }

    void CalculateKeyAndExit()
    {
        
    }
}
