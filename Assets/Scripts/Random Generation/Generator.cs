using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Generator : MonoBehaviour
{
    public static Generator InstanceGen { get; private set; }
    public enum Difficulty
    {
        Easy, Medium, Hard
    }

    public SeedManager seedManager;
    [Header("Dificulty select(hover over most variable names for tooltips)")]
    [Space(10)]
    public Difficulty difficulty;

    [Header("The amount of rooms to generate with each dificulty")]
    [Space(10)]
    public int easyRooms;
    public int normalRooms, hardRooms;
    [HideInInspector] public int roomAmount = 1;

    [Header("Info for the generator")]
    [Space]
    [Tooltip("Allows the generation to start if true")] public bool canGenarate;
    [Space]
    [Tooltip("The GameObject you want the generation to start from")] public GameObject firstRoom;
    [Tooltip("The last room you want to spawn in to close of the dungeon")] public GameObject lastRoom;
    [Space]
    [Tooltip("The amount of times the generetor is allowed to retry the placement of a room before a full reset")] public int retryAmount;
    [Space]
    [Tooltip("The straight rooms you want to be used for generation")] public GameObject[] cornerRooms;
    [Space]
    [Tooltip("The corner rooms you want to be used for generation")] public GameObject[] straightRooms;
    [Space]
    [Tooltip("The stairs going up you want to be used for generation")]public GameObject[] staircaseUp;
    [Space]
    [Tooltip("The stairs going down you want to be used for generation")] public GameObject[] staircaseDown;

    [Header("Misc info")]
    public List<GameObject> dungeonRooms;
    public bool dungeonGenerationComplete;
    public bool removeLastRoom;
    public Slider progressSlider;
    public int roomSelect;
    int currentRetryAmount;

    private void Awake()
    {
        if(InstanceGen != null && InstanceGen != this)
        {
            Destroy(this);
        }
        else
        {
            InstanceGen = this;
        }
        //qseedManager = SeedManager.InstanceSeed;

        DifficultySelect(difficulty);

        currentRetryAmount = retryAmount;
    }

    public void Update()
    {
        if (canGenarate)
        {
            firstRoom.GetComponent<RoomManager>().gameObject.SetActive(true);
        }

        for (int i = 0; i < dungeonRooms.Count; i++)
        {
            if (dungeonRooms[i] == null)
            {
                dungeonRooms.RemoveAt(i);
            }
        }

        if (removeLastRoom && currentRetryAmount > 0)
            RemoveLastRoom();

        if(currentRetryAmount <= 0)
        {
            seedManager.reset = true;
        }

        if (dungeonGenerationComplete && gameObject.activeSelf && canGenarate)
        {
            canGenarate = false;
        }

        //progressSlider.value = roomAmount;
    }

    public void RemoveLastRoom()
    {
        if (dungeonRooms.Count != 0)
        {
            Destroy(dungeonRooms[dungeonRooms.Count -1]);
            dungeonRooms.RemoveAt(dungeonRooms.Count - 1);
            dungeonRooms[dungeonRooms.Count -1].GetComponent<RoomManager>().RoomReset();
        }

        roomAmount++;
        currentRetryAmount--;
        removeLastRoom = false;
    }

    public void DifficultySelect(Difficulty chosenDifficulty)
    {
        difficulty = chosenDifficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                roomAmount = easyRooms;
                //progressSlider.highValue = easyRooms;
                break;

            case Difficulty.Medium:
                roomAmount = normalRooms;
                //progressSlider.highValue = normalRooms;
                break;

            case Difficulty.Hard:
                roomAmount = hardRooms;
                //progressSlider.highValue = hardRooms;
                break;
        }
    }

    //getters\\

    public GameObject GetRandomStaightRoom(GameObject room)
    {
        room = straightRooms[Random.Range(0, straightRooms.Length)].gameObject;
        return room;
    }

    public GameObject GetRandomCornerRoom(GameObject room)
    {
        room = cornerRooms[Random.Range(0, cornerRooms.Length)].gameObject;
        return room;
    }

    public GameObject GetRandomStairsUpRoom(GameObject room)
    {
        room = staircaseUp[Random.Range(0, staircaseUp.Length)].gameObject;
        return room;
    }

    public GameObject GetRandomStairsDownRoom(GameObject room)
    {
        room = staircaseDown[Random.Range(0, staircaseDown.Length)].gameObject;
        return room;
    }

    //setters

    public void SetRetryAmount(int amount)
    {
        retryAmount = amount;
    }

    public void SetCurrentRetryAmount(int amount)
    {
        currentRetryAmount = amount;
    }
}  