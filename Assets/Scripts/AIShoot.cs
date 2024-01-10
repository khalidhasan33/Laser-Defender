using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        shooter.StartFiring();
    }

}
