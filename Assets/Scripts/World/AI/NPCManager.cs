using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] NPCControl npcPrefab;
    [SerializeField] List<NPCControl> currentNPCList;
    [SerializeField] float NpcCheckTimeTick = 2;

    float currentNpcCheckTime = 0;

    public void FixedUpdate()
    {
        currentNpcCheckTime += Time.fixedDeltaTime;
        if(currentNpcCheckTime > NpcCheckTimeTick)
        {
            currentNpcCheckTime = 0;
            //Do stuff
        }
    }

    public void NPCDeath(GameObject npc)
    {
        Destroy(npc);
    }
}
