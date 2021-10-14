using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roomgenerator : MonoBehaviour
{
    public enum Direction { up, down, left, right };
    public Direction dir;
    private GameObject startroom;
    private List<GameObject> farrooms = new List<GameObject>();
    private List<GameObject> lessfar = new List<GameObject>();
    private List<GameObject> oneway = new List<GameObject>();
    public int maxstep;

    [Header("房间信息")]
    public GameObject roomprefab;
    public int roomnumber;
    public Color startColor, endColor;
    [Header("位置控制")]
    public Transform generatorPoint;
    public static float x, y;
    public List<room> rooms = new List<room>();
    public LayerMask roomlayer;
    // Start is called before the first frame update
    void Start()
    {


        for (int i = 1; i < roomnumber; i++)
        {
            rooms.Add(Instantiate(roomprefab, generatorPoint.position, Quaternion.identity).GetComponent<room>());
            Changepoint();
        }

        rooms[0].gameObject.GetComponent<SpriteRenderer>().color = startColor;
        startroom = rooms[0].gameObject;

        foreach (var room in rooms)
        {

            if (room.transform.position.sqrMagnitude > startroom.transform.position.sqrMagnitude)
            {
                startroom = room.gameObject;

            }
            SetRoom(room, room.transform.position);
        }
        startroom.gameObject.GetComponent<SpriteRenderer>().color = endColor;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("test"); 
        }
    }

    public void Changepoint()
    {

        dir = (Direction)Random.Range(0, 4);

        do
        {
            switch (dir)

            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, y, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -y, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-x, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(x, 0, 0);
                    break;

            }
        } while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomlayer));
    }

    public void SetRoom(room room,Vector3 position)
    {
        room.up = Physics2D.OverlapCircle(position + new Vector3(0, y, 0), 0.2f, roomlayer);
        room.down = Physics2D.OverlapCircle(position + new Vector3(0, -y, 0), 0.2f, roomlayer);
        room.left = Physics2D.OverlapCircle(position + new Vector3(-x, 0, 0), 0.2f, roomlayer);
        room.right = Physics2D.OverlapCircle(position + new Vector3(x, 0, 0), 0.2f, roomlayer);

        room.UpdateRoom();
    }

    public void Findfirstroom()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].step>maxstep)
            {
                maxstep = rooms[i].step;
            }

            foreach(var room in rooms)
            {
                if (room.step==maxstep)
                {
                    farrooms.Add(room.gameObject);
                }

                if (room.step == maxstep - 1)
                {
                    lessfar.Add(room.gameObject);
                }
            }

            for (int i = 0; i < farrooms.Count; i++)
            {
                if (farrooms[i].GetComponent<room>().passagenum == 1)
                    oneway.Add(farrooms[i]);

            }

        }
    }

}
