using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roomgenerator : MonoBehaviour
{
    public enum Direction { up, down, left, right };
    public Direction dir;
    private static room startroom;
    private static room endroom;
    private List<room> farrooms = new List<room>();
    private List<room> lessfar = new List<room>();
    private List<room> oneway = new List<room>();
    private List<GameObject> wallnum = new List<GameObject>();
    public int maxstep;
    public  static Vector2 startposition;

    public float maxX, minX, maxY, minY;
    public GameObject smallmap;



    [Header("������Ϣ")]
    public GameObject roomprefab;
    public int roomnumber;

    [Header("λ�ÿ���")]
    public Transform generatorPoint;
    public static float x=43f, y= 41.5f;
    public List<room> rooms = new List<room>();
    public LayerMask roomlayer;


    public wall wall;
    [Header("װ��")]
    public GameObject[] decoration;
    [Header("����")]
    public GameObject[] reward;
    public GameObject box_weapon;
    // Start is called before the first frame update
    void Awake()
    {
        maxX = -9999;
        maxY = -9999;
        minX = 9999;
        minY = 9999;
        //������ɵ�ͼ
        CreatMap();

        startroom = oneway[Random.Range(0, oneway.Count)];
        startposition = startroom.gameObject.transform.position;
        oneway.Clear();

        //�Գ�ʼ��ͼΪ��׼���¼���ÿ����ͼ�����ʼ��ͼ�ľ���
        foreach (var room in rooms)
        {

            maxX = maxX > room.gameObject.transform.position.x ? maxX : room.gameObject.transform.position.x;
            minX = minX < room.gameObject.transform.position.x ? minX : room.gameObject.transform.position.x;
            maxY = maxY > room.gameObject.transform.position.y ? maxY : room.gameObject.transform.position.y;
            minY = minY < room.gameObject.transform.position.y ? minY : room.gameObject.transform.position.y;

            room.UpdateRoom(startroom.transform.position.x, startroom.transform.position.y);
        }
        
        //�ҵ�һ�������ʼ����Զ����ֻ��һ��ͨ���ĵ�ͼ��Ϊ�յ�
        Findendroom();

        PlayerControler.tostartroom = true;

        for(int i = 0; i < oneway.Count; i++)
        {
            rooms.Remove(oneway[i]);
        }

        Putcamera();

        CreateDecoration();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }


    //�ı�����λ��
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
        } while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomlayer));//�����ǰλ���е�ͼ����һ��λ��
    }


    //����ͼ��Χ����������ͼ���Ӷ�����ͨ��
    public void SetRoom(room room,Vector3 position)
    {
        room.up = Physics2D.OverlapCircle(position + new Vector3(0, y, 0), 0.2f, roomlayer);
        room.down = Physics2D.OverlapCircle(position + new Vector3(0, -y, 0), 0.2f, roomlayer);
        room.left = Physics2D.OverlapCircle(position + new Vector3(-x, 0, 0), 0.2f, roomlayer);
        room.right = Physics2D.OverlapCircle(position + new Vector3(x, 0, 0), 0.2f, roomlayer);

        room.UpdateRoom(0,0);

        switch (room.passagenum)
        {
            case 1:
                if (room.up)
                    wallnum.Add(Instantiate(wall.one_up,room.gameObject.transform.position,Quaternion.identity));
                if (room.down)
                    wallnum.Add(Instantiate(wall.one_down, room.gameObject.transform.position, Quaternion.identity));
                if (room.right)
                    wallnum.Add(Instantiate(wall.one_right, room.gameObject.transform.position, Quaternion.identity));
                if (room.left)
                    wallnum.Add(Instantiate(wall.one_left, room.gameObject.transform.position, Quaternion.identity));
                break;

            case 2:
                if(room.up&&room.down)
                    wallnum.Add(Instantiate(wall.two_up_down, room.gameObject.transform.position, Quaternion.identity));
                if (room.up && room.left)
                    wallnum.Add(Instantiate(wall.two_up_left, room.gameObject.transform.position, Quaternion.identity));
                if (room.up && room.right)
                    wallnum.Add(Instantiate(wall.two_up_right, room.gameObject.transform.position, Quaternion.identity));
                if (room.left && room.down)
                    wallnum.Add(Instantiate(wall.two_down_left, room.gameObject.transform.position, Quaternion.identity));
                if (room.right && room.down)
                    wallnum.Add(Instantiate(wall.two_down_right, room.gameObject.transform.position, Quaternion.identity));
                if (room.left && room.right)
                    wallnum.Add(Instantiate(wall.two_right_left, room.gameObject.transform.position, Quaternion.identity));
                break;

            case 3:
                    if(room.up&&room.down&&room.left)
                         wallnum.Add(Instantiate(wall.three_up_down_left, room.gameObject.transform.position, Quaternion.identity));
                if (room.up && room.down && room.right)
                    wallnum.Add(Instantiate(wall.three_up_down_right, room.gameObject.transform.position, Quaternion.identity));
                if (room.right && room.down && room.left)
                    wallnum.Add(Instantiate(wall.three_right_left_down, room.gameObject.transform.position, Quaternion.identity));
                if (room.up && room.right && room.left)
                    wallnum.Add(Instantiate(wall.three_right_left_up, room.gameObject.transform.position, Quaternion.identity));
                break;

            case 4:
                wallnum.Add(Instantiate(wall.four_up_down_left_right, room.gameObject.transform.position, Quaternion.identity));
                break;
        }

    }


    public void Findendroom()
    {
        //������ͼ���ҳ����ʼ��ͼ��������
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].step > maxstep)
            {
                maxstep = rooms[i].step;
            }
        }
        //��������������������δ�����������м����ͼ
        foreach (var room in rooms)
            {
            if (room.step ==maxstep)
                {
                    farrooms.Add(room);
                }

                if (room.step == maxstep - 1)
                {
                    lessfar.Add(room);
                }
            }
        //��ͨ�������м����ͼ
        for (int i = 0; i < farrooms.Count; i++)
            {
                if (farrooms[i].GetComponent<room>().passagenum == 1)
                    oneway.Add(farrooms[i]);
            }
            for (int i = 0; i < lessfar.Count; i++)
            {
                if (lessfar[i].GetComponent<room>().passagenum == 1)
                    oneway.Add(lessfar[i]);
            }

            for(int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].GetComponent<room>().passagenum == 1)
            {
                rooms.Remove(rooms[i]);
            }
        }

        endroom = oneway[Random.Range(0, oneway.Count)];
        oneway.Remove(endroom);
        oneway.Remove(startroom);
        rooms.Remove(startroom);
        rooms.Remove(endroom);
        rooms[Random.Range(0, rooms.Count)].isnb = true;
    }

    //���ɵ�ͼ
    public void CreatMap()
    {

        for (int i = 0; i < roomnumber; i++)
        {
            rooms.Add(Instantiate(roomprefab, generatorPoint.position, Quaternion.identity).GetComponent<room>());
            Changepoint();
        }

        //����ÿ����ͼ�����ʼ���λ�ü�ͨ����
        foreach (var room in rooms)
        {

            SetRoom(room, room.transform.position);
        }

        //�ҵ�����ͨ����Ϊ1�ĵ�ͼ�����뵽������
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].GetComponent<room>().passagenum == 1)
            {
                oneway.Add(rooms[i]);

            }
        }


        if (oneway.Count < 3)
        {

            //�������
            oneway.Clear();
            foreach (var room in rooms)
            {
                Destroy(room.gameObject);
            }

            rooms.Clear();

            foreach (var wall in wallnum)
            {
                Destroy(wall.gameObject);
            }

            wallnum.Clear();

            CreatMap();

        }

    }

    public void CreateDecoration()
    {
        int rewardroom = Random.Range(0, rooms.Count);
        //end
        Instantiate(decoration[0], endroom.transform.position, Quaternion.identity);

        Instantiate(reward[Random.Range(0,1)], oneway[0].transform.position, Quaternion.identity);
        Instantiate(box_weapon, rooms[rewardroom].transform.position, Quaternion.identity);
        rooms.Remove(rooms[rewardroom]);
        for (int i = 0; i < rooms.Count; i++)
        {
            Instantiate(decoration[Random.Range(1, 8)], rooms[i].transform.position, Quaternion.identity);
        }
    }
    public void Putcamera()
    {;
        float positionX = (maxX + minX) / 2;
        float positionY = (maxY + minY) / 2;
        smallmap.transform.position = new Vector3(positionX, positionY,-10);
    }

}


    [System.Serializable]

public class wall
{
    public GameObject one_up, one_down, one_left, one_right,
        two_up_left, two_up_right, two_up_down, two_right_left, two_down_left, two_down_right,
        three_up_down_left, three_up_down_right, three_right_left_down, three_right_left_up,
        four_up_down_left_right;
}
