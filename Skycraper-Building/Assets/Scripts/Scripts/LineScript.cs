using UnityEngine;
using System;

public class LineScript : MonoBehaviour
{
    float _timer;
    const float Speed = 25f;
    const float TimerReset = 31.416f;

    void Start()
    {
        _timer = 0;
    }

    void Update()
    {
        Pendulum();
    }
    void Pendulum()
    {
        _timer += Time.deltaTime;
        if (_timer >= TimerReset)
        {
            _timer = 0;
        }
        transform.Rotate(Vector3.forward * Speed * MathF.Cos(_timer) * Time.deltaTime);

    }

}
