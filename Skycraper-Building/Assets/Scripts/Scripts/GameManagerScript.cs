using UnityEngine.SceneManagement;
using System;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    float _speed = 0;

    public GameObject Block;
    public Material SkyMaterial;

    [SerializeField] 
    int _blocks = 0;
    [SerializeField] 
    int _hp = 3;
    [SerializeField] 
    double _score;
    float _darkeningTheSkyValue = 0.0f;

    //
    const float ZeroPosition = 0.0f;
    const float DistanceCameraFromBlocks = - 7.0f;
    //
    GameObject _pivotLine;
    GameObject _planeBlock;
    GameObject _previousBlock;
    //
    HigherScript _line;
    HigherScript _levelCamera;
    HigherScript _destroyTrigger;
    LifesScript _lifesScript;
    TextMeshProUGUI _scoreText;
    void Start()
    {
        //
        _pivotLine = GameObject.Find("SpawnPivot");
        _planeBlock = GameObject.Find("StartBlock");
        //
        _line = GameObject.Find("Line").GetComponent<HigherScript>();
        _levelCamera = GameObject.Find("Main Camera").GetComponent<HigherScript>();
        _destroyTrigger = GameObject.Find("DestroyTrigger").GetComponent<HigherScript>();
        //
        _line.Higher(ZeroPosition, 15 + _blocks, ZeroPosition);
        _levelCamera.Higher(ZeroPosition, 3 + _blocks, DistanceCameraFromBlocks);
        _destroyTrigger.Higher(ZeroPosition, ZeroPosition, ZeroPosition);
        //
        _scoreText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        //
        _lifesScript = GameObject.Find("GameManager").GetComponent<LifesScript>();

        SpawnBlock();
    }
    public void minusHP()
    {
        _lifesScript.LoseHeart();
        if (_hp == 1)
        {
            EndResultScript.Instance.Result = _score;
            SceneManager.LoadScene(2);
        }
        _hp--;
    }
    public void RespawnFromFall()
    {
        SpawnBlock();
    }
    public void RespawnNewBlock()
    {
        SpawnBlock();
        IncreaseSpeed();
        ChangeOfSky();
        _blocks++;
        if (_blocks >= 4)
        {
            _previousBlock = _planeBlock;
            IPushHigher next = _planeBlock.GetComponent<IPushHigher>();
            _planeBlock = next.PushMechanismHigher();
            Destroy(_previousBlock);

            _line.Higher(_planeBlock, ZeroPosition, 17, ZeroPosition);
            _levelCamera.Higher(_planeBlock, ZeroPosition, 5, DistanceCameraFromBlocks);
            _destroyTrigger.Higher(_planeBlock, ZeroPosition, -0.25f, ZeroPosition);
        }
        else
        {
            _line.Higher(ZeroPosition, 15 + _blocks, ZeroPosition);
            _levelCamera.Higher(ZeroPosition, 3 + _blocks, DistanceCameraFromBlocks);
        }
    }
    public void UpdateScore(double scoreToAdd)
    {
        _score = _score + ScoreLimit(scoreToAdd);
        _scoreText.text = "Score : " + _score + "\n" + "High : " + _blocks;
    }
    void SpawnBlock()
    {
        Instantiate(Block, _pivotLine.transform.position, Block.transform.rotation);
    }
    double ScoreLimit(double scoreToAdd)
    {
        double scoreLimit = Math.Round(10 / (scoreToAdd * 10));
        if(scoreLimit > 10)
            return 10;
        else
            return scoreLimit;
    }
    void IncreaseSpeed()
    {
        if (Speed == 2)
            return;
        Speed += 0.01f;

    }
    void ChangeOfSky()
    {
        if (SkyMaterial.shader.GetPropertyDefaultFloatValue(2) - _darkeningTheSkyValue < 0)
            return;
        _darkeningTheSkyValue += 0.01f;
        SkyMaterial.SetFloat(SkyMaterial.shader.GetPropertyName(2), SkyMaterial.shader.GetPropertyDefaultFloatValue(2) - _darkeningTheSkyValue);
    }
}
