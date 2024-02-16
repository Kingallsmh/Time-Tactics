using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemyTargetFromFieldOfView : FsmStateAction
{
    [CheckForComponent(typeof(FieldOfView))]
    public FsmGameObject fieldOfViewObject;
    [CheckForComponent(typeof(CharacterTeam))]
    public FsmGameObject characterTeamObject;
    public float checkEverySeconds;
    public FsmGameObject targetSelected;

    FieldOfView fow;
    CharacterTeam team;
    float currentTime = 0;

    public override void OnEnter()
    {
        fow = fieldOfViewObject.Value.GetComponent<FieldOfView>();
        team = characterTeamObject.Value.GetComponent<CharacterTeam>();
        currentTime = 0;
    }

    public override void OnUpdate()
    {
        if(currentTime > checkEverySeconds)
        {
            GetUpdatedList();
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }

    void GetUpdatedList()
    {
        fow.FindVisibleTargets();
        List<GameObject> objArray = fow.ObjectsInVision;
        for (int i = 0; i < objArray.Count; i++)
        {
            if(objArray[i].TryGetComponent(out CharacterTeam team))
            {
                if(team.TeamNumber != this.team.TeamNumber)
                {
                    targetSelected.Value = objArray[i];
                    return;
                }
            }
        }
        targetSelected.Value = null;
    }
}
