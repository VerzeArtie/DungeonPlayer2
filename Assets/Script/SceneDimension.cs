using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class SceneDimension
{
  public static void JumpToHomeTown()
  {
    One.StopDungeonMusic();
    SceneManager.LoadSceneAsync(Fix.SCENE_HOME_TOWN);
    One.Parent.Clear();
  }

  public static void JumpToDungeonField(string dungeon_field)
  {
    One.StopDungeonMusic();
    One.TF.CurrentDungeonField = dungeon_field;
    Resources.UnloadUnusedAssets();
    SceneManager.LoadSceneAsync(Fix.SCENE_DUNGEON_FIELD);
    One.Parent.Clear();
  }

  public static void JumpToTitle()
  {
    One.ReInitializeGroundOne(false);
    One.StopDungeonMusic();
    SceneManager.LoadSceneAsync(Fix.Title);
    One.Parent.Clear();
  }

  //public static void CallSaveLoad(MotherBase scene, bool SaveMode, bool AfterBacktoTitle)
  //{
  //  One.SaveMode = SaveMode;
  //  One.AfterBacktoTitle = AfterBacktoTitle;
  //  One.Parent.Add(scene);
  //  One.SaveAndExit = false;
  //  if (scene.Filter != null)
  //  {
  //    scene.Filter.SetActive(true);
  //  }
  //  SceneManager.LoadSceneAsync(Fix.SaveLoad, LoadSceneMode.Additive);
  //}

  public static void CallBattleEnemy(List<string> enemy_list, bool cannot_runaway)
  {
    One.EnemyList.Clear();
    for (int ii = 0; ii < enemy_list.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_1");
      Character character = objEC.AddComponent<Character>();
      character.Construction(enemy_list[ii]);
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    One.CannotRunAway = cannot_runaway;

    One.StopDungeonMusic();
    SceneManager.LoadSceneAsync("BattleEnemy");
  }

  //public static void CallTutorial(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.Tutorial, LoadSceneMode.Additive);
  //}

  //public static void CallGameSetting(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.GameSetting, LoadSceneMode.Additive);
  //}

  //public static void CallDungeonTicket(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.DungeonTicket, LoadSceneMode.Additive);
  //}

  //public static void CallTruthBattleEnemy(string sceneName, bool duel, bool hiSpeed, bool final, bool lifecount, bool enableReward, bool callFromMQ, int area, int stage)
  //{
  //  One.DuelMode = duel;
  //  One.HiSpeedAnimation = hiSpeed;
  //  One.FinalBattle = final;
  //  One.LifeCountBattle = lifecount;
  //  One.EnableBattleReward = enableReward;
  //  One.CallFromMonsterQuest = callFromMQ;
  //  One.MQ_AreaNumber = area;
  //  One.MQ_StageNumber = stage;
  //  One.BattleResult = One.battleResult.None;
  //  One.SceneName = sceneName;
  //  One.StopDungeonMusic();
  //  SceneManager.LoadScene(Fix.TruthBattleEnemy);
  //  One.Parent.Clear();
  //}
  //public static void CallSingleBattleEnemy(string sceneName, bool duel, bool hiSpeed, bool final, bool lifecount)
  //{
  //  One.DuelMode = duel;
  //  One.HiSpeedAnimation = hiSpeed;
  //  One.FinalBattle = final;
  //  One.LifeCountBattle = lifecount;
  //  One.BattleResult = One.battleResult.None;
  //  One.SceneName = sceneName;
  //  One.StopDungeonMusic();
  //  SceneManager.LoadScene(Fix.SingleBattleEnemy);
  //  One.Parent.Clear();
  //}

  //public static void CallBackBattleEnemy()
  //{
  //  string target = One.SceneName;
  //  One.SceneName = string.Empty;
  //  SceneManager.LoadScene(target);
  //}
  //public static void CallBackSingleBattleEnemy()
  //{
  //  string target = One.SceneName;
  //  One.SceneName = string.Empty;
  //  SceneManager.LoadScene(target);
  //}

  //public static void CallTruthPlayBack(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthPlayback, LoadSceneMode.Additive);
  //}

  //public static void CallAchievement(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthAchievement, LoadSceneMode.Additive);
  //}

  //public static void CallTruthBookManual(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthInformation, LoadSceneMode.Additive);
  //}

  //public static void CallTruthSelectCharacter(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthSelectCharacter, LoadSceneMode.Additive);
  //}

  //public static void CallTruthChoiceStatue(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthChoiceStatue, LoadSceneMode.Additive);
  //}

  //public static void CallTruthWill(MotherBase scene)
  //{
  //  One.GodSeuqence = false;
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthWill, LoadSceneMode.Additive);
  //}

  //public static void CallTruthAnswer(MotherBase scene)
  //{
  //  One.GodSeuqence = false;
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthAnswer, LoadSceneMode.Additive);
  //}

  //public static void CallTruthInputRequest(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthRequestInput, LoadSceneMode.Additive);
  //}

  //public static void CallTruthDuelPlayerStatus(MotherBase scene, string duelPlayerName)
  //{
  //  One.Parent.Add(scene);
  //  One.DuelPlayerName = duelPlayerName;
  //  SceneManager.LoadSceneAsync(Fix.TruthDuelPlayerStatus, LoadSceneMode.Additive);
  //}

  //public static void CallTruthDuelRule(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthDuelRule, LoadSceneMode.Additive);
  //}

  //public static void CallTruthItemDesc(MotherBase scene, string itemNameTitle)
  //{
  //  One.Parent.Add(scene);
  //  One.ItemNameTitle = itemNameTitle;
  //  SceneManager.LoadSceneAsync(Fix.TruthItemDesc, LoadSceneMode.Additive);
  //}

  //public static void CallTruthDecision(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthDecision, LoadSceneMode.Additive);
  //}

  //public static void CallTruthDecision3(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthDecision3, LoadSceneMode.Additive);
  //}

  //public static void CallTruthDecision2(MotherBase scene, string message, string textTop, string textLeft, string textRight, string textBottom, bool permutation)
  //{
  //  One.Decision2_Message = message;
  //  One.Decision2_TopText = textTop;
  //  One.Decision2_LeftText = textLeft;
  //  One.Decision2_RightText = textRight;
  //  One.Decision2_BottomText = textBottom;
  //  One.Decision2_SelectPermutation = permutation;
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthDecision2, LoadSceneMode.Additive);
  //}

  //public static void CallDuelRule(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthDuelRule, LoadSceneMode.Additive);
  //}

  //public static void CallRequestFood(string src, MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthRequestFood, LoadSceneMode.Additive);
  //}

  //public static void CallItemBank(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthItemBank, LoadSceneMode.Additive);
  //}

  //public static void CallPotionShop(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthPotionShop, LoadSceneMode.Additive);
  //}

  //public static void CallMonsterQuest(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthMonsterQuest, LoadSceneMode.Additive);
  //}

  //public static void CallSaveLoadWithSaveOnly()
  //{
  //  One.SaveMode = true;
  //  One.SaveAndExit = true;
  //  SceneManager.LoadSceneAsync(Fix.SaveLoad, LoadSceneMode.Additive);
  //}

  //public static void CallTruthSelectEquipment(MotherBase scene, int equipType, MainCharacter targetPlayer)
  //{
  //  One.EquipType = equipType;
  //  One.TargetPlayer = targetPlayer;
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthSelectEquipment, LoadSceneMode.Additive);
  //}

  //public static void CallTruthStatusPlayer(MotherBase scene, bool onlySelectTrash, string newItem, string itemName)
  //{
  //  One.OnlySelectTrash = onlySelectTrash;
  //  One.OnlySelectTrashNewItem = newItem;
  //  One.CannotSelectTrash = itemName;
  //  One.LevelUpCharacter = One.MC.FullName;
  //  One.LevelUp = false;
  //  One.UpPoint = 0;
  //  One.CumultiveLvUpValue = 0;
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthStatusPlayer, LoadSceneMode.Additive);
  //}
  //public static void CallTruthStatusPlayer(MotherBase scene, ref bool leveUp, ref int upPoint, ref int cumultivaLvUpValue, string characterName)
  //{
  //  One.OnlySelectTrash = false;
  //  One.OnlySelectTrashNewItem = string.Empty;
  //  One.CannotSelectTrash = string.Empty;
  //  One.LevelUp = leveUp;
  //  One.LevelUpCharacter = characterName;
  //  One.UpPoint = upPoint;
  //  One.CumultiveLvUpValue = cumultivaLvUpValue;
  //  One.Parent.Add(scene);
  //  leveUp = false;
  //  upPoint = 0;
  //  cumultivaLvUpValue = 0;

  //  SceneManager.LoadSceneAsync(Fix.TruthStatusPlayer, LoadSceneMode.Additive);
  //}

  //public static void CallTruthSkillSpellDesc(MotherBase scene, string playerName, string commandName)
  //{
  //  One.Parent.Add(scene);
  //  One.playerName = playerName;
  //  One.SpellSkillName = commandName;
  //  SceneManager.LoadSceneAsync(Fix.TruthSkillSpellDesc, LoadSceneMode.Additive);
  //}

  //public static void CallTruthEquipmentShop(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthEquipmentShop, LoadSceneMode.Additive);
  //}

  //public static void CallTruthBattleSetting(MotherBase scene)
  //{
  //  One.Parent.Add(scene);
  //  SceneManager.LoadSceneAsync(Fix.TruthBattleSetting, LoadSceneMode.Additive);
  //}

  public static void Back(MotherBase scene)
  {
    Debug.Log("back name: " + scene.GetType().Name);
    string sceneName = scene.GetType().Name;
    if (One.Parent.Count > 0)
    {
      One.Parent[One.Parent.Count - 1].SceneBack();
      One.Parent.RemoveAt(One.Parent.Count - 1);
    }
    SceneManager.UnloadSceneAsync(sceneName);
  }

  public static void BackSuddenly(MotherBase scene)
  {
    SceneManager.UnloadSceneAsync(scene.GetType().Name);

    if (One.Parent.Count > 0)
    {
      MotherBase current = One.Parent[One.Parent.Count - 1];
      One.Parent.RemoveAt(One.Parent.Count - 1);
      current.SceneBack();
    }
  }
}