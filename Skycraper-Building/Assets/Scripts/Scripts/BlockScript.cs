using UnityEngine;
using System;

public class BlockScript : MonoBehaviour, IPushHigher
{
    public GameObject NextBlock;
    public PlaneRotate PlaneRotate;
    public ParticleSystem BuildingParticles;
    public AudioSource AudioOfBuilding;

    const float HalfWidthOfBlock = 0.5f;
    bool _onPlane;
    bool _isHooked;
    bool _isConnected;
    Rigidbody _blockRigidbody;
    GameObject _pivotSpawn;
    GameManagerScript _gameManager;
    
    void Start()
    {
        _isConnected = false;
        _onPlane = false;
        _isHooked = true;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        _pivotSpawn = GameObject.Find("SpawnPivot");
        _blockRigidbody = GetComponent<Rigidbody>();
        PlaneRotate = GetComponent<PlaneRotate>();
    }
    void Update()
    {
        BlockState(_isHooked);
        if(Input.GetKeyDown(KeyCode.Space) && !_isConnected)
        {
            _isHooked = false;
            _blockRigidbody.useGravity = true;
        }
        if(_onPlane)
            FallOfBlock();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!_isConnected)
        {
            if (collision.gameObject.CompareTag("Block") && BuildingCondition(collision))
            {
                FixedJoint fixedJoint = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fixedJoint.connectedBody = collision.rigidbody;
                
                _blockRigidbody.useGravity = false;
                _isConnected = true;
                _gameManager.RespawnNewBlock();
                Score(collision);
                _gameManager.UpdateScore(Score(collision));
                BuildingParticles.Play();
                AudioOfBuilding.Play();
            }
        }
        else if(BuildingCondition(collision) && _isConnected)
            NextBlock = collision.gameObject;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyer") && _isConnected != true)
            FallOfBlock();
        if (other.gameObject.CompareTag("Destroyer") && _isConnected == true)
        {
            _blockRigidbody.isKinematic = true;
            PlaneRotate.enabled = true;
        }
        if (other.gameObject.CompareTag("Plane"))
            _onPlane = true;
    }
    public GameObject PushMechanismHigher()
    {
        return NextBlock;
    }
    bool BuildingCondition(Collision collision)
    {
        return ((transform.position.y - HalfWidthOfBlock) - (collision.transform.position.y + HalfWidthOfBlock)) < 0.1
            && ((transform.position.x - HalfWidthOfBlock < collision.transform.position.x) 
            && (collision.transform.position.x < transform.position.x + HalfWidthOfBlock));
    }
    double Score(Collision collision)
    {
        return Math.Abs(collision.transform.position.x - transform.position.x);
    }
    void BlockState(bool state)
    {
        if(state)
            transform.position = new Vector3(_pivotSpawn.transform.position.x,
                _pivotSpawn.transform.position.y - HalfWidthOfBlock,
                _pivotSpawn.transform.position.z);
    }
    void FallOfBlock()
    {
        Destroy(gameObject);
        _gameManager.minusHP();
        _gameManager.RespawnFromFall();
    }
}
