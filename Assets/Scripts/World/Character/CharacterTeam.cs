using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTeam : MonoBehaviour
{
    [SerializeField] int teamNumber = 0;

    public int TeamNumber { get => teamNumber; set => teamNumber = value; }
}
