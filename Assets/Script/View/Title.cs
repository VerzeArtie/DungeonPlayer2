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
    lana.ShiningHeal = 1;
    lana.EverflowMind = 1;
    lana.StraightSmash = 1;
    lana.BlackContract = 1;
    lana.InnerInspiration = 1;
    lana.SeventhPrinciple = 1;
    lana.ActionCommand2 = Fix.SHINING_HEAL;
    lana.ActionCommand3 = Fix.STRAIGHT_SMASH;
    lana.ActionCommand4 = Fix.EVERFLOW_MIND;
    lana.ActionCommand5 = Fix.BLACK_CONTRACT;
    lana.ActionCommand6 = Fix.INNER_INSPIRATION;
    lana.ActionCommand7 = Fix.SEVENTH_PRINCIPLE;

    lana.Strength = 1000;
    lana.Agility = 10;
    lana.Intelligence = 10;
    lana.Mind = 50;
    lana.BaseManaPoint = 999;
    lana.BaseLife = 1000;
    lana.MaxGain();
    //lana.CurrentManaPoint = 3;

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.GaleWind = 1;
    ein.IceNeedle = 1;
    ein.FreezingCube = 1;
    ein.VolcanicBlaze = 1;
    ein.IronBuster = 1;
    ein.CounterAttack = 1;
    ein.CursedEvangile = 1;
    ein.PenetrationArrow = 1;
    ein.CircleOfSerenity = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.HunterShot = 1;
    ein.FlameStrike = 1;
    ein.ShiningHeal = 1;
    ein.BloodSign = 1;
    ein.CircleOfTheDespair = 1;
    ein.RagingStorm = 1;
    ein.InnerInspiration = 1;
    ein.FreshHeal = 1;
    ein.EnergyBolt = 1;
    ein.SpeedStep = 1;

    ein.Strength = 1000;
    ein.Agility = 10;
    ein.Intelligence = 10;
    ein.Mind = 100;
    ein.BaseManaPoint = 999;
    ein.BaseLife = 1000;
    ein.ActionCommand1 = Fix.FIRE_BALL;
    ein.ActionCommand2 = Fix.FLAME_STRIKE;
    ein.ActionCommand3 = Fix.INNER_INSPIRATION;
    ein.ActionCommand4 = Fix.FRESH_HEAL;
    ein.ActionCommand5 = Fix.CIRCLE_OF_THE_DESPAIR;
    ein.ActionCommand6 = Fix.RAGING_STORM;
    ein.ActionCommand7 = Fix.COUNTER_ATTACK;
    ein.ActionCommand8 = Fix.PHANTOM_OBORO;
    ein.ActionCommand9 = Fix.SPEED_STEP;
    ein.MaxGain();
    //ein.CurrentManaPoint = 2;
    //Character eone = One.SelectCharacter(Fix.NAME_EONE_FULNEA);
    //eone.AgilityFood = 1;

    One.TF.BattlePlayer2 = Fix.NAME_LANA_AMIRIA;
    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    //One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA;

    One.CreateShadowData();

    One.EnemyList.Clear();
    One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
    One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
    //One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
    //One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);

    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      character.Strength = 100;
      character.Agility = 1;
      character.Intelligence = 1;
      character.Mind = 100;
      character.BaseLife = 999999;
      character.BaseManaPoint = 99999;
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
    lana.BaseManaPoint = 999;
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
    ein.CircleOfSerenity = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.FlameStrike = 1;
    ein.FrostLance = 1;
    ein.CounterDisallow = 1;
    ein.PrecisionStrike = 1;
    ein.UnintentionalHit = 1;
    ein.HardestParry = 1;
    ein.EverflowMind = 1;

    ein.Strength = 30;
    ein.Agility = 9;
    ein.Intelligence = 6;
    ein.Stamina = 20;
    ein.Mind = 30;
    ein.BaseManaPoint = 999;
    ein.ActionCommand1 = Fix.STRAIGHT_SMASH;
    ein.ActionCommand2 = Fix.FIRE_BALL;
    ein.ActionCommand3 = Fix.DEFENSE;
    ein.ActionCommand4 = Fix.FLAME_STRIKE;
    ein.ActionCommand5 = Fix.FROST_LANCE;
    ein.ActionCommand6 = Fix.COUNTER_DISALLOW;
    ein.ActionCommand7 = Fix.PRECISION_STRIKE;
    ein.ActionCommand8 = Fix.UNINTENTIONAL_HIT;
    ein.ActionCommand9 = Fix.HARDEST_PARRY;
    ein.MaxGain();

    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;

    One.CreateShadowData();

    One.EnemyList.Clear();
    One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);//.DUEL_JEDA_ARUS);
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
    lana.BaseManaPoint = 999;
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
    ein.CircleOfSerenity = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.Strength = 10;
    ein.Agility = 10;
    ein.Intelligence = 10;
    ein.Mind = 100;
    ein.BaseManaPoint = 999;
    ein.BaseLife = 1000;
    ein.ActionCommand1 = Fix.FIRE_BALL;
    ein.ActionCommand2 = Fix.DOMINATION_FIELD;
    ein.ActionCommand3 = Fix.CURSED_EVANGILE;
    ein.ActionCommand4 = Fix.PENETRATION_ARROW;
    ein.ActionCommand5 = Fix.CIRCLE_OF_SERENITY;
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
      character.BaseManaPoint = 99999;
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
