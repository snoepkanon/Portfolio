using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour  
{                                          
    [Tooltip("Set to true if this is the start for the Dungeon")]public bool firstRoom;
    [Tooltip("The layer your doorPoints are on")]public LayerMask doorPointLayer;
    [Tooltip("All the door points in a room")]public List<Transform> doorPoints;
    [Tooltip("The centerpont of the room arount wich it can rotate")]public GameObject roomRotPoint;
    [Tooltip("Set to true if you want to spawn a specific room after this one everytime")]public bool useSetRoom;
    [ConditionalHide("useSetRoom"),Tooltip("this room will always spawn after this room")]public GameObject setRoom;

    [HideInInspector] public Generator generator;
    [HideInInspector] public GameObject spawnedRoom;                                      

    [Header("Spawn info")]
    public GameObject collisionCheckOBJ;
    public Transform spawnDoorPoint;
    public GameObject spawnedCollCheck;
    public bool debug;
    [ConditionalHide("debug")][SerializeField]bool checkSpawned;
    [ConditionalHide("debug")][SerializeField]bool outSideChecked;
    [ConditionalHide("debug")][SerializeField]bool collIsClear;
    [ConditionalHide("debug")][SerializeField]bool roomSpawned;


    private void Start()
    {
        generator = Generator.InstanceGen;
        
        if (useSetRoom && generator.roomAmount > 0)
        {
            SpawnSetRoom();
        }

        if (firstRoom && !useSetRoom)
        {
            SpawnFirstRoom();
        }
    }

    private void Update()
    {
        if (generator == null)
        {
            generator = Generator.InstanceGen;
        }

        if (!checkSpawned && spawnedRoom == null && generator.roomAmount > 0) 
        {
            ChooseRoom();
        }

        if (!outSideChecked && spawnDoorPoint.gameObject.activeSelf == true)
        {
            checkColl();
        }

        if (roomSpawned && outSideChecked && doorPoints.Count < 3)
        {
            doorPoints[0].gameObject.SetActive(false);
            for (int i = 0; i < doorPoints.Count; i++)
            {
                if ( doorPoints.Count != 0 && doorPoints[i].gameObject.activeSelf == false || doorPoints[i] == null)
                {
                    doorPoints.RemoveAt(i);
                }
            }

            if (doorPoints.Count == 0 && spawnedRoom != null)
            {
                GetComponent<RoomManager>().enabled = false;

                if (spawnedRoom.TryGetComponent<RoomManager>(out RoomManager room))
                {
                    room.enabled = true;
                }
            }
        }

        if (generator.roomAmount == 0)
        {
            SpawnLastRoom();
        }

        if(spawnDoorPoint != null && doorPoints.Count == 0)
        {
            doorPoints.Add(spawnDoorPoint);
        }
    }

    public void ChooseRoom()
    {
        int roomPick = Random.Range(1, (generator.roomSelect+1));

        if(roomPick == 1)
        {
            spawnedRoom = generator.GetRandomStaightRoom(gameObject);
        }
        else if(roomPick == 2)
        {
            spawnedRoom = generator.GetRandomCornerRoom(gameObject);
        }
        
        if( roomPick == 3)
        {
            spawnedRoom = generator.GetRandomStairsUpRoom(gameObject);
        }
        else if (roomPick == 4)
        {
            spawnedRoom = generator.GetRandomStairsDownRoom(gameObject);
        }
        
        spawnedCollCheck = Instantiate(spawnedRoom.GetComponent<RoomManager>().collisionCheckOBJ, spawnDoorPoint.transform.position, spawnDoorPoint.transform.rotation);
        checkSpawned = true;
    }

    public void spawnRoom()
    {
        if (spawnedRoom != null)
        {
            if (outSideChecked)
            {
                spawnedRoom = Instantiate<GameObject>(spawnedRoom, new Vector3(spawnDoorPoint.transform.position.x, spawnDoorPoint.transform.position.y, spawnDoorPoint.transform.position.z), spawnDoorPoint.transform.rotation);
                generator.roomAmount--;
                generator.dungeonRooms.Add(spawnedRoom);
                roomSpawned = true;
            }
        }
    }

    public void SpawnFirstRoom()
    {
        spawnedRoom = generator.straightRooms[Random.Range(0, generator.straightRooms.Length)].gameObject;
        spawnedCollCheck = Instantiate(spawnedRoom.GetComponent<RoomManager>().collisionCheckOBJ, spawnDoorPoint.position, spawnDoorPoint.rotation);
        checkSpawned = true;
        doorPoints.Add(spawnDoorPoint);
    }

    public void SpawnSetRoom()
    {
        spawnedRoom = setRoom;
        spawnedCollCheck = Instantiate(spawnedRoom.GetComponent<RoomManager>().collisionCheckOBJ, spawnDoorPoint.position, spawnDoorPoint.rotation);
        checkSpawned = true;
        doorPoints.Add(spawnDoorPoint);
    }

    public void SpawnLastRoom()
    {
        if (spawnDoorPoint != null && spawnedRoom == null && GetSpawnedCollCheck() == null)
        {
            spawnedRoom = generator.lastRoom;
            spawnedCollCheck = (Instantiate(spawnedRoom.GetComponent<EndRoomInfo>().collisionCheckOBJ, spawnDoorPoint.transform.position, spawnDoorPoint.transform.rotation));
            checkSpawned = true;
        }

        if (spawnedRoom != null && spawnedRoom == generator.lastRoom && outSideChecked)
        {
            Destroy(spawnedCollCheck);

            GameObject theLastRoom = Instantiate<GameObject>(generator.lastRoom, new Vector3(spawnDoorPoint.position.x, spawnDoorPoint.position.y, spawnDoorPoint.position.z), spawnDoorPoint.rotation);
            generator.dungeonRooms.Add(theLastRoom);

            generator.dungeonGenerationComplete = true;
            roomSpawned = true; enabled = false;

            enabled = false;

            gameObject.SetActive(false);
        }
    }


    public void checkColl()
    {
        if (checkSpawned)
        {
            if (spawnedCollCheck != null && spawnedCollCheck.GetComponent<CollisionCheck>().GetCollEnabled())
            {
                if(doorPoints.Count > 0 && spawnedCollCheck.GetComponent<CollisionCheck>().GetCollClear())
                {
                    collIsClear = true;
                    Destroy(spawnedCollCheck);
                }
                else if(spawnedCollCheck.GetComponent<CollisionCheck>().GetCollLenght() > 0)
                {
                    generator.removeLastRoom = true;
                    Destroy(spawnedCollCheck);
                }
            }

            if (spawnedCollCheck == null)
            {
                if (collIsClear)
                {
                    generator.SetRetryAmount(generator.retryAmount);
                    outSideChecked = true;
                    spawnRoom();
                }
                else
                {
                    generator.removeLastRoom = true;
                }
            }
        }
    }

    public void RoomReset()
    {
        if (setRoom)
        {
            generator.dungeonRooms[generator.dungeonRooms.Count - 1].GetComponent<RoomManager>().RoomReset();
            generator.dungeonRooms[generator.dungeonRooms.Count - 2].GetComponent<RoomManager>().RoomReset();
        }
        spawnedCollCheck = null;
        spawnedRoom = null;
        roomSpawned = false;
        outSideChecked = false;
        collIsClear = false;
        checkSpawned = false;
        ChooseRoom();
        spawnDoorPoint.gameObject.SetActive(true);
        enabled = true;
    }

    //Setter\\

    public void SetCheckSpawn(bool SpanwedCheck)
    {
        checkSpawned = SpanwedCheck;
    }

    public void SetSpawnedCollCheck(GameObject collCheck)
    {
        spawnedCollCheck = collCheck;
    }

    //getters\\

    public GameObject GetSpawnedCollCheck()
    {
        return spawnedCollCheck;
    }
}