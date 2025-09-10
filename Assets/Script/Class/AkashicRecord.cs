using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkashicRecord : MonoBehaviour
{
  // 新規ゲーム、ロード、リロードに関わらず常に記憶されるクラス

  // SeekerMode
  [SerializeField] protected bool _enter_seeker_mode = false;
  public bool EnterSeekerMode { set { _enter_seeker_mode = value; } get { return _enter_seeker_mode; } }

  [SerializeField] protected bool _leave_seeker_mode = false;
  public bool LeaveSeekerMode { set { _leave_seeker_mode = value; } get { return _leave_seeker_mode; } }

  [SerializeField] protected bool _normal_ending = false;
  public bool NormalEnding { get { return _normal_ending; } set { _normal_ending = value; } } // ノーマル・エンド

  [SerializeField] protected bool _true_ending = false;
  public bool TrueEnding { get { return _true_ending; } set { _true_ending = value; } } // トゥルー・エンド

  // コア・シナリオ
  [SerializeField] protected bool _record_earring_of_lana = false;
  public bool Record_EarringOfLana { get { return _record_earring_of_lana; } set { _record_earring_of_lana = value; } } // ラナのイヤリングを入手した事がある。

  // Item Shop
  // 武具合成
  [SerializeField] protected bool _equip_available_11 = false;
  public bool EquipAvailable_11
  {
    set { _equip_available_11 = value; }
    get { return _equip_available_11; }
  }
  [SerializeField] protected bool _equip_available_12 = false;
  public bool EquipAvailable_12
  {
    set { _equip_available_12 = value; }
    get { return _equip_available_12; }
  }
  [SerializeField] protected bool _equip_available_13 = false;
  public bool EquipAvailable_13
  {
    set { _equip_available_13 = value; }
    get { return _equip_available_13; }
  }

  [SerializeField] protected bool _equip_available_21 = false;
  public bool EquipAvailable_21
  {
    set { _equip_available_21 = value; }
    get { return _equip_available_21; }
  }
  [SerializeField] protected bool _equip_available_22 = false;
  public bool EquipAvailable_22
  {
    set { _equip_available_22 = value; }
    get { return _equip_available_22; }
  }

  // ポーション合成
  [SerializeField] protected bool _potion_available_11 = false;
  public bool PotionAvailable_11
  {
    set { _potion_available_11 = value; }
    get { return _potion_available_11; }
  }
  [SerializeField] protected bool _potion_available_12 = false;
  public bool PotionAvailable_12
  {
    set { _potion_available_12 = value; }
    get { return _potion_available_12; }
  }
  [SerializeField] protected bool _potion_available_13 = false;
  public bool PotionAvailable_13
  {
    set { _potion_available_13 = value; }
    get { return _potion_available_13; }
  }

  [SerializeField] protected bool _potion_available_21 = false;
  public bool PotionAvailable_21
  {
    set { _potion_available_21 = value; }
    get { return _potion_available_21; }
  }
  [SerializeField] protected bool _potion_available_22 = false;
  public bool PotionAvailable_22
  {
    set { _potion_available_22 = value; }
    get { return _potion_available_22; }
  }

  // 食事合成
  [SerializeField] protected bool _food_available_11 = false;
  public bool FoodAvailable_11
  {
    set { _food_available_11 = value; }
    get { return _food_available_11; }
  }
  [SerializeField] protected bool _food_available_12 = false;
  public bool FoodAvailable_12
  {
    set { _food_available_12 = value; }
    get { return _food_available_12; }
  }
  [SerializeField] protected bool _food_available_13 = false;
  public bool FoodAvailable_13
  {
    set { _food_available_13 = value; }
    get { return _food_available_13; }
  }

  [SerializeField] protected bool _food_available_21 = false;
  public bool FoodAvailable_21
  {
    set { _food_available_21 = value; }
    get { return _food_available_21; }
  }
  [SerializeField] protected bool _food_available_22 = false;
  public bool FoodAvailable_22
  {
    set { _food_available_22 = value; }
    get { return _food_available_22; }
  }

  // 武具合成
  [SerializeField] protected int _equip_mixtureDay_11 = 0;
  public int EquipMixtureDay_11
  {
    set { _equip_mixtureDay_11 = value; }
    get { return _equip_mixtureDay_11; }
  }
  [SerializeField] protected int _equip_mixtureDay_12 = 0;
  public int EquipMixtureDay_12
  {
    set { _equip_mixtureDay_12 = value; }
    get { return _equip_mixtureDay_12; }
  }
  [SerializeField] protected int _equip_mixtureDay_13 = 0;
  public int EquipMixtureDay_13
  {
    set { _equip_mixtureDay_13 = value; }
    get { return _equip_mixtureDay_13; }
  }

  [SerializeField] protected int _equip_mixtureDay_21 = 0;
  public int EquipMixtureDay_21
  {
    set { _equip_mixtureDay_21 = value; }
    get { return _equip_mixtureDay_21; }
  }

  [SerializeField] protected int _equip_mixtureDay_22 = 0;
  public int EquipMixtureDay_22
  {
    set { _equip_mixtureDay_22 = value; }
    get { return _equip_mixtureDay_22; }
  }

  // ポーション合成
  [SerializeField] protected int _potion_mixtureDay_11 = 0;
  public int PotionMixtureDay_11
  {
    set { _potion_mixtureDay_11 = value; }
    get { return _potion_mixtureDay_11; }
  }
  [SerializeField] protected int _potion_mixtureDay_12 = 0;
  public int PotionMixtureDay_12
  {
    set { _potion_mixtureDay_12 = value; }
    get { return _potion_mixtureDay_12; }
  }
  [SerializeField] protected int _potion_mixtureDay_13 = 0;
  public int PotionMixtureDay_13
  {
    set { _potion_mixtureDay_13 = value; }
    get { return _potion_mixtureDay_13; }
  }

  [SerializeField] protected int _potion_mixtureDay_21 = 0;
  public int PotionMixtureDay_21
  {
    set { _potion_mixtureDay_21 = value; }
    get { return _potion_mixtureDay_21; }
  }
  [SerializeField] protected int _potion_mixtureDay_22 = 0;
  public int PotionMixtureDay_22
  {
    set { _potion_mixtureDay_22 = value; }
    get { return _potion_mixtureDay_22; }
  }

  // 食事合成
  [SerializeField] protected int _food_mixtureDay_11 = 0;
  public int FoodMixtureDay_11
  {
    set { _food_mixtureDay_11 = value; }
    get { return _food_mixtureDay_11; }
  }
  [SerializeField] protected int _food_mixtureDay_12 = 0;
  public int FoodMixtureDay_12
  {
    set { _food_mixtureDay_12 = value; }
    get { return _food_mixtureDay_12; }
  }
  [SerializeField] protected int _food_mixtureDay_13 = 0;
  public int FoodMixtureDay_13
  {
    set { _food_mixtureDay_13 = value; }
    get { return _food_mixtureDay_13; }
  }

  [SerializeField] protected int _food_mixtureDay_21 = 0;
  public int FoodMixtureDay_21
  {
    set { _food_mixtureDay_21 = value; }
    get { return _food_mixtureDay_21; }
  }
  [SerializeField] protected int _food_mixtureDay_22 = 0;
  public int FoodMixtureDay_22
  {
    set { _food_mixtureDay_22 = value; }
    get { return _food_mixtureDay_22; }
  }

  // 武具合成
  [SerializeField] protected int _equip_material_11 = 0;
  public int EquipMaterial_11
  {
    set { _equip_material_11 = value; }
    get { return _equip_material_11; }
  }
  [SerializeField] protected int _equip_material_12 = 0;
  public int EquipMaterial_12
  {
    set { _equip_material_12 = value; }
    get { return _equip_material_12; }
  }
  [SerializeField] protected int _equip_material_13 = 0;
  public int EquipMaterial_13
  {
    set { _equip_material_13 = value; }
    get { return _equip_material_13; }
  }
  [SerializeField] protected int _equip_material_14 = 0;
  public int EquipMaterial_14
  {
    set { _equip_material_14 = value; }
    get { return _equip_material_14; }
  }
  [SerializeField] protected int _equip_material_15 = 0;
  public int EquipMaterial_15
  {
    set { _equip_material_15 = value; }
    get { return _equip_material_15; }
  }
  [SerializeField] protected int _equip_material_16 = 0;
  public int EquipMaterial_16
  {
    set { _equip_material_16 = value; }
    get { return _equip_material_16; }
  }

  [SerializeField] protected int _equip_material_21 = 0;
  public int EquipMaterial_21
  {
    set { _equip_material_21 = value; }
    get { return _equip_material_21; }
  }
  [SerializeField] protected int _equip_material_22 = 0;
  public int EquipMaterial_22
  {
    set { _equip_material_22 = value; }
    get { return _equip_material_22; }
  }
  [SerializeField] protected int _equip_material_23 = 0;
  public int EquipMaterial_23
  {
    set { _equip_material_23 = value; }
    get { return _equip_material_23; }
  }
  [SerializeField] protected int _equip_material_24 = 0;
  public int EquipMaterial_24
  {
    set { _equip_material_24 = value; }
    get { return _equip_material_24; }
  }

  // ポーション合成
  [SerializeField] protected int _potion_material_11 = 0;
  public int PotionMaterial_11
  {
    set { _potion_material_11 = value; }
    get { return _potion_material_11; }
  }
  [SerializeField] protected int _potion_material_12 = 0;
  public int PotionMaterial_12
  {
    set { _potion_material_12 = value; }
    get { return _potion_material_12; }
  }
  [SerializeField] protected int _potion_material_13 = 0;
  public int PotionMaterial_13
  {
    set { _potion_material_13 = value; }
    get { return _potion_material_13; }
  }
  [SerializeField] protected int _potion_material_14 = 0;
  public int PotionMaterial_14
  {
    set { _potion_material_14 = value; }
    get { return _potion_material_14; }
  }
  [SerializeField] protected int _potion_material_15 = 0;
  public int PotionMaterial_15
  {
    set { _potion_material_15 = value; }
    get { return _potion_material_15; }
  }
  [SerializeField] protected int _potion_material_16 = 0;
  public int PotionMaterial_16
  {
    set { _potion_material_16 = value; }
    get { return _potion_material_16; }
  }
  [SerializeField] protected int _potion_material_21 = 0;
  public int PotionMaterial_21
  {
    set { _potion_material_21 = value; }
    get { return _potion_material_21; }
  }
  [SerializeField] protected int _potion_material_22 = 0;
  public int PotionMaterial_22
  {
    set { _potion_material_22 = value; }
    get { return _potion_material_22; }
  }
  [SerializeField] protected int _potion_material_23 = 0;
  public int PotionMaterial_23
  {
    set { _potion_material_23 = value; }
    get { return _potion_material_23; }
  }
  [SerializeField] protected int _potion_material_24 = 0;
  public int PotionMaterial_24
  {
    set { _potion_material_24 = value; }
    get { return _potion_material_24; }
  }

  // 食事合成
  [SerializeField] protected int _food_material_11 = 0;
  public int FoodMaterial_11
  {
    set { _food_material_11 = value; }
    get { return _food_material_11; }
  }
  [SerializeField] protected int _food_material_12 = 0;
  public int FoodMaterial_12
  {
    set { _food_material_12 = value; }
    get { return _food_material_12; }
  }
  [SerializeField] protected int _food_material_13 = 0;
  public int FoodMaterial_13
  {
    set { _food_material_13 = value; }
    get { return _food_material_13; }
  }
  [SerializeField] protected int _food_material_14 = 0;
  public int FoodMaterial_14
  {
    set { _food_material_14 = value; }
    get { return _food_material_14; }
  }
  [SerializeField] protected int _food_material_15 = 0;
  public int FoodMaterial_15
  {
    set { _food_material_15 = value; }
    get { return _food_material_15; }
  }
  [SerializeField] protected int _food_material_16 = 0;
  public int FoodMaterial_16
  {
    set { _food_material_16 = value; }
    get { return _food_material_16; }
  }

  [SerializeField] protected int _food_material_21 = 0;
  public int FoodMaterial_21
  {
    set { _food_material_21 = value; }
    get { return _food_material_21; }
  }
  [SerializeField] protected int _food_material_22 = 0;
  public int FoodMaterial_22
  {
    set { _food_material_22 = value; }
    get { return _food_material_22; }
  }
  [SerializeField] protected int _food_material_23 = 0;
  public int FoodMaterial_23
  {
    set { _food_material_23 = value; }
    get { return _food_material_23; }
  }
  [SerializeField] protected int _food_material_24 = 0;
  public int FoodMaterial_24
  {
    set { _food_material_24 = value; }
    get { return _food_material_24; }
  }

  // アクションコマンドの刻印（一度誰かが記憶したなら、非表示としないためのフラグ）
  [SerializeField] protected bool _FireBall = false;
  public bool FireBall
  {
    set { _FireBall = value; }
    get { return _FireBall; }
  }

  [SerializeField] protected bool _IceNeedle = false;
  public bool IceNeedle
  {
    set { _IceNeedle = value; }
    get { return _IceNeedle; }
  }

  [SerializeField] protected bool _FreshHeal = false;
  public bool FreshHeal
  {
    set { _FreshHeal = value; }
    get { return _FreshHeal; }
  }

  [SerializeField] protected bool _ShadowBlast = false;
  public bool ShadowBlast
  {
    set { _ShadowBlast = value; }
    get { return _ShadowBlast; }
  }

  [SerializeField] protected bool _OracleCommand = false;
  public bool OracleCommand
  {
    set { _OracleCommand = value; }
    get { return _OracleCommand; }
  }

  [SerializeField] protected bool _EnergyBolt = false;
  public bool EnergyBolt
  {
    set { _EnergyBolt = value; }
    get { return _EnergyBolt; }
  }

  [SerializeField] protected bool _StraightSmash = false;
  public bool StraightSmash
  {
    set { _StraightSmash = value; }
    get { return _StraightSmash; }
  }

  [SerializeField] protected bool _ShieldBash = false;
  public bool ShieldBash
  {
    set { _ShieldBash = value; }
    get { return _ShieldBash; }
  }

  [SerializeField] protected bool _LegStrike = false;
  public bool LegStrike
  {
    set { _LegStrike = value; }
    get { return _LegStrike; }
  }

  [SerializeField] protected bool _HunterShot = false;
  public bool HunterShot
  {
    set { _HunterShot = value; }
    get { return _HunterShot; }
  }

  [SerializeField] protected bool _TrueSight = false;
  public bool TrueSight
  {
    set { _TrueSight = value; }
    get { return _TrueSight; }
  }

  [SerializeField] protected bool _DispelMagic = false;
  public bool DispelMagic
  {
    set { _DispelMagic = value; }
    get { return _DispelMagic; }
  }

  [SerializeField] protected bool _FlameBlade = false;
  public bool FlameBlade
  {
    set { _FlameBlade = value; }
    get { return _FlameBlade; }
  }

  [SerializeField] protected bool _PurePurification = false;
  public bool PurePurification
  {
    set { _PurePurification = value; }
    get { return _PurePurification; }
  }

  [SerializeField] protected bool _DivineCircle = false;
  public bool DivineCircle
  {
    set { _DivineCircle = value; }
    get { return _DivineCircle; }
  }

  [SerializeField] protected bool _BloodSign = false;
  public bool BloodSign
  {
    set { _BloodSign = value; }
    get { return _BloodSign; }
  }

  [SerializeField] protected bool _FortuneSpirit = false;
  public bool FortuneSpirit
  {
    set { _FortuneSpirit = value; }
    get { return _FortuneSpirit; }
  }

  [SerializeField] protected bool _FlashCounter = false;
  public bool FlashCounter
  {
    set { _FlashCounter = value; }
    get { return _FlashCounter; }
  }

  [SerializeField] protected bool _StanceOfTheBlade = false;
  public bool StanceOfTheBlade
  {
    set { _StanceOfTheBlade = value; }
    get { return _StanceOfTheBlade; }
  }

  [SerializeField] protected bool _StanceOfTheGuard = false;
  public bool StanceOfTheGuard
  {
    set { _StanceOfTheGuard = value; }
    get { return _StanceOfTheGuard; }
  }

  [SerializeField] protected bool _SpeedStep = false;
  public bool SpeedStep
  {
    set { _SpeedStep = value; }
    get { return _SpeedStep; }
  }

  [SerializeField] protected bool _MultipleShot = false;
  public bool MultipleShot
  {
    set { _MultipleShot = value; }
    get { return _MultipleShot; }
  }

  [SerializeField] protected bool _LeylineSchema = false;
  public bool LeylineSchema
  {
    set { _LeylineSchema = value; }
    get { return _LeylineSchema; }
  }

  [SerializeField] protected bool _SpiritualRest = false;
  public bool SpiritualRest
  {
    set { _SpiritualRest = value; }
    get { return _SpiritualRest; }
  }

  [SerializeField] protected bool _MeteorBullet = false;
  public bool MeteorBullet
  {
    set { _MeteorBullet = value; }
    get { return _MeteorBullet; }
  }

  [SerializeField] protected bool _BlueBullet = false;
  public bool BlueBullet
  {
    set { _BlueBullet = value; }
    get { return _BlueBullet; }
  }

  [SerializeField] protected bool _HolyBreath = false;
  public bool HolyBreath
  {
    set { _HolyBreath = value; }
    get { return _HolyBreath; }
  }

  [SerializeField] protected bool _BlackContract = false;
  public bool BlackContract
  {
    set { _BlackContract = value; }
    get { return _BlackContract; }
  }

  [SerializeField] protected bool _WordOfPower = false;
  public bool WordOfPower
  {
    set { _WordOfPower = value; }
    get { return _WordOfPower; }
  }

  [SerializeField] protected bool _SigilOfThePending = false;
  public bool SigilOfThePending
  {
    set { _WordOfPower = value; }
    get { return _SigilOfThePending; }
  }

  [SerializeField] protected bool _DoubleSlash = false;
  public bool DoubleSlash
  {
    set { _DoubleSlash = value; }
    get { return _DoubleSlash; }
  }

  [SerializeField] protected bool _ConcussiveHit = false;
  public bool ConcussiveHit
  {
    set { _ConcussiveHit = value; }
    get { return _ConcussiveHit; }
  }

  [SerializeField] protected bool _BoneCrush = false;
  public bool BoneCrush
  {
    set { _BoneCrush = value; }
    get { return _BoneCrush; }
  }

  [SerializeField] protected bool _EyeOfTheIsshin = false;
  public bool EyeOfTheIsshin
  {
    set { _EyeOfTheIsshin = value; }
    get { return _EyeOfTheIsshin; }
  }

  [SerializeField] protected bool _VoiceOfVigor = false;
  public bool VoiceOfVigor
  {
    set { _VoiceOfVigor = value; }
    get { return _VoiceOfVigor; }
  }

  [SerializeField] protected bool _UnseenAid = false;
  public bool UnseenAid
  {
    set { _UnseenAid = value; }
    get { return _UnseenAid; }
  }

  [SerializeField] protected bool _VolcanicBlaze = false;
  public bool VolcanicBlaze
  {
    set { _VolcanicBlaze = value; }
    get { return _VolcanicBlaze; }
  }

  [SerializeField] protected bool _FreezingCube = false;
  public bool FreezingCube
  {
    set { _FreezingCube = value; }
    get { return _FreezingCube; }
  }

  [SerializeField] protected bool _AngelicEcho = false;
  public bool AngelicEcho
  {
    set { _AngelicEcho = value; }
    get { return _AngelicEcho; }
  }

  [SerializeField] protected bool _CursedEvangile = false;
  public bool CursedEvangile
  {
    set { _CursedEvangile = value; }
    get { return _CursedEvangile; }
  }

  [SerializeField] protected bool _GaleWind = false;
  public bool GaleWind
  {
    set { _GaleWind = value; }
    get { return _GaleWind; }
  }

  [SerializeField] protected bool _PhantomOboro = false;
  public bool PhantomOboro
  {
    set { _PhantomOboro = value; }
    get { return _PhantomOboro; }
  }

  [SerializeField] protected bool _IronBuster = false;
  public bool IronBuster
  {
    set { _IronBuster = value; }
    get { return _IronBuster; }
  }

  [SerializeField] protected bool _DominationField = false;
  public bool DominationField
  {
    set { _DominationField = value; }
    get { return _DominationField; }
  }

  [SerializeField] protected bool _DeadlyDrive = false;
  public bool DeadlyDrive
  {
    set { _DeadlyDrive = value; }
    get { return _DeadlyDrive; }
  }

  [SerializeField] protected bool _PenetrationArrow = false;
  public bool PenetrationArrow
  {
    set { _PenetrationArrow = value; }
    get { return _PenetrationArrow; }
  }

  [SerializeField] protected bool _WillAwakening = false;
  public bool WillAwakening
  {
    set { _WillAwakening = value; }
    get { return _WillAwakening; }
  }

  [SerializeField] protected bool _CircleOfSerenity = false;
  public bool CircleOfSerenity
  {
    set { _CircleOfSerenity = value; }
    get { return _CircleOfSerenity; }
  }

  [SerializeField] protected bool _FlameStrike = false;
  public bool FlameStrike
  {
    set { _FlameStrike = value; }
    get { return _FlameStrike; }
  }

  [SerializeField] protected bool _FrostLance = false;
  public bool FrostLance
  {
    set { _FrostLance = value; }
    get { return _FrostLance; }
  }

  [SerializeField] protected bool _ShiningHeal = false;
  public bool ShiningHeal
  {
    set { _ShiningHeal = value; }
    get { return _ShiningHeal; }
  }

  [SerializeField] protected bool _CircleOfTheDespair = false;
  public bool CircleOfTheDespair
  {
    set { _CircleOfTheDespair = value; }
    get { return _CircleOfTheDespair; }
  }

  [SerializeField] protected bool _SeventhPrinciple = false;
  public bool SeventhPrinciple
  {
    set { _SeventhPrinciple = value; }
    get { return _SeventhPrinciple; }
  }

  [SerializeField] protected bool _CounterDisallow = false;
  public bool CounterDisallow
  {
    set { _CounterDisallow = value; }
    get { return _CounterDisallow; }
  }

  [SerializeField] protected bool _RagingStorm = false;
  public bool RagingStorm
  {
    set { _RagingStorm = value; }
    get { return _RagingStorm; }
  }

  [SerializeField] protected bool _HardestParry = false;
  public bool HardestParry
  {
    set { _HardestParry = value; }
    get { return _HardestParry; }
  }

  [SerializeField] protected bool _UnintentionalHit = false;
  public bool UnintentionalHit
  {
    set { _UnintentionalHit = value; }
    get { return _UnintentionalHit; }
  }

  [SerializeField] protected bool _PrecisionStrike = false;
  public bool PrecisionStrike
  {
    set { _PrecisionStrike = value; }
    get { return _PrecisionStrike; }
  }

  [SerializeField] protected bool _EverflowMind = false;
  public bool EverflowMind
  {
    set { _EverflowMind = value; }
    get { return _EverflowMind; }
  }

  [SerializeField] protected bool _InnerInspiration = false;
  public bool InnerInspiration
  {
    set { _InnerInspiration = value; }
    get { return _InnerInspiration; }
  }

  [SerializeField] protected bool _CircleOfTheIgnite = false;
  public bool CircleOfTheIgnite
  {
    set { _CircleOfTheIgnite = value; }
    get { return _CircleOfTheIgnite; }
  }

  [SerializeField] protected bool _WaterPresence = false;
  public bool WaterPresence
  {
    set { _WaterPresence = value; }
    get { return _WaterPresence; }
  }

  [SerializeField] protected bool _ValkyrieBlade = false;
  public bool ValkyrieBlade
  {
    set { _ValkyrieBlade = value; }
    get { return _ValkyrieBlade; }
  }

  [SerializeField] protected bool _TheDarkIntensity = false;
  public bool TheDarkIntensity
  {
    set { _TheDarkIntensity = value; }
    get { return _TheDarkIntensity; }
  }

  [SerializeField] protected bool _FutureVision = false;
  public bool FutureVision
  {
    set { _FutureVision = value; }
    get { return _FutureVision; }
  }

  [SerializeField] protected bool _DetachmentFault = false;
  public bool DetachmentFault
  {
    set { _DetachmentFault = value; }
    get { return _DetachmentFault; }
  }

  [SerializeField] protected bool _StanceOfTheIai = false;
  public bool StanceOfTheIai
  {
    set { _StanceOfTheIai = value; }
    get { return _StanceOfTheIai; }
  }

  [SerializeField] protected bool _OneImmunity = false;
  public bool OneImmunity
  {
    set { _OneImmunity = value; }
    get { return _OneImmunity; }
  }

  [SerializeField] protected bool _StanceOfMuin = false;
  public bool StanceOfMuin
  {
    set { _StanceOfMuin = value; }
    get { return _StanceOfMuin; }
  }

  [SerializeField] protected bool _EternalConcentration = false;
  public bool EternalConcentration
  {
    set { _EternalConcentration = value; }
    get { return _EternalConcentration; }
  }

  [SerializeField] protected bool _SigilOfTheFaith = false;
  public bool SigilOfTheFaith
  {
    set { _SigilOfTheFaith = value; }
    get { return _SigilOfTheFaith; }
  }

  [SerializeField] protected bool _ZeroImmunity = false;
  public bool ZeroImmunity
  {
    set { _ZeroImmunity = value; }
    get { return _ZeroImmunity; }
  }

  [SerializeField] protected bool _LavaAnnihilation = false;
  public bool LavaAnnihilation
  {
    set { _LavaAnnihilation = value; }
    get { return _LavaAnnihilation; }
  }

  [SerializeField] protected bool _AbsoluteZero = false;
  public bool AbsoluteZero
  {
    set { _AbsoluteZero = value; }
    get { return _AbsoluteZero; }
  }

  [SerializeField] protected bool _Resurrection = false;
  public bool Resurrection
  {
    set { _Resurrection = value; }
    get { return _Resurrection; }
  }

  [SerializeField] protected bool _DeathScythe = false;
  public bool DeathScythe
  {
    set { _DeathScythe = value; }
    get { return _DeathScythe; }
  }

  [SerializeField] protected bool _Genesis = false;
  public bool Genesis
  {
    set { _Genesis = value; }
    get { return _Genesis; }
  }

  [SerializeField] protected bool _TimeSkip = false;
  public bool TimeSkip
  {
    set { _TimeSkip = value; }
    get { return _TimeSkip; }
  }

  [SerializeField] protected bool _KineticSmash = false;
  public bool KineticSmash
  {
    set { _KineticSmash = value; }
    get { return _KineticSmash; }
  }

  [SerializeField] protected bool _Catastrophe = false;
  public bool Catastrophe
  {
    set { _Catastrophe = value; }
    get { return _Catastrophe; }
  }

  [SerializeField] protected bool _CarnageRush = false;
  public bool CarnageRush
  {
    set { _CarnageRush = value; }
    get { return _CarnageRush; }
  }

  [SerializeField] protected bool _PiercingArrow = false;
  public bool PiercingArrow
  {
    set { _PiercingArrow = value; }
    get { return _PiercingArrow; }
  }

  [SerializeField] protected bool _StanceOfTheKokoroe = false;
  public bool StanceOfTheKokoroe
  {
    set { _StanceOfTheKokoroe = value; }
    get { return _StanceOfTheKokoroe; }
  }

  [SerializeField] protected bool _TranscendenceReached = false;
  public bool TranscendenceReached
  {
    set { _TranscendenceReached = value; }
    get { return _TranscendenceReached; }
  }

  // エオネ・フルネアを仲間にした事がある。
  [SerializeField] protected bool _partyjoin_EoneFulnea = false;
  public bool PartyJoin_EoneFulnea
  {
    set { _partyjoin_EoneFulnea = value; }
    get { return _partyjoin_EoneFulnea; }
  }

  // ビリー・ラキを仲間にした事がある。
  [SerializeField] protected bool _partyjoin_BillyRaki = false;
  public bool PartyJoin_BillyRaki
  {
    set { _partyjoin_BillyRaki = value; }
    get { return _partyjoin_BillyRaki; }
  }

  // アデル・ブリガンディを仲間にした後、宿屋で休んだ事がある。
  [SerializeField] protected bool _partyjoin_AdelBrigandy = false;
  public bool PartyJoin_AdelBrigandy
  {
    set { _partyjoin_AdelBrigandy = value; }
    get { return _partyjoin_AdelBrigandy; }
  }

  // パルメテイシア神殿で神言を授かる。
  [SerializeField] protected bool _gift_ParmetysiaWord = false;
  public bool GiftParmetysiaWord
  {
    set { _gift_ParmetysiaWord = value; }
    get { return _gift_ParmetysiaWord; }
  }

  // （３）ゴラトラム洞窟のObsidianStoneと接触する。
  [SerializeField] protected bool _inscribeObsidianStone_1 = false;
  public bool InscribeObsidianStone_1
  {
    set { _inscribeObsidianStone_1 = value; }
    get { return _inscribeObsidianStone_1; }
  }

  // （５）神秘の森のObsidianStoneと接触する。
  [SerializeField] protected bool _inscribeObsidianStone_2 = false;
  public bool InscribeObsidianStone_2
  {
    set { _inscribeObsidianStone_2 = value; }
    get { return _inscribeObsidianStone_2; }
  }

  // （２）オーランの塔のObsidianStoneと接触する。
  [SerializeField] protected bool _inscribeObsidianStone_3 = false;
  public bool InscribeObsidianStone_3
  {
    set { _inscribeObsidianStone_3 = value; }
    get { return _inscribeObsidianStone_3; }
  }

  // （１）ヴェルガス海底神殿のObsidianStoneと接触する。
  [SerializeField] protected bool _inscribeObsidianStone_4 = false;
  public bool InscribeObsidianStone_4
  {
    set { _inscribeObsidianStone_4 = value; }
    get { return _inscribeObsidianStone_4; }
  }

  // （４）エデルガイゼン城のObsidianStoneと接触する。
  [SerializeField] protected bool _inscribeObsidianStone_5 = false;
  public bool InscribeObsidianStone_5
  {
    set { _inscribeObsidianStone_5 = value; }
    get { return _inscribeObsidianStone_5; }
  }

  // （０）エスミリア草原区域のObsidianStoneと接触する。
  [SerializeField] protected bool _inscribeObsidianStone_6 = false;
  public bool InscribeObsidianStone_6
  {
    set { _inscribeObsidianStone_6 = value; }
    get { return _inscribeObsidianStone_6; }
  }

  // ヴェルガスの海底神殿、右方の間、詩の節２～１５の記録ナンバー
  // 詩の節１と１６は固定値（変更されない）だが分かり難くなるので、記録には入れておく。
  [SerializeField] protected int _velgus_chant_sequence_1 = 1; // 1初期固定
  public int Velgus_Chant_Sequence_1
  {
    set { _velgus_chant_sequence_1 = value; }
    get { return _velgus_chant_sequence_1; }
  }
  [SerializeField] protected int _velgus_chant_sequence_2 = 0;
  public int Velgus_Chant_Sequence_2
  {
    set { _velgus_chant_sequence_2 = value; }
    get { return _velgus_chant_sequence_2; }
  }
  [SerializeField] protected int _velgus_chant_sequence_3 = 0;
  public int Velgus_Chant_Sequence_3
  {
    set { _velgus_chant_sequence_3 = value; }
    get { return _velgus_chant_sequence_3; }
  }
  [SerializeField] protected int _velgus_chant_sequence_4 = 0;
  public int Velgus_Chant_Sequence_4
  {
    set { _velgus_chant_sequence_4 = value; }
    get { return _velgus_chant_sequence_4; }
  }
  [SerializeField] protected int _velgus_chant_sequence_5 = 0;
  public int Velgus_Chant_Sequence_5
  {
    set { _velgus_chant_sequence_5 = value; }
    get { return _velgus_chant_sequence_5; }
  }
  [SerializeField] protected int _velgus_chant_sequence_6 = 0;
  public int Velgus_Chant_Sequence_6
  {
    set { _velgus_chant_sequence_6 = value; }
    get { return _velgus_chant_sequence_6; }
  }
  [SerializeField] protected int _velgus_chant_sequence_7 = 0;
  public int Velgus_Chant_Sequence_7
  {
    set { _velgus_chant_sequence_7 = value; }
    get { return _velgus_chant_sequence_7; }
  }
  [SerializeField] protected int _velgus_chant_sequence_8 = 0;
  public int Velgus_Chant_Sequence_8
  {
    set { _velgus_chant_sequence_8 = value; }
    get { return _velgus_chant_sequence_8; }
  }
  [SerializeField] protected int _velgus_chant_sequence_9 = 0;
  public int Velgus_Chant_Sequence_9
  {
    set { _velgus_chant_sequence_9 = value; }
    get { return _velgus_chant_sequence_9; }
  }
  [SerializeField] protected int _velgus_chant_sequence_10 = 0;
  public int Velgus_Chant_Sequence_10
  {
    set { _velgus_chant_sequence_10 = value; }
    get { return _velgus_chant_sequence_10; }
  }
  [SerializeField] protected int _velgus_chant_sequence_11 = 0;
  public int Velgus_Chant_Sequence_11
  {
    set { _velgus_chant_sequence_11 = value; }
    get { return _velgus_chant_sequence_11; }
  }
  [SerializeField] protected int _velgus_chant_sequence_12 = 0;
  public int Velgus_Chant_Sequence_12
  {
    set { _velgus_chant_sequence_12 = value; }
    get { return _velgus_chant_sequence_12; }
  }
  [SerializeField] protected int _velgus_chant_sequence_13 = 0;
  public int Velgus_Chant_Sequence_13
  {
    set { _velgus_chant_sequence_13 = value; }
    get { return _velgus_chant_sequence_13; }
  }
  [SerializeField] protected int _velgus_chant_sequence_14 = 0;
  public int Velgus_Chant_Sequence_14
  {
    set { _velgus_chant_sequence_14 = value; }
    get { return _velgus_chant_sequence_14; }
  }
  [SerializeField] protected int _velgus_chant_sequence_15 = 0;
  public int Velgus_Chant_Sequence_15
  {
    set { _velgus_chant_sequence_15 = value; }
    get { return _velgus_chant_sequence_15; }
  }
  [SerializeField] protected int _velgus_chant_sequence_16 = 16; // 16初期固定
  public int Velgus_Chant_Sequence_16
  {
    set { _velgus_chant_sequence_16 = value; }
    get { return _velgus_chant_sequence_16; }
  }

  [SerializeField] protected bool _velgus_chant_achivement = false;
  public bool VelgusChantAchivement
  {
    set { _velgus_chant_achivement = value; }
    get { return _velgus_chant_achivement; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_1 = 0;
  public int EdelgarzenMirrorSequence_1
  {
    set { _edelgarzen_mirror_sequence_1 = value; }
    get { return _edelgarzen_mirror_sequence_1; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_2 = 0;
  public int EdelgarzenMirrorSequence_2
  {
    set { _edelgarzen_mirror_sequence_2 = value; }
    get { return _edelgarzen_mirror_sequence_2; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_3 = 0;
  public int EdelgarzenMirrorSequence_3
  {
    set { _edelgarzen_mirror_sequence_3 = value; }
    get { return _edelgarzen_mirror_sequence_3; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_4 = 0;
  public int EdelgarzenMirrorSequence_4
  {
    set { _edelgarzen_mirror_sequence_4 = value; }
    get { return _edelgarzen_mirror_sequence_4; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_5 = 0;
  public int EdelgarzenMirrorSequence_5
  {
    set { _edelgarzen_mirror_sequence_5 = value; }
    get { return _edelgarzen_mirror_sequence_5; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_6 = 0;
  public int EdelgarzenMirrorSequence_6
  {
    set { _edelgarzen_mirror_sequence_6 = value; }
    get { return _edelgarzen_mirror_sequence_6; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_7 = 0;
  public int EdelgarzenMirrorSequence_7
  {
    set { _edelgarzen_mirror_sequence_7 = value; }
    get { return _edelgarzen_mirror_sequence_7; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_8 = 0;
  public int EdelgarzenMirrorSequence_8
  {
    set { _edelgarzen_mirror_sequence_8 = value; }
    get { return _edelgarzen_mirror_sequence_8; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_9 = 0;
  public int EdelgarzenMirrorSequence_9
  {
    set { _edelgarzen_mirror_sequence_9 = value; }
    get { return _edelgarzen_mirror_sequence_9; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_10 = 0;
  public int EdelgarzenMirrorSequence_10
  {
    set { _edelgarzen_mirror_sequence_10 = value; }
    get { return _edelgarzen_mirror_sequence_10; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_11 = 0;
  public int EdelgarzenMirrorSequence_11
  {
    set { _edelgarzen_mirror_sequence_11 = value; }
    get { return _edelgarzen_mirror_sequence_11; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_12 = 0;
  public int EdelgarzenMirrorSequence_12
  {
    set { _edelgarzen_mirror_sequence_12 = value; }
    get { return _edelgarzen_mirror_sequence_12; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_13 = 0;
  public int EdelgarzenMirrorSequence_13
  {
    set { _edelgarzen_mirror_sequence_13 = value; }
    get { return _edelgarzen_mirror_sequence_13; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_14 = 0;
  public int EdelgarzenMirrorSequence_14
  {
    set { _edelgarzen_mirror_sequence_14 = value; }
    get { return _edelgarzen_mirror_sequence_14; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_15 = 0;
  public int EdelgarzenMirrorSequence_15
  {
    set { _edelgarzen_mirror_sequence_15 = value; }
    get { return _edelgarzen_mirror_sequence_15; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_A = 0;
  public int EdelgarzenMirrorSequence_A
  {
    set { _edelgarzen_mirror_sequence_A = value; }
    get { return _edelgarzen_mirror_sequence_A; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_B = 0;
  public int EdelgarzenMirrorSequence_B
  {
    set { _edelgarzen_mirror_sequence_B = value; }
    get { return _edelgarzen_mirror_sequence_B; }
  }

  [SerializeField] protected int _edelgarzen_mirror_sequence_C = 0;
  public int EdelgarzenMirrorSequence_C
  {
    set { _edelgarzen_mirror_sequence_C = value; }
    get { return _edelgarzen_mirror_sequence_C; }
  }

  [SerializeField] protected int _edelgarzen_mirror_final_A = 0;
  public int EdelgarzenMirrorFinal_A
  {
    set { _edelgarzen_mirror_final_A = value; }
    get { return _edelgarzen_mirror_final_A; }
  }

  [SerializeField] protected int _edelgarzen_mirror_final_B = 0;
  public int EdelgarzenMirrorFinal_B
  {
    set { _edelgarzen_mirror_final_B = value; }
    get { return _edelgarzen_mirror_final_B; }
  }

  [SerializeField] protected int _edelgarzen_mirror_final_C = 0;
  public int EdelgarzenMirrorFinal_C
  {
    set { _edelgarzen_mirror_final_C = value; }
    get { return _edelgarzen_mirror_final_C; }
  }

  [SerializeField] protected bool _edelgarzen_holy_answer = false;
  public bool EdelgarzenHolyAnswer
  {
    set { _edelgarzen_holy_answer = value; }
    get { return _edelgarzen_holy_answer; }
  }

  [SerializeField] protected bool _edelgarzen_fool_answer = false;
  public bool EdelgarzenFoolAnswer
  {
    set { _edelgarzen_fool_answer = value; }
    get { return _edelgarzen_fool_answer; }
  }

  [SerializeField] protected bool _velgus_badend_genesisgate = false;
  public bool Velgus_BadEnd_GenesisGate
  {
    set { _velgus_badend_genesisgate = value; }
    get { return _velgus_badend_genesisgate; }
  }

  public void Velgus_Chant_Sequence(int number)
  {
    if (number == One.AR.Velgus_Chant_Sequence_2 ||
        number == One.AR.Velgus_Chant_Sequence_3 ||
        number == One.AR.Velgus_Chant_Sequence_4 ||
        number == One.AR.Velgus_Chant_Sequence_5 ||
        number == One.AR.Velgus_Chant_Sequence_6 ||
        number == One.AR.Velgus_Chant_Sequence_7 ||
        number == One.AR.Velgus_Chant_Sequence_8 ||
        number == One.AR.Velgus_Chant_Sequence_9 ||
        number == One.AR.Velgus_Chant_Sequence_10 ||
        number == One.AR.Velgus_Chant_Sequence_11 ||
        number == One.AR.Velgus_Chant_Sequence_12 ||
        number == One.AR.Velgus_Chant_Sequence_13 ||
        number == One.AR.Velgus_Chant_Sequence_14 ||
        number == One.AR.Velgus_Chant_Sequence_15)
    {
      // 既にレコードした箇所がある場合は更新しない。
      Debug.Log("AkashicRecord has been already recorded, then no action: " + number.ToString());
      return;
    }

    if (One.AR.Velgus_Chant_Sequence_2 == 0)
    {
      One.AR.Velgus_Chant_Sequence_2 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_2:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_3 == 0)
    {
      One.AR.Velgus_Chant_Sequence_3 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_3:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_4 == 0)
    {
      One.AR.Velgus_Chant_Sequence_4 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_4:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_5 == 0)
    {
      One.AR.Velgus_Chant_Sequence_5 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_5:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_6 == 0)
    {
      One.AR.Velgus_Chant_Sequence_6 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_6:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_7 == 0)
    {
      One.AR.Velgus_Chant_Sequence_7 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_7:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_8 == 0)
    {
      One.AR.Velgus_Chant_Sequence_8 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_8:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_9 == 0)
    {
      One.AR.Velgus_Chant_Sequence_9 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_9:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_10 == 0)
    {
      One.AR.Velgus_Chant_Sequence_10 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_10:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_11 == 0)
    {
      One.AR.Velgus_Chant_Sequence_11 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_11:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_12 == 0)
    {
      One.AR.Velgus_Chant_Sequence_12 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_12:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_13 == 0)
    {
      One.AR.Velgus_Chant_Sequence_13 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_13:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_14 == 0)
    {
      One.AR.Velgus_Chant_Sequence_14 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_14:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_15 == 0)
    {
      One.AR.Velgus_Chant_Sequence_15 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_15:" + number.ToString());
    }
  }

  public int VelgusSearchChantNumber(int number)
  {
    if (number == 1) { return One.AR.Velgus_Chant_Sequence_1; }
    if (number == 2) { return One.AR.Velgus_Chant_Sequence_2; }
    if (number == 3) { return One.AR.Velgus_Chant_Sequence_3; }
    if (number == 4) { return One.AR.Velgus_Chant_Sequence_4; }
    if (number == 5) { return One.AR.Velgus_Chant_Sequence_5; }
    if (number == 6) { return One.AR.Velgus_Chant_Sequence_6; }
    if (number == 7) { return One.AR.Velgus_Chant_Sequence_7; }
    if (number == 8) { return One.AR.Velgus_Chant_Sequence_8; }
    if (number == 9) { return One.AR.Velgus_Chant_Sequence_9; }
    if (number == 10) { return One.AR.Velgus_Chant_Sequence_10; }
    if (number == 11) { return One.AR.Velgus_Chant_Sequence_11; }
    if (number == 12) { return One.AR.Velgus_Chant_Sequence_12; }
    if (number == 13) { return One.AR.Velgus_Chant_Sequence_13; }
    if (number == 14) { return One.AR.Velgus_Chant_Sequence_14; }
    if (number == 15) { return One.AR.Velgus_Chant_Sequence_15; }
    if (number == 16) { return One.AR.Velgus_Chant_Sequence_16; }

    return 0;
  }
}
