using UnityEngine;
using System.Collections;

public class MapMakerScript : MonoBehaviour {

    public GameObject map;
    public GameObject room;
    public GameObject nextRoom;
    public float distance = 10;
    public int mapMax = 5;
    public int roomsLeft = 5;
    public int stemLength = 5;

    void Start()
    {
//        GenerateMap();
//        This is just a test for Git.
    }

    public void GenerateMap()
    {
        GameObject newroom = (GameObject)Instantiate(room, new Vector3(0, 0, 0), Quaternion.identity);
        SproutStem(newroom);
        for (int i = mapMax; i > 0; i--)
        {
            SproutStem(nextRoom);
        }
    }

    private void SproutStem(GameObject originalRoom)
    {
        bool isDoneYet = false;
        while (!isDoneYet)
        {
            int directionCount = Random.Range(0, 4);
            Vector3 direction = new Vector3(originalRoom.transform.position.x, originalRoom.transform.position.y, originalRoom.transform.position.z + 10);
            switch (directionCount)
            {
                case 0:
                    direction = new Vector3(originalRoom.transform.position.x, originalRoom.transform.position.y, originalRoom.transform.position.z + 10);
                    break;
                case 1:
                    direction = new Vector3(originalRoom.transform.position.x, originalRoom.transform.position.y, originalRoom.transform.position.z - 10);
                    break;
                case 2:
                    direction = new Vector3(originalRoom.transform.position.x + 10, originalRoom.transform.position.y, originalRoom.transform.position.z);
                    break;
                case 3:
                    direction = new Vector3(originalRoom.transform.position.x - 10, originalRoom.transform.position.y, originalRoom.transform.position.z);
                    break;
            }
            float randomSpawn = Random.Range(0, 1);
            Debug.DrawRay(new Vector3(direction.x, direction.y + 50, direction.z), Vector3.down, Color.green,30f);
            if (!Physics.Raycast(new Vector3(direction.x,direction.y+50,direction.z), Vector3.down, 100))
            {
                GameObject newRoom = (GameObject)Instantiate(originalRoom, direction, Quaternion.identity);
                Debug.DrawRay(new Vector3(direction.x, direction.y + 50, direction.z), Vector3.down, Color.green, 30f);
                newRoom.name = "Room" + GetComponent<MapMakerScript>().roomsLeft;
                nextRoom = newRoom;
                isDoneYet = true;
            }
            directionCount++;
            print(directionCount);
        }
    }
}
