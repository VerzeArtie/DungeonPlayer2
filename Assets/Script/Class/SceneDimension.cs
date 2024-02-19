using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class SceneDimension
{
  public static void SceneClose(string scene_name)
  {
    SceneManager.UnloadSceneAsync(scene_name);
  }

  public static void SceneAdd(string scene_name)
  {
    SceneManager.LoadSceneAsync(scene_name, LoadSceneMode.Additive);
  }

  public static void JumpToHomeTown()
  {
    One.StopDungeonMusic();
    SceneManager.LoadSceneAsync(Fix.SCENE_HOME_TOWN);
  }

  public static void JumpToDungeonField(string dungeon_field)
  {
    One.StopDungeonMusic();
    One.TF.CurrentDungeonField = dungeon_field;
    Resources.UnloadUnusedAssets();
    SceneManager.LoadSceneAsync(Fix.SCENE_DUNGEON_FIELD);
  }

  public static void JumpToTitle()
  {
    One.ReInitializeGroundOne(false);
    One.StopDungeonMusic();
    SceneManager.LoadSceneAsync(Fix.Title);
  }

  public static void CallBattleEnemy()
  {
    One.StopDungeonMusic();
    SceneManager.LoadSceneAsync("BattleEnemy");
  }
}