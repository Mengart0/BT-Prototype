using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Variables

    [SerializeField]private GameObject spawnPointObject;

    private Transform _spawnPointTransform;
    private Vector3 _upperSpawnPoint;
    private Vector3 _middleSpawnPoint;
    private Vector3 _bottomSpawnPoint;

    //Spawnpoint x vise always same y has 3 points

    //Spawning depending on enemies on screen

    private void Start()
    {
        _spawnPointTransform = spawnPointObject.transform;
        _upperSpawnPoint = spawnPointObject.transform.position;
        _middleSpawnPoint = spawnPointObject.transform.position;
        _bottomSpawnPoint = spawnPointObject.transform.position;

        _upperSpawnPoint.y += 15;

        _bottomSpawnPoint.y -= 15;

    }



        




}
