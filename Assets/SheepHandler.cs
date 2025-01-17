﻿using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

//                       _oo0oo_
//                      o8888888o
//                      88" . "88
//                      (| -_- |)
//                      0\  =  /0
//                    ___/`---'\___
//                  .' \\|     |// '.
//                 / \\|||  :  |||// \
//                / _||||| -:- |||||- \
//               |   | \\\  -  /// |   |
//               | \_|  ''\---/''  |_/ |
//               \  .-\__  '-'  ___/-. /
//             ___'. .'  /--.--\  `. .'___
//          ."" '<  `.___\_<|>_/___.' >' "".
//         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
//         \  \ `_.   \_ __\ /__ _/   .-` /  /
//     =====`-.____`.___ \_____/___.-`___.-'=====
//                       `=---='
//
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//            Phật phù hộ, không bao giờ BUG
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


public class SheepHandler : Singleton<SheepHandler>
{

    public List<Vector2> bornPos;
    public List<Sheep> sheeps;
    private Sheep targetSheep;
    public GameObject sheepArrow;
    UnityEngine.Vector2 vectorDir = new UnityEngine.Vector2(0,0);
    private bool isJumped;

    [HideInInspector]
    public int NumberSheepFlagged = 0;

    private void Awake()
    {

        //sinh cuu
        for (int i = 0; i < sheeps.Count; i++)
        { 
            sheeps[i]=GameObject.Instantiate(sheeps[i], bornPos[i], Quaternion.identity);
            sheeps[i].SetUp();
        }

        //gan cuu
        targetSheep = sheeps[0];

    }

   // control the sheep
    public void CharterInputControl()
    {
        //Moving Left Right
        if (Input.GetKey(KeyCode.A))
            {
                targetSheep.Move("left");
            }
        if (Input.GetKey(KeyCode.D))
            {
                targetSheep.Move("right");
            }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
        {
            targetSheep.Jump();
        }

        //Switching sheep
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetSheep = sheeps[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetSheep = sheeps[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetSheep = sheeps[2];
        }

    }

    //Check if sheep hit the Flag
    public void CheckSheepsFlagged()
    {
        if( NumberSheepFlagged == 3)
        {
            print("gameComplete");
        }
    }
    
    private void Update()
    {
        
        CharterInputControl();
        CheckSheepsFlagged();
        //dieu khien cuu duoc chon

        //print(targetSheep.sheepGameObject.transform.position);
    }
}
