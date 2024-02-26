using UnityEngine;

public class DoorPoint : MonoBehaviour
{
    public Transform otherDoorPoint;
    public RoomManager roomManager;
    public Generator generator;

    public bool roomChecked;

    private void Awake()
    {
        generator = Generator.InstanceGen;
        roomManager = GetComponentInParent<RoomManager>();
    }

    void Update()
    {
        if(generator == null)
        {
            generator = Generator.InstanceGen;
        }

        if (generator != null && generator.canGenarate)
        {
            if (roomManager.roomSpawned)
            {
                Collider[] points = Physics.OverlapBox(transform.position, new Vector3(1, 1, 1), transform.rotation, roomManager.doorPointLayer, queryTriggerInteraction: QueryTriggerInteraction.UseGlobal);
                for (int i = 0; i < points.Length; i++)
                {
                    if (otherDoorPoint == null && points[i].gameObject != this.gameObject)
                    {
                        otherDoorPoint = points[i].transform;
                    }
                }
            }

            if (otherDoorPoint == this.transform)
            {
                otherDoorPoint = null;
            }

            if (otherDoorPoint != null)
                CheckRoom();

            
        }

        if (roomManager.roomSpawned && roomChecked && roomManager.doorPoints.Count < 2)
        {
            roomManager.SetSpawningDone(true);
            gameObject.SetActive(false);

            if (otherDoorPoint != null)
            {
                otherDoorPoint.gameObject.SetActive(false);
            }
        }
        else
        {
            roomManager.SetSpawningDone(false);
        }
    }

    public void CheckRoom()
    {
        float dst = Vector3.Distance(transform.position, otherDoorPoint.transform.position);

        if (dst < 0.11f)
        {
            roomChecked = true;
        }
    }

    /*public void SpawnLastRoom()
    {
        if (roomManager.spawnDoorPoint != null && roomManager.spawnedRoom == null && roomManager.GetSpawnedCollCheck() == null)
        {
            roomManager.spawnedRoom = roomManager.generator.lastRoom;
            roomManager.SetSpawnedCollCheck(Instantiate(roomManager.spawnedRoom.GetComponent<EndRoomInfo>().collisionCheckOBJ, transform.position, transform.rotation));
            roomManager.SetCheckSpawn(true);
        }
        
        if (roomManager.spawnedRoom != null && roomManager.spawnedRoom == generator.lastRoom && roomManager.outSideChecked)
        {
            Destroy(roomManager.GetSpawnedCollCheck());
            Transform doorPoint = GameObject.FindGameObjectWithTag("DoorPoint").transform;

            GameObject theLastRoom = Instantiate<GameObject>(generator.lastRoom, new Vector3(doorPoint.position.x, doorPoint.position.y, doorPoint.position.z), doorPoint.rotation);
            generator.dungeonRooms.Add(theLastRoom);

            generator.dungeonGenerationComplete = true;
            roomManager.roomSpawned = true; roomChecked = true; enabled = false;

            roomManager.enabled = false;

            gameObject.SetActive(false);
        }
    }*/

    public void ResetDoor()
    {
        otherDoorPoint = null;
        roomChecked = false;
        roomManager.roomSpawned = false;
        gameObject.SetActive(true);
    }
}