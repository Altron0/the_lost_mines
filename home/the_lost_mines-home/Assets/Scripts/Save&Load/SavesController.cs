using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesController : MonoBehaviour
{
    MineController mine;
    Player player;
    BarsController bars;
    InventoryController inventory;

    void Save()
    {

    }
    void Load()
    {

    }
}
public interface ISavable
{
    void Save();
    void Load();
}