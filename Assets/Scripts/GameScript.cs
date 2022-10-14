using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public InputField InputTime;
    public InputField InputDist;
    public InputField InputSpeed;
    public GameObject Cube;
    public GameObject Menu;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private float _dist;
    private float _timeSpawn;
    private float _timeEnd;
    private float _speed;

    void Start()
    {
        _startPos = Cube.transform.position;
        _endPos = _startPos;
    }
    public void OnStart()
    {
        _dist = float.Parse(InputDist.text);
        _timeSpawn = float.Parse(InputTime.text);
        _speed = float.Parse(InputSpeed.text);
        _endPos.z += _dist;
        if (_timeSpawn > 0 && _speed != 0 && _dist > 0)
        {
            Menu.SetActive(false);
            Cube.SetActive(true);
        }
    }

    private void Timer()
    {
        if (Time.time >= _timeEnd)
        {
            Cube.transform.position = _startPos;
            Cube.SetActive(true);
        }
    }

    private void MoveCube(Vector3 endPos, float speed)
    {
        if (Cube.transform.position != endPos)
        {
            Cube.transform.position = Vector3.MoveTowards(Cube.transform.position, endPos, speed * Time.deltaTime);
        }
        else
        {
            _timeEnd = Time.time + _timeSpawn;
            Cube.SetActive(false);
        }
    }

    void Update()
    {
        if (Cube.activeSelf && Menu.activeSelf == false)
        {
            MoveCube(_endPos, _speed);
        }
        else
        {
            Timer();
        }
    }
}
