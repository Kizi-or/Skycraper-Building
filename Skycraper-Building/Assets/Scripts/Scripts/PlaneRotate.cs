using UnityEngine;

public class PlaneRotate : MonoBehaviour
{
    GameManagerScript _gameManagerScript; 
    bool _right;
    bool _left;
    float _speedOfSwinging;

    void Start()
    {
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        _right = true;
        _left = false;
        _speedOfSwinging = 0;
    }
    void Update()
    {
        _speedOfSwinging = _gameManagerScript.Speed;
        if(_right)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * (1 + _speedOfSwinging));
            transform.Translate(Vector3.left * _speedOfSwinging * Time.deltaTime);
            if(transform.rotation.eulerAngles.z > (1 + _speedOfSwinging) && transform.rotation.eulerAngles.z < 95)
            {
                _right = false;
                _left = true;
            }
        }
        if (_left)
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * (1 + _gameManagerScript.Speed));
            transform.Translate(Vector3.right * _speedOfSwinging * Time.deltaTime);
            if (transform.rotation.eulerAngles.z < 360 - (1 + _speedOfSwinging) && transform.rotation.eulerAngles.z > 275)
            {
                _right = true;
                _left = false;
            }
        }
    }

}
