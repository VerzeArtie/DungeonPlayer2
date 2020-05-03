using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TeamFoundation : MonoBehaviour
{
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

  [SerializeField] public bool Zetanium_001 { get; set; }
  [SerializeField] public bool Zetanium_002 { get; set; }
  [SerializeField] public bool Zetanium_003 { get; set; }
  [SerializeField] public bool Zetanium_004 { get; set; }
  [SerializeField] public bool Zetanium_005 { get; set; }

  [SerializeField] protected bool _event_message100010 = false;
  public bool Event_Message100010
  {
    get { return _event_message100010; }
    set { _event_message100010 = value; }
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

  [SerializeField] protected bool _event_message100040 = false;
  public bool Event_Message100040
  {
    get { return _event_message100040; }
    set { _event_message100040 = value; }
  }

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

  // todo
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

  [SerializeField] protected bool _treasure_artharium_00001 = false;
  public bool Treasure_Artharium_00001 { get { return _treasure_artharium_00001; } set { _treasure_artharium_00001 = value; } }

  [SerializeField] protected bool _fieldobject_artharium_00001 = false;
  [SerializeField] protected bool _fieldobject_artharium_00002 = false;
  [SerializeField] protected bool _fieldobject_artharium_00003 = false;
  [SerializeField] protected bool _fieldobject_artharium_00004 = false;
  [SerializeField] protected bool _fieldobject_artharium_00005 = false;
  public bool FieldObject_Artharium_00001 { get { return _fieldobject_artharium_00001; } set { _fieldobject_artharium_00001 = value; } }
  public bool FieldObject_Artharium_00002 { get { return _fieldobject_artharium_00002; } set { _fieldobject_artharium_00002 = value; } }
  public bool FieldObject_Artharium_00003 { get { return _fieldobject_artharium_00003; } set { _fieldobject_artharium_00003 = value; } }
  public bool FieldObject_Artharium_00004 { get { return _fieldobject_artharium_00004; } set { _fieldobject_artharium_00004 = value; } }
  public bool FieldObject_Artharium_00005 { get { return _fieldobject_artharium_00005; } set { _fieldobject_artharium_00005 = value; } }

  [SerializeField] protected bool _location_player2 = false;
  public bool LocationPlayer2 { get { return _location_player2; } set { _location_player2 = value; } }

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
}
