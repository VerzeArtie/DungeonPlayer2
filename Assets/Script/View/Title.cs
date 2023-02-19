using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MotherBase
{
  public SaveLoad groupSaveLoad;
  public GameObject groupConfig;

  bool firstAction = false;
  // Start is called before the first frame update
  public override void Start()
  {
    base.Start();
  }

  // Update is called once per frame
  void Update()
  {
    if (this.firstAction == false)
    {
      this.firstAction = true;
      // 初期開始時、ファイルが無い場合準備しておく。
      One.MakeDirectory();
    }
  }

  public void TapGameStart()
  {
    Debug.Log("TapGameStart ok");

    if (System.IO.File.Exists(One.PathForRootFile(Fix.AR_FILE)) == false)
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE no exist, then create it.: " + One.PathForRootFile(Fix.AR_FILE));
      One.UpdateAkashicRecord();
    }
    else
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE exist, then no action.: " + One.PathForRootFile(Fix.AR_FILE));
    }

    One.TF.AvailableEinWolence = true;
    One.TF.AvailableLanaAmiria = true;
    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    One.TF.BattlePlayer2 = Fix.NAME_LANA_AMIRIA;
    One.TF.CurrentAreaName = Fix.TOWN_ANSHET;
    One.TF.BeforeAreaName = Fix.TOWN_ANSHET;
    SceneDimension.JumpToHomeTown();
  }

  public void TapGameLoad()
  {
    One.SaveMode = false;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    One.Parent.Add(this);
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //SceneDimension.CallSaveLoad(this, false, false);
  }

  public void TapConfig()
  {
    groupConfig.SetActive(true);
  }

  public void TapClose()
  {
    groupConfig.SetActive(false);
    groupSaveLoad.gameObject.SetActive(false);
  }

  public void TapBattleTest()
  {
    One.BattleEnd = Fix.GameEndType.None;

    One.TF.AvailableEoneFulnea = true;

    Character lana = One.SelectCharacter(Fix.NAME_LANA_AMIRIA);
    lana.Strength = 10;
    lana.Agility = 10;
    lana.Intelligence = 10;
    lana.Mind = 100;
    lana.BaseSoulPoint = 999;
    lana.BaseLife = 1000;

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.GaleWind = 1;
    ein.IceNeedle = 1;
    ein.FreezingCube = 1;
    ein.VolcanicBlaze = 1;
    ein.IronBuster = 1;
    ein.CounterAttack = 1;
    ein.CursedEvangile = 1;
    ein.PenetrationArrow = 1;
    ein.CircleOfTheVigor = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.Strength = 10;
    ein.Agility = 10;
    ein.Intelligence = 10;
    ein.Mind = 100;
    ein.BaseSoulPoint = 999;
    ein.BaseLife = 1000;
    ein.ActionCommand1 = Fix.FIRE_BALL;
    ein.ActionCommand2 = Fix.DOMINATION_FIELD;
    ein.ActionCommand3 = Fix.CURSED_EVANGILE;
    ein.ActionCommand4 = Fix.PENETRATION_ARROW;
    ein.ActionCommand5 = Fix.CIRCLE_OF_THE_VIGOR;
    ein.ActionCommand6 = Fix.WILL_AWAKENING;
    ein.ActionCommand7 = Fix.COUNTER_ATTACK;
    ein.ActionCommand8 = Fix.PHANTOM_OBORO;
    ein.ActionCommand9 = Fix.DEADLY_DRIVE;
    ein.MaxGain();
    //Character eone = One.SelectCharacter(Fix.NAME_EONE_FULNEA);
    //eone.AgilityFood = 1;

    One.TF.BattlePlayer1 = Fix.NAME_LANA_AMIRIA;
    One.TF.BattlePlayer2 = Fix.NAME_EIN_WOLENCE;
    //One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA;

    One.CreateShadowData();

    One.EnemyList.Clear();
    One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
    //One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
    //One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
    //One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);

    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      character.Strength = 50;
      character.Agility = 20;
      character.Intelligence = 100;
      character.Mind = 20;
      character.BaseLife = 999999;
      character.BaseSoulPoint = 99999;
      character.MaxGain();
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    //    SceneDimension.CallBattleEnemy();

    One.BattleMode = Fix.BattleMode.Normal;
    SceneDimension.CallBattleEnemy();
  }

  public void TapDuelTest()
  {
    One.BattleEnd = Fix.GameEndType.None;

    One.TF.AvailableEoneFulnea = true;

    Character lana = One.SelectCharacter(Fix.NAME_LANA_AMIRIA);
    lana.Strength = 10;
    lana.Agility = 10;
    lana.Intelligence = 10;
    lana.Mind = 100;
    lana.BaseSoulPoint = 999;
    lana.BaseLife = 1000;

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.GaleWind = 1;
    ein.IceNeedle = 1;
    ein.FreezingCube = 1;
    ein.VolcanicBlaze = 1;
    ein.IronBuster = 1;
    ein.CounterAttack = 1;
    ein.CursedEvangile = 1;
    ein.PenetrationArrow = 1;
    ein.CircleOfTheVigor = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.Strength = 30;
    ein.Agility = 9;
    ein.Intelligence = 6;
    ein.Stamina = 20;
    ein.Mind = 10;
    ein.ActionCommand1 = Fix.STRAIGHT_SMASH;
    ein.ActionCommand2 = Fix.FIRE_BALL;
    ein.ActionCommand3 = Fix.DEFENSE;
    ein.MaxGain();

    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;

    One.CreateShadowData();

    One.EnemyList.Clear();
    One.BattleEnemyList.Add(Fix.DUEL_JEDA_ARUS);
    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      character.MaxGain();
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    //    SceneDimension.CallBattleEnemy();

    One.BattleMode = Fix.BattleMode.Duel;
    SceneDimension.CallBattleEnemy();
  }


  public void TapBossTest()
  {
    One.BattleEnd = Fix.GameEndType.None;

    One.TF.AvailableEoneFulnea = true;

    Character lana = One.SelectCharacter(Fix.NAME_LANA_AMIRIA);
    lana.Strength = 10;
    lana.Agility = 10;
    lana.Intelligence = 10;
    lana.Mind = 100;
    lana.BaseSoulPoint = 999;
    lana.BaseLife = 1000;

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.GaleWind = 1;
    ein.IceNeedle = 1;
    ein.FreezingCube = 1;
    ein.VolcanicBlaze = 1;
    ein.IronBuster = 1;
    ein.CounterAttack = 1;
    ein.CursedEvangile = 1;
    ein.PenetrationArrow = 1;
    ein.CircleOfTheVigor = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.Strength = 10;
    ein.Agility = 10;
    ein.Intelligence = 10;
    ein.Mind = 100;
    ein.BaseSoulPoint = 999;
    ein.BaseLife = 1000;
    ein.ActionCommand1 = Fix.FIRE_BALL;
    ein.ActionCommand2 = Fix.DOMINATION_FIELD;
    ein.ActionCommand3 = Fix.CURSED_EVANGILE;
    ein.ActionCommand4 = Fix.PENETRATION_ARROW;
    ein.ActionCommand5 = Fix.CIRCLE_OF_THE_VIGOR;
    ein.ActionCommand6 = Fix.WILL_AWAKENING;
    ein.ActionCommand7 = Fix.COUNTER_ATTACK;
    ein.ActionCommand8 = Fix.PHANTOM_OBORO;
    ein.ActionCommand9 = Fix.DEADLY_DRIVE;
    ein.MaxGain();
    //Character eone = One.SelectCharacter(Fix.NAME_EONE_FULNEA);
    //eone.AgilityFood = 1;

    One.TF.BattlePlayer1 = Fix.NAME_LANA_AMIRIA;
    One.TF.BattlePlayer2 = Fix.NAME_EIN_WOLENCE;
    //One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA;

    One.CreateShadowData();

    One.EnemyList.Clear();
    One.BattleEnemyList.Add(Fix.THE_GALVADAZER);
    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      character.Strength = 50;
      character.Agility = 20;
      character.Intelligence = 100;
      character.Mind = 20;
      character.BaseLife = 999999;
      character.BaseSoulPoint = 99999;
      character.MaxGain();
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    //    SceneDimension.CallBattleEnemy();

    One.BattleMode = Fix.BattleMode.Boss;
    SceneDimension.CallBattleEnemy();
  }
}
