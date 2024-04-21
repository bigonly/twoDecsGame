﻿using UnityEngine;

[CreateAssetMenu (fileName = "PlayerPrefabData", menuName = "StaticData")]
public class StaticData : ScriptableObject
{
    public GameObject playerPrefab;
    public float playerHealth;
    public float playerSpeed;
    public float gravity;
}