using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Witch_0 : Unit
{
    public static int cost = 4;
    void Awake()
    {
        _name = "狛紫 0";
        _max_hp = 20;
        _hp = _max_hp;
        _code = (int)UNIT.FOREST_SOLDIER_1;
        _damage = 10;
        _basedistance = 1;
        _attackdistance = 2;
        maxCreateCount = 3;
        SaveX = GameMng.I.selectedTile.PosX;
        SaveY = GameMng.I.selectedTile.PosZ;
        _desc = "持失猿走 " + (maxCreateCount - createCount) + "渡 害製";

        GameMng.I._BuiltGM.act = ACTIVITY.NONE;
        GameMng.I.AddDelegate(this.waitingCreate);
    }

    void init()
    {
        _activity.Add(ACTIVITY.MOVE);
        _activity.Add(ACTIVITY.ATTACK);
    }

    public void waitingCreate()
    {
        createCount++;
        _desc = "持失猿走 " + (maxCreateCount - createCount) + "渡 害製";

        if (createCount > maxCreateCount - 1)        // 2渡 板拭 持失喫
        {
            GameMng.I._hextile.GetCell(SaveX, SaveY)._builtObj.GetComponent<Built>()._bActAccess = true;

            _desc = "けけけけけけけけけ";

            _anim.SetTrigger("isSpawn");

            if (NetworkMng.getInstance.uniqueNumber.Equals(_uniqueNumber))
                init();


            GameMng.I.RemoveDelegate(this.waitingCreate);
        }
    }

    void OnDestroy()
    {
        if (!(createCount > maxCreateCount - 1))
            GameMng.I.RemoveDelegate(waitingCreate);
    }
}
