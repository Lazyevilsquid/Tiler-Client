using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Built
{
    // Start is called before the first frame update
    void Start()
    {
        uniqueNumber = NetworkMng.getInstance.uniqueNumber;                                         //성의 유니크 넘버를 정해줌
        _name = "성";
        _desc = "일꾼을 생성한다";
        _hp = 15;
        _code = (int)BUILT.CASTLE;
        _activity.Add(ACTIVITY.WORKER_UNIT_CREATE);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void CastleInfo()
    //{
    //    Debug.Log("성의 정보를 보여줍니다.");
    //}
    public static void CreateUnit()
    {
        if (GameMng.I.selectedTile._code == (int)BUILT.CASTLE)
        {
            GameMng.I._BuiltGM.act = ACTIVITY.WORKER_UNIT_CREATE;
            GameMng.I._range.moveRange();
        }
        Debug.Log("일꾼 유닛 생성");

    }
}
