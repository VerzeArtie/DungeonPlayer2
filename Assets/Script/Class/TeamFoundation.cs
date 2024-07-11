using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TeamFoundation : MonoBehaviour
{
  #region "General"
  [SerializeField] protected int _gold = 0;
  public int Gold
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _gold = value;
    }
    get { return _gold; }
  }

  [SerializeField] protected int _obsidianStone = 0;
  public int ObsidianStone
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _obsidianStone = value;
    }
    get { return _obsidianStone; }
  }

  [SerializeField] protected int _gameDay = 1;
  public int GameDay
  {
    set { _gameDay = value; }
    get { return _gameDay; }
  }

  [SerializeField] protected bool _saveByDungeon = false;
  public bool SaveByDungeon
  {
    set { _saveByDungeon = value; }
    get { return _saveByDungeon; }
  }

  [SerializeField] protected float _field_X = 0;
  public float Field_X
  {
    set { _field_X = value; }
    get { return _field_X; }
  }
  [SerializeField] protected float _field_Y = 1;
  public float Field_Y
  {
    set { _field_Y = value; }
    get { return _field_Y; }
  }
  [SerializeField] protected float _field_Z = 0;
  public float Field_Z
  {
    set { _field_Z = value; }
    get { return _field_Z; }
  }

  [SerializeField] protected bool _availableImmediateAction = false;
  public bool AvailableImmediateAction
  {
    set { _availableImmediateAction = value; }
    get { return _availableImmediateAction; }
  }

  [SerializeField] protected bool _availableFirstCommand = true;
  public bool AvailableFirstCommand
  {
    set { _availableFirstCommand = value; }
    get { return _availableFirstCommand; }
  }

  [SerializeField] protected bool _availableSecondCommand = false;
  public bool AvailableSecondCommand
  {
    set { _availableSecondCommand = value; }
    get { return _availableSecondCommand; }
  }

  [SerializeField] protected bool _availableThirdCommand = false;
  public bool AvailableThirdCommand
  {
    set { _availableThirdCommand = value; }
    get { return _availableThirdCommand; }
  }

  [SerializeField] protected bool _availableAllCommand = false;
  public bool AvailableAllCommand
  {
    set { _availableAllCommand = value; }
    get { return _availableAllCommand; }
  }

  [SerializeField] protected bool _availableSkillTree = false;
  public bool AvailableSkillTree
  {
    set { _availableSkillTree = value; }
    get { return _availableSkillTree; }
  }

  [SerializeField] protected bool _availableTactics = false;
  public bool AvailableTactics
  {
    set { _availableTactics = value; }
    get { return _availableTactics; }
  }
  [SerializeField] protected bool _availablePotentialGauge = false;
  public bool AvailablePotentialGauge
  {
    set { _availablePotentialGauge = value; }
    get { return _availablePotentialGauge; }
  }

  [SerializeField] protected bool _availableArchetype_EinWolence = false;
  public bool AvailableArchetype_EinWolence
  {
    set { _availableArchetype_EinWolence = value; }
    get { return _availableArchetype_EinWolence; }
  }
  [SerializeField] protected bool _availableArchetype_LanaAmiria = false;
  public bool AvailableArchetype_LanaAmiria
  {
    set { _availableArchetype_LanaAmiria = value; }
    get { return _availableArchetype_LanaAmiria; }
  }
  [SerializeField] protected bool _availableArchetype_EoneFulnea = false;
  public bool AvailableArchetype_EoneFulnea
  {
    set { _availableArchetype_EoneFulnea = value; }
    get { return _availableArchetype_EoneFulnea; }
  }
  [SerializeField] protected bool _availableArchetype_BillyRaki = false;
  public bool AvailableArchetype_BillyRaki
  {
    set { _availableArchetype_BillyRaki = value; }
    get { return _availableArchetype_BillyRaki; }
  }
  [SerializeField] protected bool _availableArchetype_AdelBrigandy = false;
  public bool AvailableArchetype_AdelBrigandy
  {
    set { _availableArchetype_AdelBrigandy = value; }
    get { return _availableArchetype_AdelBrigandy; }
  }
  [SerializeField] protected bool _availableArchetype_SelmoiRo = false;
  public bool AvailableArchetype_SelmoiRo
  {
    set { _availableArchetype_SelmoiRo = value; }
    get { return _availableArchetype_SelmoiRo; }
  }

  [SerializeField] protected bool _availableFirstEssence = false;
  public bool AvailableFirstEssence
  {
    set { _availableFirstEssence = value; }
    get { return _availableFirstEssence; }
  }

  [SerializeField] protected bool _availableSecondEssence = false;
  public bool AvailableSecondEssence
  {
    set { _availableSecondEssence = value; }
    get { return _availableSecondEssence; }
  }

  [SerializeField] protected bool _availableThirdEssence = false;
  public bool AvailableThirdEssence
  {
    set { _availableThirdEssence = value; }
    get { return _availableThirdEssence; }
  }

  [SerializeField] protected bool _availableFourthEssence = false;
  public bool AvailableFourthEssence
  {
    set { _availableFourthEssence = value; }
    get { return _availableFourthEssence; }
  }

  [SerializeField] protected List<Item> _backpackList = new List<Item>();
  public List<Item> BackpackList
  {
    //  set { _backpackList = value; }
    get { return _backpackList; }
  }

  [SerializeField] protected bool _alreadyRestInn = false;
  public bool AlreadyRestInn
  {
    set { _alreadyRestInn = value; }
    get { return _alreadyRestInn; }
  }

  [SerializeField] protected bool _alreadyDungeon = false;
  public bool AlreadyDungeon
  {
    set { _alreadyDungeon = value; }
    get { return _alreadyDungeon; }
  }

  [SerializeField] protected bool _alreadyPureCleanWater = false;
  public bool AlreadyPureCleanWater
  {
    set { _alreadyPureCleanWater = value; }
    get { return _alreadyPureCleanWater; }
  }

  [SerializeField] protected bool _alreadySinseisui = false;
  public bool AlreadySinseisui
  {
    set { _alreadySinseisui = value; }
    get { return _alreadySinseisui; }
  }

  [SerializeField] protected string _currentAreaName = String.Empty;
  public string CurrentAreaName
  {
    set { _currentAreaName = value; }
    get { return _currentAreaName; }
  }
  [SerializeField] protected string _currentDungeonField = String.Empty;
  public string CurrentDungeonField
  {
    set { _currentDungeonField = value; }
    get { return _currentDungeonField; }
  }
  [SerializeField] protected string _beforeAreaName = String.Empty;
  public string BeforeAreaName
  {
    set { _beforeAreaName = value; }
    get { return _beforeAreaName; }
  }

  protected bool _escapeFromDungeon = false;
  public bool EscapeFromDungeon
  {
    set { _escapeFromDungeon = value; }
    get { return _escapeFromDungeon; }
  }
  #endregion

  #region "Battle Settings"
  [SerializeField] protected string _battlePlayer1 = String.Empty;
  public string BattlePlayer1 { get { return _battlePlayer1; } set { _battlePlayer1 = value; } }
  [SerializeField] protected string _battlePlayer2 = String.Empty;
  public string BattlePlayer2 { get { return _battlePlayer2; } set { _battlePlayer2 = value; } }
  [SerializeField] protected string _battlePlayer3 = String.Empty;
  public string BattlePlayer3 { get { return _battlePlayer3; } set { _battlePlayer3 = value; } }
  [SerializeField] protected string _battlePlayer4 = String.Empty;
  public string BattlePlayer4 { get { return _battlePlayer4; } set { _battlePlayer4 = value; } }
  [SerializeField] protected string _battlePlayer5 = String.Empty;
  public string BattlePlayer5 { get { return _battlePlayer5; } set { _battlePlayer5 = value; } }
  [SerializeField] protected string _battlePlayer6 = String.Empty;
  public string BattlePlayer6 { get { return _battlePlayer6; } set { _battlePlayer6 = value; } }

  [SerializeField] protected int _maxPotentialEnergy = 10000;
  public int MaxPotentialEnergy { get { return _maxPotentialEnergy; } set { _maxPotentialEnergy = value; } }

  [SerializeField] protected int _potentialEnergy = 0;
  public int PotentialEnergy 
  {
    get
    {
      return _potentialEnergy;
    }
    set
    {
      if (value >= _maxPotentialEnergy)
      {
        _potentialEnergy = _maxPotentialEnergy;
      }
      else
      {
        _potentialEnergy = value;
      }
    }
  }
  #endregion

  #region "Characters"
  [SerializeField] protected bool _availableEinWolence = false;
  [SerializeField] protected bool _availableLanaAmiria = false;
  [SerializeField] protected bool _availableEoneFulnea = false;
  [SerializeField] protected bool _availableMagiZelkis = false;
  [SerializeField] protected bool _availableSelmoiRo = false;
  [SerializeField] protected bool _availableKartinMai = false;
  [SerializeField] protected bool _availableJedaArus = false;
  [SerializeField] protected bool _availableSinikiaVeilhanz = false;
  [SerializeField] protected bool _availableAdelBrigandy = false;
  [SerializeField] protected bool _availableLeneColtos = false;
  [SerializeField] protected bool _availablePermaWaramy = false;
  [SerializeField] protected bool _availableKiltJorju = false;
  [SerializeField] protected bool _availableBillyRaki = false;
  [SerializeField] protected bool _availableAnnaHamilton = false;
  [SerializeField] protected bool _availableCalmansOhn = false;
  [SerializeField] protected bool _availableSunYu = false;
  [SerializeField] protected bool _availableShuvaltzFlore = false;
  [SerializeField] protected bool _availableRvelZelkis = false;
  [SerializeField] protected bool _availableVanHehgustel = false;
  [SerializeField] protected bool _availableOhryuGenma = false;
  [SerializeField] protected bool _availableLadaMystorus = false;
  [SerializeField] protected bool _availableSinOscurete = false;
  [SerializeField] protected bool _availableDelvaTreckino = false;
  [SerializeField] protected bool _availableIlzinaMeldiete = false;

  public bool AvailableEinWolence
  {
    set { _availableEinWolence = value; }
    get { return _availableEinWolence; }
  }
  public bool AvailableLanaAmiria
  {
    set { _availableLanaAmiria = value; }
    get { return _availableLanaAmiria; }
  }
  public bool AvailableEoneFulnea
  {
    set { _availableEoneFulnea = value; }
    get { return _availableEoneFulnea; }
  }
  public bool AvailableMagiZelkis
  {
    set { _availableMagiZelkis = value; }
    get { return _availableMagiZelkis; }
  }
  public bool AvailableSelmoiRo
  {
    set { _availableSelmoiRo = value; }
    get { return _availableSelmoiRo; }
  }
  public bool AvailableKartinMai
  {
    set { _availableKartinMai = value; }
    get { return _availableKartinMai; }
  }
  public bool AvailableJedaArus
  {
    set { _availableJedaArus = value; }
    get { return _availableJedaArus; }
  }
  public bool AvailableSinikiaVeilhanz
  {
    set { _availableSinikiaVeilhanz = value; }
    get { return _availableSinikiaVeilhanz; }
  }
  public bool AvailableAdelBrigandy
  {
    set { _availableAdelBrigandy = value; }
    get { return _availableAdelBrigandy; }
  }
  public bool AvailableLeneColtos
  {
    set { _availableLeneColtos = value; }
    get { return _availableLeneColtos; }
  }
  public bool AvailablePermaWaramy
  {
    set { _availablePermaWaramy = value; }
    get { return _availablePermaWaramy; }
  }
  public bool AvailableKiltJorju
  {
    set { _availableKiltJorju = value; }
    get { return _availableKiltJorju; }
  }
  public bool AvailableBillyRaki
  {
    set { _availableBillyRaki = value; }
    get { return _availableBillyRaki; }
  }
  public bool AvailableAnnaHamilton
  {
    set { _availableAnnaHamilton = value; }
    get { return _availableAnnaHamilton; }
  }
  public bool AvailableCalmansOhn
  {
    set { _availableCalmansOhn = value; }
    get { return _availableCalmansOhn; }
  }
  public bool AvailableSunYu
  {
    set { _availableSunYu = value; }
    get { return _availableSunYu; }
  }
  public bool AvailableShuvaltzFlore
  {
    set { _availableShuvaltzFlore = value; }
    get { return _availableShuvaltzFlore; }
  }
  public bool AvailableRvelZelkis
  {
    set { _availableRvelZelkis = value; }
    get { return _availableRvelZelkis; }
  }
  public bool AvailableVanHehgustel
  {
    set { _availableVanHehgustel = value; }
    get { return _availableVanHehgustel; }
  }
  public bool AvailableOhryuGenma
  {
    set { _availableOhryuGenma = value; }
    get { return _availableOhryuGenma; }
  }
  public bool AvailableLadaMystorus
  {
    set { _availableLadaMystorus = value; }
    get { return _availableLadaMystorus; }
  }
  public bool AvailableSinOscurete
  {
    set { _availableSinOscurete = value; }
    get { return _availableSinOscurete; }
  }
  public bool AvailableDelvaTreckino
  {
    set { _availableDelvaTreckino = value; }
    get { return _availableDelvaTreckino; }
  }
  public bool AvailableIlzinaMeldiete
  {
    set { _availableIlzinaMeldiete = value; }
    get { return _availableIlzinaMeldiete; }
  }
  #endregion

  #region "Map Available"
  [SerializeField] protected bool _availableAnshet = false;
  public bool AvailableAnshet
  {
    set { _availableAnshet = value; }
    get { return _availableAnshet; }
  }

  [SerializeField] protected bool _availableGoratrum = false;
  public bool AvailableGoratrum
  {
    set { _availableGoratrum = value; }
    get { return _availableGoratrum; }
  }

  [SerializeField] protected bool _availableQvelta = false;
  public bool AvailableQvelta
  {
    set { _availableQvelta = value; }
    get { return _availableQvelta; }
  }

  [SerializeField] protected bool _availableArtharium = false;
  public bool AvailableArtharium
  {
    set { _availableArtharium = value; }
    get { return _availableArtharium; }
  }

  [SerializeField] protected bool _availableCotuhsye = false;
  public bool AvailableCotuhsye
  {
    set { _availableCotuhsye = value; }
    get { return _availableCotuhsye; }
  }

  [SerializeField] protected bool _availableZhalman = false;
  public bool AvailableZhalman
  {
    set { _availableZhalman = value; }
    get { return _availableZhalman; }
  }

  [SerializeField] protected bool _availableOhran = false;
  public bool AvailableOhran
  {
    set { _availableOhran = value; }
    get { return _availableOhran; }
  }

  [SerializeField] protected bool _availableVelgus = false;
  public bool AvailableVelgus
  {
    set { _availableVelgus = value; }
    get { return _availableVelgus; }
  }

  [SerializeField] protected bool _availableArcaneDine = false;
  public bool AvailableArcaneDine
  {
    set { _availableArcaneDine = value; }
    get { return _availableArcaneDine; }
  }

  [SerializeField] protected bool _availableParmetysia = false;
  public bool AvailableParmetysia
  {
    set { _availableParmetysia = value; }
    get { return _availableParmetysia; }
  }

  [SerializeField] protected bool _availableSaritan = false;
  public bool AvailableSaritan
  {
    set { _availableSaritan = value; }
    get { return _availableSaritan; }
  }

  [SerializeField] protected bool _availableDhal = false;
  public bool AvailableDhal
  {
    set { _availableDhal = value; }
    get { return _availableDhal; }
  }

  [SerializeField] protected bool _availableDale = false;
  public bool AvailableDale
  {
    set { _availableDale = value; }
    get { return _availableDale; }
  }

  [SerializeField] protected bool _availableDiskel = false;
  public bool AvailableDiskel
  {
    set { _availableDiskel = value; }
    get { return _availableDiskel; }
  }

  [SerializeField] protected bool _availableGanro = false;
  public bool AvailableGanro
  {
    set { _availableGanro = value; }
    get { return _availableGanro; }
  }

  [SerializeField] protected bool _availableEdelgarzen = false;
  public bool AvailableEdelgarzen
  {
    set { _availableEdelgarzen = value; }
    get { return _availableEdelgarzen; }
  }

  [SerializeField] protected bool _availableLoslon = false;
  public bool AvailableLoslon
  {
    set { _availableLoslon = value; }
    get { return _availableLoslon; }
  }

  [SerializeField] protected bool _availableZelman = false;
  public bool AvailableZelman
  {
    set { _availableZelman = value; }
    get { return _availableZelman; }
  }

  [SerializeField] protected bool _availableLataHouse = false;
  public bool AvailableLataHouse
  {
    set { _availableLataHouse = value; }
    get { return _availableLataHouse; }
  }

  [SerializeField] protected bool _availableSithGraveyard = false;
  public bool AvailableSithGraveyard
  {
    set { _availableSithGraveyard = value; }
    get { return _availableSithGraveyard; }
  }

  [SerializeField] protected bool _availableFran = false;
  public bool AvailableFran
  {
    set { _availableFran = value; }
    get { return _availableFran; }
  }

  [SerializeField] protected bool _availableSnowtreeLata = false;
  public bool AvailableSnowtreeLata
  {
    set { _availableSnowtreeLata = value; }
    get { return _availableSnowtreeLata; }
  }

  [SerializeField] protected bool _availableWosm = false;
  public bool AvailableWosm
  {
    set { _availableWosm = value; }
    get { return _availableWosm; }
  }

  [SerializeField] protected bool _availableFazilCastle = false;
  public bool AvailableFazilCastle
  {
    set { _availableFazilCastle = value; }
    get { return _availableFazilCastle; }
  }

  [SerializeField] protected bool _availableHeavenGenesisGate = false;
  public bool AvailableHeavenGenesisGate
  {
    set { _availableHeavenGenesisGate = value; }
    get { return _availableHeavenGenesisGate; }
  }
  #endregion

  #region "Map KnownTileInfo"
  [SerializeField] protected List<bool> _knownTileList_EsmiliaGrassField = new List<bool>(Fix.MAPSIZE_X_ESMILIA_GRASSFIELD * Fix.MAPSIZE_Z_ESMILIA_GRASSFIELD);
  public List<bool> KnownTileList_EsmiliaGrassField
  {
    set { _knownTileList_EsmiliaGrassField = value; }
    get { return _knownTileList_EsmiliaGrassField; }
  }

  [SerializeField] protected List<bool> _knownTileList_Goratrum = new List<bool>(Fix.MAPSIZE_X_GORATRUM * Fix.MAPSIZE_Z_GORATRUM);
  public List<bool> KnownTileList_Goratrum
  {
    set { _knownTileList_Goratrum = value; }
    get { return _knownTileList_Goratrum; }
  }
  [SerializeField] protected List<bool> _knownTileList_Goratrum_2 = new List<bool>(Fix.MAPSIZE_X_GORATRUM * Fix.MAPSIZE_Z_GORATRUM);
  public List<bool> KnownTileList_Goratrum_2
  {
    set { _knownTileList_Goratrum_2 = value; }
    get { return _knownTileList_Goratrum_2; }
  }

  [SerializeField] protected List<bool> _knownTileList_MysticForest = new List<bool>(Fix.MAPSIZE_X_MYSTICFOREST * Fix.MAPSIZE_Z_MYSTICFOREST);
  public List<bool> KnownTileList_MysticForest
  {
    set { _knownTileList_MysticForest = value; }
    get { return _knownTileList_MysticForest; }
  }

  [SerializeField] protected List<bool> _knownTileList_VelgusSeaTemple = new List<bool>(Fix.MAPSIZE_X_VELGUS_SEATEMPLE * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE);
  public List<bool> KnownTileList_VelgusSeaTemple
  {
    set { _knownTileList_VelgusSeaTemple = value; }
    get { return _knownTileList_VelgusSeaTemple; }
  }

  [SerializeField] protected List<bool> _knownTileList_VelgusSeaTemple_2 = new List<bool>(Fix.MAPSIZE_X_VELGUS_SEATEMPLE_2 * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_2);
  public List<bool> KnownTileList_VelgusSeaTemple_2
  {
    set { _knownTileList_VelgusSeaTemple_2 = value; }
    get { return _knownTileList_VelgusSeaTemple_2; }
  }

  [SerializeField] protected List<bool> _knownTileList_VelgusSeaTemple_3 = new List<bool>(Fix.MAPSIZE_X_VELGUS_SEATEMPLE_3 * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_3);
  public List<bool> KnownTileList_VelgusSeaTemple_3
  {
    set { _knownTileList_VelgusSeaTemple_3 = value; }
    get { return _knownTileList_VelgusSeaTemple_3; }
  }

  [SerializeField] protected List<bool> _knownTileList_VelgusSeaTemple_4 = new List<bool>(Fix.MAPSIZE_X_VELGUS_SEATEMPLE_4 * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_4);
  public List<bool> KnownTileList_VelgusSeaTemple_4
  {
    set { _knownTileList_VelgusSeaTemple_4 = value; }
    get { return _knownTileList_VelgusSeaTemple_4; }
  }

  [SerializeField] protected List<bool> _knownTileList_Edelgarzen_1 = new List<bool>(Fix.MAPSIZE_X_EDELGARZEN_1 * Fix.MAPSIZE_Z_EDELGARZEN_1);
  public List<bool> KnownTileList_Edelgarzen_1
  {
    set { _knownTileList_Edelgarzen_1 = value; }
    get { return _knownTileList_Edelgarzen_1; }
  }

  [SerializeField] protected List<bool> _knownTileList_Edelgarzen_2 = new List<bool>(Fix.MAPSIZE_X_EDELGARZEN_2 * Fix.MAPSIZE_Z_EDELGARZEN_2);
  public List<bool> KnownTileList_Edelgarzen_2
  {
    set { _knownTileList_Edelgarzen_2 = value; }
    get { return _knownTileList_Edelgarzen_2; }
  }

  [SerializeField] protected List<bool> _knownTileList_Edelgarzen_3 = new List<bool>(Fix.MAPSIZE_X_EDELGARZEN_3 * Fix.MAPSIZE_Z_EDELGARZEN_3);
  public List<bool> KnownTileList_Edelgarzen_3
  {
    set { _knownTileList_Edelgarzen_3 = value; }
    get { return _knownTileList_Edelgarzen_3; }
  }

  [SerializeField] protected List<bool> _knownTileList_Edelgarzen_4 = new List<bool>(Fix.MAPSIZE_X_EDELGARZEN_4 * Fix.MAPSIZE_Z_EDELGARZEN_4);
  public List<bool> KnownTileList_Edelgarzen_4
  {
    set { _knownTileList_Edelgarzen_4 = value; }
    get { return _knownTileList_Edelgarzen_4; }
  }
  #endregion

  #region "Event"
  [SerializeField] public bool Zetanium_001 { get; set; }
  [SerializeField] public bool Zetanium_002 { get; set; }
  [SerializeField] public bool Zetanium_003 { get; set; }
  [SerializeField] public bool Zetanium_004 { get; set; }
  [SerializeField] public bool Zetanium_005 { get; set; }

  [SerializeField] protected bool _event_message000010 = false;
  public bool Event_Message000010
  {
    get { return _event_message000010; }
    set { _event_message000010 = value; }
  }
  [SerializeField] protected bool _event_message000040 = false;
  public bool Event_Message000040
  {
    get { return _event_message000040; }
    set { _event_message000040 = value; }
  }
  [SerializeField] protected bool _event_message000050 = false;
  public bool Event_Message000050
  {
    get { return _event_message000050; }
    set { _event_message000050 = value; }
  }
  [SerializeField] protected bool _event_message000060 = false;
  public bool Event_Message000060
  {
    get { return _event_message000060; }
    set { _event_message000060 = value; }
  }
  [SerializeField] protected bool _event_message000080 = false;
  public bool Event_Message000080
  {
    get { return _event_message000080; }
    set { _event_message000080 = value; }
  }

  [SerializeField] protected bool _event_message000090= false;
  public bool Event_Message000090
  {
    get { return _event_message000090; }
    set { _event_message000090 = value; }
  }

  [SerializeField] protected bool _event_message000095 = false;
  public bool Event_Message000095
  {
    get { return _event_message000095; }
    set { _event_message000095 = value; }
  }

  [SerializeField] protected bool _event_message000100 = false;
  public bool Event_Message000100
  {
    get { return _event_message000100; }
    set { _event_message000100 = value; }
  }

  [SerializeField] protected bool _event_message000111 = false;
  public bool Event_Message000111
  {
    get { return _event_message000111; }
    set { _event_message000111 = value; }
  }

  [SerializeField] protected bool _event_message100010 = false;
  public bool Event_Message100010
  {
    get { return _event_message100010; }
    set { _event_message100010 = value; }
  }

  [SerializeField] protected bool _event_message100001 = false;
  public bool Event_Message100001
  {
    get { return _event_message100001; }
    set { _event_message100001 = value; }
  }

  [SerializeField] protected bool _event_message100020 = false;
  public bool Event_Message100020
  {
    get { return _event_message100020; }
    set { _event_message100020 = value; }
  }

  [SerializeField] protected bool _event_message100030 = false;
  public bool Event_Message100030
  {
    get { return _event_message100030; }
    set { _event_message100030 = value; }
  }

  protected bool _event_field_10 = false;
  public bool EventField_10 { get { return _event_field_10; } set { _event_field_10 = value; } }
  protected bool _event_field_20 = false;
  public bool EventField_20 { get { return _event_field_20; } set { _event_field_20 = value; } }
  protected bool _event_field_20_GetName = false;
  public bool EventField_20_GetName { get { return _event_field_20_GetName; } set { _event_field_20_GetName = value; } }


  [SerializeField] protected bool _event_message200010 = false;
  public bool Event_Message200010
  {
    get { return _event_message200010; }
    set { _event_message200010 = value; }
  }

  [SerializeField] protected bool _event_message200020 = false;
  public bool Event_Message200020
  {
    get { return _event_message200020; }
    set { _event_message200020 = value; }
  }

  [SerializeField] protected bool _event_message200030 = false;
  public bool Event_Message200030
  {
    get { return _event_message200030; }
    set { _event_message200030 = value; }
  }

  [SerializeField] protected bool _event_message200040 = false;
  public bool Event_Message200040 { get { return _event_message200040; } set { _event_message200040 = value; } }

  [SerializeField] protected bool _event_message200050 = false;
  public bool Event_Message200050 { get { return _event_message200050; } set { _event_message200050 = value; } }

  [SerializeField] protected bool _event_message300010 = false;
  public bool Event_Message300010
  {
    get { return _event_message300010; }
    set { _event_message300010 = value; }
  }

  [SerializeField] protected bool _event_message300020 = false;
  public bool Event_Message300020
  {
    get { return _event_message300020; }
    set { _event_message300020 = value; }
  }

  [SerializeField] protected bool _event_message300021 = false;
  public bool Event_Message300021
  {
    get { return _event_message300021; }
    set { _event_message300021 = value; }
  }

  [SerializeField] protected bool _event_message300022 = false;
  public bool Event_Message300022
  {
    get { return _event_message300022; }
    set { _event_message300022 = value; }
  }

  [SerializeField] protected bool _event_message300023 = false;
  public bool Event_Message300023
  {
    get { return _event_message300023; }
    set { _event_message300023 = value; }
  }

  [SerializeField] protected bool _event_message300024 = false;
  public bool Event_Message300024
  {
    get { return _event_message300024; }
    set { _event_message300024 = value; }
  }

  [SerializeField] protected bool _event_message300030 = false;
  public bool Event_Message300030
  {
    get { return _event_message300030; }
    set { _event_message300030 = value; }
  }

  [SerializeField] protected bool _event_message300040 = false;
  public bool Event_Message300040
  {
    get { return _event_message300040; }
    set { _event_message300040 = value; }
  }
  [SerializeField] protected bool _event_message300050 = false;
  public bool Event_Message300050 { get { return _event_message300050; } set { _event_message300050 = value; } }
  [SerializeField] protected bool _event_message300070 = false;
  public bool Event_Message300070 { get { return _event_message300070; } set { _event_message300070 = value; } }
  [SerializeField] protected bool _event_message300090 = false;
  public bool Event_Message300090 { get { return _event_message300090; } set { _event_message300090 = value; } }
  [SerializeField] protected bool _event_message300100 = false;
  public bool Event_Message300100 { get { return _event_message300100; } set { _event_message300100 = value; } }
  [SerializeField] protected bool _event_message300110 = false;
  public bool Event_Message300110 { get { return _event_message300110; } set { _event_message300110 = value; } }
  [SerializeField] protected bool _event_message300111 = false;
  public bool Event_Message300111 { get { return _event_message300111; } set { _event_message300111 = value; } }
  [SerializeField] protected bool _event_message300120 = false;
  public bool Event_Message300120 { get { return _event_message300120; } set { _event_message300120 = value; } }
  [SerializeField] protected bool _event_message300121 = false;
  public bool Event_Message300121 { get { return _event_message300121; } set { _event_message300121 = value; } }
  [SerializeField] protected bool _event_message300140 = false;
  public bool Event_Message300140 { get { return _event_message300140; } set { _event_message300140 = value; } }
  [SerializeField] protected bool _event_message300141 = false;
  public bool Event_Message300141 { get { return _event_message300141; } set { _event_message300141 = value; } }
  [SerializeField] protected bool _event_message300170 = false;
  public bool Event_Message300170 { get { return _event_message300170; } set { _event_message300170 = value; } }


  [SerializeField] protected bool _event_message400010 = false;
  public bool Event_Message400010
  {
    get { return _event_message400010; }
    set { _event_message400010 = value; }
  }

  [SerializeField] protected bool _event_message400020 = false;
  public bool Event_Message400020
  {
    get { return _event_message400020; }
    set { _event_message400020 = value; }
  }

  protected bool _event_message400030 = false;
  public bool Event_Message400030 { get { return _event_message400030; } set { _event_message400030 = value; } }

  protected bool _event_message400040 = false;
  public bool Event_Message400040 { get { return _event_message400040; } set { _event_message400040 = value; } }

  protected bool _event_message400050 = false;
  public bool Event_Message400050 { get { return _event_message400050; } set { _event_message400050 = value; } }

  [SerializeField] protected bool _event_message500010 = false;
  public bool Event_Message500010
  {
    get { return _event_message500010; }
    set { _event_message500010 = value; }
  }

  [SerializeField] protected bool _event_message500020 = false;
  public bool Event_Message500020
  {
    get { return _event_message500020; }
    set { _event_message500020 = value; }
  }

  [SerializeField] protected bool _event_message500022 = false;
  public bool Event_Message500022
  {
    get { return _event_message500022; }
    set { _event_message500022 = value; }
  }

  [SerializeField] protected bool _event_message500024 = false;
  public bool Event_Message500024
  {
    get { return _event_message500024; }
    set { _event_message500024 = value; }
  }

  [SerializeField] protected bool _event_message500030 = false;
  public bool Event_Message500030
  {
    get { return _event_message500030; }
    set { _event_message500030 = value; }
  }

  [SerializeField] protected bool _event_message600001 = false;
  public bool Event_Message600001
  {
    get { return _event_message600001; }
    set { _event_message600001 = value; }
  }

  [SerializeField] protected bool _event_message600010 = false;
  public bool Event_Message600010
  {
    get { return _event_message600010; }
    set { _event_message600010 = value; }
  }

  [SerializeField] protected bool _event_message600020 = false;
  public bool Event_Message600020
  {
    get { return _event_message600020; }
    set { _event_message600020 = value; }
  }

  [SerializeField] protected bool _event_message600030 = false;
  public bool Event_Message600030
  {
    get { return _event_message600030; }
    set { _event_message600030 = value; }
  }

  [SerializeField] protected bool _event_message600040 = false;
  public bool Event_Message600040
  {
    get { return _event_message600040; }
    set { _event_message600040 = value; }
  }

  [SerializeField] protected bool _event_message600050 = false;
  public bool Event_Message600050
  {
    get { return _event_message600050; }
    set { _event_message600050 = value; }
  }

  [SerializeField] protected bool _event_message600060 = false;
  public bool Event_Message600060
  {
    get { return _event_message600060; }
    set { _event_message600060 = value; }
  }

  [SerializeField] protected bool _event_message600070 = false;
  public bool Event_Message600070
  {
    get { return _event_message600070; }
    set { _event_message600070 = value; }
  }

  [SerializeField] protected bool _event_message600080 = false;
  public bool Event_Message600080
  {
    get { return _event_message600080; }
    set { _event_message600080 = value; }
  }

  [SerializeField] protected bool _event_message600090 = false;
  public bool Event_Message600090
  {
    get { return _event_message600090; }
    set { _event_message600090 = value; }
  }

  [SerializeField] protected bool _event_message600100 = false;
  public bool Event_Message600100
  {
    get { return _event_message600100; }
    set { _event_message600100 = value; }
  }

  [SerializeField] protected bool _event_message600110 = false;
  public bool Event_Message600110
  {
    get { return _event_message600110; }
    set { _event_message600110 = value; }
  }

  [SerializeField] protected bool _event_message600120 = false;
  public bool Event_Message600120
  {
    get { return _event_message600120; }
    set { _event_message600120 = value; }
  }

  [SerializeField] protected bool _event_message600130 = false;
  public bool Event_Message600130
  {
    get { return _event_message600130; }
    set { _event_message600130 = value; }
  }

  [SerializeField] protected bool _event_message600140 = false;
  public bool Event_Message600140
  {
    get { return _event_message600140; }
    set { _event_message600140 = value; }
  }

  [SerializeField] protected bool _event_message600150 = false;
  public bool Event_Message600150
  {
    get { return _event_message600150; }
    set { _event_message600150 = value; }
  }

  [SerializeField] protected bool _event_message600160 = false;
  public bool Event_Message600160
  {
    get { return _event_message600160; }
    set { _event_message600160 = value; }
  }

  [SerializeField] protected bool _event_message600170 = false;
  public bool Event_Message600170
  {
    get { return _event_message600170; }
    set { _event_message600170 = value; }
  }

  [SerializeField] protected bool _event_message600180 = false;
  public bool Event_Message600180
  {
    get { return _event_message600180; }
    set { _event_message600180 = value; }
  }

  [SerializeField] protected bool _event_message600190 = false;
  public bool Event_Message600190
  {
    get { return _event_message600190; }
    set { _event_message600190 = value; }
  }

  [SerializeField] protected bool _event_message600200 = false;
  public bool Event_Message600200
  {
    get { return _event_message600200; }
    set { _event_message600200 = value; }
  }

  [SerializeField] protected bool _event_message700010 = false;
  public bool Event_Message700010
  {
    get { return _event_message700010; }
    set { _event_message700010 = value; }
  }
  [SerializeField] protected bool _event_message700020 = false;
  public bool Event_Message700020
  {
    get { return _event_message700020; }
    set { _event_message700020 = value; }
  }
  [SerializeField] protected bool _event_message700030 = false;
  public bool Event_Message700030
  {
    get { return _event_message700030; }
    set { _event_message700030 = value; }
  }

  [SerializeField] protected bool _event_message700040 = false;
  public bool Event_Message700040
  {
    get { return _event_message700040; }
    set { _event_message700040 = value; }
  }

  [SerializeField] protected bool _event_message700050 = false;
  public bool Event_Message700050
  {
    get { return _event_message700050; }
    set { _event_message700050 = value; }
  }
  [SerializeField] protected bool _event_message700060 = false;
  public bool Event_Message700060
  {
    get { return _event_message700060; }
    set { _event_message700060 = value; }
  }

  [SerializeField] protected bool _event_message800010 = false;
  [SerializeField] protected bool _event_message800020 = false;
  [SerializeField] protected bool _event_message800030 = false;
  [SerializeField] protected bool _event_message800040 = false;
  [SerializeField] protected bool _event_message800041 = false;
  [SerializeField] protected bool _event_message800042 = false;
  [SerializeField] protected bool _event_message800043 = false;
  [SerializeField] protected bool _event_message800044 = false;
  [SerializeField] protected bool _event_message800045 = false;
  [SerializeField] protected bool _event_message800046 = false;
  [SerializeField] protected bool _event_message800050 = false;
  [SerializeField] protected bool _event_message800051 = false;
  [SerializeField] protected bool _event_message800052 = false;
  [SerializeField] protected bool _event_message800060 = false;
  [SerializeField] protected bool _event_message800070 = false;
  [SerializeField] protected bool _event_message800080 = false;
  [SerializeField] protected bool _event_message800090 = false;
  [SerializeField] protected bool _event_message800100 = false;
  [SerializeField] protected bool _event_message800110 = false;
  [SerializeField] protected bool _event_message800120 = false;
  [SerializeField] protected bool _event_message800130 = false;
  [SerializeField] protected bool _event_message800140 = false;
  [SerializeField] protected bool _event_message800150 = false;
  [SerializeField] protected bool _event_message800160 = false;
  [SerializeField] protected bool _event_message800170 = false;
  [SerializeField] protected bool _event_message800180 = false;
  [SerializeField] protected bool _event_message800190 = false;
  [SerializeField] protected bool _event_message800200 = false;
  [SerializeField] protected bool _event_message800210 = false;
  [SerializeField] protected bool _event_message800220 = false;
  [SerializeField] protected bool _event_message800230 = false;
  [SerializeField] protected bool _event_message800240 = false;
  [SerializeField] protected bool _event_message800250 = false;
  [SerializeField] protected bool _event_message800260 = false;
  [SerializeField] protected bool _event_message801000 = false;
  [SerializeField] protected bool _event_message801010 = false;
  [SerializeField] protected bool _event_message801020 = false;
  [SerializeField] protected bool _event_message801030 = false;
  public bool Event_Message800010 { get { return _event_message800010; } set { _event_message800010 = value; } }
  public bool Event_Message800020 { get { return _event_message800020; } set { _event_message800020 = value; } }
  public bool Event_Message800030 { get { return _event_message800030; } set { _event_message800030 = value; } }
  public bool Event_Message800040 { get { return _event_message800040; } set { _event_message800040 = value; } }
  public bool Event_Message800041 { get { return _event_message800041; } set { _event_message800041 = value; } }
  public bool Event_Message800042 { get { return _event_message800042; } set { _event_message800042 = value; } }
  public bool Event_Message800043 { get { return _event_message800043; } set { _event_message800043 = value; } }
  public bool Event_Message800044 { get { return _event_message800044; } set { _event_message800044 = value; } }
  public bool Event_Message800045 { get { return _event_message800045; } set { _event_message800045 = value; } }
  public bool Event_Message800046 { get { return _event_message800046; } set { _event_message800046 = value; } }
  public bool Event_Message800050 { get { return _event_message800050; } set { _event_message800050 = value; } }
  public bool Event_Message800051 { get { return _event_message800051; } set { _event_message800051 = value; } }
  public bool Event_Message800052 { get { return _event_message800052; } set { _event_message800052 = value; } }
  public bool Event_Message800060 { get { return _event_message800060; } set { _event_message800060 = value; } }
  public bool Event_Message800070 { get { return _event_message800070; } set { _event_message800070 = value; } }
  public bool Event_Message800080 { get { return _event_message800080; } set { _event_message800080 = value; } } // 7層、クリア直前の会話
  public bool Event_Message800090 { get { return _event_message800090; } set { _event_message800090 = value; } } // 8層、移動中の通常会話
  public bool Event_Message800100 { get { return _event_message800100; } set { _event_message800100 = value; } } // ヨーディリアン撃破後の会話
  public bool Event_Message800110 { get { return _event_message800110; } set { _event_message800110 = value; } } // 最上階探索後の移動ブロック
  public bool Event_Message800120 { get { return _event_message800120; } set { _event_message800120 = value; } } // 浮遊石11の位置をリセットする時の会話
  public bool Event_Message800130 { get { return _event_message800130; } set { _event_message800130 = value; } } // 7層、条件不一致でタイル１が動かない時の会話
  public bool Event_Message800140 { get { return _event_message800140; } set { _event_message800140 = value; } } // 7層、条件不一致でタイル２が動かない時の会話
  public bool Event_Message800150 { get { return _event_message800150; } set { _event_message800150 = value; } } // 7層、条件不一致でタイル３が動かない時の会話
  public bool Event_Message800160 { get { return _event_message800160; } set { _event_message800160 = value; } } // ヨーディリアン戦闘前の会話
  public bool Event_Message800170 { get { return _event_message800170; } set { _event_message800170 = value; } } // 星屑の扉の前、強制会話
  public bool Event_Message800180 { get { return _event_message800180; } set { _event_message800180 = value; } } // 最上階到達時の会話
  public bool Event_Message800190 { get { return _event_message800190; } set { _event_message800190 = value; } } // 星屑の鍵で扉を開錠
  public bool Event_Message800200 { get { return _event_message800200; } set { _event_message800200 = value; } } // 原初の扉の前で会話（鍵無し）
  public bool Event_Message800210 { get { return _event_message800210; } set { _event_message800210 = value; } } // 原初の鍵で扉を開錠）
  public bool Event_Message800220 { get { return _event_message800220; } set { _event_message800220 = value; } } // オーランの塔、原初の鍵を入手後の帰還で会話
  public bool Event_Message800230 { get { return _event_message800230; } set { _event_message800230 = value; } } // 帰還後、再びオーランの塔を選択した時の会話
  public bool Event_Message800240 { get { return _event_message800240; } set { _event_message800240 = value; } } // 制覇後、オーランの塔の入口における会話
  public bool Event_Message800250 { get { return _event_message800250; } set { _event_message800250 = value; } } // 制覇後、オーランの塔の最下層中枢部へ降りる時の会話
  public bool Event_Message800260 { get { return _event_message800260; } set { _event_message800260 = value; } } // 制覇後、オーランの塔の最下層中枢部へ降りた後の会話
  public bool Event_Message801000 { get { return _event_message801000; } set { _event_message801000 = value; } } // オーランの塔、ObsidianStoneと接触時の会話
  public bool Event_Message801010 { get { return _event_message801010; } set { _event_message801010 = value; } } // オーランの塔、ObsidianStoneと接触後のファージル宮殿での会話
  public bool Event_Message801020 { get { return _event_message801020; } set { _event_message801020 = value; } } // オーランの塔制覇後、ファージル宮殿へ誘導する会話
  public bool Event_Message801030 { get { return _event_message801030; } set { _event_message801030 = value; } } // ファージル宮殿から、パルメテイシア神殿へ向かう際の会話


  [SerializeField] protected bool _event_message900010 = false;
  public bool Event_Message900010
  {
    get { return _event_message900010; }
    set { _event_message900010 = value; }
  }
  [SerializeField] protected bool _event_message900020 = false;
  public bool Event_Message900020
  {
    get { return _event_message900020; }
    set { _event_message900020 = value; }
  }
  [SerializeField] protected bool _event_message900030 = false;
  public bool Event_Message900030
  {
    get { return _event_message900030; }
    set { _event_message900030 = value; }
  }

  [SerializeField] protected bool _event_message900040 = false;
  public bool Event_Message900040
  {
    get { return _event_message900040; }
    set { _event_message900040 = value; }
  }
  [SerializeField] protected bool _event_message900041 = false;
  public bool Event_Message900041
  {
    get { return _event_message900041; }
    set { _event_message900041 = value; }
  }

  [SerializeField] protected bool _event_message900050 = false;
  public bool Event_Message900050
  {
    get { return _event_message900050; }
    set { _event_message900050 = value; }
  }

  [SerializeField] protected bool _event_message900051 = false;
  public bool Event_Message900051
  {
    get { return _event_message900051; }
    set { _event_message900051 = value; }
  }

  [SerializeField] protected bool _event_message900055 = false;
  public bool Event_Message900055
  {
    get { return _event_message900055; }
    set { _event_message900055 = value; }
  }

  [SerializeField] protected bool _event_message900056 = false;
  public bool Event_Message900056
  {
    get { return _event_message900056; }
    set { _event_message900056 = value; }
  }

  [SerializeField] protected bool _event_message900060 = false;
  public bool Event_Message900060
  {
    get { return _event_message900060; }
    set { _event_message900060 = value; }
  }

  [SerializeField] protected bool _event_message900070 = false;
  public bool Event_Message900070
  {
    get { return _event_message900070; }
    set { _event_message900070 = value; }
  }

  [SerializeField] protected bool _event_message900075 = false;
  public bool Event_Message900075
  {
    get { return _event_message900075; }
    set { _event_message900075 = value; }
  }

  [SerializeField] protected bool _event_message900080 = false;
  public bool Event_Message900080
  {
    get { return _event_message900080; }
    set { _event_message900080 = value; }
  }

  [SerializeField] protected bool _event_message900090 = false;
  public bool Event_Message900090
  {
    get { return _event_message900090; }
    set { _event_message900090 = value; }
  }

  [SerializeField] protected bool _event_message900100 = false;
  public bool Event_Message900100
  {
    get { return _event_message900100; }
    set { _event_message900100 = value; }
  }

  [SerializeField] protected bool _event_message900110 = false;
  public bool Event_Message900110
  {
    get { return _event_message900110; }
    set { _event_message900110 = value; }
  }

  [SerializeField] protected bool _event_message900120 = false;
  public bool Event_Message900120
  {
    get { return _event_message900120; }
    set { _event_message900120 = value; }
  }

  // ヴェルガスの海底神殿
  [SerializeField] protected bool _event_message1000000 = false;
  public bool Event_Message1000000 { get { return _event_message1000000; } set { _event_message1000000 = value; } }
  [SerializeField] protected bool _event_message1000010 = false;
  public bool Event_Message1000010 { get { return _event_message1000010; } set { _event_message1000010 = value; } }
  [SerializeField] protected bool _event_message1000011 = false;
  public bool Event_Message1000011 { get { return _event_message1000011; } set { _event_message1000011 = value; } }
  [SerializeField] protected bool _event_message1000012 = false;
  public bool Event_Message1000012 { get { return _event_message1000012; } set { _event_message1000012 = value; } }
  [SerializeField] protected bool _event_message1000013 = false;
  public bool Event_Message1000013 { get { return _event_message1000013; } set { _event_message1000013 = value; } }
  [SerializeField] protected bool _event_message1000014 = false;
  public bool Event_Message1000014 { get { return _event_message1000014; } set { _event_message1000014 = value; } }
  [SerializeField] protected bool _event_message1000010_fail = false;
  public bool Event_Message1000010_Fail { get { return _event_message1000010_fail; } set { _event_message1000010_fail = value; } }
  [SerializeField] protected bool _event_message1000010_movewall = false;
  public bool Event_Message1000010_MoveWall { get { return _event_message1000010_movewall; } set { _event_message1000010_movewall = value; } }
  [SerializeField] protected bool _event_message1000010_complete = false;
  public bool Event_Message1000010_Complete { get { return _event_message1000010_complete; } set { _event_message1000010_complete = value; } }
  [SerializeField] protected bool _event_message1000010_nomessageboard = false;
  public bool Event_Message1000010_NoMessageBoard { get { return _event_message1000010_nomessageboard; } set { _event_message1000010_nomessageboard = value; } }
  [SerializeField] protected bool _event_message1000010_failedmessage1 = false;
  public bool Event_Message1000010_FailedMessage1 { get { return _event_message1000010_failedmessage1; } set { _event_message1000010_failedmessage1 = value; } }
  [SerializeField] protected bool _event_message1000010_failedmessage2 = false;
  public bool Event_Message1000010_FailedMessage2 { get { return _event_message1000010_failedmessage2; } set { _event_message1000010_failedmessage2 = value; } }
  [SerializeField] protected bool _event_message1000010_progress1 = false;
  public bool Event_Message1000010_Progress1 { get { return _event_message1000010_progress1; } set { _event_message1000010_progress1 = value; } }
  [SerializeField] protected bool _event_message1000010_progress2 = false;
  public bool Event_Message1000010_Progress2 { get { return _event_message1000010_progress2; } set { _event_message1000010_progress2 = value; } }

  [SerializeField] protected bool _event_message1000020 = false;
  public bool Event_Message1000020 { get { return _event_message1000020; } set { _event_message1000020 = value; } }
  [SerializeField] protected bool _event_message1000021 = false;
  public bool Event_Message1000021 { get { return _event_message1000021; } set { _event_message1000021 = value; } }
  [SerializeField] protected bool _event_message1000022 = false;
  public bool Event_Message1000022 { get { return _event_message1000022; } set { _event_message1000022 = value; } }
  [SerializeField] protected bool _event_message1000023 = false;
  public bool Event_Message1000023 { get { return _event_message1000023; } set { _event_message1000023 = value; } }
  [SerializeField] protected bool _event_message1000024 = false;
  public bool Event_Message1000024 { get { return _event_message1000024; } set { _event_message1000024 = value; } }

  [SerializeField] protected int _velgus_center_number1 = -1;
  public int Velgus_Center_Number1 { get { return _velgus_center_number1; } set { _velgus_center_number1 = value; } }
  [SerializeField] protected int _velgus_center_number2 = -1;
  public int Velgus_Center_Number2 { get { return _velgus_center_number2; } set { _velgus_center_number2 = value; } }
  [SerializeField] protected int _velgus_center_number3 = -1;
  public int Velgus_Center_Number3 { get { return _velgus_center_number3; } set { _velgus_center_number3 = value; } }
  [SerializeField] protected int _velgus_center_number4 = -1;
  public int Velgus_Center_Number4 { get { return _velgus_center_number4; } set { _velgus_center_number4 = value; } }

  [SerializeField] protected bool _event_message1000020_fail = false;
  public bool Event_Message1000020_Fail { get { return _event_message1000020_fail; } set { _event_message1000020_fail = value; } }

  [SerializeField] protected bool _event_message1000020_failedmessage1 = false;
  public bool Event_Message1000020_FailedMessage1 { get { return _event_message1000020_failedmessage1; } set { _event_message1000020_failedmessage1 = value; } }
  [SerializeField] protected bool _event_message1000020_progress1 = false;
  public bool Event_Message1000020_Progress1 { get { return _event_message1000020_progress1; } set { _event_message1000020_progress1 = value; } }
  [SerializeField] protected bool _event_message1000020_progress2 = false;
  public bool Event_Message1000020_Progress2 { get { return _event_message1000020_progress2; } set { _event_message1000020_progress2 = value; } }
  [SerializeField] protected bool _event_message1000020_progress3 = false;
  public bool Event_Message1000020_Progress3 { get { return _event_message1000020_progress3; } set { _event_message1000020_progress3 = value; } }

  [SerializeField] protected bool _event_message1000020_complete = false;
  public bool Event_Message1000020_Complete { get { return _event_message1000020_complete; } set { _event_message1000020_complete = value; } }
  [SerializeField] protected bool _event_message1000020_2_complete = false;
  public bool Event_Message1000020_2_Complete { get { return _event_message1000020_2_complete; } set { _event_message1000020_2_complete = value; } }
  [SerializeField] protected bool _event_message1000020_3_complete = false;
  public bool Event_Message1000020_3_Complete { get { return _event_message1000020_3_complete; } set { _event_message1000020_3_complete = value; } }

  [SerializeField] protected bool _event_message1000040 = false;
  public bool Event_Message1000040 { get { return _event_message1000040; } set { _event_message1000040 = value; } }
  [SerializeField] protected bool _event_message1000041 = false;
  public bool Event_Message1000041 { get { return _event_message1000041; } set { _event_message1000041 = value; } }
  [SerializeField] protected bool _event_message1000042= false;
  public bool Event_Message1000042 { get { return _event_message1000042; } set { _event_message1000042 = value; } }
  [SerializeField] protected bool _event_message1000043 = false;
  public bool Event_Message1000043 { get { return _event_message1000043; } set { _event_message1000043 = value; } }
  [SerializeField] protected bool _event_message1000044 = false;
  public bool Event_Message1000044 { get { return _event_message1000044; } set { _event_message1000044 = value; } }
  [SerializeField] protected bool _event_message1000045 = false;
  public bool Event_Message1000045 { get { return _event_message1000045; } set { _event_message1000045 = value; } }
  [SerializeField] protected bool _event_message1000046 = false;
  public bool Event_Message1000046 { get { return _event_message1000046; } set { _event_message1000046 = value; } }
  [SerializeField] protected bool _event_message1000047 = false;
  public bool Event_Message1000047 { get { return _event_message1000047; } set { _event_message1000047 = value; } }
  [SerializeField] protected bool _event_message1000048 = false;
  public bool Event_Message1000048 { get { return _event_message1000048; } set { _event_message1000048 = value; } }
  [SerializeField] protected bool _event_message1000049 = false;
  public bool Event_Message1000049 { get { return _event_message1000049; } set { _event_message1000049 = value; } }
  [SerializeField] protected bool _event_message1000050 = false;
  public bool Event_Message1000050 { get { return _event_message1000050; } set { _event_message1000050 = value; } }
  [SerializeField] protected bool _event_message1000051 = false;
  public bool Event_Message1000051 { get { return _event_message1000051; } set { _event_message1000051 = value; } }
  [SerializeField] protected bool _event_message1000052 = false;
  public bool Event_Message1000052 { get { return _event_message1000052; } set { _event_message1000052 = value; } }
  [SerializeField] protected bool _event_message1000053 = false;
  public bool Event_Message1000053 { get { return _event_message1000053; } set { _event_message1000053 = value; } }
  [SerializeField] protected bool _event_message1000054 = false;
  public bool Event_Message1000054 { get { return _event_message1000054; } set { _event_message1000054 = value; } }
  [SerializeField] protected bool _event_message1000055 = false;
  public bool Event_Message1000055 { get { return _event_message1000055; } set { _event_message1000055 = value; } }
  [SerializeField] protected bool _event_message1000056 = false;
  public bool Event_Message1000056 { get { return _event_message1000056; } set { _event_message1000056 = value; } }
  [SerializeField] protected bool _event_message1000057 = false;
  public bool Event_Message1000057 { get { return _event_message1000057; } set { _event_message1000057 = value; } }
  [SerializeField] protected bool _event_message1000058 = false;
  public bool Event_Message1000058 { get { return _event_message1000058; } set { _event_message1000058 = value; } }
  [SerializeField] protected bool _event_message1000059 = false;
  public bool Event_Message1000059 { get { return _event_message1000059; } set { _event_message1000059 = value; } }
  [SerializeField] protected bool _event_message1000060 = false;
  public bool Event_Message1000060 { get { return _event_message1000060; } set { _event_message1000060 = value; } } // １６の節を発見した時のイベント
  [SerializeField] protected bool _event_message1000061 = false;
  public bool Event_Message1000061 { get { return _event_message1000061; } set { _event_message1000061 = value; } }
  [SerializeField] protected bool _event_message1000062 = false;
  public bool Event_Message1000062 { get { return _event_message1000062; } set { _event_message1000062 = value; } }
  [SerializeField] protected bool _event_message1000063 = false;
  public bool Event_Message1000063 { get { return _event_message1000063; } set { _event_message1000063 = value; } }
  [SerializeField] protected bool _event_message1000064 = false;
  public bool Event_Message1000064 { get { return _event_message1000064; } set { _event_message1000064 = value; } }
  [SerializeField] protected bool _event_message1000065 = false;
  public bool Event_Message1000065 { get { return _event_message1000065; } set { _event_message1000065 = value; } }
  [SerializeField] protected bool _event_message1000066 = false;
  public bool Event_Message1000066 { get { return _event_message1000066; } set { _event_message1000066 = value; } }
  [SerializeField] protected bool _event_message1000067 = false;
  public bool Event_Message1000067 { get { return _event_message1000067; } set { _event_message1000067 = value; } }
  [SerializeField] protected bool _event_message1000068 = false;
  public bool Event_Message1000068 { get { return _event_message1000068; } set { _event_message1000068 = value; } }
  [SerializeField] protected bool _event_message1000069 = false;
  public bool Event_Message1000069 { get { return _event_message1000069; } set { _event_message1000069 = value; } }
  [SerializeField] protected bool _event_message1000070 = false;
  public bool Event_Message1000070 { get { return _event_message1000070; } set { _event_message1000070 = value; } }
  [SerializeField] protected bool _event_message1000071 = false;
  public bool Event_Message1000071 { get { return _event_message1000071; } set { _event_message1000071 = value; } }
  [SerializeField] protected bool _event_message1000072 = false;
  public bool Event_Message1000072 { get { return _event_message1000072; } set { _event_message1000072 = value; } }
  [SerializeField] protected bool _event_message1000073 = false;
  public bool Event_Message1000073 { get { return _event_message1000073; } set { _event_message1000073 = value; } }
  [SerializeField] protected bool _event_message1000074 = false;
  public bool Event_Message1000074 { get { return _event_message1000074; } set { _event_message1000074 = value; } }
  [SerializeField] protected bool _event_message1000075 = false;
  public bool Event_Message1000075 { get { return _event_message1000075; } set { _event_message1000075 = value; } }
  [SerializeField] protected bool _event_message1000076 = false;
  public bool Event_Message1000076 { get { return _event_message1000076; } set { _event_message1000076 = value; } }
  [SerializeField] protected bool _event_message1000077 = false;
  public bool Event_Message1000077 { get { return _event_message1000077; } set { _event_message1000077 = value; } }
  [SerializeField] protected bool _event_message1000078 = false;
  public bool Event_Message1000078 { get { return _event_message1000078; } set { _event_message1000078 = value; } }
  [SerializeField] protected bool _event_message1000079 = false;
  public bool Event_Message1000079 { get { return _event_message1000079; } set { _event_message1000079 = value; } }

  [SerializeField] protected bool _event_message1000040_complete = false;
  public bool Event_Message1000040_Complete { get { return _event_message1000040_complete; } set { _event_message1000040_complete = value; } }
  [SerializeField] protected bool _event_message1000040_complete_1 = false;
  public bool Event_Message1000040_Complete_1 { get { return _event_message1000040_complete_1; } set { _event_message1000040_complete_1 = value; } }
  [SerializeField] protected bool _event_message1000040_complete_2 = false;
  public bool Event_Message1000040_Complete_2 { get { return _event_message1000040_complete_2; } set { _event_message1000040_complete_2 = value; } }
  [SerializeField] protected bool _event_message1000040_complete_3 = false;
  public bool Event_Message1000040_Complete_3 { get { return _event_message1000040_complete_3; } set { _event_message1000040_complete_3 = value; } }
  [SerializeField] protected bool _event_message1000040_complete_4 = false;
  public bool Event_Message1000040_Complete_4 { get { return _event_message1000040_complete_4; } set { _event_message1000040_complete_4 = value; } }

  [SerializeField] protected bool _event_message1000040_progress_1 = false;
  public bool Event_Message1000040_Progress_1 { get { return _event_message1000040_progress_1; } set { _event_message1000040_progress_1 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_1 = false;
  public bool Event_Message1000040_Reading_1 { get { return _event_message1000040_reading_1; } set { _event_message1000040_reading_1 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_2 = false;
  public bool Event_Message1000040_Reading_2 { get { return _event_message1000040_reading_2; } set { _event_message1000040_reading_2 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_3 = false;
  public bool Event_Message1000040_Reading_3 { get { return _event_message1000040_reading_3; } set { _event_message1000040_reading_3 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_4 = false;
  public bool Event_Message1000040_Reading_4 { get { return _event_message1000040_reading_4; } set { _event_message1000040_reading_4 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_5 = false;
  public bool Event_Message1000040_Reading_5 { get { return _event_message1000040_reading_5; } set { _event_message1000040_reading_5 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_6 = false;
  public bool Event_Message1000040_Reading_6 { get { return _event_message1000040_reading_6; } set { _event_message1000040_reading_6 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_7 = false;
  public bool Event_Message1000040_Reading_7 { get { return _event_message1000040_reading_7; } set { _event_message1000040_reading_7 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_8 = false;
  public bool Event_Message1000040_Reading_8 { get { return _event_message1000040_reading_8; } set { _event_message1000040_reading_8 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_9 = false;
  public bool Event_Message1000040_Reading_9 { get { return _event_message1000040_reading_9; } set { _event_message1000040_reading_9 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_10 = false;
  public bool Event_Message1000040_Reading_10 { get { return _event_message1000040_reading_10; } set { _event_message1000040_reading_10 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_11 = false;
  public bool Event_Message1000040_Reading_11 { get { return _event_message1000040_reading_11; } set { _event_message1000040_reading_11 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_12 = false;
  public bool Event_Message1000040_Reading_12 { get { return _event_message1000040_reading_12; } set { _event_message1000040_reading_12 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_13 = false;
  public bool Event_Message1000040_Reading_13 { get { return _event_message1000040_reading_13; } set { _event_message1000040_reading_13 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_14 = false;
  public bool Event_Message1000040_Reading_14 { get { return _event_message1000040_reading_14; } set { _event_message1000040_reading_14 = value; } }
  [SerializeField] protected bool _event_message1000040_reading_15 = false;
  public bool Event_Message1000040_Reading_15 { get { return _event_message1000040_reading_15; } set { _event_message1000040_reading_15 = value; } }

  [SerializeField] protected bool _event_message1000040_complete_5 = false;
  public bool Event_Message1000040_Complete_5 { get { return _event_message1000040_complete_5; } set { _event_message1000040_complete_5 = value; } }
  [SerializeField] protected bool _event_message1000040_complete_6 = false;
  public bool Event_Message1000040_Complete_6 { get { return _event_message1000040_complete_6; } set { _event_message1000040_complete_6 = value; } }
  [SerializeField] protected bool _event_message1000040_complete_7 = false;
  public bool Event_Message1000040_Complete_7 { get { return _event_message1000040_complete_7; } set { _event_message1000040_complete_7 = value; } }

  // 球体に取り込まれた際の神々の詠唱に成功
  [SerializeField] protected bool _event_message1000040_velgus_chant_success = false;
  public bool Event_Message1000040_VelgusChantSuccess { get { return _event_message1000040_velgus_chant_success; } set { _event_message1000040_velgus_chant_success = value; } }

  // １６の節を見つける前の隠し扉開錠イベント
  [SerializeField] protected bool _event_message1000040_complete_8 = false;
  public bool Event_Message1000040_Complete_8 { get { return _event_message1000040_complete_8; } set { _event_message1000040_complete_8 = value; } }

  [SerializeField] protected bool _event_message1000100 = false;
  public bool Event_Message1000100 { get { return _event_message1000100; } set { _event_message1000100 = value; } }
  [SerializeField] protected bool _event_message1000101 = false;
  public bool Event_Message1000101 { get { return _event_message1000101; } set { _event_message1000101 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_1 = false;
  public bool Event_Message1000100_Number_1 { get { return _event_message1000100_Number_1; } set { _event_message1000100_Number_1 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_1_1 = false;
  public bool Event_Message1000100_Number_1_1 { get { return _event_message1000100_Number_1_1; } set { _event_message1000100_Number_1_1 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_1_2 = false;
  public bool Event_Message1000100_Number_1_2 { get { return _event_message1000100_Number_1_2; } set { _event_message1000100_Number_1_2 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_1_3 = false;
  public bool Event_Message1000100_Number_1_3 { get { return _event_message1000100_Number_1_3; } set { _event_message1000100_Number_1_3 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_2 = false;
  public bool Event_Message1000100_Number_2 { get { return _event_message1000100_Number_2; } set { _event_message1000100_Number_2 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_2_1 = false;
  public bool Event_Message1000100_Number_2_1 { get { return _event_message1000100_Number_2_1; } set { _event_message1000100_Number_2_1 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_3 = false;
  public bool Event_Message1000100_Number_3 { get { return _event_message1000100_Number_3; } set { _event_message1000100_Number_3 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_3_1 = false;
  public bool Event_Message1000100_Number_3_1 { get { return _event_message1000100_Number_3_1; } set { _event_message1000100_Number_3_1 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_3_2 = false;
  public bool Event_Message1000100_Number_3_2 { get { return _event_message1000100_Number_3_2; } set { _event_message1000100_Number_3_2 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_3_3 = false;
  public bool Event_Message1000100_Number_3_3 { get { return _event_message1000100_Number_3_3; } set { _event_message1000100_Number_3_3 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_4 = false;
  public bool Event_Message1000100_Number_4 { get { return _event_message1000100_Number_4; } set { _event_message1000100_Number_4 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_4_1 = false;
  public bool Event_Message1000100_Number_4_1 { get { return _event_message1000100_Number_4_1; } set { _event_message1000100_Number_4_1 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_5 = false;
  public bool Event_Message1000100_Number_5 { get { return _event_message1000100_Number_5; } set { _event_message1000100_Number_5 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_5_1 = false;
  public bool Event_Message1000100_Number_5_1 { get { return _event_message1000100_Number_5_1; } set { _event_message1000100_Number_5_1 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_5_2 = false;
  public bool Event_Message1000100_Number_5_2 { get { return _event_message1000100_Number_5_2; } set { _event_message1000100_Number_5_2 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_6 = false;
  public bool Event_Message1000100_Number_6 { get { return _event_message1000100_Number_6; } set { _event_message1000100_Number_6 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_6_1 = false;
  public bool Event_Message1000100_Number_6_1 { get { return _event_message1000100_Number_6_1; } set { _event_message1000100_Number_6_1 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_6_2 = false;
  public bool Event_Message1000100_Number_6_2 { get { return _event_message1000100_Number_6_2; } set { _event_message1000100_Number_6_2 = value; } }
  [SerializeField] protected bool _event_message1000100_Number_7 = false;
  public bool Event_Message1000100_Number_7 { get { return _event_message1000100_Number_7; } set { _event_message1000100_Number_7 = value; } }
  [SerializeField] protected bool _event_message1000100_failed = false;
  public bool Event_Message1000100_Failed { get { return _event_message1000100_failed; } set { _event_message1000100_failed = value; } }
  [SerializeField] protected bool _event_message1000100_success = false;
  public bool Event_Message1000100_Success { get { return _event_message1000100_success; } set { _event_message1000100_success = value; } }

  [SerializeField] protected bool _event_message1000110 = false;
  public bool Event_Message1000110 { get { return _event_message1000110; } set { _event_message1000110 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_0_1 = false;
  public bool Event_Message1000110_Number_0_1 { get { return _event_message1000110_Number_0_1; } set { _event_message1000110_Number_0_1 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_0_2 = false;
  public bool Event_Message1000110_Number_0_2 { get { return _event_message1000110_Number_0_2; } set { _event_message1000110_Number_0_2 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_0_3 = false;
  public bool Event_Message1000110_Number_0_3 { get { return _event_message1000110_Number_0_3; } set { _event_message1000110_Number_0_3 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_0_4 = false;
  public bool Event_Message1000110_Number_0_4 { get { return _event_message1000110_Number_0_4; } set { _event_message1000110_Number_0_4 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_0_5 = false;
  public bool Event_Message1000110_Number_0_5 { get { return _event_message1000110_Number_0_5; } set { _event_message1000110_Number_0_5 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_0_6 = false;
  public bool Event_Message1000110_Number_0_6 { get { return _event_message1000110_Number_0_6; } set { _event_message1000110_Number_0_6 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1 = false;
  public bool Event_Message1000110_Number_1 { get { return _event_message1000110_Number_1; } set { _event_message1000110_Number_1 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_0 = false;
  public bool Event_Message1000110_Number_1_0 { get { return _event_message1000110_Number_1_0; } set { _event_message1000110_Number_1_0 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_1 = false;
  public bool Event_Message1000110_Number_1_1 { get { return _event_message1000110_Number_1_1; } set { _event_message1000110_Number_1_1 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_2 = false;
  public bool Event_Message1000110_Number_1_2 { get { return _event_message1000110_Number_1_2; } set { _event_message1000110_Number_1_2 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_3 = false;
  public bool Event_Message1000110_Number_1_3 { get { return _event_message1000110_Number_1_3; } set { _event_message1000110_Number_1_3 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_4 = false;
  public bool Event_Message1000110_Number_1_4 { get { return _event_message1000110_Number_1_4; } set { _event_message1000110_Number_1_4 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_5 = false;
  public bool Event_Message1000110_Number_1_5 { get { return _event_message1000110_Number_1_5; } set { _event_message1000110_Number_1_5 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_6 = false;
  public bool Event_Message1000110_Number_1_6 { get { return _event_message1000110_Number_1_6; } set { _event_message1000110_Number_1_6 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_7 = false;
  public bool Event_Message1000110_Number_1_7 { get { return _event_message1000110_Number_1_7; } set { _event_message1000110_Number_1_7 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_8 = false;
  public bool Event_Message1000110_Number_1_8 { get { return _event_message1000110_Number_1_8; } set { _event_message1000110_Number_1_8 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_1_9 = false;
  public bool Event_Message1000110_Number_1_9 { get { return _event_message1000110_Number_1_9; } set { _event_message1000110_Number_1_9 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_2 = false;
  public bool Event_Message1000110_Number_2 { get { return _event_message1000110_Number_2; } set { _event_message1000110_Number_2 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_2_1 = false;
  public bool Event_Message1000110_Number_2_1 { get { return _event_message1000110_Number_2_1; } set { _event_message1000110_Number_2_1 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_2_2 = false;
  public bool Event_Message1000110_Number_2_2 { get { return _event_message1000110_Number_2_2; } set { _event_message1000110_Number_2_2 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_3 = false;
  public bool Event_Message1000110_Number_3 { get { return _event_message1000110_Number_3; } set { _event_message1000110_Number_3 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_3_1 = false;
  public bool Event_Message1000110_Number_3_1 { get { return _event_message1000110_Number_3_1; } set { _event_message1000110_Number_3_1 = value; } }
  [SerializeField] protected bool _event_message1000110_Number_3_2 = false;
  public bool Event_Message1000110_Number_3_2 { get { return _event_message1000110_Number_3_2; } set { _event_message1000110_Number_3_2 = value; } }
  [SerializeField] protected bool _event_message1000110_failed = false;
  public bool Event_Message1000110_Failed { get { return _event_message1000110_failed; } set { _event_message1000110_failed = value; } }
  [SerializeField] protected bool _event_message1000110_success = false;
  public bool Event_Message1000110_Success { get { return _event_message1000110_success; } set { _event_message1000110_success = value; } }

  [SerializeField] protected bool _event_message1000120 = false;
  public bool Event_Message1000120 { get { return _event_message1000120; } set { _event_message1000120 = value; } }
  [SerializeField] protected bool _event_message1000120_Number_0_1 = false;
  public bool Event_Message1000120_Number_0_1 { get { return _event_message1000120_Number_0_1; } set { _event_message1000120_Number_0_1 = value; } }
  [SerializeField] protected bool _event_message1000120_Number_0_2 = false;
  public bool Event_Message1000120_Number_0_2 { get { return _event_message1000120_Number_0_2; } set { _event_message1000120_Number_0_2 = value; } }
  [SerializeField] protected bool _event_message1000120_Number_0_3 = false;
  public bool Event_Message1000120_Number_0_3 { get { return _event_message1000120_Number_0_3; } set { _event_message1000120_Number_0_3 = value; } }
  [SerializeField] protected bool _event_message1000120_Number_0_4 = false;
  public bool Event_Message1000120_Number_0_4 { get { return _event_message1000120_Number_0_4; } set { _event_message1000120_Number_0_4 = value; } }
  [SerializeField] protected bool _event_message1000120_Number_0_5 = false;
  public bool Event_Message1000120_Number_0_5 { get { return _event_message1000120_Number_0_5; } set { _event_message1000120_Number_0_5 = value; } }
  [SerializeField] protected bool _event_message1000120_Number_0_6 = false;
  public bool Event_Message1000120_Number_0_6 { get { return _event_message1000120_Number_0_6; } set { _event_message1000120_Number_0_6 = value; } }
  [SerializeField] protected bool _event_message1000120_Number_0_7 = false;
  public bool Event_Message1000120_Number_0_7 { get { return _event_message1000120_Number_0_7; } set { _event_message1000120_Number_0_7 = value; } }
  [SerializeField] protected bool _event_message1000120_failed = false;
  public bool Event_Message1000120_Failed { get { return _event_message1000120_failed; } set { _event_message1000120_failed = value; } }
  [SerializeField] protected bool _event_message1000120_success = false;
  public bool Event_Message1000120_Success { get { return _event_message1000120_success; } set { _event_message1000120_success = value; } }

  [SerializeField] protected bool _event_message1000130 = false;
  public bool Event_Message1000130 { get { return _event_message1000130; } set { _event_message1000130 = value; } }
  [SerializeField] protected bool _event_message1000131 = false;
  public bool Event_Message1000131 { get { return _event_message1000131; } set { _event_message1000131 = value; } }
  [SerializeField] protected bool _event_message1000132 = false;
  public bool Event_Message1000132 { get { return _event_message1000132; } set { _event_message1000132 = value; } }
  [SerializeField] protected bool _event_message1000133 = false;
  public bool Event_Message1000133 { get { return _event_message1000133; } set { _event_message1000133 = value; } }
  [SerializeField] protected bool _event_message1000134 = false;
  public bool Event_Message1000134 { get { return _event_message1000134; } set { _event_message1000134 = value; } }
  [SerializeField] protected bool _event_message1000135 = false;
  public bool Event_Message1000135 { get { return _event_message1000135; } set { _event_message1000135 = value; } }
  [SerializeField] protected bool _event_message1000136 = false;
  public bool Event_Message1000136 { get { return _event_message1000136; } set { _event_message1000136 = value; } }
  [SerializeField] protected bool _event_message1000137 = false;
  public bool Event_Message1000137 { get { return _event_message1000137; } set { _event_message1000137 = value; } }
  [SerializeField] protected bool _event_message1000138 = false;
  public bool Event_Message1000138 { get { return _event_message1000138; } set { _event_message1000138 = value; } }
  [SerializeField] protected bool _event_message1000139 = false;
  public bool Event_Message1000139 { get { return _event_message1000139; } set { _event_message1000139 = value; } }
  [SerializeField] protected bool _event_message1000140 = false;
  public bool Event_Message1000140 { get { return _event_message1000140; } set { _event_message1000140 = value; } }
  [SerializeField] protected bool _event_message1000141 = false;
  public bool Event_Message1000141 { get { return _event_message1000141; } set { _event_message1000141 = value; } }
  [SerializeField] protected bool _event_message1000142 = false;
  public bool Event_Message1000142 { get { return _event_message1000142; } set { _event_message1000142 = value; } }

  [SerializeField] protected bool _event_message1000130_progress_1 = false;
  public bool Event_Message1000130_Progress_1 { get { return _event_message1000130_progress_1; } set { _event_message1000130_progress_1 = value; } }
  [SerializeField] protected bool _event_message1000130_success = false;
  public bool Event_Message1000130_Success { get { return _event_message1000130_success; } set { _event_message1000130_success = value; } }
  [SerializeField] protected bool _event_message1000130_success_2 = false;
  public bool Event_Message1000130_Success_2 { get { return _event_message1000130_success_2; } set { _event_message1000130_success_2 = value; } }
  [SerializeField] protected bool _event_message1000130_success_3 = false;
  public bool Event_Message1000130_Success_3 { get { return _event_message1000130_success_3; } set { _event_message1000130_success_3 = value; } }

  [SerializeField] protected bool _event_message1000183 = false;
  public bool Event_Message1000183 { get { return _event_message1000183; } set { _event_message1000183 = value; } }

  [SerializeField] protected bool _event_message1000200 = false;
  public bool Event_Message1000200 { get { return _event_message1000200; } set { _event_message1000200 = value; } }
  [SerializeField] protected bool _event_message1000201 = false;
  public bool Event_Message1000201 { get { return _event_message1000201; } set { _event_message1000201 = value; } }
  [SerializeField] protected bool _event_message1000202 = false;
  public bool Event_Message1000202 { get { return _event_message1000202; } set { _event_message1000202 = value; } }
  [SerializeField] protected bool _event_message1000203 = false;
  public bool Event_Message1000203 { get { return _event_message1000203; } set { _event_message1000203 = value; } }
  [SerializeField] protected bool _event_message1000204 = false;
  public bool Event_Message1000204 { get { return _event_message1000204; } set { _event_message1000204 = value; } }
  [SerializeField] protected bool _event_message1000205 = false;
  public bool Event_Message1000205 { get { return _event_message1000205; } set { _event_message1000205 = value; } }
  [SerializeField] protected bool _event_message1000206 = false;
  public bool Event_Message1000206 { get { return _event_message1000206; } set { _event_message1000206 = value; } }
  [SerializeField] protected bool _event_message1000207 = false;
  public bool Event_Message1000207 { get { return _event_message1000207; } set { _event_message1000207 = value; } }
  [SerializeField] protected bool _event_message1000208 = false;
  public bool Event_Message1000208 { get { return _event_message1000208; } set { _event_message1000208 = value; } }
  [SerializeField] protected int _event_speedrun1_progress = -1; // 0は開始の意味でつかうので初期値は-1とする。
  public int Event_SpeedRun1_Progress { get { return _event_speedrun1_progress; } set { _event_speedrun1_progress = value; } }
  [SerializeField] protected bool _event_speedrun1_failed1 = false;
  public bool Event_SpeedRun1_Failed1 { get { return _event_speedrun1_failed1; } set { _event_speedrun1_failed1 = value; } }
  [SerializeField] protected bool _event_speedrun1_failed2 = false;
  public bool Event_SpeedRun1_Failed2 { get { return _event_speedrun1_failed2; } set { _event_speedrun1_failed2 = value; } }
  [SerializeField] protected bool _event_speedrun1_complete = false;
  public bool Event_SpeedRun1_Complete { get { return _event_speedrun1_complete; } set { _event_speedrun1_complete = value; } }

  [SerializeField] protected bool _event_message1000209 = false;
  public bool Event_Message1000209 { get { return _event_message1000209; } set { _event_message1000209 = value; } }

  [SerializeField] protected bool _event_speedrun2_failed1 = false;
  public bool Event_SpeedRun2_Failed1 { get { return _event_speedrun2_failed1; } set { _event_speedrun2_failed1 = value; } }
  [SerializeField] protected bool _event_speedrun2_failed2 = false;
  public bool Event_SpeedRun2_Failed2 { get { return _event_speedrun2_failed2; } set { _event_speedrun2_failed2 = value; } }
  [SerializeField] protected bool _event_speedrun2_complete = false;
  public bool Event_SpeedRun2_Complete { get { return _event_speedrun2_complete; } set { _event_speedrun2_complete = value; } }

  [SerializeField] protected bool _event_message1000211 = false;
  public bool Event_Message1000211 { get { return _event_message1000211; } set { _event_message1000211 = value; } }

  [SerializeField] protected bool _event_speedrun3_failed1 = false;
  public bool Event_SpeedRun3_Failed1 { get { return _event_speedrun3_failed1; } set { _event_speedrun3_failed1 = value; } }
  [SerializeField] protected bool _event_speedrun3_failed2 = false;
  public bool Event_SpeedRun3_Failed2 { get { return _event_speedrun3_failed2; } set { _event_speedrun3_failed2 = value; } }
  [SerializeField] protected bool _event_speedrun3_complete = false;
  public bool Event_SpeedRun3_Complete { get { return _event_speedrun3_complete; } set { _event_speedrun3_complete = value; } }

  [SerializeField] protected bool _event_message1000213 = false;
  public bool Event_Message1000213 { get { return _event_message1000213; } set { _event_message1000213 = value; } }

  [SerializeField] protected bool _event_speedrun4_failed1 = false;
  public bool Event_SpeedRun4_Failed1 { get { return _event_speedrun4_failed1; } set { _event_speedrun4_failed1 = value; } }
  [SerializeField] protected bool _event_speedrun4_failed2 = false;
  public bool Event_SpeedRun4_Failed2 { get { return _event_speedrun4_failed2; } set { _event_speedrun4_failed2 = value; } }
  [SerializeField] protected bool _event_speedrun4_failed3 = false;
  public bool Event_SpeedRun4_Failed3 { get { return _event_speedrun4_failed3; } set { _event_speedrun4_failed3 = value; } }
  [SerializeField] protected bool _event_speedrun4_complete = false;
  public bool Event_SpeedRun4_Complete { get { return _event_speedrun4_complete; } set { _event_speedrun4_complete = value; } }

  [SerializeField] protected bool _event_message1000215 = false;
  public bool Event_Message1000215 { get { return _event_message1000215; } set { _event_message1000215 = value; } }

  [SerializeField] protected bool _event_speedrun5_failed1 = false;
  public bool Event_SpeedRun5_Failed1 { get { return _event_speedrun5_failed1; } set { _event_speedrun5_failed1 = value; } }
  [SerializeField] protected bool _event_speedrun5_failed2 = false;
  public bool Event_SpeedRun5_Failed2 { get { return _event_speedrun5_failed2; } set { _event_speedrun5_failed2 = value; } }
  [SerializeField] protected bool _event_speedrun5_complete = false;
  public bool Event_SpeedRun5_Complete { get { return _event_speedrun5_complete; } set { _event_speedrun5_complete = value; } }

  [SerializeField] protected bool _event_message1000217 = false;
  public bool Event_Message1000217 { get { return _event_message1000217; } set { _event_message1000217 = value; } }
  [SerializeField] protected bool _event_seacirculate1_complete = false;
  public bool EventSeaCirculate1_Complete { get { return _event_seacirculate1_complete; } set { _event_seacirculate1_complete = value; } }

  [SerializeField] protected bool _event_message1000219 = false;
  public bool Event_Message1000219 { get { return _event_message1000219; } set { _event_message1000219 = value; } }
  [SerializeField] protected bool _event_seacirculate2_complete = false;
  public bool EventSeaCirculate2_Complete { get { return _event_seacirculate2_complete; } set { _event_seacirculate2_complete = value; } }

  [SerializeField] protected bool _event_message1000221 = false;
  public bool Event_Message1000221 { get { return _event_message1000221; } set { _event_message1000221 = value; } }
  [SerializeField] protected bool _event_seacirculate3_tilestart1 = false;
  public bool EventSseaCirculate3_TileStart1 { get { return _event_seacirculate3_tilestart1; } set { _event_seacirculate3_tilestart1 = value; } }
  [SerializeField] protected bool _event_seacirculate3_tilestart2 = false;
  public bool EventSseaCirculate3_TileStart2 { get { return _event_seacirculate3_tilestart2; } set { _event_seacirculate3_tilestart2 = value; } }
  [SerializeField] protected bool _event_seacirculate3_tilestart3 = false;
  public bool EventSseaCirculate3_TileStart3 { get { return _event_seacirculate3_tilestart3; } set { _event_seacirculate3_tilestart3 = value; } }
  [SerializeField] protected bool _event_seacirculate3_tilestart4 = false;
  public bool EventSseaCirculate3_TileStart4 { get { return _event_seacirculate3_tilestart4; } set { _event_seacirculate3_tilestart4 = value; } }
  [SerializeField] protected bool _event_seacirculate3_complete = false;
  public bool EventSeaCirculate3_Complete { get { return _event_seacirculate3_complete; } set { _event_seacirculate3_complete = value; } }
  [SerializeField] protected bool _event_seacirculate4_complete = false;
  public bool EventSeaCirculate4_Complete { get { return _event_seacirculate4_complete; } set { _event_seacirculate4_complete = value; } }

  [SerializeField] protected bool _event_message1000227 = false;
  public bool Event_Message1000227 { get { return _event_message1000227; } set { _event_message1000227 = value; } } // 
  [SerializeField] protected bool _event_message1000228 = false;
  public bool Event_Message1000228 { get { return _event_message1000228; } set { _event_message1000228 = value; } }

  [SerializeField] protected bool _event_message1000234 = false;
  public bool Event_Message1000234 { get { return _event_message1000234; } set { _event_message1000234 = value; } }
  [SerializeField] protected bool _event_message1000234_2 = false;
  public bool Event_Message1000234_2 { get { return _event_message1000234_2; } set { _event_message1000234_2 = value; } }

  [SerializeField] protected bool _event_message1000235 = false;
  public bool Event_Message1000235 { get { return _event_message1000235; } set { _event_message1000235 = value; } }
  [SerializeField] protected bool _event_message1000236 = false;
  public bool Event_Message1000236 { get { return _event_message1000236; } set { _event_message1000236 = value; } }
  [SerializeField] protected bool _event_message1000237 = false;
  public bool Event_Message1000237 { get { return _event_message1000237; } set { _event_message1000237 = value; } }

  [SerializeField] protected bool _event_randomball_complete = false;
  public bool Event_RandomBall_Complete { get { return _event_randomball_complete; } set { _event_randomball_complete = value; } }
  [SerializeField] protected bool _event_randomball_failed1 = false;
  public bool Event_RandomBall_Failed1 { get { return _event_randomball_failed1; } set { _event_randomball_failed1 = value; } }
  [SerializeField] protected bool _event_randomball_failed2 = false;
  public bool Event_RandomBall_Failed2 { get { return _event_randomball_failed2; } set { _event_randomball_failed2 = value; } }

  [SerializeField] protected bool _event_message1000248 = false;
  public bool Event_Message1000248 { get { return _event_message1000248; } set { _event_message1000248 = value; } }
  [SerializeField] protected bool _event_message1000249 = false;
  public bool Event_Message1000249 { get { return _event_message1000249; } set { _event_message1000249 = value; } }
  [SerializeField] protected bool _event_message1000250 = false;
  public bool Event_Message1000250 { get { return _event_message1000250; } set { _event_message1000250 = value; } }
  [SerializeField] protected bool _event_message1000256 = false;
  public bool Event_Message1000256 { get { return _event_message1000256; } set { _event_message1000256 = value; } }

  [SerializeField] protected bool _event_randomball_complete2 = false;
  public bool Event_RandomBall_Complete2 { get { return _event_randomball_complete2; } set { _event_randomball_complete2 = value; } }
  [SerializeField] protected bool _event_randomball_failed2_1 = false;
  public bool Event_RandomBall_Failed2_1 { get { return _event_randomball_failed2_1; } set { _event_randomball_failed2_1 = value; } }
  [SerializeField] protected bool _event_randomball_failed2_2 = false;
  public bool Event_RandomBall_Failed2_2 { get { return _event_randomball_failed2_2; } set { _event_randomball_failed2_2 = value; } }
  [SerializeField] protected bool _event_randomball_failed2_3 = false;
  public bool Event_RandomBall_Failed2_3 { get { return _event_randomball_failed2_3; } set { _event_randomball_failed2_3 = value; } }

  [SerializeField] protected bool _event_message1000259 = false;
  public bool Event_Message1000259 { get { return _event_message1000259; } set { _event_message1000259 = value; } }

  [SerializeField] protected bool _event_message1000260 = false;
  public bool Event_Message1000260 { get { return _event_message1000260; } set { _event_message1000260 = value; } }

  [SerializeField] protected bool _event_message1000261 = false;
  public bool Event_Message1000261 { get { return _event_message1000261; } set { _event_message1000261 = value; } }

  [SerializeField] protected bool _event_message1000262 = false;
  public bool Event_Message1000262 { get { return _event_message1000262; } set { _event_message1000262 = value; } }

  [SerializeField] protected bool _event_message1000264 = false;
  public bool Event_Message1000264 { get { return _event_message1000264; } set { _event_message1000264 = value; } }

  // ヴェルガス海底神殿：第三階層
  [SerializeField] protected bool _event_message1000265 = false;
  public bool Event_Message1000265 { get { return _event_message1000265; } set { _event_message1000265 = value; } }

  [SerializeField] protected bool _event_message1000267 = false;
  public bool Event_Message1000267 { get { return _event_message1000267; } set { _event_message1000267 = value; } }

  [SerializeField] protected bool _event_message1000269 = false;
  public bool Event_Message1000269 { get { return _event_message1000269; } set { _event_message1000269 = value; } }

  [SerializeField] protected bool _event_message1000270 = false;
  public bool Event_Message1000270 { get { return _event_message1000270; } set { _event_message1000270 = value; } }

  [SerializeField] protected bool _event_message1000272 = false;
  public bool Event_Message1000272 { get { return _event_message1000272; } set { _event_message1000272 = value; } }

  [SerializeField] protected bool _event_message1000273 = false;
  public bool Event_Message1000273 { get { return _event_message1000273; } set { _event_message1000273 = value; } }

  [SerializeField] protected bool _event_message1000275 = false;
  public bool Event_Message1000275 { get { return _event_message1000275; } set { _event_message1000275 = value; } }

  [SerializeField] protected bool _event_message1000276 = false;
  public bool Event_Message1000276 { get { return _event_message1000276; } set { _event_message1000276 = value; } }

  [SerializeField] protected bool _event_message1000278 = false;
  public bool Event_Message1000278 { get { return _event_message1000278; } set { _event_message1000278 = value; } }

  [SerializeField] protected bool _event_message1000279 = false;
  public bool Event_Message1000279 { get { return _event_message1000279; } set { _event_message1000279 = value; } }

  [SerializeField] protected bool _event_message1000281 = false;
  public bool Event_Message1000281 { get { return _event_message1000281; } set { _event_message1000281 = value; } }

  [SerializeField] protected bool _event_message1000282 = false;
  public bool Event_Message1000282 { get { return _event_message1000282; } set { _event_message1000282 = value; } }

  [SerializeField] protected bool _event_message1000284 = false;
  public bool Event_Message1000284 { get { return _event_message1000284; } set { _event_message1000284 = value; } }

  [SerializeField] protected bool _event_message1000285 = false;
  public bool Event_Message1000285 { get { return _event_message1000285; } set { _event_message1000285 = value; } }

  [SerializeField] protected bool _event_message1000287 = false;
  public bool Event_Message1000287 { get { return _event_message1000287; } set { _event_message1000287 = value; } }

  [SerializeField] protected bool _event_message1000288 = false;
  public bool Event_Message1000288 { get { return _event_message1000288; } set { _event_message1000288 = value; } }

  [SerializeField] protected bool _event_message1000289 = false;
  public bool Event_Message1000289 { get { return _event_message1000289; } set { _event_message1000289 = value; } }

  [SerializeField] protected bool _event_message1000290 = false;
  public bool Event_Message1000290 { get { return _event_message1000290; } set { _event_message1000290 = value; } }

  [SerializeField] protected bool _event_message1000291 = false;
  public bool Event_Message1000291 { get { return _event_message1000291; } set { _event_message1000291 = value; } }

  // ヴェルガス海底神殿：第四階層
  [SerializeField] protected bool _event_message1000292 = false;
  public bool Event_Message1000292 { get { return _event_message1000292; } set { _event_message1000292 = value; } }

  [SerializeField] protected bool _event_mindroom_complete = false;
  public bool Event_MindRoom_Complete { get { return _event_mindroom_complete; } set { _event_mindroom_complete = value; } }

  [SerializeField] protected bool _event_message1000294 = false;
  public bool Event_Message1000294 { get { return _event_message1000294; } set { _event_message1000294 = value; } }

  [SerializeField] protected bool _event_message1000295 = false;
  public bool Event_Message1000295 { get { return _event_message1000295; } set { _event_message1000295 = value; } }

  [SerializeField] protected bool _event_message1000296 = false;
  public bool Event_Message1000296 { get { return _event_message1000296; } set { _event_message1000296 = value; } }

  [SerializeField] protected bool _event_message1000297 = false;
  public bool Event_Message1000297 { get { return _event_message1000297; } set { _event_message1000297 = value; } }

  [SerializeField] protected bool _event_message1000302 = false;
  public bool Event_Message1000302 { get { return _event_message1000302; } set { _event_message1000302 = value; } }

  [SerializeField] protected bool _event_message1009010 = false;
  public bool Event_Message1009010 { get { return _event_message1009010; } set { _event_message1009010 = value; } }

  [SerializeField] protected bool _event_message1009070 = false;
  public bool Event_Message1009070 { get { return _event_message1009070; } set { _event_message1009070 = value; } }

  [SerializeField] protected bool _event_message1010000 = false;
  public bool Event_Message1010000 { get { return _event_message1010000; } set { _event_message1010000 = value; } }
  [SerializeField] protected bool _event_message1010010 = false;
  public bool Event_Message1010010 { get { return _event_message1010010; } set { _event_message1010010 = value; } }
  [SerializeField] protected bool _event_message1010020 = false;
  public bool Event_Message1010020 { get { return _event_message1010020; } set { _event_message1010020 = value; } }
  [SerializeField] protected bool _event_message1010030 = false;
  public bool Event_Message1010030 { get { return _event_message1010030; } set { _event_message1010030 = value; } }

  [SerializeField] protected bool _event_message1100010 = false;
  public bool Event_Message1100010 { get { return _event_message1100010; } set { _event_message1100010 = value; } }
  [SerializeField] protected bool _event_message1100020 = false;
  public bool Event_Message1100020 { get { return _event_message1100020; } set { _event_message1100020 = value; } }
  [SerializeField] protected bool _event_message1100030 = false;
  public bool Event_Message1100030 { get { return _event_message1100030; } set { _event_message1100030 = value; } }
  [SerializeField] protected bool _event_message1100040 = false;
  public bool Event_Message1100040 { get { return _event_message1100040; } set { _event_message1100040 = value; } }
  [SerializeField] protected bool _event_message1100050 = false;
  public bool Event_Message1100050 { get { return _event_message1100050; } set { _event_message1100050 = value; } }

  [SerializeField] protected bool _event_message1400010 = false;
  [SerializeField] protected bool _event_message1400020 = false;
  [SerializeField] protected bool _event_message1400030 = false;
  public bool Event_Message1400010 { get { return _event_message1400010; } set { _event_message1400010 = value; } }
  public bool Event_Message1400020 { get { return _event_message1400020; } set { _event_message1400020 = value; } }
  public bool Event_Message1400030 { get { return _event_message1400030; } set { _event_message1400030 = value; } }

  #region "エデルガイゼン城"
  [SerializeField] protected bool _event_message1900010 = false;
  [SerializeField] protected bool _event_message1900020 = false;
  [SerializeField] protected bool _event_message1900040 = false;
  [SerializeField] protected bool _event_message1900050 = false;
  [SerializeField] protected bool _event_message1900051 = false;
  [SerializeField] protected bool _event_message1900052 = false;
  [SerializeField] protected bool _event_message1900053 = false;
  [SerializeField] protected bool _event_message1900054 = false;
  public bool Event_Message1900010 { get { return _event_message1900010; } set { _event_message1900010 = value; } } // 始めの探索開始イベント
  public bool Event_Message1900020 { get { return _event_message1900020; } set { _event_message1900020 = value; } } // 1F：ワープ鏡１
  public bool Event_Message1900040 { get { return _event_message1900040; } set { _event_message1900040 = value; } } // 1F：扉５
  public bool Event_Message1900050 { get { return _event_message1900050; } set { _event_message1900050 = value; } } // 1F：扉６
  public bool Event_Message1900051 { get { return _event_message1900051; } set { _event_message1900051 = value; } } // 2F：扉１
  public bool Event_Message1900052 { get { return _event_message1900052; } set { _event_message1900052 = value; } } // 2F：扉２
  public bool Event_Message1900053 { get { return _event_message1900053; } set { _event_message1900053 = value; } } // 2F：扉３
  public bool Event_Message1900054 { get { return _event_message1900054; } set { _event_message1900054 = value; } } // 2F：扉４

  #endregion

  [SerializeField] protected bool _event_message2200000 = false;
  public bool Event_Message2200000 { get { return _event_message2200000; } set { _event_message2200000 = value; } }
  [SerializeField] protected bool _event_message2200010 = false;
  public bool Event_Message2200010 { get { return _event_message2200010; } set { _event_message2200010 = value; } }
  [SerializeField] protected bool _event_message2200020 = false;
  public bool Event_Message2200020 { get { return _event_message2200020; } set { _event_message2200020 = value; } }

  [SerializeField] protected bool _event_message1200010 = false;
  public bool Event_Message1200010 { get { return _event_message1200010; } set { _event_message1200010 = value; } }

  [SerializeField] protected bool _event_message1200012 = false;
  public bool Event_Message1200012 { get { return _event_message1200012; } set { _event_message1200012 = value; } }

  [SerializeField] protected bool _event_entry_mystic_forest = false;
  public bool Event_EntryMysticForest {  get { return _event_entry_mystic_forest; } set { _event_entry_mystic_forest = value; } }
  #endregion

  #region "Quest"
  [SerializeField] protected bool _questmain_00001 = false;
  [SerializeField] protected bool _questmain_00002 = false;
  [SerializeField] protected bool _questmain_00003 = false;
  [SerializeField] protected bool _questmain_00004 = false;
  [SerializeField] protected bool _questmain_00005 = false;
  [SerializeField] protected bool _questmain_00006 = false;
  [SerializeField] protected bool _questmain_00007 = false;
  [SerializeField] protected bool _questmain_00008 = false;
  [SerializeField] protected bool _questmain_00009 = false;
  [SerializeField] protected bool _questmain_00010 = false;
  [SerializeField] protected bool _questmain_00011 = false;

  [SerializeField] protected bool _questmain_00020 = false;
  [SerializeField] protected bool _questmain_00021 = false;
  [SerializeField] protected bool _questmain_00022 = false;
  [SerializeField] protected bool _questmain_00023 = false;
  [SerializeField] protected bool _questmain_00024 = false;

  [SerializeField] protected bool _questmain_complete_00001 = false;
  [SerializeField] protected bool _questmain_complete_00002 = false;
  [SerializeField] protected bool _questmain_complete_00003 = false;
  [SerializeField] protected bool _questmain_complete_00004 = false;
  [SerializeField] protected bool _questmain_complete_00005 = false;
  [SerializeField] protected bool _questmain_complete_00006 = false;
  [SerializeField] protected bool _questmain_complete_00007 = false;
  [SerializeField] protected bool _questmain_complete_00008 = false;
  [SerializeField] protected bool _questmain_complete_00009 = false;
  [SerializeField] protected bool _questmain_complete_00010 = false;
  [SerializeField] protected bool _questmain_complete_00011 = false;
  [SerializeField] protected bool _questmain_complete_00020 = false;
  [SerializeField] protected bool _questmain_complete_00021 = false;
  [SerializeField] protected bool _questmain_complete_00022 = false;
  [SerializeField] protected bool _questmain_complete_00023 = false;
  [SerializeField] protected bool _questmain_complete_00024 = false;
  public bool QuestMain_00001 { get { return _questmain_00001; } set { _questmain_00001 = value; } }
  public bool QuestMain_00002 { get { return _questmain_00002; } set { _questmain_00002 = value; } }
  public bool QuestMain_00003 { get { return _questmain_00003; } set { _questmain_00003 = value; } }
  public bool QuestMain_00004 { get { return _questmain_00004; } set { _questmain_00004 = value; } }
  public bool QuestMain_00005 { get { return _questmain_00005; } set { _questmain_00005 = value; } }
  public bool QuestMain_00006 { get { return _questmain_00006; } set { _questmain_00006 = value; } }
  public bool QuestMain_00007 { get { return _questmain_00007; } set { _questmain_00007 = value; } }
  public bool QuestMain_00008 { get { return _questmain_00008; } set { _questmain_00008 = value; } }
  public bool QuestMain_00009 { get { return _questmain_00009; } set { _questmain_00009 = value; } }
  public bool QuestMain_00010 { get { return _questmain_00010; } set { _questmain_00010 = value; } }
  public bool QuestMain_00011 { get { return _questmain_00011; } set { _questmain_00011 = value; } }

  public bool QuestMain_00020 { get { return _questmain_00020; } set { _questmain_00020 = value; } }
  public bool QuestMain_00021 { get { return _questmain_00021; } set { _questmain_00021 = value; } }
  public bool QuestMain_00022 { get { return _questmain_00022; } set { _questmain_00022 = value; } }
  public bool QuestMain_00023 { get { return _questmain_00023; } set { _questmain_00023 = value; } }
  public bool QuestMain_00024 { get { return _questmain_00024; } set { _questmain_00024 = value; } }

  public bool QuestMain_Complete_00001 { get { return _questmain_complete_00001; } set { _questmain_complete_00001 = value; } }
  public bool QuestMain_Complete_00002 { get { return _questmain_complete_00002; } set { _questmain_complete_00002 = value; } }
  public bool QuestMain_Complete_00003 { get { return _questmain_complete_00003; } set { _questmain_complete_00003 = value; } }
  public bool QuestMain_Complete_00004 { get { return _questmain_complete_00004; } set { _questmain_complete_00004 = value; } }
  public bool QuestMain_Complete_00005 { get { return _questmain_complete_00005; } set { _questmain_complete_00005 = value; } }
  public bool QuestMain_Complete_00006 { get { return _questmain_complete_00006; } set { _questmain_complete_00006 = value; } }
  public bool QuestMain_Complete_00007 { get { return _questmain_complete_00007; } set { _questmain_complete_00007 = value; } }
  public bool QuestMain_Complete_00008 { get { return _questmain_complete_00008; } set { _questmain_complete_00008 = value; } }
  public bool QuestMain_Complete_00009 { get { return _questmain_complete_00009; } set { _questmain_complete_00009 = value; } }
  public bool QuestMain_Complete_00010 { get { return _questmain_complete_00010; } set { _questmain_complete_00010 = value; } }
  public bool QuestMain_Complete_00011 { get { return _questmain_complete_00011; } set { _questmain_complete_00011 = value; } }

  public bool QuestMain_Complete_00020 { get { return _questmain_complete_00020; } set { _questmain_complete_00020 = value; } }
  public bool QuestMain_Complete_00021 { get { return _questmain_complete_00021; } set { _questmain_complete_00021 = value; } }
  public bool QuestMain_Complete_00022 { get { return _questmain_complete_00022; } set { _questmain_complete_00022 = value; } }
  public bool QuestMain_Complete_00023 { get { return _questmain_complete_00023; } set { _questmain_complete_00023 = value; } }
  public bool QuestMain_Complete_00024 { get { return _questmain_complete_00024; } set { _questmain_complete_00024 = value; } }
  #endregion

  #region "Treasure"
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00001 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00002 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00003 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00004 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00005 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00006 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00007 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00008 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00009 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00010 = false;
  [SerializeField] protected bool _treasure_EsmiliaGrassField_00011 = false;

  [SerializeField] protected bool _treasure_goratrum_00001 = false;
  [SerializeField] protected bool _treasure_goratrum_00002 = false;
  [SerializeField] protected bool _treasure_goratrum_00003 = false;
  [SerializeField] protected bool _treasure_goratrum_00004 = false;
  [SerializeField] protected bool _treasure_goratrum_00005 = false;
  [SerializeField] protected bool _treasure_goratrum_00006 = false;
  [SerializeField] protected bool _treasure_goratrum_00007 = false;
  [SerializeField] protected bool _treasure_goratrum_00008 = false;
  [SerializeField] protected bool _treasure_goratrum_00009 = false;
  [SerializeField] protected bool _treasure_goratrum_00010 = false;
  [SerializeField] protected bool _treasure_goratrum_00011 = false;

  [SerializeField] protected bool _treasure_goratrum2_00001 = false;
  [SerializeField] protected bool _treasure_goratrum2_00002 = false;
  [SerializeField] protected bool _treasure_goratrum2_00003 = false;
  [SerializeField] protected bool _treasure_goratrum2_00004 = false;

  [SerializeField] protected bool _treasure_mysticforest_00001 = false;
  [SerializeField] protected bool _treasure_mysticforest_00002 = false;
  [SerializeField] protected bool _treasure_mysticforest_00003 = false;
  [SerializeField] protected bool _treasure_mysticforest_00004 = false;
  [SerializeField] protected bool _treasure_mysticforest_00005 = false;
  [SerializeField] protected bool _treasure_mysticforest_00006 = false;
  [SerializeField] protected bool _treasure_mysticforest_00007 = false;
  [SerializeField] protected bool _treasure_mysticforest_00008 = false;
  [SerializeField] protected bool _treasure_mysticforest_00009 = false;
  [SerializeField] protected bool _treasure_mysticforest_00010 = false;
  [SerializeField] protected bool _treasure_mysticforest_00011 = false;
  [SerializeField] protected bool _treasure_mysticforest_00012 = false;
  [SerializeField] protected bool _treasure_mysticforest_00013 = false;
  [SerializeField] protected bool _treasure_mysticforest_00014 = false;
  [SerializeField] protected bool _treasure_mysticforest_00015 = false;
  [SerializeField] protected bool _treasure_mysticforest_00016 = false;
  [SerializeField] protected bool _treasure_mysticforest_00017 = false;
  [SerializeField] protected bool _treasure_mysticforest_00018 = false;
  [SerializeField] protected bool _treasure_mysticforest_00019 = false;

  [SerializeField] protected bool _treasure_artharium_00001 = false;
  [SerializeField] protected bool _treasure_artharium_00002 = false;
  [SerializeField] protected bool _treasure_artharium_00003 = false;
  [SerializeField] protected bool _treasure_artharium_00004 = false;
  [SerializeField] protected bool _treasure_artharium_00005 = false;
  [SerializeField] protected bool _treasure_artharium_00006 = false;
  [SerializeField] protected bool _treasure_artharium_00007 = false;
  [SerializeField] protected bool _treasure_artharium_00008 = false;
  [SerializeField] protected bool _treasure_artharium_00009 = false;
  [SerializeField] protected bool _treasure_artharium_00010 = false;
  [SerializeField] protected bool _treasure_artharium_00011 = false;
  [SerializeField] protected bool _treasure_artharium_00012 = false;
  [SerializeField] protected bool _treasure_artharium_00013 = false;
  [SerializeField] protected bool _treasure_artharium_00014 = false;
  [SerializeField] protected bool _treasure_artharium_00015 = false;
  [SerializeField] protected bool _treasure_artharium_00016 = false;
  [SerializeField] protected bool _treasure_artharium_00017 = false;
  [SerializeField] protected bool _treasure_artharium_00018 = false;
  [SerializeField] protected bool _treasure_artharium_00019 = false;
  [SerializeField] protected bool _treasure_artharium_00020 = false;
  [SerializeField] protected bool _treasure_artharium_00021 = false;
  [SerializeField] protected bool _treasure_artharium_00022 = false;
  [SerializeField] protected bool _treasure_artharium_00023 = false;
  [SerializeField] protected bool _treasure_artharium_00024 = false;
  [SerializeField] protected bool _treasure_artharium_00025 = false;
  [SerializeField] protected bool _obsidian_artharium_00001 = false;

  [SerializeField] protected bool _treasure_ohrantower_00001 = false;
  [SerializeField] protected bool _treasure_ohrantower_00002 = false;
  [SerializeField] protected bool _treasure_ohrantower_00003 = false;
  [SerializeField] protected bool _treasure_ohrantower_00004 = false;
  [SerializeField] protected bool _treasure_ohrantower_00005 = false;
  [SerializeField] protected bool _treasure_ohrantower_00006 = false;
  [SerializeField] protected bool _treasure_ohrantower_00007 = false;
  [SerializeField] protected bool _treasure_ohrantower_00008 = false;
  [SerializeField] protected bool _treasure_ohrantower_00009 = false;
  [SerializeField] protected bool _treasure_ohrantower_00010 = false;
  [SerializeField] protected bool _treasure_ohrantower_00011 = false;
  [SerializeField] protected bool _treasure_ohrantower_00012 = false;
  [SerializeField] protected bool _treasure_ohrantower_00013 = false;
  [SerializeField] protected bool _treasure_ohrantower_00014 = false;
  [SerializeField] protected bool _treasure_ohrantower_00015 = false;
  [SerializeField] protected bool _treasure_ohrantower_00016 = false;
  [SerializeField] protected bool _treasure_ohrantower_00017 = false;
  [SerializeField] protected bool _treasure_ohrantower_00018 = false;
  [SerializeField] protected bool _treasure_ohrantower_00019 = false;
  [SerializeField] protected bool _treasure_ohrantower_00020 = false;
  [SerializeField] protected bool _treasure_ohrantower_00021 = false;
  [SerializeField] protected bool _treasure_ohrantower_00022 = false;
  [SerializeField] protected bool _treasure_ohrantower_00023 = false;
  [SerializeField] protected bool _treasure_ohrantower_00024 = false;
  [SerializeField] protected bool _treasure_ohrantower_00025 = false;
  [SerializeField] protected bool _treasure_ohrantower_00026 = false;
  [SerializeField] protected bool _treasure_ohrantower_00027 = false;
  [SerializeField] protected bool _treasure_ohrantower_00028 = false;
  [SerializeField] protected bool _treasure_ohrantower_00029 = false;
  [SerializeField] protected bool _treasure_ohrantower_00030 = false;
  [SerializeField] protected bool _treasure_ohrantower_00031 = false;
  [SerializeField] protected bool _treasure_ohrantower_00032 = false;
  [SerializeField] protected bool _treasure_ohrantower_00033 = false;
  [SerializeField] protected bool _treasure_ohrantower_00034 = false;
  [SerializeField] protected bool _treasure_ohrantower_00035 = false;
  [SerializeField] protected bool _treasure_ohrantower_00036 = false;
  [SerializeField] protected bool _treasure_ohrantower_00037 = false;

  [SerializeField] protected bool _treasure_velgus_00001 = false;
  [SerializeField] protected bool _treasure_velgus_00002 = false;
  [SerializeField] protected bool _treasure_velgus_00003 = false;
  [SerializeField] protected bool _treasure_velgus_00004 = false;
  [SerializeField] protected bool _treasure_velgus_00005 = false;
  [SerializeField] protected bool _treasure_velgus_00006 = false;
  [SerializeField] protected bool _treasure_velgus_00007 = false;
  [SerializeField] protected bool _treasure_velgus_00008 = false;
  [SerializeField] protected bool _treasure_velgus_00009 = false;
  [SerializeField] protected bool _treasure_velgus_00010 = false;
  [SerializeField] protected bool _treasure_velgus_00011 = false;
  [SerializeField] protected bool _treasure_velgus_00012 = false;
  [SerializeField] protected bool _treasure_velgus_00013 = false;
  [SerializeField] protected bool _treasure_velgus2_00001 = false;
  [SerializeField] protected bool _treasure_velgus2_00002 = false;
  [SerializeField] protected bool _treasure_velgus2_00003 = false;
  [SerializeField] protected bool _treasure_velgus2_00004 = false;
  [SerializeField] protected bool _treasure_velgus2_00005 = false;
  [SerializeField] protected bool _treasure_velgus2_00006 = false;
  [SerializeField] protected bool _treasure_velgus2_00007 = false;
  [SerializeField] protected bool _treasure_velgus2_00008 = false;
  [SerializeField] protected bool _treasure_velgus2_00009 = false;
  [SerializeField] protected bool _treasure_velgus2_00010 = false;
  [SerializeField] protected bool _treasure_velgus2_00011 = false;
  [SerializeField] protected bool _treasure_velgus2_00012 = false;
  [SerializeField] protected bool _treasure_velgus2_00013 = false;
  [SerializeField] protected bool _treasure_velgus2_00014 = false;
  [SerializeField] protected bool _treasure_velgus2_00015 = false;
  [SerializeField] protected bool _treasure_velgus2_00016 = false;
  [SerializeField] protected bool _treasure_velgus3_00001 = false;
  [SerializeField] protected bool _treasure_velgus3_00002 = false;
  [SerializeField] protected bool _treasure_velgus3_00003 = false;
  [SerializeField] protected bool _treasure_velgus3_00004 = false;
  [SerializeField] protected bool _treasure_velgus3_00005 = false;
  [SerializeField] protected bool _treasure_velgus3_00006 = false;
  [SerializeField] protected bool _treasure_velgus3_00007 = false;
  [SerializeField] protected bool _treasure_velgus3_00008 = false;
  [SerializeField] protected bool _treasure_velgus3_00009 = false;
  [SerializeField] protected bool _treasure_velgus3_00010 = false;
  [SerializeField] protected bool _treasure_velgus3_00011 = false;
  public bool Treasure_Velgus_00001 { get { return _treasure_velgus_00001; } set { _treasure_velgus_00001 = value; } }
  public bool Treasure_Velgus_00002 { get { return _treasure_velgus_00002; } set { _treasure_velgus_00002 = value; } }
  public bool Treasure_Velgus_00003 { get { return _treasure_velgus_00003; } set { _treasure_velgus_00003 = value; } }
  public bool Treasure_Velgus_00004 { get { return _treasure_velgus_00004; } set { _treasure_velgus_00004 = value; } }
  public bool Treasure_Velgus_00005 { get { return _treasure_velgus_00005; } set { _treasure_velgus_00005 = value; } }
  public bool Treasure_Velgus_00006 { get { return _treasure_velgus_00006; } set { _treasure_velgus_00006 = value; } }
  public bool Treasure_Velgus_00007 { get { return _treasure_velgus_00007; } set { _treasure_velgus_00007 = value; } }
  public bool Treasure_Velgus_00008 { get { return _treasure_velgus_00008; } set { _treasure_velgus_00008 = value; } }
  public bool Treasure_Velgus_00009 { get { return _treasure_velgus_00009; } set { _treasure_velgus_00009 = value; } }
  public bool Treasure_Velgus_00010 { get { return _treasure_velgus_00010; } set { _treasure_velgus_00010 = value; } }
  public bool Treasure_Velgus_00011 { get { return _treasure_velgus_00011; } set { _treasure_velgus_00011 = value; } }
  public bool Treasure_Velgus_00012 { get { return _treasure_velgus_00012; } set { _treasure_velgus_00012 = value; } }
  public bool Treasure_Velgus_00013 { get { return _treasure_velgus_00013; } set { _treasure_velgus_00013 = value; } }
  public bool Treasure_Velgus2_00001 { get { return _treasure_velgus2_00001; } set { _treasure_velgus2_00001 = value; } }
  public bool Treasure_Velgus2_00002 { get { return _treasure_velgus2_00002; } set { _treasure_velgus2_00002 = value; } }
  public bool Treasure_Velgus2_00003 { get { return _treasure_velgus2_00003; } set { _treasure_velgus2_00003 = value; } }
  public bool Treasure_Velgus2_00004 { get { return _treasure_velgus2_00004; } set { _treasure_velgus2_00004 = value; } }
  public bool Treasure_Velgus2_00005 { get { return _treasure_velgus2_00005; } set { _treasure_velgus2_00005 = value; } }
  public bool Treasure_Velgus2_00006 { get { return _treasure_velgus2_00006; } set { _treasure_velgus2_00006 = value; } }
  public bool Treasure_Velgus2_00007 { get { return _treasure_velgus2_00007; } set { _treasure_velgus2_00007 = value; } }
  public bool Treasure_Velgus2_00008 { get { return _treasure_velgus2_00008; } set { _treasure_velgus2_00008 = value; } }
  public bool Treasure_Velgus2_00009 { get { return _treasure_velgus2_00009; } set { _treasure_velgus2_00009 = value; } }
  public bool Treasure_Velgus2_00010 { get { return _treasure_velgus2_00010; } set { _treasure_velgus2_00010 = value; } }
  public bool Treasure_Velgus2_00011 { get { return _treasure_velgus2_00011; } set { _treasure_velgus2_00011 = value; } }
  public bool Treasure_Velgus2_00012 { get { return _treasure_velgus2_00012; } set { _treasure_velgus2_00012 = value; } }
  public bool Treasure_Velgus2_00013 { get { return _treasure_velgus2_00013; } set { _treasure_velgus2_00013 = value; } }
  public bool Treasure_Velgus2_00014 { get { return _treasure_velgus2_00014; } set { _treasure_velgus2_00014 = value; } }
  public bool Treasure_Velgus2_00015 { get { return _treasure_velgus2_00015; } set { _treasure_velgus2_00015 = value; } }
  public bool Treasure_Velgus2_00016 { get { return _treasure_velgus2_00016; } set { _treasure_velgus2_00016 = value; } }
  public bool Treasure_Velgus3_00001 { get { return _treasure_velgus3_00001; } set { _treasure_velgus3_00001 = value; } }
  public bool Treasure_Velgus3_00002 { get { return _treasure_velgus3_00002; } set { _treasure_velgus3_00002 = value; } }
  public bool Treasure_Velgus3_00003 { get { return _treasure_velgus3_00003; } set { _treasure_velgus3_00003 = value; } }
  public bool Treasure_Velgus3_00004 { get { return _treasure_velgus3_00004; } set { _treasure_velgus3_00004 = value; } }
  public bool Treasure_Velgus3_00005 { get { return _treasure_velgus3_00005; } set { _treasure_velgus3_00005 = value; } }
  public bool Treasure_Velgus3_00006 { get { return _treasure_velgus3_00006; } set { _treasure_velgus3_00006 = value; } }
  public bool Treasure_Velgus3_00007 { get { return _treasure_velgus3_00007; } set { _treasure_velgus3_00007 = value; } }
  public bool Treasure_Velgus3_00008 { get { return _treasure_velgus3_00008; } set { _treasure_velgus3_00008 = value; } }
  public bool Treasure_Velgus3_00009 { get { return _treasure_velgus3_00009; } set { _treasure_velgus3_00009 = value; } }
  public bool Treasure_Velgus3_00010 { get { return _treasure_velgus3_00010; } set { _treasure_velgus3_00010 = value; } }
  public bool Treasure_Velgus3_00011 { get { return _treasure_velgus3_00011; } set { _treasure_velgus3_00011 = value; } }

  public bool Treasure_EsmiliaGrassField_00001 { get { return _treasure_EsmiliaGrassField_00001; } set { _treasure_EsmiliaGrassField_00001 = value; } }
  public bool Treasure_EsmiliaGrassField_00002 { get { return _treasure_EsmiliaGrassField_00002; } set { _treasure_EsmiliaGrassField_00002 = value; } }
  public bool Treasure_EsmiliaGrassField_00003 { get { return _treasure_EsmiliaGrassField_00003; } set { _treasure_EsmiliaGrassField_00003 = value; } }
  public bool Treasure_EsmiliaGrassField_00004 { get { return _treasure_EsmiliaGrassField_00004; } set { _treasure_EsmiliaGrassField_00004 = value; } }
  public bool Treasure_EsmiliaGrassField_00005 { get { return _treasure_EsmiliaGrassField_00005; } set { _treasure_EsmiliaGrassField_00005 = value; } }
  public bool Treasure_EsmiliaGrassField_00006 { get { return _treasure_EsmiliaGrassField_00006; } set { _treasure_EsmiliaGrassField_00006 = value; } }
  public bool Treasure_EsmiliaGrassField_00007 { get { return _treasure_EsmiliaGrassField_00007; } set { _treasure_EsmiliaGrassField_00007 = value; } }
  public bool Treasure_EsmiliaGrassField_00008 { get { return _treasure_EsmiliaGrassField_00008; } set { _treasure_EsmiliaGrassField_00008 = value; } }
  public bool Treasure_EsmiliaGrassField_00009 { get { return _treasure_EsmiliaGrassField_00009; } set { _treasure_EsmiliaGrassField_00009 = value; } }
  public bool Treasure_EsmiliaGrassField_00010 { get { return _treasure_EsmiliaGrassField_00010; } set { _treasure_EsmiliaGrassField_00010 = value; } }
  public bool Treasure_EsmiliaGrassField_00011 { get { return _treasure_EsmiliaGrassField_00011; } set { _treasure_EsmiliaGrassField_00011 = value; } }

  public bool Treasure_Goratrum_00001 { get { return _treasure_goratrum_00001; } set { _treasure_goratrum_00001 = value; } }
  public bool Treasure_Goratrum_00002 { get { return _treasure_goratrum_00002; } set { _treasure_goratrum_00002 = value; } }
  public bool Treasure_Goratrum_00003 { get { return _treasure_goratrum_00003; } set { _treasure_goratrum_00003 = value; } }
  public bool Treasure_Goratrum_00004 { get { return _treasure_goratrum_00004; } set { _treasure_goratrum_00004 = value; } }
  public bool Treasure_Goratrum_00005 { get { return _treasure_goratrum_00005; } set { _treasure_goratrum_00005 = value; } }
  public bool Treasure_Goratrum_00006 { get { return _treasure_goratrum_00006; } set { _treasure_goratrum_00006 = value; } }
  public bool Treasure_Goratrum_00007 { get { return _treasure_goratrum_00007; } set { _treasure_goratrum_00007 = value; } }
  public bool Treasure_Goratrum_00008 { get { return _treasure_goratrum_00008; } set { _treasure_goratrum_00008 = value; } }
  public bool Treasure_Goratrum_00009 { get { return _treasure_goratrum_00009; } set { _treasure_goratrum_00009 = value; } }
  public bool Treasure_Goratrum_00010 { get { return _treasure_goratrum_00010; } set { _treasure_goratrum_00010 = value; } }
  public bool Treasure_Goratrum_00011 { get { return _treasure_goratrum_00011; } set { _treasure_goratrum_00011 = value; } }

  public bool Treasure_Goratrum2_00001 { get { return _treasure_goratrum2_00001; } set { _treasure_goratrum2_00001 = value; } }
  public bool Treasure_Goratrum2_00002 { get { return _treasure_goratrum2_00002; } set { _treasure_goratrum2_00002 = value; } }
  public bool Treasure_Goratrum2_00003 { get { return _treasure_goratrum2_00003; } set { _treasure_goratrum2_00003 = value; } }
  public bool Treasure_Goratrum2_00004 { get { return _treasure_goratrum2_00004; } set { _treasure_goratrum2_00004 = value; } }

  public bool Treasure_MysticForest_00001 { get { return _treasure_mysticforest_00001; } set { _treasure_mysticforest_00001 = value; } }
  public bool Treasure_MysticForest_00002 { get { return _treasure_mysticforest_00002; } set { _treasure_mysticforest_00002 = value; } }
  public bool Treasure_MysticForest_00003 { get { return _treasure_mysticforest_00003; } set { _treasure_mysticforest_00003 = value; } }
  public bool Treasure_MysticForest_00004 { get { return _treasure_mysticforest_00004; } set { _treasure_mysticforest_00004 = value; } }
  public bool Treasure_MysticForest_00005 { get { return _treasure_mysticforest_00005; } set { _treasure_mysticforest_00005 = value; } }
  public bool Treasure_MysticForest_00006 { get { return _treasure_mysticforest_00006; } set { _treasure_mysticforest_00006 = value; } }
  public bool Treasure_MysticForest_00007 { get { return _treasure_mysticforest_00007; } set { _treasure_mysticforest_00007 = value; } }
  public bool Treasure_MysticForest_00008 { get { return _treasure_mysticforest_00008; } set { _treasure_mysticforest_00008 = value; } }
  public bool Treasure_MysticForest_00009 { get { return _treasure_mysticforest_00009; } set { _treasure_mysticforest_00009 = value; } }
  public bool Treasure_MysticForest_00010 { get { return _treasure_mysticforest_00010; } set { _treasure_mysticforest_00010 = value; } }
  public bool Treasure_MysticForest_00011 { get { return _treasure_mysticforest_00011; } set { _treasure_mysticforest_00011 = value; } }
  public bool Treasure_MysticForest_00012 { get { return _treasure_mysticforest_00012; } set { _treasure_mysticforest_00012 = value; } }
  public bool Treasure_MysticForest_00013 { get { return _treasure_mysticforest_00013; } set { _treasure_mysticforest_00013 = value; } }
  public bool Treasure_MysticForest_00014 { get { return _treasure_mysticforest_00014; } set { _treasure_mysticforest_00014 = value; } }
  public bool Treasure_MysticForest_00015 { get { return _treasure_mysticforest_00015; } set { _treasure_mysticforest_00015 = value; } }
  public bool Treasure_MysticForest_00016 { get { return _treasure_mysticforest_00016; } set { _treasure_mysticforest_00016 = value; } }
  public bool Treasure_MysticForest_00017 { get { return _treasure_mysticforest_00017; } set { _treasure_mysticforest_00017 = value; } }
  public bool Treasure_MysticForest_00018 { get { return _treasure_mysticforest_00018; } set { _treasure_mysticforest_00018 = value; } }
  public bool Treasure_MysticForest_00019 { get { return _treasure_mysticforest_00019; } set { _treasure_mysticforest_00019 = value; } }

  public bool Treasure_Artharium_00001 { get { return _treasure_artharium_00001; } set { _treasure_artharium_00001 = value; } }
  public bool Treasure_Artharium_00002 { get { return _treasure_artharium_00002; } set { _treasure_artharium_00002 = value; } }
  public bool Treasure_Artharium_00003 { get { return _treasure_artharium_00003; } set { _treasure_artharium_00003 = value; } }
  public bool Treasure_Artharium_00004 { get { return _treasure_artharium_00004; } set { _treasure_artharium_00004 = value; } }
  public bool Treasure_Artharium_00005 { get { return _treasure_artharium_00005; } set { _treasure_artharium_00005 = value; } }
  public bool Treasure_Artharium_00006 { get { return _treasure_artharium_00006; } set { _treasure_artharium_00006 = value; } }
  public bool Treasure_Artharium_00007 { get { return _treasure_artharium_00007; } set { _treasure_artharium_00007 = value; } }
  public bool Treasure_Artharium_00008 { get { return _treasure_artharium_00008; } set { _treasure_artharium_00008 = value; } }
  public bool Treasure_Artharium_00009 { get { return _treasure_artharium_00009; } set { _treasure_artharium_00009 = value; } }
  public bool Treasure_Artharium_00010 { get { return _treasure_artharium_00010; } set { _treasure_artharium_00010 = value; } }
  public bool Treasure_Artharium_00011 { get { return _treasure_artharium_00011; } set { _treasure_artharium_00011 = value; } }
  public bool Treasure_Artharium_00012 { get { return _treasure_artharium_00012; } set { _treasure_artharium_00012 = value; } }
  public bool Treasure_Artharium_00013 { get { return _treasure_artharium_00013; } set { _treasure_artharium_00013 = value; } }
  public bool Treasure_Artharium_00014 { get { return _treasure_artharium_00014; } set { _treasure_artharium_00014 = value; } }
  public bool Treasure_Artharium_00015 { get { return _treasure_artharium_00015; } set { _treasure_artharium_00015 = value; } }
  public bool Treasure_Artharium_00016 { get { return _treasure_artharium_00016; } set { _treasure_artharium_00016 = value; } }
  public bool Treasure_Artharium_00017 { get { return _treasure_artharium_00017; } set { _treasure_artharium_00017 = value; } }
  public bool Treasure_Artharium_00018 { get { return _treasure_artharium_00018; } set { _treasure_artharium_00018 = value; } }
  public bool Treasure_Artharium_00019 { get { return _treasure_artharium_00019; } set { _treasure_artharium_00019 = value; } }
  public bool Treasure_Artharium_00020 { get { return _treasure_artharium_00020; } set { _treasure_artharium_00020 = value; } }
  public bool Treasure_Artharium_00021 { get { return _treasure_artharium_00021; } set { _treasure_artharium_00021 = value; } }
  public bool Treasure_Artharium_00022 { get { return _treasure_artharium_00022; } set { _treasure_artharium_00022 = value; } }
  public bool Treasure_Artharium_00023 { get { return _treasure_artharium_00023; } set { _treasure_artharium_00023 = value; } }
  public bool Treasure_Artharium_00024 { get { return _treasure_artharium_00024; } set { _treasure_artharium_00024 = value; } }
  public bool Treasure_Artharium_00025 { get { return _treasure_artharium_00025; } set { _treasure_artharium_00025 = value; } }
  public bool Obsidian_Artharium_00001 { get { return _obsidian_artharium_00001; } set { _obsidian_artharium_00001 = value; } }

  public bool Treasure_OhranTower_00001 { get { return _treasure_ohrantower_00001; } set { _treasure_ohrantower_00001 = value; } }
  public bool Treasure_OhranTower_00002 { get { return _treasure_ohrantower_00002; } set { _treasure_ohrantower_00002 = value; } }
  public bool Treasure_OhranTower_00003 { get { return _treasure_ohrantower_00003; } set { _treasure_ohrantower_00003 = value; } }
  public bool Treasure_OhranTower_00004 { get { return _treasure_ohrantower_00004; } set { _treasure_ohrantower_00004 = value; } }
  public bool Treasure_OhranTower_00005 { get { return _treasure_ohrantower_00005; } set { _treasure_ohrantower_00005 = value; } }
  public bool Treasure_OhranTower_00006 { get { return _treasure_ohrantower_00006; } set { _treasure_ohrantower_00006 = value; } }
  public bool Treasure_OhranTower_00007 { get { return _treasure_ohrantower_00007; } set { _treasure_ohrantower_00007 = value; } }
  public bool Treasure_OhranTower_00008 { get { return _treasure_ohrantower_00008; } set { _treasure_ohrantower_00008 = value; } }
  public bool Treasure_OhranTower_00009 { get { return _treasure_ohrantower_00009; } set { _treasure_ohrantower_00009 = value; } }
  public bool Treasure_OhranTower_00010 { get { return _treasure_ohrantower_00010; } set { _treasure_ohrantower_00010 = value; } }
  public bool Treasure_OhranTower_00011 { get { return _treasure_ohrantower_00011; } set { _treasure_ohrantower_00011 = value; } }
  public bool Treasure_OhranTower_00012 { get { return _treasure_ohrantower_00012; } set { _treasure_ohrantower_00012 = value; } }
  public bool Treasure_OhranTower_00013 { get { return _treasure_ohrantower_00013; } set { _treasure_ohrantower_00013 = value; } }
  public bool Treasure_OhranTower_00014 { get { return _treasure_ohrantower_00014; } set { _treasure_ohrantower_00014 = value; } }
  public bool Treasure_OhranTower_00015 { get { return _treasure_ohrantower_00015; } set { _treasure_ohrantower_00015 = value; } }
  public bool Treasure_OhranTower_00016 { get { return _treasure_ohrantower_00016; } set { _treasure_ohrantower_00016 = value; } }
  public bool Treasure_OhranTower_00017 { get { return _treasure_ohrantower_00017; } set { _treasure_ohrantower_00017 = value; } }
  public bool Treasure_OhranTower_00018 { get { return _treasure_ohrantower_00018; } set { _treasure_ohrantower_00018 = value; } }
  public bool Treasure_OhranTower_00019 { get { return _treasure_ohrantower_00019; } set { _treasure_ohrantower_00019 = value; } }
  public bool Treasure_OhranTower_00020 { get { return _treasure_ohrantower_00020; } set { _treasure_ohrantower_00020 = value; } }
  public bool Treasure_OhranTower_00021 { get { return _treasure_ohrantower_00021; } set { _treasure_ohrantower_00021 = value; } }
  public bool Treasure_OhranTower_00022 { get { return _treasure_ohrantower_00022; } set { _treasure_ohrantower_00022 = value; } }
  public bool Treasure_OhranTower_00023 { get { return _treasure_ohrantower_00023; } set { _treasure_ohrantower_00023 = value; } }
  public bool Treasure_OhranTower_00024 { get { return _treasure_ohrantower_00024; } set { _treasure_ohrantower_00024 = value; } }
  public bool Treasure_OhranTower_00025 { get { return _treasure_ohrantower_00025; } set { _treasure_ohrantower_00025 = value; } }
  public bool Treasure_OhranTower_00026 { get { return _treasure_ohrantower_00026; } set { _treasure_ohrantower_00026 = value; } }
  public bool Treasure_OhranTower_00027 { get { return _treasure_ohrantower_00027; } set { _treasure_ohrantower_00027 = value; } }
  public bool Treasure_OhranTower_00028 { get { return _treasure_ohrantower_00028; } set { _treasure_ohrantower_00028 = value; } }
  public bool Treasure_OhranTower_00029 { get { return _treasure_ohrantower_00029; } set { _treasure_ohrantower_00029 = value; } }
  public bool Treasure_OhranTower_00030 { get { return _treasure_ohrantower_00030; } set { _treasure_ohrantower_00030 = value; } }
  public bool Treasure_OhranTower_00031 { get { return _treasure_ohrantower_00031; } set { _treasure_ohrantower_00031 = value; } }
  public bool Treasure_OhranTower_00032 { get { return _treasure_ohrantower_00032; } set { _treasure_ohrantower_00032 = value; } }
  public bool Treasure_OhranTower_00033 { get { return _treasure_ohrantower_00033; } set { _treasure_ohrantower_00033 = value; } }
  public bool Treasure_OhranTower_00034 { get { return _treasure_ohrantower_00034; } set { _treasure_ohrantower_00034 = value; } }
  public bool Treasure_OhranTower_00035 { get { return _treasure_ohrantower_00035; } set { _treasure_ohrantower_00035 = value; } }
  public bool Treasure_OhranTower_00036 { get { return _treasure_ohrantower_00036; } set { _treasure_ohrantower_00036 = value; } }
  public bool Treasure_OhranTower_00037 { get { return _treasure_ohrantower_00037; } set { _treasure_ohrantower_00037 = value; } }
  #endregion

  #region "etc"
  [SerializeField] protected bool _fieldobject_EsmiliaGrassField_00001 = false;
  [SerializeField] protected bool _fieldobject_EsmiliaGrassField_00002 = false;
  [SerializeField] protected bool _fieldobject_EsmiliaGrassField_00003 = false;
  [SerializeField] protected bool _fieldobject_EsmiliaGrassField_00007 = false;
  [SerializeField] protected bool _fieldobject_EsmiliaGrassField_00008 = false;
  [SerializeField] protected bool _fieldobject_EsmiliaGrassField_00009 = false;
  public bool FieldObject_EsmiliaGrassField_00001 { get { return _fieldobject_EsmiliaGrassField_00001; } set { _fieldobject_EsmiliaGrassField_00001 = value; } }
  public bool FieldObject_EsmiliaGrassField_00002 { get { return _fieldobject_EsmiliaGrassField_00002; } set { _fieldobject_EsmiliaGrassField_00002 = value; } }
  public bool FieldObject_EsmiliaGrassField_00003 { get { return _fieldobject_EsmiliaGrassField_00003; } set { _fieldobject_EsmiliaGrassField_00003 = value; } }
  public bool FieldObject_EsmiliaGrassField_00007 { get { return _fieldobject_EsmiliaGrassField_00007; } set { _fieldobject_EsmiliaGrassField_00007 = value; } }
  public bool FieldObject_EsmiliaGrassField_00008 { get { return _fieldobject_EsmiliaGrassField_00008; } set { _fieldobject_EsmiliaGrassField_00008 = value; } }
  public bool FieldObject_EsmiliaGrassField_00009 { get { return _fieldobject_EsmiliaGrassField_00009; } set { _fieldobject_EsmiliaGrassField_00009 = value; } }

  [SerializeField] protected bool _fieldobject_goratrum_00001 = false;
  [SerializeField] protected bool _fieldobject_goratrum_00002 = false;
  [SerializeField] protected bool _fieldobject_goratrum_00003 = false;
  public bool FieldObject_Goratrum_00001 { get { return _fieldobject_goratrum_00001; } set { _fieldobject_goratrum_00001 = value; } }
  public bool FieldObject_Goratrum_00002 { get { return _fieldobject_goratrum_00002; } set { _fieldobject_goratrum_00002 = value; } }
  public bool FieldObject_Goratrum_00003 { get { return _fieldobject_goratrum_00003; } set { _fieldobject_goratrum_00003 = value; } }

  [SerializeField] protected bool _fieldobject_mysticforest_00001 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00002 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00003 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00004 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00005 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00006 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00007 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00008 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00009 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00010 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00011 = false;
  [SerializeField] protected bool _fieldobject_mysticforest_00012 = false;
  public bool FieldObject_MysticForest_00001 { get { return _fieldobject_mysticforest_00001; } set { _fieldobject_mysticforest_00001 = value; } }
  public bool FieldObject_MysticForest_00002 { get { return _fieldobject_mysticforest_00002; } set { _fieldobject_mysticforest_00002 = value; } }
  public bool FieldObject_MysticForest_00003 { get { return _fieldobject_mysticforest_00003; } set { _fieldobject_mysticforest_00003 = value; } }
  public bool FieldObject_MysticForest_00004 { get { return _fieldobject_mysticforest_00004; } set { _fieldobject_mysticforest_00004 = value; } }
  public bool FieldObject_MysticForest_00005 { get { return _fieldobject_mysticforest_00005; } set { _fieldobject_mysticforest_00005 = value; } }
  public bool FieldObject_MysticForest_00006 { get { return _fieldobject_mysticforest_00006; } set { _fieldobject_mysticforest_00006 = value; } }
  public bool FieldObject_MysticForest_00007 { get { return _fieldobject_mysticforest_00007; } set { _fieldobject_mysticforest_00007 = value; } }
  public bool FieldObject_MysticForest_00008 { get { return _fieldobject_mysticforest_00008; } set { _fieldobject_mysticforest_00008 = value; } }
  public bool FieldObject_MysticForest_00009 { get { return _fieldobject_mysticforest_00009; } set { _fieldobject_mysticforest_00009 = value; } }
  public bool FieldObject_MysticForest_00010 { get { return _fieldobject_mysticforest_00010; } set { _fieldobject_mysticforest_00010 = value; } }
  public bool FieldObject_MysticForest_00011 { get { return _fieldobject_mysticforest_00011; } set { _fieldobject_mysticforest_00011 = value; } }
  public bool FieldObject_MysticForest_00012 { get { return _fieldobject_mysticforest_00012; } set { _fieldobject_mysticforest_00012 = value; } }

  [SerializeField] protected bool _fieldobject_artharium_00001 = false;
  [SerializeField] protected bool _fieldobject_artharium_00002 = false;
  [SerializeField] protected bool _fieldobject_artharium_00003 = false;
  [SerializeField] protected bool _fieldobject_artharium_00004 = false;
  [SerializeField] protected bool _fieldobject_artharium_00005 = false;
  [SerializeField] protected bool _fieldobject_artharium_00006 = false;
  [SerializeField] protected bool _fieldobject_artharium_00007 = false;
  [SerializeField] protected bool _fieldobject_artharium_00008 = false;
  [SerializeField] protected bool _fieldobject_artharium_00009 = false;
  [SerializeField] protected bool _fieldobject_artharium_00010 = false;
  public bool FieldObject_Artharium_00001 { get { return _fieldobject_artharium_00001; } set { _fieldobject_artharium_00001 = value; } }
  public bool FieldObject_Artharium_00002 { get { return _fieldobject_artharium_00002; } set { _fieldobject_artharium_00002 = value; } }
  public bool FieldObject_Artharium_00003 { get { return _fieldobject_artharium_00003; } set { _fieldobject_artharium_00003 = value; } }
  public bool FieldObject_Artharium_00004 { get { return _fieldobject_artharium_00004; } set { _fieldobject_artharium_00004 = value; } }
  public bool FieldObject_Artharium_00005 { get { return _fieldobject_artharium_00005; } set { _fieldobject_artharium_00005 = value; } }
  public bool FieldObject_Artharium_00006 { get { return _fieldobject_artharium_00006; } set { _fieldobject_artharium_00006 = value; } }
  public bool FieldObject_Artharium_00007 { get { return _fieldobject_artharium_00007; } set { _fieldobject_artharium_00007 = value; } }
  public bool FieldObject_Artharium_00008 { get { return _fieldobject_artharium_00008; } set { _fieldobject_artharium_00008 = value; } }
  public bool FieldObject_Artharium_00009 { get { return _fieldobject_artharium_00009; } set { _fieldobject_artharium_00009 = value; } }
  public bool FieldObject_Artharium_00010 { get { return _fieldobject_artharium_00010; } set { _fieldobject_artharium_00010 = value; } }

  protected bool _defeat_screaming_rafflesia = false;
  public bool DefeatScreamingRafflesia { get { return _defeat_screaming_rafflesia; } set { _defeat_screaming_rafflesia = value; } }

  protected bool _defeat_magical_hail_gun = false;
  public bool DefeatMagicalHailGun { get { return _defeat_magical_hail_gun; } set { _defeat_magical_hail_gun = value; } }

  protected bool _defeat_hell_kerberos = false;
  public bool DefeatHellKerberos { get { return _defeat_hell_kerberos; } set { _defeat_hell_kerberos = value; } }

  protected bool _defeat_galvadazer = false;
  protected bool _defeat_yodirian = false;
  public bool DefeatGalvadazer { get { return _defeat_galvadazer; } set { _defeat_galvadazer = value; } }
  public bool DefeatYodirian { get { return _defeat_yodirian; } set { _defeat_yodirian = value; } }

  protected bool _defeat_flansis_queen_of_verdant = false;
  public bool DefeatFlansisQueenOfVerdant { get { return _defeat_flansis_queen_of_verdant; } set { _defeat_flansis_queen_of_verdant = value; } }

  protected bool _defeat_light_thunder_lancebolts = false;
  public bool DefeatLightThunderLancebolts { get { return _defeat_light_thunder_lancebolts; } set { _defeat_light_thunder_lancebolts = value; } }

  protected bool _defeat_selmoi_ro = false;
  public bool DefeatSelmoiRo { get { return _defeat_selmoi_ro; } set { _defeat_selmoi_ro = value; } }

  protected bool _defeat_death_flodiete = false;
  public bool DefeatDeathFlodiete { get { return _defeat_death_flodiete; } set { _defeat_death_flodiete = value; } }

  protected bool _defeat_bighand_kraken = false;
  public bool DefeatBighandKraken { get { return _defeat_bighand_kraken; } set { _defeat_bighand_kraken = value; } }

  protected bool _defeat_brilliant_sea_prince = false;
  public bool DefeatBrilliantSeaPrince { get { return _defeat_brilliant_sea_prince; } set { _defeat_brilliant_sea_prince = value; } }

  protected bool _defeat_shell_sword_knight = false;
  public bool DefeatShellSwordKnight { get { return _defeat_shell_sword_knight; } set { _defeat_shell_sword_knight = value; } }

  protected bool _defeat_aegiru_amara = false;
  public bool DefeatAegiruAmara { get { return _defeat_aegiru_amara; } set { _defeat_aegiru_amara = value; } }

  protected bool _defeat_origin_star_coral_queen = false;
  public bool DefeatOriginStarCoralQueen { get { return _defeat_origin_star_coral_queen; } set { _defeat_origin_star_coral_queen = value; } }

  protected bool _defeat_bluered_eye = false;
  public bool DefeatBlueRedEye { get { return _defeat_bluered_eye; } set { _defeat_bluered_eye = value; } }

  protected bool _defeat_leviathan = false;
  public bool DefeatLeviathan { get { return _defeat_leviathan; } set { _defeat_leviathan = value; } }

  protected bool _defeat_kingofvelgus = false;
  public bool DefeatKingOfVelgus { get { return _defeat_kingofvelgus; } set { _defeat_kingofvelgus = value; } }

  protected bool _defeat_eone_fulnea = false;
  public bool DefeatEoneFulnea { get { return _defeat_eone_fulnea; } set { _defeat_eone_fulnea = value; } }

  [SerializeField] protected bool _location_player2 = false;
  public bool LocationPlayer2 { get { return _location_player2; } set { _location_player2 = value; } }

  protected bool _fieldobject_ohrantower_00001 = false;
  protected bool _fieldobject_ohrantower_00002 = false;
  protected bool _fieldobject_ohrantower_00003 = false;
  protected bool _fieldobject_ohrantower_00004 = false;
  protected bool _fieldobject_ohrantower_00005 = false;
  protected bool _fieldobject_ohrantower_00006 = false;
  protected bool _fieldobject_ohrantower_00007 = false;
  protected bool _fieldobject_ohrantower_00008 = false;
  protected bool _fieldobject_ohrantower_00009 = false;
  protected bool _fieldobject_ohrantower_00010 = false;
  protected bool _fieldobject_ohrantower_00011 = false;
  protected bool _fieldobject_ohrantower_00012 = false;
  protected bool _fieldobject_ohrantower_00013 = false;
  protected bool _fieldobject_ohrantower_00014 = false;
  protected bool _fieldobject_ohrantower_00015 = false;
  protected bool _fieldobject_ohrantower_00016 = false;
  protected bool _fieldobject_ohrantower_00017 = false;
  protected bool _fieldobject_ohrantower_00018 = false;
  protected bool _fieldobject_ohrantower_00019 = false;
  protected bool _fieldobject_ohrantower_00020 = false;
  protected bool _fieldobject_ohrantower_00021 = false;
  protected bool _fieldobject_ohrantower_00022 = false;
  protected bool _fieldobject_ohrantower_00023 = false;
  protected bool _fieldobject_ohrantower_00024 = false;
  protected bool _fieldobject_ohrantower_00025 = false;
  protected bool _fieldobject_ohrantower_00026 = false;
  protected bool _fieldobject_ohrantower_00027 = false;
  protected bool _fieldobject_ohrantower_00028 = false;
  protected bool _fieldobject_ohrantower_00029 = false;
  protected bool _fieldobject_ohrantower_00030 = false;
  protected bool _fieldobject_ohrantower_00031 = false;
  protected bool _fieldobject_ohrantower_00032 = false;
  protected bool _fieldobject_ohrantower_00033 = false;
  protected bool _fieldobject_ohrantower_00034 = false;
  protected bool _fieldobject_ohrantower_00035 = false;
  protected bool _fieldobject_ohrantower_00036 = false;
  protected bool _fieldobject_ohrantower_00037 = false;
  protected bool _fieldobject_ohrantower_00038 = false;
  protected bool _fieldobject_ohrantower_00039 = false;
  protected bool _fieldobject_ohrantower_00040 = false;
  protected bool _fieldobject_ohrantower_00041 = false;
  protected bool _fieldobject_ohrantower_00042 = false;
  protected bool _fieldobject_ohrantower_00043 = false;
  protected bool _fieldobject_ohrantower_00044 = false;
  protected bool _fieldobject_ohrantower_00045 = false;
  protected bool _fieldobject_ohrantower_00046 = false;
  protected bool _fieldobject_ohrantower_00047 = false;
  protected bool _fieldobject_ohrantower_00048 = false;
  protected bool _fieldobject_ohrantower_00049 = false;
  protected bool _fieldobject_ohrantower_00050 = false;
  protected bool _fieldobject_ohrantower_00051 = false;
  protected bool _fieldobject_ohrantower_00052 = false;
  protected bool _fieldobject_ohrantower_00053 = false;
  protected bool _fieldobject_ohrantower_00054 = false;
  protected bool _fieldobject_ohrantower_00055 = false;
  protected bool _fieldobject_ohrantower_00056 = false;
  protected bool _fieldobject_ohrantower_00057 = false;
  protected bool _fieldobject_ohrantower_00058 = false;
  protected bool _fieldobject_ohrantower_00059 = false;
  protected bool _fieldobject_ohrantower_00060 = false;
  protected bool _fieldobject_ohrantower_00061 = false;
  protected bool _fieldobject_ohrantower_00062 = false;
  protected bool _fieldobject_ohrantower_00063 = false;
  protected bool _fieldobject_ohrantower_00064 = false;
  protected bool _fieldobject_ohrantower_00065 = false;
  protected bool _fieldobject_ohrantower_00066 = false;
  protected bool _fieldobject_ohrantower_00067 = false;
  protected bool _fieldobject_ohrantower_00068 = false;
  protected bool _fieldobject_ohrantower_00069 = false;
  protected bool _fieldobject_ohrantower_00070 = false;
  protected bool _fieldobject_ohrantower_00071 = false;
  protected bool _fieldobject_ohrantower_00072 = false;
  protected bool _fieldobject_ohrantower_00073 = false;
  protected bool _fieldobject_ohrantower_00074 = false;
  protected bool _fieldobject_ohrantower_00075 = false;
  protected bool _fieldobject_ohrantower_00076 = false;
  protected bool _fieldobject_ohrantower_00077 = false;
  protected bool _fieldobject_ohrantower_00078 = false;
  protected bool _fieldobject_ohrantower_00079 = false;
  protected bool _fieldobject_ohrantower_00080 = false;
  protected bool _fieldobject_ohrantower_00081 = false;
  protected bool _fieldobject_ohrantower_00082 = false;
  protected bool _fieldobject_ohrantower_00083 = false;
  protected bool _fieldobject_ohrantower_00084 = false;
  protected bool _fieldobject_ohrantower_00085 = false;
  protected bool _fieldobject_ohrantower_00086 = false;
  protected bool _fieldobject_ohrantower_00087 = false;
  protected bool _fieldobject_ohrantower_00088 = false;
  protected bool _fieldobject_ohrantower_00089 = false;
  protected bool _fieldobject_ohrantower_00090 = false;
  protected bool _fieldobject_ohrantower_00091 = false;
  protected bool _fieldobject_ohrantower_00092 = false;
  protected bool _fieldobject_ohrantower_00093 = false;
  protected bool _fieldobject_ohrantower_00094 = false;
  protected bool _fieldobject_ohrantower_00095 = false;
  protected bool _fieldobject_ohrantower_00096 = false;
  protected bool _fieldobject_ohrantower_00097 = false;
  protected bool _fieldobject_ohrantower_00098 = false;
  protected bool _fieldobject_ohrantower_00099 = false;
  protected bool _fieldobject_ohrantower_00100 = false;
  protected bool _fieldobject_ohrantower_00101 = false;
  protected bool _fieldobject_ohrantower_00102 = false;
  protected bool _fieldobject_ohrantower_00103 = false;
  protected bool _fieldobject_ohrantower_00104 = false;
  protected bool _fieldobject_ohrantower_00105 = false;
  protected bool _fieldobject_ohrantower_00106 = false;
  protected bool _fieldobject_ohrantower_00107 = false;
  protected bool _fieldobject_ohrantower_00108 = false;
  protected bool _fieldobject_ohrantower_00109 = false;
  protected bool _fieldobject_ohrantower_00110 = false;
  protected bool _fieldobject_ohrantower_00111 = false;
  protected bool _fieldobject_ohrantower_00112 = false;
  protected bool _fieldobject_ohrantower_00113 = false;
  protected bool _fieldobject_ohrantower_00114 = false;
  protected bool _fieldobject_ohrantower_00115 = false;
  protected bool _fieldobject_ohrantower_00116 = false;
  protected bool _fieldobject_ohrantower_00117 = false;
  protected bool _fieldobject_ohrantower_00118 = false;
  protected bool _fieldobject_ohrantower_00119 = false;
  protected bool _fieldobject_ohrantower_00120 = false;
  protected bool _fieldobject_ohrantower_00121 = false;
  protected bool _fieldobject_ohrantower_00122 = false;
  protected bool _fieldobject_ohrantower_00123 = false;
  protected bool _fieldobject_ohrantower_00124 = false;
  protected bool _fieldobject_ohrantower_00125 = false;
  protected bool _fieldobject_ohrantower_00126 = false;
  protected bool _fieldobject_ohrantower_00127 = false;
  protected bool _fieldobject_ohrantower_00128 = false;
  protected bool _fieldobject_ohrantower_00129 = false;
  public bool FieldObject_OhranTower_00001 { get { return _fieldobject_ohrantower_00001; } set { _fieldobject_ohrantower_00001 = value; } }
  public bool FieldObject_OhranTower_00002 { get { return _fieldobject_ohrantower_00002; } set { _fieldobject_ohrantower_00002 = value; } }
  public bool FieldObject_OhranTower_00003 { get { return _fieldobject_ohrantower_00003; } set { _fieldobject_ohrantower_00003 = value; } }
  public bool FieldObject_OhranTower_00004 { get { return _fieldobject_ohrantower_00004; } set { _fieldobject_ohrantower_00004 = value; } }
  public bool FieldObject_OhranTower_00005 { get { return _fieldobject_ohrantower_00005; } set { _fieldobject_ohrantower_00005 = value; } }
  public bool FieldObject_OhranTower_00006 { get { return _fieldobject_ohrantower_00006; } set { _fieldobject_ohrantower_00006 = value; } }
  public bool FieldObject_OhranTower_00007 { get { return _fieldobject_ohrantower_00007; } set { _fieldobject_ohrantower_00007 = value; } }
  public bool FieldObject_OhranTower_00008 { get { return _fieldobject_ohrantower_00008; } set { _fieldobject_ohrantower_00008 = value; } }
  public bool FieldObject_OhranTower_00009 { get { return _fieldobject_ohrantower_00009; } set { _fieldobject_ohrantower_00009 = value; } }
  public bool FieldObject_OhranTower_00010 { get { return _fieldobject_ohrantower_00010; } set { _fieldobject_ohrantower_00010 = value; } }
  public bool FieldObject_OhranTower_00011 { get { return _fieldobject_ohrantower_00011; } set { _fieldobject_ohrantower_00011 = value; } }
  public bool FieldObject_OhranTower_00012 { get { return _fieldobject_ohrantower_00012; } set { _fieldobject_ohrantower_00012 = value; } }
  public bool FieldObject_OhranTower_00013 { get { return _fieldobject_ohrantower_00013; } set { _fieldobject_ohrantower_00013 = value; } }
  public bool FieldObject_OhranTower_00014 { get { return _fieldobject_ohrantower_00014; } set { _fieldobject_ohrantower_00014 = value; } }
  public bool FieldObject_OhranTower_00015 { get { return _fieldobject_ohrantower_00015; } set { _fieldobject_ohrantower_00015 = value; } }
  public bool FieldObject_OhranTower_00016 { get { return _fieldobject_ohrantower_00016; } set { _fieldobject_ohrantower_00016 = value; } }
  public bool FieldObject_OhranTower_00017 { get { return _fieldobject_ohrantower_00017; } set { _fieldobject_ohrantower_00017 = value; } }
  public bool FieldObject_OhranTower_00018 { get { return _fieldobject_ohrantower_00018; } set { _fieldobject_ohrantower_00018 = value; } }
  public bool FieldObject_OhranTower_00019 { get { return _fieldobject_ohrantower_00019; } set { _fieldobject_ohrantower_00019 = value; } }
  public bool FieldObject_OhranTower_00020 { get { return _fieldobject_ohrantower_00020; } set { _fieldobject_ohrantower_00020 = value; } }
  public bool FieldObject_OhranTower_00021 { get { return _fieldobject_ohrantower_00021; } set { _fieldobject_ohrantower_00021 = value; } }
  public bool FieldObject_OhranTower_00022 { get { return _fieldobject_ohrantower_00022; } set { _fieldobject_ohrantower_00022 = value; } }
  public bool FieldObject_OhranTower_00023 { get { return _fieldobject_ohrantower_00023; } set { _fieldobject_ohrantower_00023 = value; } }
  public bool FieldObject_OhranTower_00024 { get { return _fieldobject_ohrantower_00024; } set { _fieldobject_ohrantower_00024 = value; } }
  public bool FieldObject_OhranTower_00025 { get { return _fieldobject_ohrantower_00025; } set { _fieldobject_ohrantower_00025 = value; } }
  public bool FieldObject_OhranTower_00026 { get { return _fieldobject_ohrantower_00026; } set { _fieldobject_ohrantower_00026 = value; } }
  public bool FieldObject_OhranTower_00027 { get { return _fieldobject_ohrantower_00027; } set { _fieldobject_ohrantower_00027 = value; } }
  public bool FieldObject_OhranTower_00028 { get { return _fieldobject_ohrantower_00028; } set { _fieldobject_ohrantower_00028 = value; } }
  public bool FieldObject_OhranTower_00029 { get { return _fieldobject_ohrantower_00029; } set { _fieldobject_ohrantower_00029 = value; } }
  public bool FieldObject_OhranTower_00030 { get { return _fieldobject_ohrantower_00030; } set { _fieldobject_ohrantower_00030 = value; } }
  public bool FieldObject_OhranTower_00031 { get { return _fieldobject_ohrantower_00031; } set { _fieldobject_ohrantower_00031 = value; } }
  public bool FieldObject_OhranTower_00032 { get { return _fieldobject_ohrantower_00032; } set { _fieldobject_ohrantower_00032 = value; } }
  public bool FieldObject_OhranTower_00033 { get { return _fieldobject_ohrantower_00033; } set { _fieldobject_ohrantower_00033 = value; } }
  public bool FieldObject_OhranTower_00034 { get { return _fieldobject_ohrantower_00034; } set { _fieldobject_ohrantower_00034 = value; } }
  public bool FieldObject_OhranTower_00035 { get { return _fieldobject_ohrantower_00035; } set { _fieldobject_ohrantower_00035 = value; } }
  public bool FieldObject_OhranTower_00036 { get { return _fieldobject_ohrantower_00036; } set { _fieldobject_ohrantower_00036 = value; } }
  public bool FieldObject_OhranTower_00037 { get { return _fieldobject_ohrantower_00037; } set { _fieldobject_ohrantower_00037 = value; } }
  public bool FieldObject_OhranTower_00038 { get { return _fieldobject_ohrantower_00038; } set { _fieldobject_ohrantower_00038 = value; } }
  public bool FieldObject_OhranTower_00039 { get { return _fieldobject_ohrantower_00039; } set { _fieldobject_ohrantower_00039 = value; } }
  public bool FieldObject_OhranTower_00040 { get { return _fieldobject_ohrantower_00040; } set { _fieldobject_ohrantower_00040 = value; } }
  public bool FieldObject_OhranTower_00041 { get { return _fieldobject_ohrantower_00041; } set { _fieldobject_ohrantower_00041 = value; } }
  public bool FieldObject_OhranTower_00042 { get { return _fieldobject_ohrantower_00042; } set { _fieldobject_ohrantower_00042 = value; } }
  public bool FieldObject_OhranTower_00043 { get { return _fieldobject_ohrantower_00043; } set { _fieldobject_ohrantower_00043 = value; } }
  public bool FieldObject_OhranTower_00044 { get { return _fieldobject_ohrantower_00044; } set { _fieldobject_ohrantower_00044 = value; } }
  public bool FieldObject_OhranTower_00045 { get { return _fieldobject_ohrantower_00045; } set { _fieldobject_ohrantower_00045 = value; } }
  public bool FieldObject_OhranTower_00046 { get { return _fieldobject_ohrantower_00046; } set { _fieldobject_ohrantower_00046 = value; } }
  public bool FieldObject_OhranTower_00047 { get { return _fieldobject_ohrantower_00047; } set { _fieldobject_ohrantower_00047 = value; } }
  public bool FieldObject_OhranTower_00048 { get { return _fieldobject_ohrantower_00048; } set { _fieldobject_ohrantower_00048 = value; } }
  public bool FieldObject_OhranTower_00049 { get { return _fieldobject_ohrantower_00049; } set { _fieldobject_ohrantower_00049 = value; } }
  public bool FieldObject_OhranTower_00050 { get { return _fieldobject_ohrantower_00050; } set { _fieldobject_ohrantower_00050 = value; } }
  public bool FieldObject_OhranTower_00051 { get { return _fieldobject_ohrantower_00051; } set { _fieldobject_ohrantower_00051 = value; } }
  public bool FieldObject_OhranTower_00052 { get { return _fieldobject_ohrantower_00052; } set { _fieldobject_ohrantower_00052 = value; } }
  public bool FieldObject_OhranTower_00053 { get { return _fieldobject_ohrantower_00053; } set { _fieldobject_ohrantower_00053 = value; } }
  public bool FieldObject_OhranTower_00054 { get { return _fieldobject_ohrantower_00054; } set { _fieldobject_ohrantower_00054 = value; } }
  public bool FieldObject_OhranTower_00055 { get { return _fieldobject_ohrantower_00055; } set { _fieldobject_ohrantower_00055 = value; } }
  public bool FieldObject_OhranTower_00056 { get { return _fieldobject_ohrantower_00056; } set { _fieldobject_ohrantower_00056 = value; } }
  public bool FieldObject_OhranTower_00057 { get { return _fieldobject_ohrantower_00057; } set { _fieldobject_ohrantower_00057 = value; } }
  public bool FieldObject_OhranTower_00058 { get { return _fieldobject_ohrantower_00058; } set { _fieldobject_ohrantower_00058 = value; } }
  public bool FieldObject_OhranTower_00059 { get { return _fieldobject_ohrantower_00059; } set { _fieldobject_ohrantower_00059 = value; } }
  public bool FieldObject_OhranTower_00060 { get { return _fieldobject_ohrantower_00060; } set { _fieldobject_ohrantower_00060 = value; } }
  public bool FieldObject_OhranTower_00061 { get { return _fieldobject_ohrantower_00061; } set { _fieldobject_ohrantower_00061 = value; } }
  public bool FieldObject_OhranTower_00062 { get { return _fieldobject_ohrantower_00062; } set { _fieldobject_ohrantower_00062 = value; } }
  public bool FieldObject_OhranTower_00063 { get { return _fieldobject_ohrantower_00063; } set { _fieldobject_ohrantower_00063 = value; } }
  public bool FieldObject_OhranTower_00064 { get { return _fieldobject_ohrantower_00064; } set { _fieldobject_ohrantower_00064 = value; } }
  public bool FieldObject_OhranTower_00065 { get { return _fieldobject_ohrantower_00065; } set { _fieldobject_ohrantower_00065 = value; } }
  public bool FieldObject_OhranTower_00066 { get { return _fieldobject_ohrantower_00066; } set { _fieldobject_ohrantower_00066 = value; } }
  public bool FieldObject_OhranTower_00067 { get { return _fieldobject_ohrantower_00067; } set { _fieldobject_ohrantower_00067 = value; } }
  public bool FieldObject_OhranTower_00068 { get { return _fieldobject_ohrantower_00068; } set { _fieldobject_ohrantower_00068 = value; } }
  public bool FieldObject_OhranTower_00069 { get { return _fieldobject_ohrantower_00069; } set { _fieldobject_ohrantower_00069 = value; } }
  public bool FieldObject_OhranTower_00070 { get { return _fieldobject_ohrantower_00070; } set { _fieldobject_ohrantower_00070 = value; } }
  public bool FieldObject_OhranTower_00071 { get { return _fieldobject_ohrantower_00071; } set { _fieldobject_ohrantower_00071 = value; } }
  public bool FieldObject_OhranTower_00072 { get { return _fieldobject_ohrantower_00072; } set { _fieldobject_ohrantower_00072 = value; } }
  public bool FieldObject_OhranTower_00073 { get { return _fieldobject_ohrantower_00073; } set { _fieldobject_ohrantower_00073 = value; } }
  public bool FieldObject_OhranTower_00074 { get { return _fieldobject_ohrantower_00074; } set { _fieldobject_ohrantower_00074 = value; } }
  public bool FieldObject_OhranTower_00075 { get { return _fieldobject_ohrantower_00075; } set { _fieldobject_ohrantower_00075 = value; } }
  public bool FieldObject_OhranTower_00076 { get { return _fieldobject_ohrantower_00076; } set { _fieldobject_ohrantower_00076 = value; } }
  public bool FieldObject_OhranTower_00077 { get { return _fieldobject_ohrantower_00077; } set { _fieldobject_ohrantower_00077 = value; } }
  public bool FieldObject_OhranTower_00078 { get { return _fieldobject_ohrantower_00078; } set { _fieldobject_ohrantower_00078 = value; } }
  public bool FieldObject_OhranTower_00079 { get { return _fieldobject_ohrantower_00079; } set { _fieldobject_ohrantower_00079 = value; } }
  public bool FieldObject_OhranTower_00080 { get { return _fieldobject_ohrantower_00080; } set { _fieldobject_ohrantower_00080 = value; } }
  public bool FieldObject_OhranTower_00081 { get { return _fieldobject_ohrantower_00081; } set { _fieldobject_ohrantower_00081 = value; } }
  public bool FieldObject_OhranTower_00082 { get { return _fieldobject_ohrantower_00082; } set { _fieldobject_ohrantower_00082 = value; } }
  public bool FieldObject_OhranTower_00083 { get { return _fieldobject_ohrantower_00083; } set { _fieldobject_ohrantower_00083 = value; } }
  public bool FieldObject_OhranTower_00084 { get { return _fieldobject_ohrantower_00084; } set { _fieldobject_ohrantower_00084 = value; } }
  public bool FieldObject_OhranTower_00085 { get { return _fieldobject_ohrantower_00085; } set { _fieldobject_ohrantower_00085 = value; } }
  public bool FieldObject_OhranTower_00086 { get { return _fieldobject_ohrantower_00086; } set { _fieldobject_ohrantower_00086 = value; } }
  public bool FieldObject_OhranTower_00087 { get { return _fieldobject_ohrantower_00087; } set { _fieldobject_ohrantower_00087 = value; } }
  public bool FieldObject_OhranTower_00088 { get { return _fieldobject_ohrantower_00088; } set { _fieldobject_ohrantower_00088 = value; } }
  public bool FieldObject_OhranTower_00089 { get { return _fieldobject_ohrantower_00089; } set { _fieldobject_ohrantower_00089 = value; } }
  public bool FieldObject_OhranTower_00090 { get { return _fieldobject_ohrantower_00090; } set { _fieldobject_ohrantower_00090 = value; } }
  public bool FieldObject_OhranTower_00091 { get { return _fieldobject_ohrantower_00091; } set { _fieldobject_ohrantower_00091 = value; } }
  public bool FieldObject_OhranTower_00092 { get { return _fieldobject_ohrantower_00092; } set { _fieldobject_ohrantower_00092 = value; } }
  public bool FieldObject_OhranTower_00093 { get { return _fieldobject_ohrantower_00093; } set { _fieldobject_ohrantower_00093 = value; } }
  public bool FieldObject_OhranTower_00094 { get { return _fieldobject_ohrantower_00094; } set { _fieldobject_ohrantower_00094 = value; } }
  public bool FieldObject_OhranTower_00095 { get { return _fieldobject_ohrantower_00095; } set { _fieldobject_ohrantower_00095 = value; } }
  public bool FieldObject_OhranTower_00096 { get { return _fieldobject_ohrantower_00096; } set { _fieldobject_ohrantower_00096 = value; } }
  public bool FieldObject_OhranTower_00097 { get { return _fieldobject_ohrantower_00097; } set { _fieldobject_ohrantower_00097 = value; } }
  public bool FieldObject_OhranTower_00098 { get { return _fieldobject_ohrantower_00098; } set { _fieldobject_ohrantower_00098 = value; } }
  public bool FieldObject_OhranTower_00099 { get { return _fieldobject_ohrantower_00099; } set { _fieldobject_ohrantower_00099 = value; } }
  public bool FieldObject_OhranTower_00100 { get { return _fieldobject_ohrantower_00100; } set { _fieldobject_ohrantower_00100 = value; } }
  public bool FieldObject_OhranTower_00101 { get { return _fieldobject_ohrantower_00101; } set { _fieldobject_ohrantower_00101 = value; } }
  public bool FieldObject_OhranTower_00102 { get { return _fieldobject_ohrantower_00102; } set { _fieldobject_ohrantower_00102 = value; } }
  public bool FieldObject_OhranTower_00103 { get { return _fieldobject_ohrantower_00103; } set { _fieldobject_ohrantower_00103 = value; } }
  public bool FieldObject_OhranTower_00104 { get { return _fieldobject_ohrantower_00104; } set { _fieldobject_ohrantower_00104 = value; } }
  public bool FieldObject_OhranTower_00105 { get { return _fieldobject_ohrantower_00105; } set { _fieldobject_ohrantower_00105 = value; } }
  public bool FieldObject_OhranTower_00106 { get { return _fieldobject_ohrantower_00106; } set { _fieldobject_ohrantower_00106 = value; } }
  public bool FieldObject_OhranTower_00107 { get { return _fieldobject_ohrantower_00107; } set { _fieldobject_ohrantower_00107 = value; } }
  public bool FieldObject_OhranTower_00108 { get { return _fieldobject_ohrantower_00108; } set { _fieldobject_ohrantower_00108 = value; } }
  public bool FieldObject_OhranTower_00109 { get { return _fieldobject_ohrantower_00109; } set { _fieldobject_ohrantower_00109 = value; } }
  public bool FieldObject_OhranTower_00110 { get { return _fieldobject_ohrantower_00110; } set { _fieldobject_ohrantower_00110 = value; } }
  public bool FieldObject_OhranTower_00111 { get { return _fieldobject_ohrantower_00111; } set { _fieldobject_ohrantower_00111 = value; } }
  public bool FieldObject_OhranTower_00112 { get { return _fieldobject_ohrantower_00112; } set { _fieldobject_ohrantower_00112 = value; } }
  public bool FieldObject_OhranTower_00113 { get { return _fieldobject_ohrantower_00113; } set { _fieldobject_ohrantower_00113 = value; } }
  public bool FieldObject_OhranTower_00114 { get { return _fieldobject_ohrantower_00114; } set { _fieldobject_ohrantower_00114 = value; } }
  public bool FieldObject_OhranTower_00115 { get { return _fieldobject_ohrantower_00115; } set { _fieldobject_ohrantower_00115 = value; } }
  public bool FieldObject_OhranTower_00116 { get { return _fieldobject_ohrantower_00116; } set { _fieldobject_ohrantower_00116 = value; } }
  public bool FieldObject_OhranTower_00117 { get { return _fieldobject_ohrantower_00117; } set { _fieldobject_ohrantower_00117 = value; } }
  public bool FieldObject_OhranTower_00118 { get { return _fieldobject_ohrantower_00118; } set { _fieldobject_ohrantower_00118 = value; } }
  public bool FieldObject_OhranTower_00119 { get { return _fieldobject_ohrantower_00119; } set { _fieldobject_ohrantower_00119 = value; } }
  public bool FieldObject_OhranTower_00120 { get { return _fieldobject_ohrantower_00120; } set { _fieldobject_ohrantower_00120 = value; } }
  public bool FieldObject_OhranTower_00121 { get { return _fieldobject_ohrantower_00121; } set { _fieldobject_ohrantower_00121 = value; } }
  public bool FieldObject_OhranTower_00122 { get { return _fieldobject_ohrantower_00122; } set { _fieldobject_ohrantower_00122 = value; } }
  public bool FieldObject_OhranTower_00123 { get { return _fieldobject_ohrantower_00123; } set { _fieldobject_ohrantower_00123 = value; } }
  public bool FieldObject_OhranTower_00124 { get { return _fieldobject_ohrantower_00124; } set { _fieldobject_ohrantower_00124 = value; } }
  public bool FieldObject_OhranTower_00125 { get { return _fieldobject_ohrantower_00125; } set { _fieldobject_ohrantower_00125 = value; } }
  public bool FieldObject_OhranTower_00126 { get { return _fieldobject_ohrantower_00126; } set { _fieldobject_ohrantower_00126 = value; } }
  public bool FieldObject_OhranTower_00127 { get { return _fieldobject_ohrantower_00127; } set { _fieldobject_ohrantower_00127 = value; } }
  public bool FieldObject_OhranTower_00128 { get { return _fieldobject_ohrantower_00128; } set { _fieldobject_ohrantower_00128 = value; } }
  public bool FieldObject_OhranTower_00129 { get { return _fieldobject_ohrantower_00129; } set { _fieldobject_ohrantower_00129 = value; } }

  protected bool _fieldobject_gatedhal_00001 = false;
  protected bool _fieldobject_gatedhal_00002 = false;
  protected bool _fieldobject_gatedhal_00003 = false;
  protected bool _fieldobject_gatedhal_00004 = false;
  protected bool _fieldobject_gatedhal_00005 = false;
  public bool Fieldobject_GateDhal_00001 { get { return _fieldobject_gatedhal_00001; } set { _fieldobject_gatedhal_00001 = value; } }
  public bool Fieldobject_GateDhal_00002 { get { return _fieldobject_gatedhal_00002; } set { _fieldobject_gatedhal_00002 = value; } }
  public bool Fieldobject_GateDhal_00003 { get { return _fieldobject_gatedhal_00003; } set { _fieldobject_gatedhal_00003 = value; } }
  public bool Fieldobject_GateDhal_00004 { get { return _fieldobject_gatedhal_00004; } set { _fieldobject_gatedhal_00004 = value; } }
  public bool Fieldobject_GateDhal_00005 { get { return _fieldobject_gatedhal_00005; } set { _fieldobject_gatedhal_00005 = value; } }

  protected bool _treasure_gatedhal_00001 = false;
  protected bool _treasure_gatedhal_00002 = false;
  protected bool _treasure_gatedhal_00003 = false;
  protected bool _treasure_gatedhal_00004 = false;
  protected bool _treasure_gatedhal_00005 = false;
  protected bool _treasure_gatedhal_00006 = false;
  protected bool _treasure_gatedhal_00007 = false;
  protected bool _treasure_gatedhal_00008 = false;
  protected bool _treasure_gatedhal_00009 = false;
  protected bool _treasure_gatedhal_00010 = false;
  protected bool _treasure_gatedhal_00011 = false;
  protected bool _treasure_gatedhal_00012 = false;
  protected bool _treasure_gatedhal_00013 = false;
  protected bool _treasure_gatedhal_00014 = false;
  protected bool _treasure_gatedhal_00015 = false;
  protected bool _treasure_gatedhal_00016 = false;
  protected bool _treasure_gatedhal_00017 = false;
  protected bool _treasure_gatedhal_00018 = false;
  protected bool _treasure_gatedhal_00019 = false;
  protected bool _treasure_gatedhal_00020 = false;
  protected bool _treasure_gatedhal_00021 = false;
  protected bool _treasure_gatedhal_00022 = false;
  protected bool _treasure_gatedhal_00023 = false;
  protected bool _treasure_gatedhal_00024 = false;
  protected bool _treasure_gatedhal_00025 = false;
  protected bool _treasure_gatedhal_00026 = false;
  protected bool _treasure_gatedhal_00027 = false;
  protected bool _treasure_gatedhal_00028 = false;
  protected bool _treasure_gatedhal_00029 = false;
  protected bool _treasure_gatedhal_00030 = false;
  protected bool _treasure_gatedhal_00031 = false;
  protected bool _treasure_gatedhal_00032 = false;
  protected bool _treasure_gatedhal_00033 = false;
  protected bool _treasure_gatedhal_00034 = false;
  protected bool _treasure_gatedhal_00035 = false;
  protected bool _treasure_gatedhal_00036 = false;
  protected bool _treasure_gatedhal_00037 = false;
  protected bool _treasure_gatedhal_00038 = false;
  protected bool _treasure_gatedhal_00039 = false;
  protected bool _treasure_gatedhal_00040 = false;
  protected bool _treasure_gatedhal_00041 = false;
  protected bool _treasure_gatedhal_00042 = false;
  protected bool _treasure_gatedhal_00043 = false;
  protected bool _treasure_gatedhal_00044 = false;
  protected bool _treasure_gatedhal_00045 = false;
  protected bool _treasure_gatedhal_00046 = false;
  protected bool _treasure_gatedhal_00047 = false;
  protected bool _treasure_gatedhal_00048 = false;
  protected bool _treasure_gatedhal_00049 = false;
  protected bool _treasure_gatedhal_00050 = false;
  protected bool _treasure_gatedhal_00051 = false;
  public bool Treasure_GateDhal_00001 { get { return _treasure_gatedhal_00001; } set { _treasure_gatedhal_00001 = value; } }
  public bool Treasure_GateDhal_00002 { get { return _treasure_gatedhal_00002; } set { _treasure_gatedhal_00002 = value; } }
  public bool Treasure_GateDhal_00003 { get { return _treasure_gatedhal_00003; } set { _treasure_gatedhal_00003 = value; } }
  public bool Treasure_GateDhal_00004 { get { return _treasure_gatedhal_00004; } set { _treasure_gatedhal_00004 = value; } }
  public bool Treasure_GateDhal_00005 { get { return _treasure_gatedhal_00005; } set { _treasure_gatedhal_00005 = value; } }
  public bool Treasure_GateDhal_00006 { get { return _treasure_gatedhal_00006; } set { _treasure_gatedhal_00006 = value; } }
  public bool Treasure_GateDhal_00007 { get { return _treasure_gatedhal_00007; } set { _treasure_gatedhal_00007 = value; } }
  public bool Treasure_GateDhal_00008 { get { return _treasure_gatedhal_00008; } set { _treasure_gatedhal_00008 = value; } }
  public bool Treasure_GateDhal_00009 { get { return _treasure_gatedhal_00009; } set { _treasure_gatedhal_00009 = value; } }
  public bool Treasure_GateDhal_00010 { get { return _treasure_gatedhal_00010; } set { _treasure_gatedhal_00010 = value; } }
  public bool Treasure_GateDhal_00011 { get { return _treasure_gatedhal_00011; } set { _treasure_gatedhal_00011 = value; } }
  public bool Treasure_GateDhal_00012 { get { return _treasure_gatedhal_00012; } set { _treasure_gatedhal_00012 = value; } }
  public bool Treasure_GateDhal_00013 { get { return _treasure_gatedhal_00013; } set { _treasure_gatedhal_00013 = value; } }
  public bool Treasure_GateDhal_00014 { get { return _treasure_gatedhal_00014; } set { _treasure_gatedhal_00014 = value; } }
  public bool Treasure_GateDhal_00015 { get { return _treasure_gatedhal_00015; } set { _treasure_gatedhal_00015 = value; } }
  public bool Treasure_GateDhal_00016 { get { return _treasure_gatedhal_00016; } set { _treasure_gatedhal_00016 = value; } }
  public bool Treasure_GateDhal_00017 { get { return _treasure_gatedhal_00017; } set { _treasure_gatedhal_00017 = value; } }
  public bool Treasure_GateDhal_00018 { get { return _treasure_gatedhal_00018; } set { _treasure_gatedhal_00018 = value; } }
  public bool Treasure_GateDhal_00019 { get { return _treasure_gatedhal_00019; } set { _treasure_gatedhal_00019 = value; } }
  public bool Treasure_GateDhal_00020 { get { return _treasure_gatedhal_00020; } set { _treasure_gatedhal_00020 = value; } }
  public bool Treasure_GateDhal_00021 { get { return _treasure_gatedhal_00021; } set { _treasure_gatedhal_00021 = value; } }
  public bool Treasure_GateDhal_00022 { get { return _treasure_gatedhal_00022; } set { _treasure_gatedhal_00022 = value; } }
  public bool Treasure_GateDhal_00023 { get { return _treasure_gatedhal_00023; } set { _treasure_gatedhal_00023 = value; } }
  public bool Treasure_GateDhal_00024 { get { return _treasure_gatedhal_00024; } set { _treasure_gatedhal_00024 = value; } }
  public bool Treasure_GateDhal_00025 { get { return _treasure_gatedhal_00025; } set { _treasure_gatedhal_00025 = value; } }
  public bool Treasure_GateDhal_00026 { get { return _treasure_gatedhal_00026; } set { _treasure_gatedhal_00026 = value; } }
  public bool Treasure_GateDhal_00027 { get { return _treasure_gatedhal_00027; } set { _treasure_gatedhal_00027 = value; } }
  public bool Treasure_GateDhal_00028 { get { return _treasure_gatedhal_00028; } set { _treasure_gatedhal_00028 = value; } }
  public bool Treasure_GateDhal_00029 { get { return _treasure_gatedhal_00029; } set { _treasure_gatedhal_00029 = value; } }
  public bool Treasure_GateDhal_00030 { get { return _treasure_gatedhal_00030; } set { _treasure_gatedhal_00030 = value; } }
  public bool Treasure_GateDhal_00031 { get { return _treasure_gatedhal_00031; } set { _treasure_gatedhal_00031 = value; } }
  public bool Treasure_GateDhal_00032 { get { return _treasure_gatedhal_00032; } set { _treasure_gatedhal_00032 = value; } }
  public bool Treasure_GateDhal_00033 { get { return _treasure_gatedhal_00033; } set { _treasure_gatedhal_00033 = value; } }
  public bool Treasure_GateDhal_00034 { get { return _treasure_gatedhal_00034; } set { _treasure_gatedhal_00034 = value; } }
  public bool Treasure_GateDhal_00035 { get { return _treasure_gatedhal_00035; } set { _treasure_gatedhal_00035 = value; } }
  public bool Treasure_GateDhal_00036 { get { return _treasure_gatedhal_00036; } set { _treasure_gatedhal_00036 = value; } }
  public bool Treasure_GateDhal_00037 { get { return _treasure_gatedhal_00037; } set { _treasure_gatedhal_00037 = value; } }
  public bool Treasure_GateDhal_00038 { get { return _treasure_gatedhal_00038; } set { _treasure_gatedhal_00038 = value; } }
  public bool Treasure_GateDhal_00039 { get { return _treasure_gatedhal_00039; } set { _treasure_gatedhal_00039 = value; } }
  public bool Treasure_GateDhal_00040 { get { return _treasure_gatedhal_00040; } set { _treasure_gatedhal_00040 = value; } }
  public bool Treasure_GateDhal_00041 { get { return _treasure_gatedhal_00041; } set { _treasure_gatedhal_00041 = value; } }
  public bool Treasure_GateDhal_00042 { get { return _treasure_gatedhal_00042; } set { _treasure_gatedhal_00042 = value; } }
  public bool Treasure_GateDhal_00043 { get { return _treasure_gatedhal_00043; } set { _treasure_gatedhal_00043 = value; } }
  public bool Treasure_GateDhal_00044 { get { return _treasure_gatedhal_00044; } set { _treasure_gatedhal_00044 = value; } }
  public bool Treasure_GateDhal_00045 { get { return _treasure_gatedhal_00045; } set { _treasure_gatedhal_00045 = value; } }
  public bool Treasure_GateDhal_00046 { get { return _treasure_gatedhal_00046; } set { _treasure_gatedhal_00046 = value; } }
  public bool Treasure_GateDhal_00047 { get { return _treasure_gatedhal_00047; } set { _treasure_gatedhal_00047 = value; } }
  public bool Treasure_GateDhal_00048 { get { return _treasure_gatedhal_00048; } set { _treasure_gatedhal_00048 = value; } }
  public bool Treasure_GateDhal_00049 { get { return _treasure_gatedhal_00049; } set { _treasure_gatedhal_00049 = value; } }
  public bool Treasure_GateDhal_00050 { get { return _treasure_gatedhal_00050; } set { _treasure_gatedhal_00050 = value; } }
  public bool Treasure_GateDhal_00051 { get { return _treasure_gatedhal_00051; } set { _treasure_gatedhal_00051 = value; } }

  [SerializeField] protected bool _first_soulfragment = false;
  public bool FirstSoulFragment { get { return _first_soulfragment; } set { _first_soulfragment = value; } }

  [SerializeField] protected int _killing_enemy = 0;
  public int KillingEnemy { get { return _killing_enemy; } set { _killing_enemy = value; } }

  #endregion

  #region ソウル・フラグメント"
  [SerializeField] protected bool _soul_fragment_00001 = false;
  public bool SoulFragment_00001 { get { return _soul_fragment_00001; } set { _soul_fragment_00001 = value; } }

  [SerializeField] protected bool _soul_fragment_00002 = false;
  public bool SoulFragment_00002 { get { return _soul_fragment_00002; } set { _soul_fragment_00002 = value; } }
  #endregion

  #region "Backpack Control"
  public void RemoveItem(Item item)
  {
    for (int ii = 0; ii < this._backpackList.Count; ii++)
    {
      if (item.ItemName == this._backpackList[ii].ItemName)
      {
        this._backpackList.RemoveAt(ii);
        break;
      }
    }
  }

  /// <summary>
  /// アイテム内容を全面的に入れ替えます。
  /// </summary>
  /// <param name="item"></param>
  public void ReplaceBackPack(Item[] item)
  {
    this._backpackList.Clear();
    for (int ii = 0; ii < item.Length; ii++)
    {
      if (item[ii] != null)
      {
        AddBackPack(item[ii]);
      }
    }
  }

  /// <summary>
  /// バックパックにアイテムを追加します。
  /// </summary>
  /// <param name="item"></param>
  /// <returns>TRUE:追加完了、FALSE:満杯のため追加できない</returns>
  public bool AddBackPack(Item item)
  {
    return AddBackPack(item, 1);
  }
  public bool AddBackPack(Item item, int addValue)
  {
    int dummyValue = 0;
    return AddBackPack(item, addValue, ref dummyValue);
  }
  public bool AddBackPack(Item item, int addValue, ref int addedNumber)
  {
    // １つもアイテムを保持していない場合、１つ目として生成する。
    if (this._backpackList.Count <= 0)
    {
      item.StackValue = addValue;
      this._backpackList.Add(item);
      addedNumber = 0;
      return true;
    }

    for (int ii = 0; ii < this._backpackList.Count; ii++)
    {
      Debug.Log("AddBackPack: " + ii.ToString());

      // 対象がnullの場合でも次の検索は行うので分岐する。
      if (this._backpackList[ii] == null)
      {
        // 次を探索すると同名アイテムを持っているかもしれないので、まず検索する。
        for (int jj = ii + 1; jj < Fix.MAX_BACKPACK_SIZE; jj++)
        {
          if (CheckBackPackExist(item, jj) > 0)
          {
            // スタック上限以上の場合、別のアイテムとして追加する。
            if (this._backpackList[jj].StackValue >= item.LimitValue)
            {
              // 次のアイテムリストへスルー
              break;
            }
            else
            {
              // スタック上限を超えていなくても、多数追加で上限を超えてしまう場合
              if (this._backpackList[jj].StackValue + addValue > item.LimitValue)
              {
                // 次のアイテムリストへスルー
                break;
              }
              else
              {
                this._backpackList[jj].StackValue += addValue;
                addedNumber = jj;
                return true;
              }
            }
          }
        }

        // やはり探索しても無かったので、そのまま追加する。
        this._backpackList[ii] = item;
        this._backpackList[ii].StackValue = addValue;
        addedNumber = ii;
        return true;
      }
      else
      {
        // 既に持っている場合、スタック量を増やす。
        if (this._backpackList[ii].ItemName == item.ItemName)
        {
          // スタック上限以上の場合、別のアイテムとして追加する。
          if (this._backpackList[ii].StackValue >= item.LimitValue)
          {
            // 次のアイテムリストへスルー
          }
          else
          {
            // スタック上限を超えていなくても、多数追加で上限を超えてしまう場合
            if (this._backpackList[ii].StackValue + addValue > item.LimitValue)
            {
              // 次のアイテムリストへスルー
            }
            else
            {
              this._backpackList[ii].StackValue += addValue;
              addedNumber = ii;
              return true;
            }
          }
        }
      }
    }

    if (this._backpackList.Count > Fix.MAX_BACKPACK_SIZE)
    {
      Debug.Log("AddBackpack: maximum_backpack_size detect, then no add.");
      return false;
    }

    addedNumber = this._backpackList.Count;
    item.StackValue = addValue;
    this._backpackList.Add(item);
    return true;
  }

  /// <summary>
  /// バックパックのアイテムを指定した数だけ削除します。
  /// </summary>
  /// <param name="item"></param>
  /// <param name="deleteValue">削除する数 ０：全て削除、正値：指定数だけ削除</param>
  /// <returns></returns>
  public void DeleteBackpack(Item item, int delete_value)
  {
    for (int ii = 0; ii < Fix.MAX_BACKPACK_SIZE; ii++) // 後編編集
    {
      if (this._backpackList[ii] != null)
      {
        if (this._backpackList[ii].ItemName == item.ItemName)
        {
          if (delete_value <= 0)
          {
            this._backpackList.RemoveAt(ii);
            //this._backpackList[ii] = null;
            break;
          }
          else
          {
            // スタック量が正値の場合、指定されたスタック量を減らす。
            this._backpackList[ii].StackValue -= delete_value;
            if (this._backpackList[ii].StackValue <= 0) // 結果的にスタック量が０になった場合はオブジェクトを消す。
            {
              this._backpackList.RemoveAt(ii);
              //this._backpackList[ii] = null;
            }
            break;
          }
        }
      }
    }
  }

  /// <summary>
  /// バックパックに対象のアイテムが含まれている数を示します。
  /// </summary>
  /// <param name="item"></param>
  /// <returns></returns>
  public int CheckBackPackExist(Item item, int ii)
  {
    if (this._backpackList[ii] != null)
    {
      if (this._backpackList[ii].ItemName == item.ItemName)
      {
        return this._backpackList[ii].StackValue;
      }
    }
    return 0;
  }

  /// <summary>
  /// バックパックに対象のアイテムが含まれているかどうかをチェックします。
  /// </summary>
  /// <param name="itemName">検索対象となるアイテム名</param>
  /// <returns>true: 存在する,  false: 存在しない</returns>
  public bool FindBackPackItem(string itemName)
  {
    for (int ii = 0; ii < this.BackpackList.Count; ii++)
    {
      if (BackpackList[ii] != null && BackpackList[ii].ItemName == itemName)
      {
        return true;
      }
    }
    return false;
  }
  #endregion
}
