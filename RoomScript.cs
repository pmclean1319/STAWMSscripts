using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour {

    public string roomType, roomTheme;
    public GameObject[] pointsOfInterest;
    public GameObject room;
    public GameObject childRoom;
    public GameObject mapmaker;
    // Use this for initialization
    void Start () {
	
	}



    public void SproutRoom()
    {
        mapmaker.GetComponent<MapMakerScript>().roomsLeft--;
        if (mapmaker.GetComponent<MapMakerScript>().roomsLeft > 0)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int directionCount = 0;
            Vector3 direction = transform.TransformDirection(Vector3.forward);
            for (int i = 0; i < 4; i++)
            {
                switch (directionCount)
                {
                    case 0:
                        direction = transform.TransformDirection(Vector3.forward);
                        break;
                    case 1:
                        direction = transform.TransformDirection(Vector3.left);
                        break;
                    case 2:
                        direction = transform.TransformDirection(Vector3.right);
                        break;
                    case 3:
                        direction = transform.TransformDirection(Vector3.back);
                        break;
                }
                float randomSpawn = Random.Range(0, 1f);
//                if (randomSpawn < .5f)
//                {
//                    if (!Physics.Raycast(transform.position, fwd, 10))
//                    {
                        childRoom = (GameObject)Instantiate(room, direction*10, Quaternion.identity);
                        childRoom.name = "Room" + mapmaker.GetComponent<MapMakerScript>().roomsLeft;
                        childRoom.GetComponent<RoomScript>().SproutRoom();
                //                    }
                //                }
                directionCount++;
                print(randomSpawn);
            }



        }
        
    }
    //    public void Define(string type, string theme)
    //    {
    //        roomType = type;
    //        roomTheme = theme;
    //        if (roomType == "stem")
    //        {
    //            if (roomTheme == "city")
    //            {
    //                
    //            }
    //        }
    //    }

}
