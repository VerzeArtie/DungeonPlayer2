﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public static class MessagePack
{
  #region "アクションイベント"
  public enum ActionEvent
  {
    None,
    LastMessage,
    MessageClear,
    GetItem,
    GetGold,
    GetNewQuest,
    QuestUpdate,
    QuestComplete,
    GetTreasure,
    RemoveFieldObject,
    CallDecision,
    MoveTop,
    MoveLeft,
    MoveRight,
    MoveBottom,
    ForceMoveRight,
    ForceMoveLeft,
    ForceMoveTop,
    ForceMoveBottom,
    ForceMoveRise,
    ForceMoveFall,
    ForceMoveObjTop,
    ForceMoveObjLeft,
    ForceMoveObjRight,
    ForceMoveObjBottom,
    ForceMoveObjRise,
    ForceMoveObjFall,
    InstantiateObject,
    GainSoulFragment,
    MessageDisplay,
    ViewQuestDisplay,
    HidePlayer,
    VisiblePlayer,
    ViewLevelUpCharacter,
    RefreshAllView,
    JumpToLocation,

    ObjectiveAdd,
    ObjectiveRemove,
    ObjectiveRefreshCheck,
    UpdateLocationTop,
    UpdateLocationLeft,
    UpdateLocationRight,
    UpdateLocationBottom,
    HomeTown,
    TurnToBlack,
    TurnToWhite,
    ReturnToNormal,
    BlueOpenTop,
    BlueOpenLeft,
    BlueOpenRight,
    BlueOpenBottom,
    TutorialOpen1,
    BigEntranceOpen,
    CenterBlueOpen,
    SmallEntranceOpen1,
    SmallEntranceOpen2,
    Floor2CenterOpen,
    UpdateUnknownTile,
    EncountBoss,
    StopMusic,
    PlayMusic01,
    PlaySound,
    YesNoGotoDungeon,
    YesNoBacktoDungeon,
    GoBackTutorial,
    GotoHomeTown,
    GotoHomeTownForce,
    DecisionOpenDoor1,
    HomeTownGetItemFullCheck,
    HomeTownRemoveItem,
    HomeTownBlackOut,
    HomeTownTurnToNormal,
    HomeTownBackToTown,
    HomeTownButtonVisibleControl,
    HomeTownMorning,
    HomeTownNight,
    HomeTownDuelSelect,
    HomeTownShowDuelRule,
    HomeTownFazilCastle,
    HomeTownFazilCastleMenu,
    HomeTownTicketChoice,
    HomeTownGoToKahlhanz,
    HomeTownGotoFirstPlace,
    HomeTownExecRestInn,
    HomeTownExecItemBank,
    HomeTownCallRequestFood,
    HomeTownButtonHidden,
    HomeTownRewardDisplay,
    HomeTownYesNoMessageDisplay,
    HomeTownShowActiveSkillSpell,
    HomeTownShowActiveSkillSpellSC,
    HomeTownCallPotionShop,
    HomeTownCallSaveLoad,
    HomeTownCallDuel,
    HomeTownCallDecision,
    HomeTownCallDecision3,
    HomeTownAddNewCharacter,
    GetGreenPotionForLana,
    CallSomeMessageWithAnimation,
    CallSomeMessageWithNotJoinLana,
    DungeonBadEnd,
    DungeonGetTreasure,
    DungeonUpdateFieldElement,
    Floor2DownstairGateOpen,
    DungeonJumpToLocation1,
    DungeonMirrorRoomGodSequence,
    DungeonJumpToLocationRecollection4,
    DungeonSetupPlayerStatus,
    DungeonRemovePartyTC,
    Fountain,
    RealWorldCallItemBank,
    AutoSaveWorldEnvironment,
    AutoMove,
    DungeonGotoDownstair,
    MirrorWay,
    MirrorLastWay,
    DungeonGotoDownstairFourTwo,
    JumpToLocationHellMirror1,
    UpdateUnknownTileAreaHellLast,
    DungeonGotoDownStairFiveTwo,
    UpdateUnknownTileAreaTruthFinal,
    Ending,
  }
  #endregion

  #region "一般"
  public static void MessageX00001(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "", ActionEvent.MessageClear);

    Message(ref m_list, ref e_list, "～ 休息を取りました ～", ActionEvent.MessageDisplay);
  }

  public static void MessageX00002(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：休息を取ったばかりだ。他に何かやらねえとな。", ActionEvent.None);
  }

  public static void MessageX00003(ref List<string> m_list, ref List<ActionEvent> e_list, string item_name)
  {
    Message(ref m_list, ref e_list, "アイン：よっしゃ、宝箱発見！", ActionEvent.None);

    Message(ref m_list, ref e_list, item_name, ActionEvent.GetTreasure);
  }

  public static void MessageX00004(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よし、回復の泉だな。休んでいくとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.Fountain);

    Message(ref m_list, ref e_list, "【 パーティメンバーのステータスが全快しました 】", ActionEvent.None);
  }

  public static void MessageX00005(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：遠見の青水晶で既にダンジョンから脱出しているからな。今日はもう止めておこう。", ActionEvent.None);
  }

  public static void MessageX00006(ref List<string> m_list, ref List<ActionEvent> e_list, string food_menu)
  {
    Message(ref m_list, ref e_list, "アイン：よし、今日はもう休むとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：飯は【" + food_menu + "】を頼むとしよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：すみません。【" + food_menu + "】をお願いできますか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "宿屋のマスター：はいよ、少々お待ちあれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "・・・しばらくして・・・", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "宿屋のマスター：おまちどうさま。どうぞ、召し上がれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ありがとうございます。いただきます！", ActionEvent.None);

    Message(ref m_list, ref e_list, food_menu, ActionEvent.HomeTownCallRequestFood);

    Message(ref m_list, ref e_list, "【 パーティは十分な食事を取りました 】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ごちそうさまでした！", ActionEvent.None);

    Message(ref m_list, ref e_list, "宿屋のマスター：あいよ。あとは部屋でゆっくり休んでいきな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ありがとうございます！", ActionEvent.None);

    Message(ref m_list, ref e_list, "【 パーティは休息を取りました】", ActionEvent.MessageDisplay);
  }

  public static void MessageX00007(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：何もねえな・・・戻るとするか。", ActionEvent.None);
  }

  public static void MessageX00008(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：いや、今は少し休むとしよう。", ActionEvent.None);
  }

  public static void MessageX00009(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：売却するアイテムをまず選ばないとな。", ActionEvent.None);
  }

  public static void MessageX00010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：購入するアイテムをまず選ばないとな。", ActionEvent.None);
  }

  public static void MessageX00011(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：まずは行き先を選択しないとな。", ActionEvent.None);
  }

  public static void MessageX00012(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：今いるのがココだ。他を選ぼう。", ActionEvent.None);
  }
  #endregion

  #region "サルン洞窟入口前のフィールド"
  public static void Message000010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "1", ActionEvent.UpdateUnknownTile);

    Message(ref m_list, ref e_list, "アイン：さてと・・・道のりだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：この草原区域、安全とは言えモンスターが出る区域よ。十分注意してよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：任せとけって。大丈夫さ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "20", ActionEvent.MoveLeft);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);

    Message(ref m_list, ref e_list, "2", ActionEvent.UpdateUnknownTile);

    Message(ref m_list, ref e_list, "アイン：おっ、なんか看板があるな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：じゃ、読んでみるわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "『　準備を怠るべからず、獣道には入るべからず　』", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なるほど、さすがにこれは俺もわかる。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：獣道に入れって事で合ってるよな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "『ッシャゴオォォオォォ！！！』（ラナのエレクトリカル・ブローがアインに炸裂）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ッグフオォ・・・、ラナ、お前もう少し加減しろよ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ハアアァァァ・・・ともかく、まずはファージル宮殿に向かいなさいよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジかよ！　どう考えてもこれは行っておくべきだろ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ホンットに時間切れで遠征許可証もらえなくなっても知らないわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いやいやいや・・・それはマズいのは確かだが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：だったらまずは最初の意気込み通りに進めてちょうだい、いいわね？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：わ、分かった。まずはファージル宮殿へ向かおう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラナ、ところでマップ見せてくれないか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：アンタ自分でマップ作成しないつもりなわけ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：せっかくなんだし、頼むぜ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ったく、しょうがないわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：私が作成しておいてあげるから、ちゃんとマップ管理しなさいよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：助かるぜ。サンキューな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ行くぜ！", ActionEvent.None);

  }

  public static void Message000020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "『　行き止まり。引き返すがよい　』", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：さすがに何もなさそうだな・・・引き返すしかないか。", ActionEvent.None);
  }

  public static void Message000030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：看板だな。どれどれ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "『　急がば回れ、報酬は遠き道にあり　』", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：どういう意味だ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：焦って探索してもしょうがないって事でしょ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そこに岩があるが、ひょっとして・・・何かあるって事か！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：どうかしら。行ってみないと、さすがに分からないわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ま、このデケぇ岩はどけられないしな。ほかのルートを探すとするか。", ActionEvent.None);
  }

  public static void Message000040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message000040 == false)
    {
      One.TF.Event_Message000040 = true;
      One.TF.FieldObject_CaveofSarun_00001 = true;

      Message(ref m_list, ref e_list, "アイン：看板だな。読んでみるぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　訪れし者よ。次へと進むが良い　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "ッゴゴゴゴ、ズズウウゥゥゥン・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "1", ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "ラナ：岩が取り除かれたみたいね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、行ってみよう。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　次へと、進むが良い　』", ActionEvent.None);
    }
  }

  public static void Message000050(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message000050 == false)
    {
      One.TF.Event_Message000050 = true;
      One.TF.FieldObject_CaveofSarun_00002 = true;

      Message(ref m_list, ref e_list, "アイン：看板だな、ええと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　訪れし者よ。手に取り、切り拓き、進むが良い。　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どういう意味だ？", ActionEvent.None);

      if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
      {
        Message(ref m_list, ref e_list, "ラナ：そこの宝箱の事を指しているんじゃないのかしら。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあ、そうなんだが・・・", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "ラナ：手に入れたマトックを使えって事じゃないの？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあ、そうなんだが・・・", ActionEvent.None);
      }

      Message(ref m_list, ref e_list, "ラナ：なんか気になるワケ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、何となく、なんかあるのかなと思っただけだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：相変わらず、よく分からないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあそこまで重要な内容じゃなさそうだ。気になったところは調べて回ろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：分かったわ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　訪れし者よ。手に取り、切り拓き、進むが良い。　』", ActionEvent.None);
    }
  }

  public static void Message000060(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message000060 == false)
    {
      One.TF.Event_Message000060 = true;

      Message(ref m_list, ref e_list, "アイン：看板だな、ええと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　訪れし者よ。手に取り、切り拓き、進むが良い。　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どういう意味だ？", ActionEvent.None);

      if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
      {
        Message(ref m_list, ref e_list, "ラナ：そこの宝箱の事を指しているんじゃないのかしら。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあ、そうなんだが・・・", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "ラナ：手に入れたマトックを使えって事じゃないの？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあ、そうなんだが・・・", ActionEvent.None);
      }

      Message(ref m_list, ref e_list, "ラナ：なんか気になるワケ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、何となく、なんかあるのかなと思っただけだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：相変わらず、よく分からないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあそこまで重要な内容じゃなさそうだ。気になったところは調べて回ろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：分かったわ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　訪れし者よ。手に取り、切り拓き、進むが良い。　』", ActionEvent.None);
    }
  }
  public static void Message000070(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "『　準備を怠るべからず、獣道には入るべからず　』", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：準備を怠ってなけりゃ・・・獣道に入っても・・・？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：遠征許可証の準備はできているのかしら？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そ、そうだな・・・", ActionEvent.None);
  }

  public static void Message000080(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "3", ActionEvent.UpdateUnknownTile);

    Message(ref m_list, ref e_list, "アイン：・・・看板が２枚か。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：見てみましょうよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ。", ActionEvent.None);
  }

  public static void Message000090(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message000090 == false)
    {
      One.TF.Event_Message000090 = true;
      Message(ref m_list, ref e_list, "『　危険区域。立ち寄るべからず　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃ、入るとしますか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと。獣道に立ち寄ってる暇はないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なぜだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：理由がいるのかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：立ち寄るのに、理由は要らない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：遠征許可証が失効する理由にはなるわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：やめておくとするか・・・", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　危険区域。立ち寄るべからず　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：分かってるわよね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、あぁ・・・", ActionEvent.None);
    }
  }

  public static void Message000095(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message000095 == false)
    {
      One.TF.Event_Message000095 = true;
      Message(ref m_list, ref e_list, "『  ←　この先、ファージル宮殿　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、こっちみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：早く行きましょう。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『  ←　この先、ファージル宮殿　』", ActionEvent.None);
    }
  }

  public static void Message000100(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：待て、なんかいるぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：えっ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あっちの広場だ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "10", ActionEvent.UpdateUnknownTile);

    Message(ref m_list, ref e_list, "2", ActionEvent.MoveBottom);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveTop);

    Message(ref m_list, ref e_list, "ラナ：本当ね。また面倒そうなモンスターが出たわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：まあ、危険レベルは低いだろうが、気を付けて行こう。", ActionEvent.None);
  }

  public static void Message000110(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "？？？：ッキシャアアアアァァァ！！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラナ、気を付けて挑むぞ、準備いいか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ええ、いつでも良いわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ、行くぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.SCREAMING_RAFFLESIA, ActionEvent.EncountBoss);

  }

  public static void Message000120(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よし、看板だな。どれどれ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "『　獣道。資格なき者、入るべからず　』", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：こっ・・・これは・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ほら、引き返すわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：今はどうしても駄目か？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：駄目に決まってるでしょ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：単なる獣道だろ？さくっとモンスター倒してお宝GETだろ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：単なる獣道なら入る必要はないわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：通行許可証さえあれば資格を手に入れた事になるんだよな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：そう思えるのは、アンタのバカ脳ミソぐらいよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ともかく、駄目なものは駄目よ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：しょうがねえ・・・ここは一つ引き下がるか・・・", ActionEvent.None);
  }

  public static void Message000130(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    // todo 資格があれば入れる事とする。
    Message(ref m_list, ref e_list, "ラナ：っちょっと！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：うわっ、そんな怒るなよ。分かった、分かった。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);

    Message(ref m_list, ref e_list, "アイン：（しばらく、ここは無理そうだな・・・）", ActionEvent.None);
  }

  public static void Message000140(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_CaveofSarun_00003 == false)
    {
      One.TF.FieldObject_CaveofSarun_00003 = true;
      UseMatockForRock(ref m_list, ref e_list, Fix.CAVEOFSARUN_Rock_5_O);
    }
  }
  public static void Message000150(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_CaveofSarun_00002 == false)
    {
      One.TF.FieldObject_CaveofSarun_00002 = true;
      UseMatockForRock(ref m_list, ref e_list, Fix.CAVEOFSARUN_Rock_6_O);
    }
  }
  public static void Message000160(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_CaveofSarun_00007 == false)
    {
      One.TF.FieldObject_CaveofSarun_00007 = true;
      UseMatockForRock(ref m_list, ref e_list, Fix.CAVEOFSARUN_Rock_7_O);
    }
  }
  public static void Message000170(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_CaveofSarun_00008 == false)
    {
      One.TF.FieldObject_CaveofSarun_00008 = true;
      UseMatockForRock(ref m_list, ref e_list, Fix.CAVEOFSARUN_Rock_4_O);
    }
  }
  public static void Message000180(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_CaveofSarun_00009 == false)
    {
      One.TF.FieldObject_CaveofSarun_00009 = true;
      UseMatockForRock(ref m_list, ref e_list, Fix.CAVEOFSARUN_Rock_8_O);
    }
  }

  public static void Message000190(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.AvailableImmediateAction = true;

    Message(ref m_list, ref e_list, "アイン：そういえば、ちょっと気になってんだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：どうかしたの？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラナが用意してくれた赤ポーションや他のアイテムを使おうと思ってんだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：これって普通に使って良いんだよな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：良いと思うけど、何よ突然。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：戦闘中に使っても良いんだよな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：まあ、良いんじゃないかしら。バカアインにしては良い案ね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：俺は決してバカではない。ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ハイハイ。で、やるんだったら前準備は必要なんじゃないかしら。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ！じゃあ、戦闘向けにどれを使うのか決めておくとするか！", ActionEvent.None);

    Message(ref m_list, ref e_list, "【　戦闘中にアイテム・アクションが使えるようになりました！　】", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "【　バトルコマンド設定画面でアイテム・アクションを設定してみてください。　】", ActionEvent.MessageDisplay);
  }
  #endregion

  #region "アンシェットの街"
  public static void Message100010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：っしゃ・・・これで準備OKかな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：え、ちょっとそれだけしか持っていかないワケ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.ReturnToNormal);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_ANSHET + "にて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：旅に出るんだ。荷物はこれぐらい軽くしておいたほうが良いだろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：軽くしておいたって・・・最低限の装備以外は何も持ってないじゃない、何考えてんのかしらホント・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：はい、ポーションと軍資金、それから遠見の青水晶を用意しておいたからね。", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.SMALL_RED_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.SMALL_RED_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.SMALL_RED_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.SMALL_BLUE_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.SMALL_BLUE_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.SMALL_BLUE_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.ITEM_TOOMI_AOSUISYOU, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, "【 " + Fix.SMALL_RED_POTION + " 】と【 " + Fix.SMALL_BLUE_POTION + " 】を取得しました！", ActionEvent.MessageDisplay);
    Message(ref m_list, ref e_list, "【 " + Fix.ITEM_TOOMI_AOSUISYOU + " 】を取得しました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "500", ActionEvent.GetGold);
    Message(ref m_list, ref e_list, "【 500 gold 】を獲得しました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：あと旅に出るわけじゃなくて、正式な調査依頼を受けて、任務遂行しに行くのよ。ちゃんと準備してよね、ホント。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：大丈夫だって、オーケーオーケー！ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：頭痛がしてきたわ・・・まったく・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ところで、ちゃんと国内外遠征許可証はそのバックパックに入ってるんでしょうね？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：国内外・・・遠征・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：許可証ってなんだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：許可証を受け取りに、ファージル宮殿には行った？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：行ってねえな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：許可証を受領するための期限が先週までだったのは知ってるわよね？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ウソだろ？そんな期限なんてあったか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：当然じゃない。国内外遠征許可証の推薦状にはちゃんと目を通したわけ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、もちろんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：その推薦状に書いてあったわよ。ちゃんと見てないわよね？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、もちろんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "『ッシャゴオォォオォォ！！！』（ラナのファイナリティ・ブローがアインに炸裂）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：わ、分かった分かった・・・すまねえ。今から取りに行くからさ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：本当に行くんでしょうね？今日中に行かないと本当にもらえなくなるわよ、頼むわよホント。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ところで、ファージル宮殿に行けば良いんだよな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：そうよ。このアンシェット町から川沿いに北へ向かえば、すぐ到着するわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ早速行くとしますか！ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_1 + " 】が開始されました！", ActionEvent.GetNewQuest);

    Message(ref m_list, ref e_list, "", ActionEvent.AutoSaveWorldEnvironment);
  }

  public static void Message100015(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "ラナ：ちょっと、そんな事やってないでファージル宮殿に行きましょうよ。", ActionEvent.None);
  }

  public static void Message100020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よし、着いたみたいだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：じゃあ、早速ファージル宮殿へ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと待って。宮殿行く前に少し休憩がしたいんだけど、良いかしら。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：分かった。それじゃあ、宿屋でも探すとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：宿屋ならハンナ叔母さんがやっているはずよ。さ、行ってみましょ♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ、了解！", ActionEvent.None);
  }

  public static void Message100021(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よし、" + Fix.TOWN_FAZIL_CASTLE + "に到着。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：正面ゲートから入ったらすぐ横の受付を済ませてちょうだいね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、わかった。了解了解！", ActionEvent.None);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、受付口にて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "　　【受付嬢：" + Fix.TOWN_FAZIL_CASTLE + "へようこそ。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：すまないがちょっと教えてくれ。国内外遠征のための通行証が欲しいんだが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：ファージル王国からの推薦状をご提示願いますでしょうか。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：えっ！なんだって！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：何、驚いてるのよ。ホラ、これでしょ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、焦ったぜ・・・サンキューな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：推薦状を拝見いたします。しばらくお待ち下さい。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：・・・　・・・】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：アイン・ウォーレンス様ですね。本日はようこそおいでくださいました。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：こちらがアイン・ウォーレンス様の国内外遠征許可証となります。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：どうぞ、お受け取りください。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "【 " + Fix.FIELD_RESEARCH_LICENSE + " 】を獲得しました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, Fix.FIELD_RESEARCH_LICENSE, ActionEvent.GetItem);

    Message(ref m_list, ref e_list, "アイン：サンキュー！助かるぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：なお、エルミ・ジョルジュ国王陛下よりアイン・ウォーレンス様へ連絡があるとの事です。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：本日、この国内外遠征許可証をお持ちの上、必ず謁見の間へ行かれます様、よろしくお願い申し上げます。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：エルミ国王が・・・なんだろう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：バカアインが許可証もらうのをサボってたから、心配してるんじゃないの？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ハハハ・・・言われてみりゃそうかもな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：謁見の間は宮殿の中央から３階まで上がった場所にあるわよ。早く行きましょう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：了解！", ActionEvent.None);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、謁見の間にて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：よし、謁見の間は確かここだったな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：じゃ、行ってきてちょうだい。失礼の無いようにね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あれ、ラナは入らないのかよ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：呼ばれたのはアインだけよ。私が入る事はできないわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そうなのか。じゃあ俺一人で行ってくるぜ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：し、失礼つかまつります！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：アイン君だね。ようこそファージル宮殿へ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：この度は、ご機嫌うるわしく・・・候・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：難しい言葉は使わなくて良いよ。謁見の間では気楽に喋ってもらえれば良いから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：は、はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：ここに呼び出してしまって、すまなかったね。でも、どうしても一件頼みたい事があるんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：頼みたい事？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：遠征先であるヴィンスガルデ王国エリアで調査して欲しい案件があるんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：案件の内容は王妃ファラから解説させようと思う。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：こら、ファラ。変なところに隠れてないで、ちゃんと出てきてくれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：フフフ。ジャーン（＾＾", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ファ、ファラ様！お、お久しゅうございます。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：ファラ。謁見の間でかくれんぼして遊んじゃいけないって言っただろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：エルミのケチンボ（＾＾＃", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：ッグ・・・ケチで言ってるわけじゃない。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ハ、ハハ・・・ええと・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：アインさん、リラックスして聞いてくださいね（＾＾", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ハイ。分かりました。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：ファージル王国では、昔から古代アーティファクトにまつわる件を分析の対象としているの。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：古代アーティファクト？　そんなのがあるんですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：伝説、古文書、語り継がれている伝承、そういったものは沢山あるのですが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：信憑性の高いものはほとんど無い・・・って所ですかね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：ええ、その通りです。", ActionEvent.None);

    Message(ref m_list, ref e_list, "（　王妃ファラは少し真剣な眼差しを向けてきた　）", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：ヴィンスガルデ王国の歴史には一つの伝承があります。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：えっ・・・？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：その伝承には一つのキーワードが示されています。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：その名は【Obsidian Stone】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：Obsidian・・・Stone・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：アインさんには、そのObsidianStoneの調査を秘密裏に遂行していただきたいの。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：秘密裏・・・え。どういう事ですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：ファラ、そこまでで良いよ。後はボクが話すから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：あら、じゃあお願いしても良いかしら（＾＾", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：アイン君。【ObsidianStone】については、様々な説があり、申し訳ないが一概にどういったものかは説明が難しい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：そこで、まずは" + Fix.TOWN_COTUHSYE + "へ寄って情報収集をしてきてもらいたい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：" + Fix.TOWN_COTUHSYE + "？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：ああ、沿岸沿いにある港町だよ。色々な人たちが集う場所だから、何か情報が得られる事を期待している。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：また、そこから船を使って" + Fix.AREA_VINSGARDE + "王国へ目指してもらいたい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：分かりました。じゃあ、まずは" + Fix.TOWN_COTUHSYE + "へ行ってみます。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：それから、少しばかりだが軍資金とアイテムを用意しておいた。好きに使ってもらって構わないよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "【 2000 gold 】を獲得しました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "2000", ActionEvent.GetGold);

    Message(ref m_list, ref e_list, " 【 " + Fix.ARTIFACT_GENSEI + " 】を手に入れました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, Fix.ARTIFACT_GENSEI, ActionEvent.GetItem);

    Message(ref m_list, ref e_list, "アイン：あ、ありがとうございます！僭越ながら、拝受つかまつります！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：丁寧にどうもありがとう。固苦しい言葉は本当に気にしなくていいからね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：さて、港町まで行くには途中にある" + Fix.DUNGEON_GORATRUM_CAVE + "を通過する必要があるだろう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：アイン君なら、きっと通過できる。信じているよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：えっと・・・分かりました！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あと、すみませんが、港町コチューシェに到着したら何かやる事はありますか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：いや、特に「何か」っていうのは気にしなくて良いよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：天の導きがあれば、自然と道は拓かれる。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そ、そんなもんですかね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：アイン君ならきっと大丈夫だよ。いつも通りで。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：はい、分かりました！", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_2 + " 】が開始されました！", ActionEvent.GetNewQuest);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、エントランスにて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：じゃあ、まずは" + Fix.TOWN_COTUHSYE + "へ向かえば良いみたいね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、遠征許可証も手に入れたし、それじゃ、そろそろ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：あら、ちょって待ってアイン。そこの出入り口に誰かいるみたいよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ん、本当だな・・・誰だ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：あ、あの。すみません・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よう、こんにちわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：あの・・・私・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：えっと、なんか用か？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアイン。あんたは引っ込んでなさい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なぜ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：いいから、任せておいて。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：あの・・・スミマセン・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：こんにちわ、はじめまして。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：あ、はじめまして、私はエオネ・フルネアと申します。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：私はラナ・アミリアよ。よろしくね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あっ、えっと。よろしくおねがいします。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あの！今日は、し、仕事の依頼があって参りました！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：私を" + Fix.TOWN_COTUHSYE + "までお送りいただけないでしょうか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おお、俺たちも今からそこに向かうつもりだ。タイミングが良いな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え、えっと、あの・・・その" + Fix.TOWN_COTUHSYE + "まで・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：（ちょっ、バカアイン出てくるとややこしいから、引っ込んでてよ）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：（あ、あぁ・・・）", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：" + Fix.TOWN_COTUHSYE + "まで護衛して欲しいって事よね、承るわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：確認なんだけど、一般市民としてかしら？それとも、戦闘で何か出来る事はある？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え、えっと。多少ですが、魔法は使えます。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：じゃあ、戦闘グループとして同行してもらう形のほうが良いかしら？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：ハ、ハイ！喜んで！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：決まりみたいね♪　じゃあ、" + Fix.TOWN_COTUHSYE + "まで、一緒に行きましょう♪", ActionEvent.None);

    Message(ref m_list, ref e_list, " 【エオネ・フルネア】が仲間になりました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, Fix.NAME_EONE_FULNEA, ActionEvent.HomeTownAddNewCharacter);

    Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます！よろしくお願いします！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ行こう！", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_1 + " 】を達成しました！", ActionEvent.QuestComplete);
  }
  #endregion

  #region "フィールド"
  public static void Message101000(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よっしゃ、回復の泉だな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.Fountain);

    Message(ref m_list, ref e_list, "パーティは全回復しました。", ActionEvent.MessageDisplay);
  }

  public static void Message101001(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FindBackPackItem(Fix.FIELD_RESEARCH_LICENSE) == false)
    {
      Message(ref m_list, ref e_list, "衛兵：通行許可証を拝見させていただきます！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なに！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ほら、だから言ってるじゃない。先に許可証が必要だって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "衛兵：通行許可証はここファージル宮殿の国王より配布されます。直ちにお戻りください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    if (One.TF.Event_Message100030 == false)
    {
      One.TF.Event_Message100030 = true;

      Message(ref m_list, ref e_list, "衛兵：通行許可証を拝見させていただきます！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なに！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：なにって、さっきもらった許可証の事じゃない。早く出しなさいよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、ああ。そうだったな。衛兵さん、これで良いかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "衛兵：うむ、確かに通行許可証を確認した！道中気をつけて行くがよい！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、サンキューな。", ActionEvent.None);
    }
  }
  public static void Message101002(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FindBackPackItem(Fix.FIELD_RESEARCH_LICENSE) == false)
    {
      Message(ref m_list, ref e_list, "衛兵：通行許可証を拝見させていただきます！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なに！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ほら、だから言ってるじゃない。先に許可証が必要だって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "衛兵：通行許可証はここファージル宮殿の国王より配布されます。直ちにお戻りください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
      return;
    }

    if (One.TF.Event_Message400010 == false)
    {
      Message(ref m_list, ref e_list, "アイン：よし、じゃあ通行許可証を・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと待ってよ。今から港町コチューシェの方へ向かうんでしょ？そっちじゃないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっと、悪い悪い・・・ここは一旦戻るとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);

      return;
    }

    if (One.TF.QuestMain_00021 == false)
    {
      Message(ref m_list, ref e_list, "アイン：よし、じゃあ通行許可証を・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと待ってよ。まずはファージル宮殿に報告しに行くんでしょ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっと、悪い悪い・・・ここは一旦戻るとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
      return;
    }
  }
  public static void Message101003(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FindBackPackItem(Fix.FIELD_RESEARCH_LICENSE) == false)
    {
      Message(ref m_list, ref e_list, "衛兵：通行許可証を拝見させていただきます！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なに！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ほら、だから言ってるじゃない。先に許可証が必要だって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "衛兵：通行許可証はここファージル宮殿の国王より配布されます。直ちにお戻りください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    if (One.TF.Event_Message400010 == false)
    {
      Message(ref m_list, ref e_list, "アイン：よし、じゃあ通行許可証を・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと待ってよ。今から港町コチューシェの方へ向かうんでしょ？そっちじゃないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっと、悪い悪い・・・ここは一旦戻るとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    if (One.TF.QuestMain_00021 == false)
    {
      Message(ref m_list, ref e_list, "アイン：よし、じゃあ通行許可証を・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと待ってよ。まずはファージル宮殿に報告しに行くんでしょ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっと、悪い悪い・・・ここは一旦戻るとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ通行許可証を・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、そっちにいってもアーケンダイン街にはたどり着けないわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっと、悪い悪い・・・ここは一旦戻るとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
    return;
  }

  public static void Message101004(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message200010 == false)
    {
      Message(ref m_list, ref e_list, "エオネ：あ、あの・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうかしたか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと、そこのバカアイン。依頼人を無視してどこに行くつもりなのよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あっ、悪かった！！本当、クヴェルタ街に行く約束だったな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：す・・・すみませんが、お願い致します。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、今から行くぜ！ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
    }
  }

  public static void Message101005(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "ラナ：ちょっと、そこのバカ。港町コチューシェはそっちじゃないわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっと、そうか。悪い悪い。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
  }

  public static void Field_000010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.EventField_10 == false)
    {
      One.TF.EventField_10 = true;

      Message(ref m_list, ref e_list, "アイン：ん・・・何か向こう側から人の気配がするな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ねえ、あの入口の門に誰か居るわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、声をかけてみるか・・・！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：こんにちわー。", ActionEvent.None);

      Message(ref m_list, ref e_list, "門番：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あの、アイン・ウォーレンスという者ですが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "門番：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ここって、通過しても良いものでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "門番：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：どけ。ちょっと俺が何とかしてやる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：たのもう！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "門番：！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：いざ、尋常に・・・！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょ、っちょっと待てって。戦いに来たわけじゃないんだぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：何でだよ。あの門番、はじめっから戦うオーラがバンバン出てるぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あれは常に警戒心を怠ってないだけだろ。別に俺たちに敵意を向けているわけじゃない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：クソ・・・じゃ、どうすんだよ。指をくわえて見てるだけってか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・あの。す、す、すみません・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・ちょ、ちょっとだけ・・・私が出ても良いでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：交渉のネタでもあるのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：と、とにかく・・・ちょっとだけで良いので　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：バカアインみたいにノープランってワケじゃなさそうね。エオネ、大丈夫？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ハ・・・ハ、ハイ。　おそらくあの・・・ハイ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：う～ん、まあ何か作戦があるなら頼みたい所だが、ちょっとリスキーだよな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラナ、お前も傍に居てやってくれ。頼んだぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：うん、わかったわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　ラナとエオネが門番に近づき、何かを話し始めた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・何か普通に会話してるな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：あの門番。女子に弱いんじゃねーのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、違うだろ。こういった者達は卓越した精神力を保持しているという噂を聞いた事がある。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：女子とか男子とかそういった類では動かないはずだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：へぇ、そんなもんかな。こういった所に限ってそういうのが弱点だったりするのが普通だけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ともかく、結構話してるみたいだし・・・少し様子を・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・おっ、戻ってきたな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よう、どうだった？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：大丈夫です。通っても良いみたいです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ありがと、エオネ♪　あなたのおかげね♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：いえ・・・あ、いえ、どういたしまして。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どういう話の内容で説得したんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：少々・・・ObsidianStoneにまつわる話を・・・いたしました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：伝承の真実を追い求めている。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：真実か偽りかは私達で判断はできない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：だからこそ、この目で見ておきたい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そういった流れの話を少々・・・すみません、出しゃばりすぎました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：へえぇ！いやいやいや、凄いな！よくそんな交渉ができたな！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアイン失礼よ、今の言い方は。感謝しなさいよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おお、ああ。悪い悪い、サンキューな！エオネ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・いえ、えっと・・・と、ともかく終わりましたので、先に進んでください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オーケー！じゃ、早速通過させてもらうとしますか！", ActionEvent.None);
    }
  }

  public static void Field_000020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.EventField_20_GetName == false)
    {
      if (One.TF.EventField_20 == false)
      {
        One.TF.EventField_20 = true;

        Message(ref m_list, ref e_list, "アイン：あ、やっぱ門番らしき人物が居るな・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：あの野郎。ここは通さねえってオーラ出しまくってやがるな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ま、まあそう言わず、まずは一応声をかけてみよう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　アインは門番の前に近寄っていった　～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "アイン：こんにちわー。", ActionEvent.None);

        Message(ref m_list, ref e_list, "門番：名を何と申す。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：アイン・ウォーレンスという者です。よろしくお願いいたします。", ActionEvent.None);

        Message(ref m_list, ref e_list, "門番：其方の名は、天より授けられし名称であるか。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：っな、いや、俺の名は・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "門番：名を名乗れぬ以上、通すわけには行かぬ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "門番：お引き取りを。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ちょっと待ってくれ。この【ムーンフォーダー区域遠征許可証】じゃダメなのか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "門番：お引き取りを。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：は・・・はい・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　アイン、そのまま引き返してきた　～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "ラナ：で、駄目だったわけ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあそうだな。基本は通してくれなさそうだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：許可証ちゃんと見せたのかよ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：見せてはいるが・・・どうもそれだけじゃ駄目みたいだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：どういう意味よ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：天の名を名乗れと言われた。そういうオカルト的なのはお手上げだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：ふーーん、そうなの。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：まあ、第一はまず神殿に行った方が良いんじゃないのかしら？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：やっぱそうかな。ここは一旦引き下がるとするか。", ActionEvent.None);

        Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
      }
      else
      {
        Message(ref m_list, ref e_list, "門番：名を何と申す。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：アイン・ウォーレンスという者です。", ActionEvent.None);

        Message(ref m_list, ref e_list, "門番：其方の名は、天より授けられし名称に非ず。", ActionEvent.None);

        Message(ref m_list, ref e_list, "門番：お引き取りを。", ActionEvent.None);

        Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
      }
    }
  }
  #endregion

  #region "クヴェルタ街"
  public static void Message200010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よし、" + Fix.TOWN_QVELTA_TOWN + "に到着したみたいだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ねえ、ちょっと寄っていきたい所があるんだけど良いかしら？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、構わねえぜ。どこに行くんだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：武器屋を営んでいるヴァスタ叔父さんの所よ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ヴァスタ叔父さん？って誰だっけ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、私達が小さい頃に会ってるじゃない。忘れたの？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あ、ああ！覚えてるぜ！名前を聞いてもちょっとピンと来なかったからさ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：エオネ、お前はヴァスタって叔父さんの事、知ってるか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え、えっと・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：そこのバカアイン、何勝手に話しかけてるのよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：え、いやエオネさんなら何か噂とか聞いたことあるのかなって思っただけだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：無理に答えなくて良いのよ。バカが何か適当に喋ってるだけだから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え・・・えぇ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：じゃ、その武器屋のおっちゃんの所へ行くとするか！", ActionEvent.None);

    //}
    //public static void Message200020(ref List<string> m_list, ref List<ActionEvent> e_list)
    //{
    //    One.TF.Event_Message200020 = true;

    Message(ref m_list, ref e_list, "～ ヴァスタの武器屋にて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：ごめんくださーい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：あいよ！いらっしゃい！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：あっ、ヴァスタおじさま、お久しぶりです♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：お、おぉー、ラナちゃんか！大きくなったな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：そちらのもうひとりのお嬢ちゃんは？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あっ・・・エオネ・フルネアと言います、よろしくお願いします。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：おお、そうかそうか。よろしくな、お嬢ちゃん。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラナ、ヴァスタおじさんに用があってきたんだろ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：うん、ちょっと待ってね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：えとね・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：あ。あったわ、ヴァスタおじさま♪　この武具を見て欲しいんだけど・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：武具鑑定か！よし、任せておきなさい！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：どれどれ・・・ふーむ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：・・・ぉお・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：おおおおおぉぉぉ、こ、こ、これは！！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なんだなんだ？ひょっとして大当たりか！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ぜんぜん、解明できん！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ガッハハハハ！！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジか、しかし鑑定出来ないなんて事もあるんだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：でもさ。これってアクセサリーの一種だと思ったんだけどな。違うのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：いや、ワシも最初はそう思ったのじゃが、どうも解析しきらんエッセンスがあるようでのう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そうか。まあ俺は鑑定出来ないしな。基本、ヴァスタ爺さんに任せるしかないわけだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そういや、ラナ。こんな代物、いつの間に持っていたんだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：え、何よ！！？　し、し、知らないわよ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：うお、そんな焦らなくても良いだろ。悪かった、単に聞いただけだって。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：すまんが、ラナちゃん。このアイテム。もうしばらく鑑定させてくれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：あ、よろしくお願いします♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあそのアイテムは、ヴァスタのおっちゃんに頼むとするか！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：うむ、任せなさい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：しかし、こちらかもすまぬが、一つだけ頼み事を聞いてもらえんかね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、なんでも言ってくれ。引き受けられる内容ならいくらでもやるぜ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ふむ・・・鑑定についてだが、実は鑑定用の機材が一部不足しておるのだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なるほど、何か機材を取ってくれば良いんだな？了解了解！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：話が早くて助かる。ここから少し北に行き、" + Fix.FIELD_ARTHARIUM_FACTORY + "に行って欲しい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：そこで、ゼタニウム鉱石を５つ取ってきて欲しいのじゃが、どうだろうか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：" + Fix.FIELD_ARTHARIUM_FACTORY + "だな、わかったぜ。ラナ、後でマップ確認を頼んだぜ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ええ、良いわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_4 + " 】が開始されました！", ActionEvent.GetNewQuest);

    Message(ref m_list, ref e_list, "ヴァスタ：あそこはモンスターも出てくるという噂を聞いておる。準備は万全にな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：オーケー！じゃあ、ゼタニウム鉱石を取ってきたらまた戻ってくるぜ。少し待っててくれよな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：すまんが、よろしく頼む。", ActionEvent.None);
  }
  public static void Message200030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message200030 = true;

    Message(ref m_list, ref e_list, "アイン：おじさん。ども、こんにちわー", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：おー、アインか。いらっしゃい！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：前にお願いしていたゼタニウム鉱石を持ってきました♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：お、そいつは嬉しいねえ！では、早速例のアイテムの鑑定を行うとするかの！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ちなみに、そのゼタニウム鉱石は５つあるから２５００ＧＯＬＤで引き取るぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：えっ、ちょっとお金なんていいですよ。そんなつもりで持ってきたんじゃないですし。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ええからええから。ワシとて商売人。売買は人との礼儀そのもの。取っておくがよい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：すみません、ではありがたく頂戴します。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：鉱石の中に、超微細レンズの仕組みを担う物質が含まれておってな。それをちょっと抽出してくる。待っておれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よろしくおねがいします！", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　しばらくして　～　", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ヴァスタ：よし、レンズが完成したぞ。これじゃ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：え？その今見せてくれている手のひらに何かあるんですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：あるに決まっておるじゃろう。何を言うとるか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そ、そうなんだ。全然見えねえぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ホントね・・・光の反射でほんの僅かに見える程度ね。普通には見えないレベルだわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：まあ、見ておれ。これで例のアイテムを鑑定する。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ふむ・・・む・・・。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：どうだ、結果は・・・？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：正直に言おう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：これは鑑定は出来ても、ワシ単独では解読はできん。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：どういう事ですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：まずは、鑑定結果を伝えよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：このアイテムのカテゴリは『武器』となる。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジかよ！？こんな小さな形状のリングがか！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：うむ、間違いない。このリングの内部に極小の窪みがあっての。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：そこに、文字が書かれておった。内容はこうじゃ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　『　封じられしはラタの蒼き門。放たれしはシスの朱き詩』", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：何だそれ・・・聞いたことねえな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あれ、なんで皆黙ってんだよ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：今度、私が後で丁寧に教えてあげるわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：えっ、ていうか何でそれで『武器』って事になるんだよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：それも、私が後で丁寧に教えてあげるわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いやいや、教えてくれよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：だから、私が後で丁寧に教えてあげるわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジか・・・。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：・・・ッ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：いえ、なんでも！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：まあ、いいか。詳しくはまた今度教えてくれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ゴッホン、とにかく鑑定自体は完了じゃ。後はお主ら次第。このアイテムは返しておくかの。", ActionEvent.None);

    Message(ref m_list, ref e_list, "～　【法剣？？？】を手に入れた！　～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：鑑定、ありがとうございました♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし。じゃあ、ありがとうな、ヴァスタのおっさん！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：おっさんか！ガハハハハ！また好きな時にどんとこい。いくらでも付き合うぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、またよろしくな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.None);
  }

  public static void Message200040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message200040 == false)
    {
      One.TF.Event_Message200040 = true;

      Message(ref m_list, ref e_list, "アイン：よし、街に一旦戻ったな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アイン、さっきの件なんだけど良いかしら？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、あの入手した奇妙な物体の事だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まず、あの中での出来事だが、声がしたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：内容はこうだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　応えよ　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　そして受諾せよ　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　さすれば意志が宿る　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　時は満たず　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　精神は満たず　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　還るべきは理と知るがよい　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　時が満ちればまた姿を現すがよい、幼きものよ　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：なんだか不思議な言葉ですね・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、その時に手に入れたのがこのアイテムなんだけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっとつかみどころのない話ね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：声はどこから聞こえてきたの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それがな、さっぱり分からないんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何か姿は見えなかったの？？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それも、さっぱり見えなかったんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何か他にこう特徴はなかったわけ？？？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだなあ・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ない！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ふ～ん、そうなんだ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あれ、いつものは飛んでこないのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：なんていうのかしら。本当に情報が無いみたいだったから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、正直そうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：私とラナさんからは何も見えませんでしたしね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そうなのよねえ・・・せめて透明で中が見えていれば、何か気付けたかも知れないんだけど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：強いて何かあると言えば、この物体だけだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：その物体は、私達だけじゃ検討もつかないですよね・・・どうしましょうか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そうだわ。ヴァスタの叔父様に聞いてみれば良いんじゃないかしら？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、そうだな。やっぱヴァスタのおっさん頼みで動くとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：じゃ、きまりね♪　さっそく行ってみましょう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ！", ActionEvent.None);
    }
  }

  public static void Message200041(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：今はヴァスタのおっさんと話すのが先だな。", ActionEvent.None);
  }

  public static void Message200050(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message200050 == false)
    {
      One.TF.Event_Message200050 = true;

      Message(ref m_list, ref e_list, "", ActionEvent.MessageClear);

      Message(ref m_list, ref e_list, "～ ヴァスタの武器屋にて ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：おじさん。どうも、こんにちわー。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：おお、よく来たな。いらっしゃい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おじさん、ちょっと見て欲しいものがあるんだ。見てくれないか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：お安い御用じゃ。どれ、見せてみなさい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。これなんだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ アインは奇妙な物体をヴァスタに見せた ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ヴァスタ：鑑定か！よし、任せておきなさい！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：どれどれ・・・ふーむ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：・・・ぉお・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：おおおおおぉぉぉ、こ、こ、これは！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おじさん？ひょっとして大当たりか！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：これまた、全然分からん！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：ガッハハハハハ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：マジか。何となく予想はしてたんだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：なに！？そりゃ一体どういう意味じゃ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：それなんですけど、アインが入手した時に、すごく奇妙な事象に遭遇しているんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：ほう。どういう経緯で入手したんじゃ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：アーサリウム工場跡地の奥の方で、このアイテムを拾った時だったんだけど、", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：その時に突然、妙な空間に連れ込まれたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、その空間内で何か得たいの知れない声を聴いたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あとは気が付いたら、これを手にしていたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：ほう・・・ほうほう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：よぉし、分かった！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっ！マジか！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：この件はワシではどうにもならん事が分かった！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：ガッハハハハハ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なっ、なんてこった・・・ハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：まあそう嘆くでない。道は指し示してやろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：アインよ。お主はそれを持ってツァルマンの里へと向かうが良いじゃろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "『アイン：なっ？』　　『ラナ：えっ？』　　『エオネ：！？』", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：なんじゃお主ら知らんのか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラナ、お前知ってるか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ、正直聞いた事もないわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エオネはどうだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：え、えっ・・・ええっと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：おーーーーーーしまった！！！すっかり忘れておった！イカン！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：今の件、とある奴から口止めされておったのを忘れておったわ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：な、何だって！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：スマンスマン！まあ、忘れなさい！ガッハハハハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：これだけはっきり言われといて、どうやって忘れるってんだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：まあまあ、そこは何とか忘れてくれい！ガッハハハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：色々と喋ったが全体的にそういうわけじゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヴァスタ：というわけで、ホレ。さっさと行きなされ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ ヴァスタの武器屋から外に出ました ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：何か・・・、色々と知ってそうだったな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：う～ん、どうかしら。そうとも限らないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何でだ？あの口ぶりはあからさまに知ってる証拠だろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：でもね、あの叔父さまはそうでもない時があるのよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうなのか。まあ、どっちみちもうこの件はもう喋ってもらえそうにない雰囲気だったし、ここまでだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：えっと、確か・・・ツァルマンの里って言ってたよな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どこにあるか知らないか？エオネ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：えっ・・・いえ、あ。はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：すみません、良く知らないんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか。うーん、しかし方向が分からないと動きにくいな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、ここから東方向なのは間違いないと思います。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：マジかよ！そういう情報は助かるぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そっちはちょうど港町コチューシェに向かう方角と同じね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ決まりだ。ここを出たらまずその東にある港町コチューシェに向かおう！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、ツァルマンの里とやらの情報もそこで探ってみよう！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_10 + " 】を達成しました！", ActionEvent.QuestComplete);
    }
  }
  #endregion

  #region "アーサリウム工場跡地"
  public static void Message300010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message300010 = true;

    Message(ref m_list, ref e_list, "アイン：よし" + Fix.FIELD_ARTHARIUM_FACTORY + "に着いたみたいだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：・・・大量のガラクタがそこら中に散らばってるわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：エオネ、足元に危ない破片が落ちてるわ。気をつけてね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます。気をつけます。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なあ、ここは特に街ってワケでもなさそうだから、無理せず待っててくれても良いんだぞ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、いえ。大丈夫です。わ、私、その・・・慣れてますから・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あれ？慣れてるのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、いえ・・・え、ええと・・・その・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアインはなんでそう人の気持ちにズカズカと踏み込んでるのよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：バカな。俺はそんな特別な会話はしてないつもりだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：エオネ、足元も注意だけど、そこのバカアインとの会話にも要注意だからね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ・・・はい、わかりました。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：うお・・・マジか・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、わかった。じゃあ次からはもう少し気をつけて喋りかける。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：それよりも、ゼタニウム鉱石を発掘しないといけないのよね。早く始めましょ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、じゃあ早速この辺りを探索開始といきますか！", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.None);
  }

  public static void Message300020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message300020 = true;
    One.TF.Zetanium_001 = true;

    Message30002X(ref m_list, ref e_list);
  }

  public static void Message300021(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message300021 = true;
    One.TF.Zetanium_002 = true;
    Message30002X(ref m_list, ref e_list);
  }
  public static void Message300022(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message300022 = true;
    One.TF.Zetanium_003 = true;
    Message30002X(ref m_list, ref e_list);
  }
  public static void Message300023(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message300023 = true;
    One.TF.Zetanium_004 = true;
    Message30002X(ref m_list, ref e_list);
  }
  public static void Message300024(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message300024 = true;
    One.TF.Zetanium_005 = true;
    Message30002X(ref m_list, ref e_list);
  }

  private static void Message30002X(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：おっ、ゼタニウム鉱石を発見っと！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：やるじゃない♪", ActionEvent.None);

    if (GetZetaniumCount() == 1)
    {
      Message(ref m_list, ref e_list, "アイン：とりあえずは１個ゲットといった所だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：残り４つは見つける必要があるわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、引き続き探索を続けよう。", ActionEvent.None);
    }
    else if (GetZetaniumCount() == 2)
    {
      Message(ref m_list, ref e_list, "アイン：よし、これで２個目だぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まだ３つ見つける必要があるわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、引き続き探索を続けよう。", ActionEvent.None);
    }
    else if (GetZetaniumCount() == 3)
    {
      Message(ref m_list, ref e_list, "アイン：ようやく、これで合計３つだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：残る２つも、うまく見つかると良いわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、引き続き探索を続けよう。", ActionEvent.None);
    }
    else if (GetZetaniumCount() == 4)
    {
      Message(ref m_list, ref e_list, "アイン：おっしゃ、きたきた！４つ目ゲット！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：後１つよ、慎重に探してよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：分かってるって。じゃ、引き続き探索を続けよう。", ActionEvent.None);
    }
    else if (GetZetaniumCount() == 5)
    {
      Message(ref m_list, ref e_list, "アイン：やったぜ、これで５つ揃ったな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：フフ、やったじゃない、おめでとう♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いやー、サンキューサンキュー。ありがとな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、おめでとうございます。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おお、エオネも戦闘は助かったぜ、サンキューな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：じゃあ、一旦" + Fix.TOWN_QVELTA_TOWN + "に戻って、ヴァスタおじさまに渡しに行きましょ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オーケー、了解！！", ActionEvent.None);
    }

    Message(ref m_list, ref e_list, "", ActionEvent.None);
  }

  public static void Message300030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
    {
      Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    if (One.TF.FieldObject_Artharium_00001 == false)
    {
      One.TF.FieldObject_Artharium_00001 = true;

      UseMatockForRock(ref m_list, ref e_list, Fix.ARTHARIUM_Rock_1_O);
    }
  }

  public static void Message300031(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
    {
      Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    if (One.TF.FieldObject_Artharium_00002 == false)
    {
      One.TF.FieldObject_Artharium_00002 = true;

      UseMatockForRock(ref m_list, ref e_list, Fix.ARTHARIUM_Rock_2_O);
    }
  }

  public static void Message300032(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
    {
      Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    if (One.TF.FieldObject_Artharium_00003 == false)
    {
      One.TF.FieldObject_Artharium_00003 = true;

      UseMatockForRock(ref m_list, ref e_list, Fix.ARTHARIUM_Rock_3_O);
    }
  }

  public static void Message300033(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
    {
      Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    if (One.TF.FieldObject_Artharium_00004 == false)
    {
      One.TF.FieldObject_Artharium_00004 = true;

      UseMatockForRock(ref m_list, ref e_list, Fix.ARTHARIUM_Rock_4_O);
    }
  }

  public static void Message300034(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
    {
      Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    if (One.TF.FieldObject_Artharium_00005 == false)
    {
      One.TF.FieldObject_Artharium_00005 = true;

      UseMatockForRock(ref m_list, ref e_list, Fix.ARTHARIUM_Rock_5_O);
    }
  }

  private static void SearchMatockQuest(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：あれ、こっちの方に通路があるように見えるが、デカい岩で塞がれているな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと手で移動させるのは難しそうね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マトックみたいなのが、あれば良いんだがな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：どうかしたの？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、いえ・・・特に意見というわけでは・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ひょっとしてマトックの在処に心当たりでも？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、そうなんです！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：実はこのエリアは昔、立ち寄った事があるので、どこかで見かけた事はあるんです。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっ、そうなのか！じゃちょうど良かった。マトックまで案内してくれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、でも・・・どこにあったかまでは、自信が持てないので・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、そこ。エオネさんに変に押し付けないでよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え・・・っと・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：良いのよ。マトックがどこかにあるって事よね。それだけで十分よ♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：あとはそこのバカが駆けずり回って探す手筈になってるから♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おい、マジかよ。今のじゃほとんど手掛かりねえじゃねえか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：あんたのいつものテキトー直観で見つけるんでしょ。頼んだわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジか・・・まあ、何とか探してみるか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ、任せておけ！ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_5 + " 】が開始されました！", ActionEvent.GetNewQuest);
  }

  private static void UseMatockForRock(ref List<string> m_list, ref List<ActionEvent> e_list, string identity)
  {
    Message(ref m_list, ref e_list, "ラナ：じゃあ、頼んだわよ。アイン。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、任せておけ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あらよっと！", ActionEvent.None);

    Message(ref m_list, ref e_list, identity, ActionEvent.RemoveFieldObject);

    Message(ref m_list, ref e_list, "　～　アインはマトックで岩壁を崩しました！　～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：上手くいったみたいね♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ進もうぜ！", ActionEvent.None);
  }

  public static void Message300040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_Complete_00006 == false)
    {
      if (One.TF.Event_Message300040 == false)
      {
        One.TF.Event_Message300040 = true;

        Message(ref m_list, ref e_list, "アイン：扉か・・・鍵がかかってるな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：他を探してみましょう。きっとどこかに鍵があるはずよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあ、ある事には間違いないんだろうが・・・どこら辺だろうな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：えっと・・・どうかされたんですか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・ッハ！　あ、いやいやいや！", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：また何かくだらないこと考えてたんでしょ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：考えてないでとにかく探してみましょ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ、探索開始だ！", ActionEvent.None);

        Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_6 + " 】が開始されました！", ActionEvent.GetNewQuest);

        Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
      }
      else
      {
        if (One.TF.FindBackPackItem(Fix.ARTHARIUM_KEY) == false)
        {
          Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

          Message(ref m_list, ref e_list, "エオネ：えっと・・・どうかされたんですか？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：・・・ッハ！　あ、いやいやいや！", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：また何かくだらないこと考えてたんでしょ。", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：考えてないでとにかく探してみましょ。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：あ、ああ。", ActionEvent.None);
        }
        else
        {
          One.TF.FieldObject_Artharium_00010 = true;

          Message(ref m_list, ref e_list, "アイン：よし、ここは例の鍵だな！", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：ラナ、開錠については頼んだぜ！", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：別に、鍵なしで開けるわけじゃないんだから、誰でも出来るんだけど。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：いやいや、ここはひとつ頼んだぜ！", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：まあ、良いけど。じゃあソコどいて。", ActionEvent.None);

          Message(ref m_list, ref e_list, "　～　ラナは注意深く扉を調べ始めた　～", ActionEvent.MessageDisplay);

          Message(ref m_list, ref e_list, "ラナ：えーと・・・多分これね。", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：うん、この鍵で大丈夫みたいよ。", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：じゃ、開けるわね。", ActionEvent.None);

          Message(ref m_list, ref e_list, "　ギッ、　ギギィ　・・・　", ActionEvent.None);

          Message(ref m_list, ref e_list, Fix.MAPEVENT_ARTHARIUM_9_O, ActionEvent.RemoveFieldObject);

          Message(ref m_list, ref e_list, "ラナ：やったわ、開いたわよ♪", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：よし！いよいよここの通路の解禁ってわけだな！！", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：じゃあ、早速・・・", ActionEvent.None);

          Message(ref m_list, ref e_list, "エオネ：　・・・　あの、ちょっと待ってください！", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：おお。どうかしたのか？", ActionEvent.None);

          Message(ref m_list, ref e_list, "エオネ：本当に、この先に進むのでしょうか？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：ああ、進むぜ。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：心配するな、大丈夫だ。", ActionEvent.None);

          Message(ref m_list, ref e_list, "エオネ：・・・　・・・っえ？", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：まあ、そこのバカアインがそう言ってるんだし、任せてみれば良いんじゃない？", ActionEvent.None);

          Message(ref m_list, ref e_list, "エオネ：・・・わ、分かりました。", ActionEvent.None);

          Message(ref m_list, ref e_list, "エオネ：じゃあ、アインさん！進軍、お願いします！", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：お・・・おお！", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：任せておけ！ッハッハッハ！", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：ちょっと。進むのは良いけど、策は考えてあるのかしら？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：ない！", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：アーッハッハッハ！", ActionEvent.None);

          Message(ref m_list, ref e_list, "『ッシャゴオォォオォォ！！！』（ラナのメギド・ストライクがアインに炸裂）", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：グフォ・・・！！おまえ、本気で打ち込むなよな。いっつつつ・・・", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：ま、まあ策というほどの事じゃねえが、考えはある。", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：頼んだわよ。この先何かある事ぐらいはエオネも私も分かってるんだから。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：ああ、了解だ！任せておけ！", ActionEvent.None);

          Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_6 + " 】を達成しました！", ActionEvent.QuestComplete);
        }
      }
    }
  }
  public static void Message300041(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：この工場跡地向けの鍵を探さないと、ここを開く事は出来ないな。鍵を見つけよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
  }

  public static void Message300050(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300050)
    {
      return;
    }

    One.TF.Event_Message300050 = true;

    Message(ref m_list, ref e_list, "アイン：へえ・・・結構広い空間だな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：なんだか雑多な場所ね。色々な物が散乱してるみたいだけど。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・きっとココは昔、誰かが使ってたんだろうな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：えっ、そうなの？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：何となくだけどな。散かり具合が微妙に不規則だしな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：その不規則なのが、どう関係あるのよ。そういう説明は昔からあい変わらずよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：それにしても・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

    Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

    Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

    Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

    Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

    Message(ref m_list, ref e_list, "アイン：雰囲気あるよな・・・・・この場所。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：エオネ、何か知ってるか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：えっ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや、知らないなら知らないで良いんだが。何となく知ってるんじゃないかと思ってな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：えっと・・・すみません・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：エオネさん、そこの意図不明な会話に付き合わなくて良いからね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：えっ・・・ええ。はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：良いから。バカはバカ言ってないで、とっとと周辺探索するわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あ、ああ、まあそうだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おし、じゃあひとまず探索と行きますか！", ActionEvent.None);
  }

  public static void Message300060(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_Complete_00005 == false)
    {
      Message(ref m_list, ref e_list, "アイン：おっ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうしたのよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ほら、こっち来てみろよ。これひょっとしてマトックじゃねえか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：確かにそうみたいね。でも・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：本当。よく見つけたわね、こんな所に置いてあるのに。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：こんな所って、そりゃこんな所にあるものだろ。マトックだしな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：意味わかんない解説は置いといて・・・ひとまずは、助かるわ♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあこれで岩壁があっても、片っ端から掘れば進められるな！ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あっ・・・あの、すみません！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうした。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そ・・・その、マトックなんですけど・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：じ・・・じつは・・・その・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ひょっとして、何回か使うと壊れるって話か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：「えっ？」　　エオネ：「っ！？」", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、これだけ色が変色してるんだ。元の素材が頑丈とは言え、無限に使えるわけじゃないだろう,", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：使うべき場所は良く選んでからつかうよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ありがとうな、エオネ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：いっ・・・　いえ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：でも、すみません。違うんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そのマトック、手元の所にこのエリアの毒が付着してるから、取った方が良いと思っただけなんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッゲ、マジかよ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは毒のダメージを食らった！！　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：なんでもかんでも早とちりして、考えもせずにアイテムを拾わない事ね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：わ、分かったって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あの・・・あとマトックの持ち方がそれだと壊れやすいので・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：こうやって・・・・こんな風に持ってください。そうるすと壊れないですから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おー、オーケーオーケー！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか、これなら回数制限とかも無さそうだな。サンキュー！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：それじゃ、使うポイントに来たらアインが振るってよね。そのマトックの扱いについては任せるわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、了解了解！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 " + Fix.ITEM_MATOCK + " 】を手に入れました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, Fix.ITEM_MATOCK, ActionEvent.GetItem);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_5 + " 】を達成しました！", ActionEvent.QuestComplete);
    }
  }

  public static void Message300070(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300070 == false)
    {
      One.TF.Event_Message300070 = true;

      Message(ref m_list, ref e_list, "アイン：おっと・・・崖のようだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうやら行き止まりみたいね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・いや、別に行き止まりってわけじゃねえ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：一応下には地面が見えている。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：え、まさか・・・, この高さからジャンプして飛び降りるって考えてないでしょうね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：俺はバカだからな。そのまさかだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：えっ・・・ちょ、ちょっと待ってください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：大丈夫だって、その気になりゃ多少滑る感じで下れば行ける。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・いえ・・・そ、そうではなくて・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？一体どうしたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと、わからないわけ？ほんと、そういう所は鈍感よね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・　・・・　ッ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：待て、分かった！とにかく、止めておいた方が良いみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：と、すると・・・どうしたものか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　何となく、筋がある気がするんだけどな・・・　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　さて、どうすっかな　）", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.DECISION_ARTHARIUM_CLIFF, ActionEvent.CallDecision);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：（　何となく、筋がある気がするんだけどな・・・　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　さて、どうすっかな　）", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.DECISION_ARTHARIUM_CLIFF, ActionEvent.CallDecision);
    }
  }

  public static void Message300071(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：ちょっと考えてみたんだが・・・。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：崖の下には俺１人で行ってみるからさ。ここで待っててくれないか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：えっ！？単身で突っ込むわけ！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：大丈夫だ。ちゃんと戻ってくるからさ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：戻ってくるって、だから崖降りた後、どうやって戻るつもりなのよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：大丈夫だろ、何とかなるって。ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、エオネからも何か言ってやって。こいつは本当に脳なしだから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え・・・えぇ・・・あの・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：お気をつけて・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ウソ、まじか・・・意外とそういう反応なんだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：まあ・・・一人でどうしても行くって言うなら、しょうがないわね。じゃあこれを持って行きなさい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっ、これひょっとして・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おー、やっぱりそうだ！" + Fix.ITEM_TOOMI_AOSUISYOU + "じゃねえか！よく持ってたな、こんな代物！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：万が一のためよ。用意は万全にしておかないとね♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジかよ。これがあるとスゲー助かるぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.ITEM_TOOMI_AOSUISYOU, ActionEvent.GetItem);

    Message(ref m_list, ref e_list, "【 " + Fix.ITEM_TOOMI_AOSUISYOU + " 】を手にいれました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：でも、こんなのどこから仕入れたんだ？少なくともアンシェット街では売ってる訳がないよな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：それはえととと・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：な、内緒なのよ！！いちいち聞かないでちょーだい！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：わ、分かったって。いちいち大きな声出さなくてもいいだろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：と、とにかくそれを使えば、アーサリウム工場跡地から外に出られるから、厳しくなったら使うことね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ちょっと待てよ。そうなると、俺は外に出られるけど、ラナとエオネはどうなるんだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：その点は大丈夫よ。最初にここに入った時に青水晶が自動的に記憶しているから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：アインがそれを使えば、私とエオネも一緒に帰還する事になるわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なるほど、そんなものか。なら心配しなくてもオッケーだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：じゃまあ、これ持ってちょっと奥の方を探索してくるとするぜ、しばらく待機しててくれ。良いな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ええ、良いわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ行くぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.InstantiateObject);

    Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveRight);

    Message(ref m_list, ref e_list, "0.4", ActionEvent.ForceMoveFall);

    Message(ref m_list, ref e_list, "0.3", ActionEvent.ForceMoveFall);

    Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);

    Message(ref m_list, ref e_list, "0.1", ActionEvent.ForceMoveFall);

    Message(ref m_list, ref e_list, "アイン：っとぉ、着地！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：オーケーオーケー！ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おーい、そっちは大丈夫かー？", ActionEvent.None);

    Message(ref m_list, ref e_list, "【　アインは崖の下から上を眺めた　】", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：あっ！ちょっと、何見ようとしてんのよ！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "【　ラナはデカい岩のつぶてを崖の下へとぶん投げた　】", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：イデっ！！ッゴワ！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おまえ、何しやがる。さすがにイテェだろうが。ったく・・・つつ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：良いから。とっとと行きなさいよ。ホラ、行った行った！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ったくもう。分かった分かった。じゃ、行ってくるからな。", ActionEvent.None);

  }

  public static void Message300072(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：ここは一旦、引き返すとするか、他の道を探してみよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
  }

  public static void Message300080(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：（ おっ、見覚えのある通路に出たな ）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：（ ここを下へジャンプして降りれば、戻れそうだな ）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：（ さて、どうすっかな ）", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.DECISION_ARTHARIUM_CLIFF_END, ActionEvent.CallDecision);

  }

  public static void Message300081(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ行くぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "0.3", ActionEvent.ForceMoveBottom);

    Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);

    Message(ref m_list, ref e_list, "0.1", ActionEvent.ForceMoveFall);

    Message(ref m_list, ref e_list, "アイン：（ よし、着地っと！ ）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：（ さて、もとに戻った事だし、ラナ達と合流しておこう ）", ActionEvent.None);

  }

  public static void Message300082(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：（ 少し気になる所がある。もう少し調べてみるか ）", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveTop);
  }

  public static void Message300090(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300090 == false && One.TF.LocationPlayer2)
    {
      One.TF.Event_Message300090 = true;
      One.TF.LocationPlayer2 = false;

      Message(ref m_list, ref e_list, "アイン：よっ、今戻ったぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);

      Message(ref m_list, ref e_list, Fix.MAPEVENT_ARTHARIUM_3_O, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "ラナ：あら、意外な方向から戻ってきたわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあな。適当に進んでいたら元の通路に戻れるポイントがあって、そこから戻ってきたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まあ、無事でなによりね。何か良いお宝はゲットできたわけ？", ActionEvent.None);

      // todo　宝箱（シークレット）に応じて会話分岐

      Message(ref m_list, ref e_list, "アイン：うん、まあまあって所だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ふーん、意外な反応ね。アインが突っ込むぐらいだから、何かあるかと思ってたんだけど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：別にいつもそういうアンテナを張ってるワケじゃえねえさ。今回はこんなもんだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ他の場所も探索しようぜ！", ActionEvent.None);
    }
  }

  public static void Message300100(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300100 == false)
    {
      One.TF.Event_Message300100 = true;

      Message(ref m_list, ref e_list, "アイン：おっ、看板があるな。どれどれ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　本エリア奥にて凶暴な生物が発生。全面的に通路を封鎖する。　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：穏やかな内容じゃないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：今まで通ってきた道でも、モンスターなら普通に出現してるけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あの・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？なんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ぁ・・・いえ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なんか気になる事があれば、どしどし言ってくれ。ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアインは変な誘導しないでくれる？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：エオネさん、そこのバカは放っておいてくださいね。無視して良いですから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ハ、ハイ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まあモンスターの位置は把握出来てないんだし、慎重に進んだ方がよさそうね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ慎重に進めるとするか、了解！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　本エリア奥にて凶暴な生物が発生。全面的に通路を封鎖する。　』", ActionEvent.None);
    }
  }

  public static void Message300110(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300110 == false)
    {
      One.TF.Event_Message300110 = true;

      Message(ref m_list, ref e_list, "アイン：扉みたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：でも何かこの扉って鍵もかかってないわね。ヤワな板で封鎖しているだけって感じね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：この程度なら、多少強引に蹴破って進められそうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：さて、どうすっかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.DECISION_ARTHARIUM_CRASH_DOOR, ActionEvent.CallDecision);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：この程度なら、多少強引に蹴破って進められそうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：さて、どうすっかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.DECISION_ARTHARIUM_CRASH_DOOR, ActionEvent.CallDecision);
    }
  }

  public static void Message300111(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300111 == false)
    {
      One.TF.Event_Message300111 = true;
      One.TF.FieldObject_Artharium_00006 = true;

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ行くぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アインのストレートキックが扉に炸裂した！ 】", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.MAPEVENT_ARTHARIUM_4_O, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);

      Message(ref m_list, ref e_list, "アイン：オーケー！開いたぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：蹴破ったけど、特に警報とかもなさそうね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっしゃ、このまま進めるとするか！", ActionEvent.None);
    }
  }

  public static void Message300112(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：いや、もう少し他を探してみるとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveTop);
  }

  public static void Message300120(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300120 == false)
    {
      One.TF.Event_Message300120 = true;

      Message(ref m_list, ref e_list, "アイン：おっ、扉みたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：これも蹴破って行けそうだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうかしたの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、ちょっとな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：今、扉を調べてはみたけど、特に鍵はかかってないみたいよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、基本は蹴破って進んでも良いんだけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：さて、どうすっかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.DECISION_ARTHARIUM_CRASH_DOOR2, ActionEvent.CallDecision);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：ここの扉か。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：さて、どうすっかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.DECISION_ARTHARIUM_CRASH_DOOR2, ActionEvent.CallDecision);
    }
  }

  public static void Message300121(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300121 == false)
    {
      One.TF.Event_Message300121 = true;
      One.TF.FieldObject_Artharium_00007 = true;

      Message(ref m_list, ref e_list, "アイン：っしゃ！じゃあ行くぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アインのストレートキックが扉に炸裂した！ 】", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.MAPEVENT_ARTHARIUM_5_O, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);

      Message(ref m_list, ref e_list, "アイン：よおし、問題なく進めたな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうかしたか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アイン！今すぐこっちに来て！早く！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なっ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：敵襲よ！背後から！", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.HELL_KERBEROS, ActionEvent.EncountBoss);
    }
  }

  public static void Message300122(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：何となく引っかかるな、少し慎重に動こう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
  }

  public static void Message300123(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.QuestMain_Complete_00007 = true;

    Message(ref m_list, ref e_list, "アイン：や・・・やっつけたか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：大丈夫です、もうピクリとも動かない様です。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ホント危なかったわね。まさか背後から襲ってくるなんて思わなかったわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：しかし、蹴破る時は気配をまるで感じなかったけどな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：どっから湧いてきたんだろうな、この生物・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：単なる工場跡地にしては、ちょっとおかしいわよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ま、考えてもしょうがねえか！ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：何よもう。まったく、考えたフリしないでよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ま、いいさいいさ。なあエオネ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：・・・ぇ・・・ええ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：そ・・・それよりも、この生物の足元、見てください。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：何か挟まっている様に見えませんか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジかよ。どれどれ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっ！こいつはレア物じゃねえか！！", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.PURE_CLEAN_WATER, ActionEvent.GetItem);

    Message(ref m_list, ref e_list, "【 " + Fix.PURE_CLEAN_WATER + " 】を手にいれました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：あら、良い物手に入れたわね♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いやあ、こいつは助かるぜ。何といってもほぼ毎日使える代物だしな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：「ほぼ」じゃなくて「確実に毎日」使えるわよ。一日につき１回しか使えないのが条件だけどね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、確かそうだったな。いやホント助かるぜ、これは。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっ、そういや見つけてくれたのはエオネだったな。サンキュー！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：い・・・いえ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし。じゃあ先へ進めるとするか！", ActionEvent.None);
  }

  public static void Message300130(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.SoulFragment_00001 == false)
    {
      One.TF.SoulFragment_00001 = true;

      GetSoulFragmentMessage(ref m_list, ref e_list);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：せっかくだし、少しだけお祈りをしていくとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは「蒼流石」の前に座り、祈りを捧げた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ行くとするか。", ActionEvent.None);
    }
  }

  public static void Message300140(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300140 == false)
    {
      One.TF.Event_Message300140 = true;

      Message(ref m_list, ref e_list, "アイン：うわ、なんだここは。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：酷い状況ね。辺り一面が毒だらけだわ。。。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：多少なら何とかなるが、こんな状況じゃ進んでも絶対に途中でダメになるな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうする？さすがに引き返すしかないわよね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どうしたもんかな・・・今引き下がるにしても打開策がねえとな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・そ・・・その・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうかしたのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：毒って・・・このエリアにある毒の事ですよね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、ああ確かにそうだが。何か知ってるのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ええ。ここの毒素については比重が重たいので、空気中に蔓延しているわけではありません。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：なので、ある程度防衛できる物を身に着けていれば・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか、それなら無傷で通り抜けられるって事か！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：無傷ってわけにはいかないでしょ。ある程度軽減されるって話よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：確かに無傷ってのは難しいか・・・だがまあ、何とかなりそうではあるな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあその防護できるアイテムを探すとするか！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・あと、すみません。もう１件だけ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おお、何でも言ってくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：防護服なら、おそらくマトックが見つかった部屋の近辺にあると思います。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、分かった。じゃあ、ここは一旦引き下がって、その部屋をくまなく探すとしよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_8 + " 】が開始されました！", ActionEvent.GetNewQuest);
    }
    else if (One.TF.QuestMain_Complete_00008 == false)
    {
      Message(ref m_list, ref e_list, "アイン：まだ、防護服が見つかってないな。ここは一旦引き下がろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
    }
    else if (One.TF.Event_Message300141 == false)
    {
      One.TF.Event_Message300141 = true;

      Message(ref m_list, ref e_list, "アイン：ここだな・・・じゃあ進んでみるぞ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【　アイン達は意を決して、毒エリアへ果敢に進んでいった！！　】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

      Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

      Message(ref m_list, ref e_list, "0.5", ActionEvent.MoveTop);

      Message(ref m_list, ref e_list, "アイン：おっ、行けるなこれは！ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：でも、ほんの少しだけどダメージを受けている感じはするわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、でもほんの僅かだしな。これなら結構気にせず進められるぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：でも、気をつけてくださいね・・・奥がどうなってるか分かりませんから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、了解！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_8 + " 】を達成しました！", ActionEvent.QuestComplete);
    }
  }

  public static void Message300150(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_Complete_00008 == false)
    {
      Message(ref m_list, ref e_list, "アイン：おっ、ひょっとして防護服ってこれの事か！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ええ。それで合ってると思います。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、どうやら見つかったみたいだな。これでようやくあの毒エリアを進むことが出来そうだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：しかし、何かやたらと薄っぺらいんだな。もっとゴツいのを想像してたんだが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：必要以上に重くしたら、本来の作業に支障が出るからじゃないかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、そんな所だろうな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：しかし、何か引っかかるんだよな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何がよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：防護服ってのはそもそも毒が噴出してから用意するもんじゃないのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そうかもしれないけど、それがどうかしたの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：この区画って明らかに毒が届いてないエリアなんだよな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：だったら、あえてここに防護服を設置した理由って何だろうなって思ったのさ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そんなの、作業員の皆が集まりやすかっただけじゃないかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：うーん、しかしだな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ホラホラ、変な所考えてないで、目的の物は見つかったんでしょ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、ああ。そうだったな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあこの防護服を装着して、例の毒エリアに行ってみるとするか！", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.RESIST_POISON_SUIT, ActionEvent.GetItem);

      Message(ref m_list, ref e_list, "【 " + Fix.RESIST_POISON_SUIT + " 】を手にいれました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_8 + " 】を達成しました！", ActionEvent.QuestComplete);
    }
  }

  public static void Message300160(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.SoulFragment_00002 == false)
    {
      One.TF.SoulFragment_00002 = true;

      GetSoulFragmentMessage(ref m_list, ref e_list);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：せっかくだし、少しだけお祈りをしていくとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは「蒼流石」の前に座り、祈りを捧げた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ行くとするか。", ActionEvent.None);
    }
  }

  public static void Message300170(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message300170 == false)
    {
      One.TF.Event_Message300170 = true;

      Message(ref m_list, ref e_list, "アイン：扉か・・・少し蹴ってみるか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アインのストレートキックが扉に炸裂した！ 】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっ、全然びくともしないな。結構やるじゃないか、この扉。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：っちょ、何勝手に蹴ってるのよ。危ないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：悪い悪い。何となく良いかなと思って。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まったくもう・・・ちょっとどいて。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　ラナは注意深く扉を調べ始めた　～", ActionEvent.MessageDisplay);

      if (One.TF.FindBackPackItem(Fix.ARTHARIUM_KEY))
      {
        One.TF.FieldObject_Artharium_00008 = true;
        Message(ref m_list, ref e_list, "ラナ：あっ、多分これね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：アイン、ちょっと鍵貸して。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：おお、これの事か。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：ありがと。ええと、じゃあ開けるわね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "　ギッ、　ギギィ　・・・　", ActionEvent.None);

        Message(ref m_list, ref e_list, Fix.MAPEVENT_ARTHARIUM_8_O, ActionEvent.RemoveFieldObject);

        Message(ref m_list, ref e_list, "ラナ：やったわ、開いたわよ♪", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：サンキュー！　よし、この先に行ってみるとするか！", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "ラナ：この扉、鍵がかかってるみたいよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：鍵を探してこないと駄目ってわけか・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：しょうがない。鍵をまず先に見つけてこよう。", ActionEvent.None);
      }
    }
    else
    {
      if (One.TF.FindBackPackItem(Fix.ARTHARIUM_KEY))
      {
        One.TF.FieldObject_Artharium_00008 = true;

        Message(ref m_list, ref e_list, "ラナ：アイン、ちょっと鍵貸して。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：おお、これの事か。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：ありがと。ええと、じゃあ開けるわね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "　ギッ、　ギギィ　・・・　", ActionEvent.None);

        Message(ref m_list, ref e_list, Fix.MAPEVENT_ARTHARIUM_8_O, ActionEvent.RemoveFieldObject);

        Message(ref m_list, ref e_list, "ラナ：やったわ、開いたわよ♪", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：サンキュー！　よし、この先に行ってみるとするか！", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "ラナ：この扉、鍵がかかってるみたいよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：鍵を探してこないと駄目ってわけか・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：しょうがない。鍵をまず先に見つけてこよう。", ActionEvent.None);
      }
    }
  }

  public static void Message300180(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
      return;
    }

    if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK) == false)
    {
      Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
      return;
    }

    if (One.TF.FieldObject_Artharium_00009 == false)
    {
      One.TF.FieldObject_Artharium_00009 = true;

      UseMatockForRock(ref m_list, ref e_list, Fix.ARTHARIUM_Rock_6_O);
    }
  }

  public static void Message300190(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.DefeatGalvadazer == false && One.TF.QuestMain_Complete_00009 == false)
    {
      Message(ref m_list, ref e_list, "アイン：おっと、デカいやつのお出ましみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：だ・・・大丈夫なんでしょうか・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：見た感じでは、パワー系って所かしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アインはどう思う？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、パワーはありそうってのは確かだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ただし、それだけじゃない。こういうタイプは「計略」を１つぐらいは持ってるもんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：戦闘関連のトラップが仕掛けられていると考えておいた方が良いだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：陣形についてだが、デカいやつが一人だ。後方には向かわせないように俺が何とかする。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あと、ダメージが大体当たってきたら要注意だろうな。もう一つ奥の手を持っている感じはする。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：大体分かったわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあなんにせよ、気を引き締めていこう。エオネ、ラナ、準備は良いか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：は、はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私はいつでも良いわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ戦闘開始だ、行くぞ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.THE_GALVADAZER, ActionEvent.EncountBoss);
    }
  }

  public static void Message300200(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.DefeatGalvadazer && One.TF.QuestMain_Complete_00009 == false)
    {
      Message(ref m_list, ref e_list, "ガルヴァデイザー：ゴッ・・・ゴガガガガガガ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：うお！　こいつまだ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ガルヴァデイザー：ゴガア・・・ガ・・・ガアァァァ・・・ガ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ガルヴァデイザー：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうやら、今のが最後の断末魔みたいね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どうやら、そのようだな。ふう・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし！制覇制覇！ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そ・・・その・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お、どうしたエオネ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：すごいですね、その・・・何というか・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：倒せるものなんでしょうか。こういった大型級のモンスターを。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：今実際にこうして俺たち全員で倒したんだ。実感湧かないか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：え・・・ええっと・・・はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：無理ないかもね。あまりこうしたモンスターを倒す所まで、一般冒険者は踏み入らないみたいだし。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：えっ、そうなのか？普通ならこの辺りまでは踏み込むもんだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アンタは考えゼロで突っ込みすぎなのよ。ヒヤヒヤさせられるこっちの身にもなってよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだったのか。まあ、次からは少し考えてみるさ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：でも、ほ・・・本当にありがとうございました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いやいや、お礼を言われる側じゃない。同じパーティだしな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：こちらこそ、ありがとうな。助かったぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：は、はい！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラナもいつもサンキューな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ッフフ、どうって事ないわよ♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あと残るは、この奥にある通路だな。絶対にお宝に違いない！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まあ、変なトラップはもう無いと思うけど、気をつけて進んでよね♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よっしゃ、任せておけ！待ってろよ、お宝！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_9 + " 】を達成しました！", ActionEvent.QuestComplete);
    }
  }

  public static void Message300210(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Obsidian_Artharium_00001 == false)
    {
      One.TF.Obsidian_Artharium_00001 = true;

      Message(ref m_list, ref e_list, "アイン：これは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：正直、お宝じゃなさそうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：いつもお宝があるとは限らないでしょ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：不思議ですね・・・その物体、宙に浮いてる様に見えます・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょっと触ってみるか。どれどれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あっ、ちょっと、そこのバカ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "　アインは奇妙な物体に手を触れてみた　", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：お・・・おおぉ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何だこれ！何か流れ込んでくるぞ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "　アインは青白い球体に包まれ始めた！　", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：バッ、バカ！！ちょっと変な球体に包まれているけど、大丈夫なの！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（何だこれ・・・音がまったく聞こえない・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そこのバカ！！聞いてるの！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・一体・・・なんだこれは・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（！？）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（何かが・・・声が聞こえる・・・なんだ？）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　応えよ　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　そして受諾せよ　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　さすれば意志が宿る　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 " + Fix.UNKNOWN_OBJECT + " 】を獲得しました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, Fix.UNKNOWN_OBJECT, ActionEvent.GetItem);

      Message(ref m_list, ref e_list, "アイン：こ、これは・・・？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：って、あんた一体誰なんだ！？どこにいるんだ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　時は満たず　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　精神は満たず　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　還るべきは理と知るがよい　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なんだって？どういう意味だ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "　－－－　時が満ちればまた姿を現すがよい、幼きものよ　－－－", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、まってくれ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "『空間が激しくフラッシュし、凝縮された空間へと連続的に小さくなる！！！』", ActionEvent.None);

      Message(ref m_list, ref e_list, "『パパパパパパパ！！！！ッバシュウウウゥゥゥン！！！！！！！』", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.MAPEVENT_ARTHARIUM_11_O, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：だ、大丈夫！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　ッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おお、大丈夫だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：しかし何だったんだ今のは。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：外からは全くわかりませんでした・・・どのような状態だったんですか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何て言うんだろうな。何かこう・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：声が、聞こえたんだけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私達の声が聞こえてたって事？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：す、すまねえ。そうじゃないんだ。うまく説明が出来ないんだが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラナ、すまねえ。今回は本当についうっかりだな。ハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：とにかく。ぶ、無事ならそれで良いのよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：で、その手に入れた物体は、どう扱うのか分かってるのかしら？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：これか・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ここじゃなんだしな。この件については後で話す。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：一旦クヴェルタ街に戻ろう。話はそれからだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ、分かったわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エオネも、街までもう少しだけ付き合ってくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：は、はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあクヴェルタ街に向かうとしよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_10 + " 】が開始されました！", ActionEvent.GetNewQuest);
    }
  }

  public static void GetSoulFragmentMessage(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FirstSoulFragment == false)
    {
      One.TF.FirstSoulFragment = true;

      Message(ref m_list, ref e_list, "アイン：おっ、何だこれは。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アイン、それちょっとよく見せて。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。頼んだぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　ラナは注意深く物体を調べ始めた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：どうだ、何か分かりそうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：おそらくだけど、これは「" + Fix.GUARDIAN_ANGEL_BLUE + "」を祭るための神具「蒼流石」ね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：へえ・・・そういう物があるんだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：こうした炭鉱では事故やトラブルが絶えないから、よくこうして神様にお祈りをしていたんでしょうね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、そういった所なんだろうな。さっきみたいな化け物も出てるのも事実だしな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アインも少しだけお祈りを捧げてみたら？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：俺か？　神様頼みは、あんまりしない主義なんだけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・すみません、私からもお願いします。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：マジか。じゃあせっかくだし、少しだけお祈りをしていくとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは「蒼流石」の前に座り、祈りを捧げた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "1", ActionEvent.GainSoulFragment);

      Message(ref m_list, ref e_list, "　～　アイン達は【ソウル・フラグメント】を獲得しました！　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：よし。こんなもんだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何となくだけど悪くないもんだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：じゃあ、行きましょうか。ここはもう通路がないみたいだし。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだな。他を探索するとしよう！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：おっ、「蒼流石」だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アイン、お祈りを捧げておいたら？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだな。じゃあ、少しだけ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは「蒼流石」の前に座り、祈りを捧げた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "1", ActionEvent.GainSoulFragment);

      Message(ref m_list, ref e_list, "　～　アイン達は【ソウル・フラグメント】を獲得しました！　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：よし。こんなもんだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：じゃあ、行きましょうか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。", ActionEvent.None);
    }
  }

  public static int GetZetaniumCount()
  {
    int counter = 0;
    if (One.TF.Zetanium_001)
    {
      counter++;
    }
    if (One.TF.Zetanium_002)
    {
      counter++;
    }
    if (One.TF.Zetanium_003)
    {
      counter++;
    }
    if (One.TF.Zetanium_004)
    {
      counter++;
    }
    if (One.TF.Zetanium_005)
    {
      counter++;
    }
    return counter;
  }
  #endregion

  #region "港町コチューシェ"
  public static void Message400010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message400010 == false)
    {
      One.TF.Event_Message400010 = true;

      Message(ref m_list, ref e_list, "アイン：よし、" + Fix.TOWN_COTUHSYE + "に着いたみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：結構ここまで長い道のりだったわね。ちょっと一休みできる所は無いかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あっ、ラナさん。あちらの角を左に曲がって、3軒目の所に美味しいパフェを売ってる店があるんですよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：本当！？じゃあ早速行きましょ♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ゲッ、マジかよ。俺は調査とかやるべき事をすぐにでもだな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そんなのいつでも出来るじゃない。今しか出来ない事をやるのよ♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま・・・まあ、そう言われればそうだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：じゃ、私は先に行ってるからね♪ほら、エオネもおいで♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：え、あ、ハイ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　行っちまったか　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、いいか。この辺りで一旦休むのもアリかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインが、曲がり角まで差し掛かった所で　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：キャア！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（今の、ラナの声か！？）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おい、大丈夫か！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：え、えぇ・・・大丈夫よ。ビックリしたわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何があったんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：うーん、それがね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：よく分からなかったのよ。何かが横切ったのは確かなんだけど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エオネ、お前は何か見なかったのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：い、いえ。わ、わたくしは何も・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか。まあとにかく誰も傷付いてなくて何よりだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ今後は気をつけるとして・・・何だっけ。パフェの店に行くんだろ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい、今目の前にあるお店です。ラナさんは既に入っていきました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：早ぇなあ・・・そういう所は見境がないんだよな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・っ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お、エオネも入るのか？ココ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あっと・・・え、ええっと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。では行ってまいります。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：うん。じゃ、俺はここで待ってるから。二人とも食い終わったらサッサと出てくるんだぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：え、えっ、ええ・・・では。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　２時間　経過後　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　っお。出てきたか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ふぅ、美味しかった♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どうだった。ちょっとは回復したか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ、バッチリよ。ありがと♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、それじゃあ、この港町で色々と調べてみるとするか！", ActionEvent.None);
    }
  }

  public static void Message400019(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：（いや、この港町をもう少し探索しておこう）", ActionEvent.None);
  }

  public static void Message400020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message400020 == false)
    {
      One.TF.Event_Message400020 = true;

      Message(ref m_list, ref e_list, "アイン：おっ、何かこっちの方はずいぶんと賑やかだな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　船着き場にて　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "係員：だから、他を当たってくれと言ってるんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：だから、他も何もねーだろ。船が出る所はココしかないだろーが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "係員：とにかく、船は出ない。他を当たってくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：チッ、ありえねぇだろ・・・くそ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おいちょっと。どうかしたのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ここの係員が船に乗せてくれねえんだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：船自体はそこの発着場にある。出ないワケがねーだろって言ってるんだが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：船があったとしてもメンテナンスか何かで出航しない場合だってあるだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：あ？何でお前まで係員と同じ事を言うんだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そんなの係員に聞くまでも無いだろ。大体予想は付く。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：「大体予想は付くって」、テメーの予想なんか聞いてねーんだよ・・・俺は船に乗る方法を・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：あっ！その適当なセリフ回し、てめぇまさか！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：お前、" + Fix.NAME_EIN_WOLENCE + "だろ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだが。なんで知ってるんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：「なんで知ってるんだ？」じゃねえよ！！おまえ、俺の顔見て何も思い出さねえのかよ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・あー・・・ああ、ああ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・誰だっけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：なんだよそれ！！もう・・・お前マジで記憶がテキトーだな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：俺だよ、" + Fix.NAME_BILLY_RAKI + "だよ。覚えてねえか！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お、おお！　ビリー！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラキ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハーッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：・・・なんてヤツだ・・・コイツは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、悪い悪い。さすがに覚えてるって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お前、雰囲気が少し変わったよな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オルガウェイン傭兵施設では、何かこう尖がりヘルメットみたいな雰囲気だったし。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：んだその、尖がりヘルメットってのは。変な言い方はよしてくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ここにやってきたのは何でだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：理由は特にねーな。ぶらぶらと色んな所に行ってみたいだけだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッハッハッハ、そういう所は相変わらずだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：まあな。いちいち理由とかめんどくせーからな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おい・・・ていうかお前。結局、俺の事覚えてるのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そりゃ覚えているさ。オルガウェインで結構遊んでたもんな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、昔話はおいといてだな。船が出ねえってのは何かの事情があるんだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょっとそのあたりの内容を聞いてみる。良いよな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：別に俺は構わねえが。でもあの係員と話しても何もでねーぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあまあ、一応聴いてくる。待っててくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　数分経過後　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：う～ん・・・何だろうなあ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おい、何か分かったのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと、そこのバカアイン。黙ってないで答えなさいよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。悪い悪い。まあ係員が言うには、船先のヴィンスガルデは何等かの理由によって交易を閉ざしてるみたいなんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ふうん、じゃあそもそも船が出ないのは納得が行くわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：でだ。係員が言うには、船のルートはもう無理だからって事で、別のルートを紹介された。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何て言われたと思う？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：うーん、そういうのはさすがに分からないわね。どんなルートなの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：「神秘の森」を突っ切るしかないと言ってきたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おいおい、あんなフザけた所なんか通れるかっつーの。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あのエリアではケガ人や行方不明者が絶えないと、よく噂になってますよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：お、おおう、そうだよ。だから「神秘の森」って言われてるんだろーが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アイン、どうするの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょっと判断が難しいけど。どうすっかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：方角は？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ヴィンスガルデ王国方面なんだし。当然、北よね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ケガ人ってのはモンスターからの襲撃か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まあ大体はそうみたいね。深い森の中だから、うっかり足首をケガする者も多いらしいわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おいアイン。ビビった時に俺ばっかり頼りにするんじゃねーぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：分かってるって。そんなことしねえって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、行ってみるとするか！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：大丈夫なんでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、大丈夫だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：根拠もなく大丈夫とか言いやがったな。あんな危険な場所に本気で行くつもりかよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、問題ない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お前が一緒に来てくれば、大丈夫だろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おー！言ってくれるじゃねえか、この野郎！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：よっしゃああああ！俺に任せとけってんだ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, " 【ビリー・ラキ】が仲間になりました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, Fix.NAME_BILLY_RAKI, ActionEvent.HomeTownAddNewCharacter);

      Message(ref m_list, ref e_list, "アイン：ッハッハッハ！じゃ、先頭突っ切って行く所はよろしく頼んだぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おうよ！", ActionEvent.None);

      if (One.TF.Event_Message400030)
      {
        Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_2 + " 】が更新されました！", ActionEvent.QuestUpdate);
      }
    }
  }

  public static void Message400021(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "係員：とにかく、船は出ない。他を当たってくれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ここから船は出そうにないな。他を当たろう。", ActionEvent.None);
  }

  public static void Message400030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message400030 == false)
    {
      One.TF.Event_Message400030 = true;
      Message(ref m_list, ref e_list, "アイン：そういえば・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：国王からの依頼ってここに来て調査をしろって話だったよな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そうなの？謁見の間はアイン一人で行ったから、私は知らないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そういやそうだったな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：しかし、こんな所まで来て一体何を探せば・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：国王様や王妃様から言われていた内容は？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：うーん、そうだなあ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　エルミ：天の導きがあれば、自然と道は拓かれる　～～～", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：それは市民達を送り出す時のお決まりのお言葉よね。他には？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そう言われてもな。他といえばこれだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　エルミ：国内外遠征先のヴィンスガルデ王国エリアで調査して欲しい案件があるんだ　～～～", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：それは一般的な依頼内容よね。他には無いの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そ、そうだなあ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ！ひょっとしてこれの事か！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　エルミ：ああ、沿岸沿いにある小さな港町だよ。色々な人たちが集う場所だから、何か情報が得られる事を期待している　～～～", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：結構ありきたりな内容よね。確かにそうなんでしょうけど・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：特にこれといった情報は・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、待てよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そういえば、国王じゃなくてファラ王妃が最初に何か言ってたぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　ファラ：ヴィンスガルデ王国の歴史には一つの伝承があります　～～～", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　ファラ：その伝承には一つのキーワードが示されています　～～～", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　ファラ：その名は【Obsidian Stone】　～～～", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：え！？何それ、全然聞いてないんだけど！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ゲッ、そんな怒るなよ。いや、何か聞き慣れないキーワードだったから、あんまり覚えてなかったんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あんた本当にバカじゃない！？何でそんな大事な内容を先に言わないのよ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：悪かったって。いや、でもなんかさ。それよりも国王エルミからの言葉が凄く気になったんだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：だから、その何だっけ・・・何とかストーンってのはあんまり関係ねえのかなと思ってたんだが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：やっぱり重要だったりするのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：当たり前じゃない！ObsidianStoneって言ったら古代遺産の一つなんだし！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そ、そうなのか・・・ハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：で？　それについて何か言ってたわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、それ以外は何も言われてない。単にこの港町コチューシェを訪れる様に言われただけだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ふ～ん、そうなのね・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか・・・いや・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：結果的に、これで良いのかも知れないな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何がよ？", ActionEvent.None);


      Message(ref m_list, ref e_list, "アイン：ここに来るまでの間、俺は遠征許可証を入手し、", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：国王エルミ様からの指令を受け、ここにきている。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、今ここでどうするべきなのか、悩んでいる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：きっと、この行動自体が何かの結果を生んでいるんだろう。おそらく。", ActionEvent.None);

      if (One.TF.AvailableBillyRaki)
      {
        Message(ref m_list, ref e_list, "アイン：あと、ついでにビリーと再会。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：んだそりゃぁ！俺は「ついで」なのかよ！？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ま、まあまあ。悪い悪い、ハハハ・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：船は出ない・・・についてはどうなんでしょうか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：それは確かに偶然といえば偶然だな。俺もそれは不思議な感じはするんだが。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：出ないからこそ、別のルートがあるんだろう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：結果的に、俺たちは今から「神秘の森」に向かう。だろ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：それは成り行き上、そうなったってだけでしょ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあ。そうなんだけどな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：さてと。じゃあ「神秘の森」に行くとするか！", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：まあ、悩んでいるというよりも、目指す方向そのものに関する設問みたいなものだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：す・・・すみません、ちょっと意味が・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：要は、Obsidian Stoneを探してるって事なのよね？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：まあ、そこはそうなんだが。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：船着き場もまだ行ってないわよね。まずヴィンスガルデ王国行きの船が出ているか見てみましょうよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ、そうだな。分かった。", ActionEvent.None);
      }

      if (One.TF.AvailableBillyRaki)
      {
        Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_2 + " 】が更新されました！", ActionEvent.QuestUpdate);
      }
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：特に何もないみたいだな。他の所へ行こう。", ActionEvent.None);
    }
  }

  public static void Message400031(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：（いや、今ここに用は無いな）", ActionEvent.None);
  }

  public static void Message400040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message400040 == false)
    {
      One.TF.Event_Message400040 = true;

      Message(ref m_list, ref e_list, "アイン：（　船の出航制限　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　Obsidian Stone　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　神秘の森　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　神秘の森と言えば、気になる点があるんだが・・・　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　考えていても仕方ないとはいえ　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　・・・　・・・　・・・　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　今のままじゃこれ以上は無理だな　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（　よし、神秘の森へ向かおう　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうしたの？ボーっと突っ立って。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッハ！悪い悪い！なんでもねえって！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、いざ出発！", ActionEvent.None);

      Message(ref m_list, ref e_list, "", ActionEvent.ViewQuestDisplay);
    }
  }
  #endregion

  #region "ツァルマンの里"
  public static void Message500010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message500010 == false)
    {
      One.TF.Event_Message500010 = true;

      Message(ref m_list, ref e_list, "アイン：へえ・・・ここがツァルマンの里か。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：なんだか不思議な感じがする場所ね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：空気が澄んでいるからだと思います。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：初めて来た所だが、何となく懐かしい感覚がするな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おいアイン。あそこ見てみろよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どこだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：あっちだよ。ほら、長老の家っぽい場所があるぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お、本当だな。おまえ本当そういうのすぐ見つけるよな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おうよ。何とやらの里とくれば長老の家で決まりだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハハハ、そいつはそうかも知れないな。見つけてくれてサンキュー。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：いきなりその長老宅に行くわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあそうだな。ここに住んでいる人達の目線もそれを望んでいるようだし。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アイン達一行は周囲からの視線を感じている ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ビリー：ッチ・・・面倒くせえ連中だな。挨拶してこいって事か。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そういう事だ。というわけで、長老宅に行ってみよう。", ActionEvent.None);
    }
  }

  public static void Message500019(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：（いや、この里をもう少し探索しておこう）", ActionEvent.None);
  }

  public static void Message500020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message500020 == false)
    {
      One.TF.Event_Message500020 = true;

      Message(ref m_list, ref e_list, "アイン：よし、ここだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ごめんください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：うむ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、ええと。俺の名前は", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アイン・ウォーレンス。そう聞いておる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：え、何で俺の名前を！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：うむ。ファージルの国王より、仰せつかっておる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主がかならずここへ訪れるとな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：え、そうなんですか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：要件を聞こうか。国王からきっての頼みじゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：え、ええ。まあ、そのややこしい話なんですが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：" + Fix.AREA_VINSGARDE + "のほうへ船で渡ろうとしたんですけど、今は封鎖中みたいで。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それで、こちらの方に迂回ルートがあると聞いてやってきたんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：うむ、そういった経緯であったか、なるほど・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ・・・　ふむ・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主。ファージル国王より、何か受け取ってはおらぬか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、俺自身は国王からは何も受け取ってないです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ。とすると、おそらくそちらの間者の方かの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　長老はまっすぐラナ・アミリアの方に眼を向けた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：わ、私？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラナ、お前国王から何か授かっていたのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：べ、べべ、別に隠してたとか、そういうのじゃないわよ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：い、いやいや・・・悪い悪い。そういうつもりで聞いたわけじゃない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：持ってないとは言わさぬぞ。ワシの目はごまかせん。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：え、ええ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：確かに持っています。私が間者扱いというのはちょっとあれだけど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：コレです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　ラナは【法剣？？？】を長老へと差し出した　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "長老：うむ、どれ・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：うむ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：これは確かに、ファージル国王が持っていた宝剣の一つじゃな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：しかし、あれじゃの。ObsidianStoneが無いようじゃな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：え！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：って、もう一度だけ。ObsidianStoneって言いました？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ああ、そうじゃ。何じゃ食らいついとるの。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、何ていうかまあ、成り行きで気になってるんで。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：成り行き。。。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主、そのObsidianStoneについて成り行きと言うたか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、はい。何て言えばいいのか分からなくて、つい・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ホッホッホ！これはまた、面白いヤツじゃの。それは成り行きでどうにかなる代物ではないぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そ、そうなんだ・・・ハハハ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：気に入った。良いじゃろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主達の要件、おおよそは掴めた。ヴィンスガルデ王国へ通りたいという事じゃな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そ、それじゃあ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：いや、すまないがお主達をここから先へ通すわけにはいかん。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：え、どうしてですか！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：それは言えん。これは、掟である。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どうしても、って感じですか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：掟じゃからの。ここは引いてもらう以外に道はない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　長老は一呼吸おき、そして・・・　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "長老：ッゴホン。では、その代わり、お主らに・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：お、おいジジイ！そりゃねえだろーが！？理由ぐらい言えよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：なっ、何じゃお主は！！　間違ってもお主だけは通さん！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：とりあえず引けったって、俺たちは遠路はるばるやってきたんだ！ちゃんと言えコラ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：なっ、なっ！！　ま、間違ってもお主だけは通さん！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：バ、バカ！　お前こんな所で挑発してどうすんだよ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：と、とにかく！ここを通してくれないか？その掟とやらは、俺も従ってみせるからさ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ええい、ならぬ！　ならぬと言ったらならぬ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：出てゆくがよい！！　もう二度と顔を見せるでないぞ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アイン達は部屋の外へ放り出されてしまった　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：な・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：追い出されちゃったわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：あのジジイ。始めっから通す気がねーだろ。もったいぶりやがって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、ここはしょうがないか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：何がしょうがねえんだ？このまま引き下がるってのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：でも、今なんとかしようとしても、あの感じだとさすがに無理だろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：じゃ、どうすんだよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、今考えてる所だが・・・。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あの・・・すみません、お取込み中に・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ファージル宮殿からの使者が、アインさん宛てに連絡があるとの事の様です。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ファージル宮殿からの・・・使者？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、わ、わたくしよりも、使者の方が実際に来てますので・・・。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お、おお。分かった。", ActionEvent.None);

      Message(ref m_list, ref e_list, "使者：アイン・ウォーレンス様。ファージル国王より言伝があって参りました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "使者：【至急、ファージル宮殿へお戻りになられるように】とのことでした。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何かあったのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "使者：お答えはできません。私は言伝を伝えるのが役割ですから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか。分かった。じゃあ、ここは諦めてひとまず戻るとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：使者さんよ、ありがとうな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "使者：それでは、失礼いたします。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　使者はその場から立ち去っていった　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：行ったみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうする？じゃあ、一旦戻りましょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ファージル宮殿に戻るのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。ビリーも一緒に来るか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おお！もちろんだ！このまま引き下がれるかよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エオネも一緒に来るよな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあこの件は一旦置いといて、まずは皆でファージル宮殿に戻ろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_2 + " 】が更新されました！", ActionEvent.QuestUpdate);
    }
  }

  public static void Message500021(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：（いや、今は長老の所に行くのは止めておこう）", ActionEvent.None);
  }

  public static void Message500022(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message500022 == false)
    {
      One.TF.Event_Message500022 = true;

      Message(ref m_list, ref e_list, "アイン：あの、ごめんくださーい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：何じゃお主か。はよ帰るがよい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、ちょっと待ってください。用件は別にあって来たんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ、申すがよい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：この里の奥には何があるんでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：それをお主に申すわけには行かぬ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、この里には何かあるのでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：何もありはせぬ。早々に立ち去るがよい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何もないなら、適当に通過しても良いのですよね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：それはならぬ。神聖な場所へとお主を導くわけには行かぬ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：神聖な場所が、やっぱりあるんですね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：っぐ・・・ぐむ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そこはおそらく・・・【神秘の森】と呼ばれる場所。違いますか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：何をしに来た。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オーランの塔に上りました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そこから空を観察して、赤い星を見かけたんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エルミ国王からはその件については、特に示唆はされませんでしたが", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：これは、きっと何かの予兆。俺はそう感じたんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お願いします、【神秘の森】を探索させていただけないでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ、そうか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：では、早々に帰るがよい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうですか・・・それでは失礼いたします。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ、で、少し待たれよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：おーい、アデルや。ちょっとお使いを頼まれてくんれかね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：はーい。ちょっと待ってー。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　部屋の奥から一人の女性が姿を現し ～～～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "？？？：やっ。お待たせ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アデルや。いつものお使いだ。【神秘の森】へ行き、どんぐり、りんご、きのこ、たけのこを取ってきてくれないか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：あー、良いわよ。じゃ行ってくるわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：これこれ、待たんか。節操の無さは相変わらずじゃの。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ほれ、そこの者達に挨拶をしなされ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：おー、みんな！アデル・ブリガンディってんだ。はじめまして！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：俺はアイン。アイン・ウォーレンスだ。よろしくな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ラナ・アミリアよ。お初にお目にかかります。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ビリー・ラキだ。元気よく行くぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ッホッホッホ。アデルや、それでは行ってくるがよい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：ああ、それじゃなじっちゃん！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：それともう一つ、アデルや。その者達と共に【神秘の森】へ入ってはくれんか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：ああ、もちろん良いぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っえ！？それじゃあ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主らが入るのではない。お主らが帰る所を、たまたま、アデルが同行するだけの事じゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、ありがとうございます！助かります！！", ActionEvent.None);

      Message(ref m_list, ref e_list, " 【" + Fix.NAME_ADEL_BRIGANDY + "】が仲間になりました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, Fix.NAME_ADEL_BRIGANDY, ActionEvent.HomeTownAddNewCharacter);

      Message(ref m_list, ref e_list, "長老：礼はよい。アデルよ、では頼んだぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：ああ、任せておいてよ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_22 + " 】が更新されました！", ActionEvent.QuestUpdate);

    }
    else
    {
      Message(ref m_list, ref e_list, "長老：アデルや、その者達を連れて【神秘の森】へお行きなさい。", ActionEvent.None);
    }
  }

  public static void Message500023(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アデル：神秘の森へ行くのか？アタシが案内してあげるよ。みんなこっちだよ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "【神秘の森】へ入りますか？", ActionEvent.HomeTownYesNoMessageDisplay);
  }

  public static void Message500024(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message500024 == false)
    {
      One.TF.Event_Message500024 = true;

      Message(ref m_list, ref e_list, "長老：おおアデルや。お帰りなさい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：ただいま、爺ちゃん。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：収穫物を拾ってきたよ。ほら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　アデルは神秘の森で採取した作物を長老に納めた。 ～～～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "長老：ホッホッホ、いつもありがとうな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：うんー、ありがとう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ところでじゃ、お主ら、アデルと神秘の森を探索してどうじゃった？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：えっ、どうと言いますと？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：その、アデルはあまり外部の方と関わった事が無くての。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：回りの人から見て、その、アデルの事をどう思ってもらえたか心配での。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：えっ、ていうか、全然普通な感じで喋ってましたけど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そうね。バカアインよりは全然喋りやすかったわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ああ、そこの意味わかんねー言葉ならべるヤツよりもはるかに喋りやすかったぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：みんな、ありがとう！バカアインもありがとう！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハハハ・・・ま、まあそういう事だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：アデル、神秘の森の案内は助かったぜ、ありがとうな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：いやいやー、いつでも呼んでちょうだい。案内してあげるよ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：こら、アデル。そんな言い方があるか。失礼でおろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：はーい。ごめんなさいね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、まあまあ。そこは大丈夫ですよ、気にしなくても。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ええと、そしたら一旦失礼します。また用があったら・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お待ちくだされ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アイン・ウォーレンス殿。１つ頼まれてはくれんか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：いや、正直な所、３つ頼まれてくれまいか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい。何でしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：１つ目、お主には神秘の森に入るため、この首飾りを授けたい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 " + Fix.ZHALMAN_NECKLACE + " 】を獲得しました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, Fix.ZHALMAN_NECKLACE, ActionEvent.GetItem);

      Message(ref m_list, ref e_list, "長老：受け取っていただけるかな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：良いんですか！？ありがたく喜んで！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ、よろしい。では２つ目じゃが、", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アデルを、お主の仲間として連れていってはもらえんかの。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：アデルを一緒に連れて行くと？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：そうじゃ。その子はもう大きくなってはおるが、世間の事をあまりに知らなすぎるのでな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主の仲間として様々な大地を歩み、成長して欲しいと思っておるのじゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アデルや。この者と一緒に行くことはできるかの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：うん、いいよー！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：本当に良いのか？しばらくはここに帰ってこれなくなるかも知れないんだぞ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：いいよー。爺ちゃんにずっと会えないワケじゃないんだし、ねー爺ちゃん。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：分かって言っておるのかのう・・・まったく。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：まあそういうわけじゃ。ふつつかではあるが、よろしくお頼み申す。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、じゃあアデル。今後ともよろしくな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：うんー！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：それで、最後の３つ目じゃが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あの・・・ひょっとして、私達は外した方が良いのでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：いいや、そういうわけではないのだ。いて頂いた方が助かる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・ふむ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アイン・ウォーレンス殿よ。とある人物を探して欲しいのじゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい。誰を探せばいいんでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：それはじゃな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：エルミ・ジョルジュという存在じゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・・・・・・・え？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主に託したい。では、頼んだぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：えっ、ちょっと待ってくださいよ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：衛兵ども！こやつらは盗人じゃ！ひっ捕らえよ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "衛兵：ハハ！！ただちに！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ウワッ、マジかよ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　アイン達は衛兵に囲まれた！ ～～～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "長老：こっそりとワシの壺を盗もうとしたな！この者どもを捕らえよ！！キエエエエェェ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ヤベ、皆逃げるぞ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　アイン達は一目散にその場から逃げ出した ～～～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：ふう・・・ここまでくれば大丈夫かな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：危なかったわね。あのお爺さん、本当強引よね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：好き勝手に衛兵を呼べるっつうのは強敵だよなマジ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：じいちゃん、いつもあんな感じだよ。あと、衛兵も本気出してないよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なっ、そうなのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：うんー。必要以上に追ってこない、ギリギリの距離感、捕まえそうで捕まえない感覚。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：全部わざとだよー。みんな慣れてる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃ・・・じゃあ、どうりで・・・なるほど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：今度、いっぺんお手合わせ願いたいな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何言ってるのよ、そんなことしたら本当にお陀仏よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハハハ・・・悪い悪い。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、アデル。俺達と一緒に来てくれ。よろしく頼む！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：うんー。よろしくねー！", ActionEvent.None);
    }
  }

  public static void Message500030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message500030 == false)
    {
      One.TF.Event_Message500030 = true;

      Message(ref m_list, ref e_list, "門番：アイン殿および御一同、お待ちください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どうかしたのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "門番：長老が今、こちらにあらせられます。しばらくこの場にてお待ち頂きたい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、分かった。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　しばらくして　～～～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "？？？：じいちゃん！　こっちでいいの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：こ、これ！　勝手に走り回ってはイカンと言うておろうが！", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：アハハハ！　こっちだよねー。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：コラ、待てと言うとるのに。まったく・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、どうも・・・ハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：いやはや。子供という年齢はとうに過ぎとると言うのに・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あの、俺たちに何か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：そうじゃったな。ちと、待ってくれないか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：おお、あった。これじゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　長老は不思議な球体をアイン・ウォーレンスへ差し出した　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：こ・・・これってまさか！！！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：その通りじゃ。これがObsidianStoneじゃよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：しかし、お主がそこまで驚くのは何故じゃ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、何というか・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、何でもありません。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ・・・ふむふむ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主、良き心と卓越した知恵を授かっておるようじゃの。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：その思考の仕方、奴にホント良く似ておるわい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：奴・・・？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：おおおぉっ、ウォッホン！ゴホン、ゴッホン！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：ふむ。それでは、行くがよい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主とその間者達にツァルマンの導きがあらんことを。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：おーじぃーちゃん！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：こら、邪魔するでない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ねえねえ、お姉ちゃん達って不思議な恰好してるよね！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：えっ？私達の事？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：名前。ねえ、名前は何て言うの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：私はエオネ・フルネアというの、よろしくね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私はラナ・アミリア。よろしく。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：こら！アデル！勝手に名前を聞くものではないとあれほど言うたじゃろ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：えーーー、良いじゃない。掟には記されてないんだし。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：な、何という事じゃ。掟をそういう類のものとして扱うとは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：で、アイン・ウォーレンスさん、ですよね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだ。何か用か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：アタシね。この世界へ飛び出そーと思ってるの。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：なので！アタシも連れて行って欲しーな☆", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：これ、待たんか。まったく・・・節操が無い行動と発言ばかりしおって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：じーちゃんの話は聞き飽きた！私、行くもん☆", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょ・・・長老どの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：すまぬ、アイン・ウォーレンス殿よ。これはしつけが出来なかったワシの問題じゃ。。。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、いえ。おそらく、何か本筋があるんですよね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：おお、そうじゃ。ッゴホン、では改めて。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アイン・ウォーレンスよ。お主に一つ頼みたい事がある。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：お主に託したObsidianStone。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：その行く末を見守るため、因果律を見定める調停者を一人、お主に同行させてもらいたい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アデル・ブリガンディよ。今ここにお主を調停者として命ずる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：さあ、こちらへ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：はーーーい！", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：『はい』は短く丁寧にと言うとろうが。ほれ、こちらで挨拶せい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：じゃ、よろしくね、アイン・ウォーレンスさん☆", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：アデルよ。それだけじゃなかろう。きちんと言うのじゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：ハイハイ。じゃあ、このぐらいにしてっと。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アデル・ブリガンディは明朗な表情と真っすぐな視線をアインへ向けた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アデル：世界の理とは、現世に在らず、具象にあらず、抽象にあらず。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：過去・現在・未来。永劫の時の中", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：常に変化し、故に、常に不変である事を知るだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：道（どう）を進む者、拒む者、見据える者", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：全ての生命へとこの言葉を授けよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：我は調停者。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：アイン・ウォーレンスよ。行く末を見守ろうぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アデル・ブリガンディはゆっくりと眼を閉じた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：ハーイ、以上だヨー☆", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：だヨー☆　は余計じゃ。せっかくの言霊を台無しにするでない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何かこう・・・洗われた感じがするな。不思議な感じですね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：掟に示される内容は、遥か古代からの知が凝縮されておる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "長老：受け取っていただければ幸いじゃ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ありがとうございます。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、アデルもまずは一緒にファージル宮殿に来てくれ。よろしく頼む！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：アハハ、いいよー☆", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：ラナさんも、エオネさんもよろしくお願いします！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：・・・あれ、俺は？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ええ、よろしくね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：よろしくお願いしますね♪", ActionEvent.None);

      Message(ref m_list, ref e_list, " 【アデル・ブリガンディ】が仲間になりました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, Fix.NAME_ADEL_BRIGANDY, ActionEvent.HomeTownAddNewCharacter);

      // Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_1 + " 】を達成しました！", ActionEvent.QuestComplete);

    }
  }
  #endregion

  #region "ゴルトラム洞窟"
  public static void Message600010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, Fix.GORATRUM_Event_1_O, ActionEvent.UpdateUnknownTile);
  }

  public static void Message600015(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600001 == false)
    {
      One.TF.Event_Message600001 = true;

      Message(ref m_list, ref e_list, "アイン：おっ、看板があるな。どれどれ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　本エリア奥にて凶暴な生物が発生。全面的に通路を封鎖する。　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：穏やかな内容じゃないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：今まで通ってきた道でも、モンスターなら普通に出現してるけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あの・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？なんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ぁ・・・いえ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なんか気になる事があれば、どしどし言ってくれ。ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアインは変な誘導しないでくれる？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：エオネさん、そこのバカは放っておいてくださいね。無視して良いですから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ハ、ハイ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まあモンスターの位置は把握出来てないんだし、慎重に進んだ方がよさそうね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ慎重に進めるとするか、了解！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　本エリア奥にて凶暴な生物が発生。全面的に通路を封鎖する。　』", ActionEvent.None);
    }
  }

  public static void Message600020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600010 == false)
    {
      One.TF.Event_Message600010 = true;
      if (One.TF.Event_Message600020 == false)
      {
        Message(ref m_list, ref e_list, "アイン：ん、扉みたいだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：この扉、鍵がかかってるみたいね。封鎖っていうのはこの事かしら。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：封鎖っていうからには、多分そうなのかもな。", ActionEvent.None);

        if (One.TF.FindBackPackItem(Fix.ITEM_COPPER_KEY))
        {
          One.TF.FieldObject_Goratrum_00001 = true;

          Message(ref m_list, ref e_list, "ラナ：そういえば、さっき入手していた銅製の鍵は使えないのかしら？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：なるほど、さっそくで悪いがちょっと開錠を頼めるか？", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：任せておいて。", ActionEvent.None);

          Message(ref m_list, ref e_list, "（ カッ・・・　・・・　・・・　ッカチ！）", ActionEvent.None);

          Message(ref m_list, ref e_list, Fix.GORATRUM_CopperDoor_1_O, ActionEvent.RemoveFieldObject);

          Message(ref m_list, ref e_list, "ラナ：開いたわよ。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：サンキュー。じゃあ先に進むぞ！", ActionEvent.None);
        }
        else
        {
          Message(ref m_list, ref e_list, "ラナ：どこかしっくり来ないわけ？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：いや、何でもない。ここはひとまず止めて別の通路を探そう。", ActionEvent.None);
        }
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：ん、扉みたいだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：この扉もさっきと同じね。鍵がかかってるみたいだわ。", ActionEvent.None);

        if (One.TF.FindBackPackItem(Fix.ITEM_COPPER_KEY))
        {
          One.TF.FieldObject_Goratrum_00001 = true;

          Message(ref m_list, ref e_list, "アイン：そういや、さっき入手した銅製の鍵が役に立ちそうだな。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：ラナ。さっそくで悪いがちょっと開錠を頼めるか？", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：任せておいて。", ActionEvent.None);

          Message(ref m_list, ref e_list, "（ カッ・・・　・・・　・・・　ッカチ！）", ActionEvent.None);

          Message(ref m_list, ref e_list, Fix.GORATRUM_CopperDoor_1_O, ActionEvent.RemoveFieldObject);

          Message(ref m_list, ref e_list, "ラナ：開いたわよ。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：サンキュー。じゃあ先に進むぞ！", ActionEvent.None);
        }
        else
        {
          Message(ref m_list, ref e_list, "アイン：ここはひとまず止めて別の通路を探そう。", ActionEvent.None);
        }
      }
    }
    else
    {
      if (One.TF.FindBackPackItem(Fix.ITEM_COPPER_KEY))
      {
        One.TF.FieldObject_Goratrum_00001 = true;

        Message(ref m_list, ref e_list, "アイン：よし、じゃあラナ。開錠を頼む。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：任せておいて。", ActionEvent.None);

        Message(ref m_list, ref e_list, "（ カッ・・・　・・・　・・・　ッカチ！）", ActionEvent.None);

        Message(ref m_list, ref e_list, Fix.GORATRUM_CopperDoor_1_O, ActionEvent.RemoveFieldObject);

        Message(ref m_list, ref e_list, "ラナ：開いたわよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：サンキュー。じゃあ先に進むぞ！", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：鍵がかかってるな。他を当たろう。", ActionEvent.None);
      }
    }
  }

  public static void Message600030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600020 == false)
    {
      One.TF.Event_Message600020 = true;
      if (One.TF.Event_Message600010 == false)
      {
        Message(ref m_list, ref e_list, "アイン：ん、扉みたいだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：この扉、鍵がかかってるみたいね。封鎖っていうのはこの事かしら。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：封鎖っていうからには、多分そうなのかもな。", ActionEvent.None);

        if (One.TF.FindBackPackItem(Fix.ITEM_COPPER_KEY))
        {
          if (One.TF.Event_Message600110 == false)
          {
            One.TF.Event_Message600110 = true;
          }
          Message(ref m_list, ref e_list, "ラナ：そういえば、さっき入手していた銅製の鍵は使えないのかしら？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：なるほど、さっそくで悪いがちょっと開錠を頼めるか？", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：任せておいて。", ActionEvent.None);

          Message(ref m_list, ref e_list, "（ カッ・・・　ッカリカリ・・・　ッカリ・・・　）", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：駄目ね。鍵穴の方がだいぶ破損しているみたい。", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：この扉の構造上、向こう側からバカアインが適当に蹴ってくれれば開くと思うんだけど。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：こっちからじゃ開けられないって事か。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：分かった。他をあたろう。", ActionEvent.None);
        }
        else
        {
          Message(ref m_list, ref e_list, "ラナ：どこかしっくり来ないわけ？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：いや、何でもない。ここはひとまず止めて別の通路を探そう。", ActionEvent.None);
        }
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：ん、扉みたいだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：この扉もさっきと同じね。鍵がかかってるみたいだわ。", ActionEvent.None);

        if (One.TF.FindBackPackItem(Fix.ITEM_COPPER_KEY))
        {
          if (One.TF.Event_Message600110 == false)
          {
            One.TF.Event_Message600110 = true;
            Message(ref m_list, ref e_list, "ラナ：そういえば、さっき入手していた銅製の鍵は使えないのかしら？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：なるほど、さっそくで悪いがちょっと開錠を頼めるか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：任せておいて。", ActionEvent.None);

            Message(ref m_list, ref e_list, "（ カッ・・・　ッカリカリ・・・　ッカリ・・・　）", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：駄目ね。鍵穴の方がだいぶ破損しているみたい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：この扉の構造上、向こう側からバカアインが適当に蹴ってくれれば開くと思うんだけど。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：こっちからじゃ開けられないって事か。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：分かった。他をあたろう。", ActionEvent.None);
          }
          else
          {
            Message(ref m_list, ref e_list, "アイン：こっちからじゃ開けられないな。他を当たろう。", ActionEvent.None);
          }
        }
        else
        {
          Message(ref m_list, ref e_list, "アイン：ここはひとまず止めて別の通路を探そう。", ActionEvent.None);
        }
      }
    }
    else
    {
      if (One.TF.FindBackPackItem(Fix.ITEM_COPPER_KEY))
      {
        if (One.TF.Event_Message600110 == false)
        {
          One.TF.Event_Message600110 = true;
          Message(ref m_list, ref e_list, "ラナ：そういえば、さっき入手していた銅製の鍵は使えないのかしら？", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：なるほど、さっそくで悪いがちょっと開錠を頼めるか？", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：任せておいて。", ActionEvent.None);

          Message(ref m_list, ref e_list, "（ カッ・・・　ッカリカリ・・・　ッカリ・・・　）", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：駄目ね。鍵穴の方がだいぶ破損しているみたい。", ActionEvent.None);

          Message(ref m_list, ref e_list, "ラナ：この扉の構造上、向こう側からバカアインが適当に蹴ってくれれば開くと思うんだけど。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：こっちからじゃ開けられないって事か。", ActionEvent.None);

          Message(ref m_list, ref e_list, "アイン：分かった。他をあたろう。", ActionEvent.None);
        }
        else
        {
          Message(ref m_list, ref e_list, "アイン：こっちからじゃ開けられないな。他を当たろう。", ActionEvent.None);
        }
      }
      else
      {
        if (One.TF.Event_Message600110)
        {
          Message(ref m_list, ref e_list, "アイン：こっちからじゃ開けられないな。他を当たろう。", ActionEvent.None);
        }
        else
        {
          Message(ref m_list, ref e_list, "アイン：鍵がかかってるな。他を当たろう。", ActionEvent.None);
        }
      }
    }
  }

  public static void Message600040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600040 == false)
    {
      One.TF.Event_Message600040 = true;

      Message(ref m_list, ref e_list, "アイン：おっ、これは何か使えそうなアイテムだな。", ActionEvent.None);

      if (One.TF.Event_Message600030)
      {
        Message(ref m_list, ref e_list, "ラナ：結構しっかりした素材で出来てるわね。さっきの穴があった場所で上手く使えば、渡れるんじゃないかしら。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：っしゃ、早速使ってみるとするか！　さっきの場所に行ってみるぞ。", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "ラナ：結構しっかりした素材で出来てるわね。設置個所を誤らなければ、遠く離れた所へ渡れるかも知れないわね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：遠く離れた地点か。ちょっと探してみるとするか。", ActionEvent.None);
      }

      Message(ref m_list, ref e_list, "エオネ：あ・・・そ、その・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：い、いえ・・・えっと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何かおかしな点があったら教えてね。私も分かってない事が沢山あるから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、そうではないんです。大丈夫です。ただ・・・", ActionEvent.None);

      if (One.TF.Event_Message600030)
      {
        Message(ref m_list, ref e_list, "エオネ：その穴の場所で使うのでしたら、設置は私に任せてもらっても良いでしょうか？", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "エオネ：使う場面がありましたら、設置は私に任せてもらっても良いでしょうか？", ActionEvent.None);
      }

      Message(ref m_list, ref e_list, "アイン：おお、マジか！設置してもらえるのは助かるぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、でも慎重に・・・やりますので・・・ちょっと時間かかりますが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：こんな道具使った事ないから本当助かるわ。その時は、お願いしますね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、続けて探索開始と行きますか！", ActionEvent.None);
    }
  }

  public static void Message600050(ref List<string> m_list, ref List<ActionEvent> e_list, string number)
  {
    One.TF.Event_Message600050 = true;

    Message(ref m_list, ref e_list, "アイン：ゲッ！！足元が！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：オワアアアアァァァ～～～・・・　（・・・・・・）", ActionEvent.None);

    Message(ref m_list, ref e_list, number, ActionEvent.DungeonGotoDownstair);
  }

  public static void Message600060(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600060 == false)
    {
      One.TF.Event_Message600060 = true;

      Message(ref m_list, ref e_list, "アイン：イデ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッツツツ・・・痛えなあ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：みんな大丈夫か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私は大丈夫よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：特には・・・。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：うっかり落ちてしまったな・・・次からはもう少し気を付けて探索するか・・・", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：イデ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッツツツ。またしても・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：みんな大丈夫か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私は大丈夫よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ええ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：少しは気を付けるとするか・・・", ActionEvent.None);
    }
  }

  public static void Message600070(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600070 == false)
    {
      GoratrumCrossHoleFirst(ref m_list, ref e_list, DungeonField.Direction.Bottom);
    }
    else
    {
      GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Bottom);
    }
  }

  public static void Message600080(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600070 == false)
    {
      GoratrumCrossHoleFirst(ref m_list, ref e_list, DungeonField.Direction.Top);
    }
    else
    {
      GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Top);
    }
  }

  public static void Message600090(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600070 == false)
    {
      GoratrumCrossHoleFirst(ref m_list, ref e_list, DungeonField.Direction.Bottom);
    }
    else
    {
      GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Bottom);
    }
  }

  public static void Message600100(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600070 == false)
    {
      GoratrumCrossHoleFirst(ref m_list, ref e_list, DungeonField.Direction.Top);
    }
    else
    {
      GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Top);
    }
  }

  public static void Message600110(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600070 == false)
    {
      GoratrumCrossHoleFirst(ref m_list, ref e_list, DungeonField.Direction.Bottom);
    }
    else
    {
      GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Bottom);
    }
  }

  public static void Message600120(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600070 == false)
    {
      GoratrumCrossHoleFirst(ref m_list, ref e_list, DungeonField.Direction.Top);
    }
    else
    {
      GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Top);
    }
  }

  public static void Message600130(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Bottom);
  }

  public static void Message600140(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Top);
  }

  public static void Message600150(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Right);
  }

  public static void Message600160(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    GoratrumCrossHole(ref m_list, ref e_list, DungeonField.Direction.Left);
  }

  public static void GoratrumCrossHoleFirst(ref List<string> m_list, ref List<ActionEvent> e_list, DungeonField.Direction direction)
  {
    One.TF.Event_Message600070 = true;

    Message(ref m_list, ref e_list, "アイン：ココだな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：では、設置しますね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、すまねえが頼む。", ActionEvent.None);

    Message(ref m_list, ref e_list, "～ エオネは足元の床を入念に調べ、綱渡りロープを固定し始めた ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "エオネ：できました。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、あとは・・・ちょっと・・・すみません・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ん？なんだ？？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：向こう側に投げてその先端のフックをひっかけるのよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え、えぇ・・・それで・・・えぇと・・・。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：バカアインがそこで突っ立って邪魔だから、どいてって事よ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジかよ。悪い悪い。じゃあ、場所を空けるんで、頼む。", ActionEvent.None);

    Message(ref m_list, ref e_list, "～ エオネは向こう側の床に向かって綱渡りロープの先端を投げた ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "（ ッヒュ・・・　・・・　・・・　ッカ！）", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：出来ました。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：な・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：うまいわね。正直驚いたわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：い、いえ・・・全然・・・なので・・・。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや、本当助かったぜ。ありがとな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：じゃ、早速わたってみましょ♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ、行ってみるぜ！", ActionEvent.None);

    if (direction == DungeonField.Direction.Top)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
    }
    else if (direction == DungeonField.Direction.Left)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);
    }
    else if (direction == DungeonField.Direction.Right)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);
    }
    else if (direction == DungeonField.Direction.Bottom)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);
    }

    Message(ref m_list, ref e_list, "アイン：オーケー、渡れたみたいだな。みんなも無事か？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：大丈夫よ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ次の探索へと進むとするか！", ActionEvent.None);
  }

  public static void GoratrumCrossHole(ref List<string> m_list, ref List<ActionEvent> e_list, DungeonField.Direction direction)
  {
    Message(ref m_list, ref e_list, "アイン：よし、渡るか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：エオネ、よろしく頼む。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "（ ッヒュ・・・　・・・　・・・　ッカ！）", ActionEvent.None);

    if (direction == DungeonField.Direction.Top)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
    }
    else if (direction == DungeonField.Direction.Left)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);
    }
    else if (direction == DungeonField.Direction.Right)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);
    }
    else if (direction == DungeonField.Direction.Bottom)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);
    }

    Message(ref m_list, ref e_list, "アイン：よし、行こう。", ActionEvent.None);
  }

  public static void Message600170(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600080 == false)
    {
      One.TF.Event_Message600080 = true;

      Message(ref m_list, ref e_list, "アイン：おっ、看板だな。ええと、なになに・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　大きな断裂が発生。足元注意！！　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうやらここは渡らない方が良さそうね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：例の綱渡りロープは届きそうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ううん、どうかしら・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：えっ・・・っと・・・届かないと思います・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ここは、止めておくか。他をあたろう。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　大きな断裂が発生。足元注意！！　』", ActionEvent.None);
    }
  }

  public static void Message600180(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600090 == false)
    {
      One.TF.Event_Message600090 = true;

      Message(ref m_list, ref e_list, "アイン：ここで看板だな。どれ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　聖堂へと向かい、地を経て、道を拓かん　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・　っ　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうかしたの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、そこまで考える必要はねえか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：行こう、こいつは多分そんなに気にしなくて良い。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：行こうってどこを探索するつもりなのよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：最初の地点だろう。道なりに行けって事だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：よく分かんないけど、行き先は分かったって事かしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：大丈夫だ。任せておけ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　聖堂へと向かい、地を経て、道を拓かん　』", ActionEvent.None);
    }
  }

  public static void Message600190(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600100 == false)
    {
      One.TF.Event_Message600100 = true;
      Message(ref m_list, ref e_list, "アイン：おっと、扉だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：鍵穴は全くないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・　・・っ・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：きっと、こっちからは開かないんだろう。他の箇所を探索しよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：なんでそう言い切れるわけ？", ActionEvent.None);

      if (One.TF.Event_Message600090)
      {
        Message(ref m_list, ref e_list, "アイン：さっき見た看板の通りだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：もう少し解説が欲しい所だけど。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：さっきの看板には【聖堂】と書かれていただろ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：で、俺たちはまだその【聖堂】らしき場所には辿り着いていない。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：【聖堂】を探して【地】を経てからだろうな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：というかココはそこまで重要な所じゃないのは確かだけどな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：微妙にベクトルが違うんだけど、まあバカアインらしい解釈ね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ここは多分良い。一旦戻ろう。", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：さっきの看板。見てはいないがおそらくこの扉に関する内容が書かれているんだろう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：もう少し解説が欲しい所だけど。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ここは行き止まりって事さ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ここから先に行くには別のルートを迂回する必要がある。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：おそらく最初の地点辺りなんじゃないかな。ちょっと予想的ではあるが。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：というかココはそこまで重要な所じゃないのは確かだけどな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：微妙にベクトルが違うんだけど、まあバカアインらしい解釈ね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ここは多分良い。一旦戻ろう。", ActionEvent.None);
      }
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：この扉は開かないみたいだ。他をあたろう。", ActionEvent.None);
    }
  }

  public static void Message600200(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よっしゃ、鍵をゲットだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：これを使えば、鍵がかかった扉を開ける事が出来るかもしれないわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：さっそく使いに行ってみるとするか！", ActionEvent.None);
  }

  public static void Message600210(ref List<string> m_list, ref List<ActionEvent> e_list, int number)
  {
    if (One.TF.Event_Message600120 == false)
    {
      One.TF.Event_Message600120 = true;
      Message(ref m_list, ref e_list, "アイン：・・・待て。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうしたのよ、突然？", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ アインは注意深く周辺を見回した ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "2", ActionEvent.UpdateUnknownTile);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なるほどな。ココが聖堂か。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・ッ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：なんでそう言い切れるのよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まず、そこの看板を見てみよう。", ActionEvent.None);

      if (number == 0)
      {
        Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);

        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
      }
      else if (number == 1)
      {
        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
      }
      else if (number == 2)
      {
        Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);

        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
      }

      Message(ref m_list, ref e_list, "『　満たされるは精神と英知。語り継ぎし者よ、安らぎと平穏を。　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ビンゴの様だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：この詩は、確かにそうみたいね。よく分かったわね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：部屋に２つ穴が開いているだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ、看板のすぐ後ろにあるわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：きっと元々は何かが祀られていたんじゃないのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そう・・・なのかしら。ちょっと分かりにくいけど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ調べようがないからな。特に気にしなくてもいい所だが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ただ、若干気になるエッセンスはあるんだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何がよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・いや、いいか。この時点だとどうにも分からない感じはする。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：で、どうするわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あの２つ穴。上手く降りられるかどうか、少し調べてみよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：分かったわ。", ActionEvent.None);
    }
  }

  public static void Message600220(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "『　満たされるは精神と英知。語り継ぎし者よ、安らぎと平穏を。　』", ActionEvent.None);
  }

  public static void Message600230(ref List<string> m_list, ref List<ActionEvent> e_list, int number)
  {
    One.TF.Event_Message600130 = true;

    if (One.TF.Event_Message600140 == false)
    {
      One.TF.Event_Message600140 = true;
      Message(ref m_list, ref e_list, "アイン：ちょっと、深さを見てみるか・・・どれどれ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：行けそうだな。二人とも準備はいいか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はっ、はい・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：特に問題ないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあちょっと降りるぞ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：二人とも準備はいいか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。　　　ラナ：いいわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ降りるぞ。", ActionEvent.None);
    }

    if (number == 0)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
    }
    else if (number == 1)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);
    }
    else if (number == 2)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);
    }
    else if (number == 3)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);
    }

    Message(ref m_list, ref e_list, "12", ActionEvent.DungeonGotoDownstair);
  }

  public static void Message600240(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600150 == false)
    {
      One.TF.Event_Message600150 = true;
      Message(ref m_list, ref e_list, "アイン：よっと。無事に着地っと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：２人とも大丈夫か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：狭い通路だな・・・元々今までも狭かったが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、このまま進めてみるとするか。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：着地っと。２人とも大丈夫か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。　　　ラナ：ええ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オーケー。このまま進めよう。", ActionEvent.None);
    }
  }

  public static void Message600250(ref List<string> m_list, ref List<ActionEvent> e_list, int number, string event_number)
  {
    One.TF.Event_Message600130 = true;

    if (One.TF.Event_Message600140 == false)
    {
      One.TF.Event_Message600140 = true;

      Message(ref m_list, ref e_list, "アイン：ちょっと、深さを見てみるか・・・どれどれ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：行けそうだな。二人とも準備はいいか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：えっ、ええ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：特に問題ないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあちょっと降りるぞ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：二人とも準備はいいか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ええ。　　ラナ：いいわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ降りるぞ。", ActionEvent.None);
    }

    if (number == 0)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
    }
    else if (number == 1)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);
    }
    else if (number == 2)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);
    }
    else if (number == 3)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);
    }

    Message(ref m_list, ref e_list, event_number, ActionEvent.DungeonGotoDownstair);
  }

  public static void Message600260(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600140 == false)
    {
      One.TF.Event_Message600140 = true;
      Message(ref m_list, ref e_list, "アイン：ここも深くはない。行けそうだな。二人とも準備はいいか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：えっ、ええ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：特に問題ないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあちょっと降りるぞ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：二人とも準備はいいか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ええ。　　ラナ：いいわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ降りるぞ。", ActionEvent.None);
    }
    Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);

    Message(ref m_list, ref e_list, "14", ActionEvent.DungeonGotoDownstair);
  }

  public static void Message600270(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.FieldObject_Goratrum_00002 = true;

    Message(ref m_list, ref e_list, "アイン：ラナ、この扉はどうだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：見せてみて。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：・・・特に仕掛けはないみたい。こちらから押せば普通に開くわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ。じゃあ、この扉は開けておくぜ。", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.GORATRUM_CopperDoor_3_O, ActionEvent.RemoveFieldObject);
  }

  public static void Message600280(ref List<string> m_list, ref List<ActionEvent> e_list, int number)
  {
    One.TF.Event_Message600160 = true;
    Message(ref m_list, ref e_list, "アイン：ここも降りれそうな箇所だな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：どうしたのよ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや、何でもねえ。おそらく、大丈夫だろう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ちょっと降りてみるぞ。二人とも良いか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：いつでも良いわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：オーケー。じゃあ行くぞ。", ActionEvent.None);

    if (number == 0)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
    }
    else if (number == 1)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);
    }
    else if (number == 2)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveLeft);
    }
    else if (number == 3)
    {
      Message(ref m_list, ref e_list, "1", ActionEvent.MoveBottom);
    }

    Message(ref m_list, ref e_list, "15", ActionEvent.DungeonGotoDownstair);
  }

  public static void Message600290(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600170 == false)
    {
      One.TF.Event_Message600170 = true;
      Message(ref m_list, ref e_list, "アイン：よっと。無事に着地っと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：２人とも大丈夫か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、このまま進めてみるとするか。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：着地っと。２人とも大丈夫か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。　　　ラナ：ええ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オーケー。このまま進めよう。", ActionEvent.None);
    }
  }

  public static void Message600300(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600180 == false)
    {
      One.TF.Event_Message600180 = true;
      One.TF.AvailablePotentialGauge = true;
      One.TF.AvailableArchetype_EinWolence = true;
      One.TF.PotentialEnergy = 0;

      Message(ref m_list, ref e_list, Fix.GORATRUM_2_Event_1_O, ActionEvent.UpdateUnknownTile);

      Message(ref m_list, ref e_list, "アイン：こ、ここは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうしたのよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なんでも、ねえ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そこに、石が設置されているな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：えっ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょっと待っててくれ。調査してくる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：えっ、ちょっと？？", ActionEvent.None);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);

      Message(ref m_list, ref e_list, "アイン：これは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アイン・ウォーレンスはその場で静止し、石へ手をかざし始めた　】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：ッグ・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "", ActionEvent.TurnToBlack);

      Message(ref m_list, ref e_list, "　　（　俺はこの時どう考えていただろうか　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　意味の追跡はここまで　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　おそらく考えていた事が重要なのではなく　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　無限に連なる空間があった事が重要だったのだろう　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　知らなかったというよりも　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　その概念の外側　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　あたかも始めから決められていたかのように　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　その石に触れた　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：石に触れし者よ", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：少年よ", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：繰り返すは永劫の記憶", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：誰だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：我は存在の定義から外れし者", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ヒトの子は我を支配竜と呼ぶ", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：支配・・・竜・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：少年がこの石を選択する事に在らず", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：石が少年を選択する事に在らず", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：手にせしその石", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：少年が遥か太古から入手しているものである", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：遥か太古・・・から・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：石との接触は", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：一つの終わりを意味する", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：少年が進むは過去への道標", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：過去へ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：行くがよい", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.GORATRUM_2_ObsidianPortal_1_O, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "【 アイン・ウォーレンス　ObsidianStoneを取得 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "【 アイン・ウォーレンス　元核【集中と断絶】を習得 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "", ActionEvent.ReturnToNormal);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっとそこのバカアイン？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何ボサっと突っ立ってるのよ？どうかしたわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：い、いや・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：汗を・・・だいぶ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何でもない。気のせいだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：それはそうと、何か気になる物でもあったの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ！　とんでもない物をゲットしたぞ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：これだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何を見せているわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：俺の手元をよく見てくれ。石があるだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アインは、ラナとエオネに向けて、手を拡げて見せた 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：っえ・・・？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・あの・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アインは自分の手元に目をやり・・・ 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：なっ、無い！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：マジかよ？　正直な所、ラナとエオネはあの石を見なかったか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：正直な所、私は見てないわよ。何の事かさっぱり。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エオネ、お前もか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：す、すみませんが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あんたが勝手に一人で何もない所にフラフラっと寄って行ったのよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そ、それで・・・そのまま・・・動かなくて・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハーッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：すまないが、次へ進めよう。これは無かった事にしてくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まあいいけど。ホント、大丈夫なのかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、大丈夫だ。さて、次へ向かうとしよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　アイン・ウォーレンスが【元核】を使えるようになりました。", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "　【元核】はポテンシャル・ゲージが溜まる事で使用可能となります。", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "　ポテンシャル・ゲージは、アクションコマンドを使っていくことで溜まります。 ", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "　ポテンシャル・ゲージが溜まったら【元核】を使ってみましょう。 ", ActionEvent.MessageDisplay);

    }
  }

  public static void Message600310(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message600190 == false)
    {
      One.TF.Event_Message600190 = true;

      Message(ref m_list, ref e_list, Fix.GORATRUM_2_Event_2_O, ActionEvent.UpdateUnknownTile);

      Message(ref m_list, ref e_list, "アイン：なるほど・・・コイツは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうしたの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ＧＯＡＡＨＨＨＨＨ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：キャッ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あぶねえ、ちょっと一旦退くぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "1", ActionEvent.MoveRight);

      Message(ref m_list, ref e_list, "アイン：さて・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：見た感じ、巨大な砲台って感じのモンスターだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラナは、今まで通りのスタイルで戦闘に挑んでくれ。ダメージは普通通り当たるだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ、分かったわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エオネも、基本的にはこれまで通り、聖魔法による後方支援を頼んだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それから、敵へ影響を与える効果もおそらく大丈夫だ。余力があれば頼む。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、ピンチな時は全員で徹底して防御も忘れないでくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：他は特に気にする事はないだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし。じゃ行くとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ・・・あの・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そ・・・その・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：勝てる見込みって・・・あるんでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何でだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：え・・・ええっと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そこのバカアインにそういう話しても無駄よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そ・・・そうなんですか・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：バカアイン、もう少し補足を付けてよね。エオネさんが不安がってるじゃない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：わ、悪い悪い・・・ええとだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、大技はあるかもしれないが、それまでって事だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：深く詮索する必要はない。順当にやれば良いって事さ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・ッ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：エオネさん、ごめんなさい。後でゆっくり説明してもらうから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ハ、ハイ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ準備が出来次第突撃だ。行くぜ！", ActionEvent.None);
    }
  }

  public static void Message600320(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "？？？：ＳＰＡＡＡＡＡＫ！！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラナ、エオネ。準備はいいか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：いつでも良いわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ、行くぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.MAGICAL_HAIL_GUN, ActionEvent.EncountBoss);

  }

  public static void Message600330(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    // todo ボス討伐後のイベント
  }

  public static void Message600340(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.FieldObject_Goratrum_00003 = true;

    Message(ref m_list, ref e_list, "アイン：ラナ、この扉についてチェック頼む。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ええ、良いわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：・・・そうね。仕掛けはないみたい。こちらからなら普通に開くわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ。じゃあ、開けておくぜ。", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.GORATRUM_CopperDoor_2_O, ActionEvent.RemoveFieldObject);
  }
  #endregion

  #region "ファージル宮殿"
  public static void Message700010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message700010 == false)
    {
      One.TF.Event_Message700010 = true;

      Message(ref m_list, ref e_list, "アイン：よし、着いたみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、早速ファージル宮殿へ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと待って。宮殿行く前に少し休憩がしたいんだけど、良いかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、もちろんだ。じゃあ、今日はハンナ叔母さんの宿屋で一泊するか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：皆も良いか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：俺は良いぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：いいよー☆", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあまずは宿屋へ行こう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　ハンナの宿屋にて　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：っしゃ、ごちそうさまでした！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アデル：これ、すごーい美味しかったねー。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：アッハハハ、気に入ってもらえた様で何よりだね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：バッチャン、これマジでウメーよ！感動した！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：欲しけりゃいくらでも作ってあげるよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・ありがとうございました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：ああ、また寄ってくんな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：叔母さん、部屋は幾つ空いてますか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：人数分だけちゃんと取ってあるよ。心配無用さ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：いつも助かります、ありがとうございます♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ皆。明日もよろしく頼む。おつかれさん！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：あ、ちょっとアイン。アンタは少しだけこちらへ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あっと、はい。何でしょう？", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アイン、宿泊部屋にて　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：（さてと・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "", ActionEvent.HomeTownBlackOut);

      if (One.AR.InscribeObsidianStone_1 == false)
      {
        Message(ref m_list, ref e_list, "（　何か重要な事を忘れている気がする。　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　何だろう・・・思い出せない。　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　この先、国王の所へ赴き、次の話をするわけだが　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　どうにも拭えないこの感覚には抗う事ができない　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　俺はきっと　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　過去の俺に　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　決別できないでいる　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　このまま進める事はできない　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　俺は一体どうしたかったのか　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　今となっては、もう分からない　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：（・・・　・・・）", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：（・・・）", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　THE　END　～　（過去からの欠落）", ActionEvent.None);

        Message(ref m_list, ref e_list, "", ActionEvent.DungeonBadEnd);
      }
      else
      {
        Message(ref m_list, ref e_list, "（　国王エルミ・ジョルジュ　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　ラナに託されていた宝剣　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　エオネ・フルネアの存在　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　偶然出くわしたビリー・ラキ　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　調停者、アデル・ブリガンディ　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　そして・・・　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　Obsidian Stone　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　違和感というよりは　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　一貫した何かを感じる　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　国王は俺達に何を依頼しているのか　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　分からない・・・　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　あのObsidianStoneについては、とにかく辻褄が合わない　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　いや、辻褄とかそういう以前に　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　色々とおかしな点が多い　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　ただ、この”おかしな点”という感覚そのものが　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　明らかに視点がズレているから、とも思える　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　ツァルマンの里から託されたObsidianStone　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　元々どこの誰のものだったのか　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　いいや、その考え方も既におかしいんだろう　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　・・・　・・・　・・・　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　国王と何を話すべきだろう　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　決めて・・・おかないとな　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　・・・　・・・　・・・　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　・・・　・・・　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　・・・　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "", ActionEvent.ReturnToNormal);

        Message(ref m_list, ref e_list, "", ActionEvent.HomeTownExecRestInn);

        Message(ref m_list, ref e_list, "アイン：さて、何すっかな。", ActionEvent.LastMessage);
      }
    }
  }

  public static void Message700020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {                  
    if (One.TF.Event_Message700020 == false)
    {
      One.TF.Event_Message700020 = true;

      Message(ref m_list, ref e_list, "ラナ：ハンナおばさん、こんにちはー♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：ラナちゃん、久しぶりだねぇ、いらっしゃい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：一泊で空き部屋はあるかしら？今日泊っていきたいんだけど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：ああ、大丈夫だよ。今日はこの宿屋でゆっくりと休んでいきなさい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あっ、ちょっと俺の部屋も予約取りたいですけど、良いですかね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：もちろん、あんたの分も用意済みだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン／ラナ：用意済み？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：ありゃりゃ、しまった口が滑っちまったようだね。アッハハハ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ハンナ：じゃあ、夕飯のメニューを選んでおきな。用意しておくよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン／ラナ：ありがとうございます！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【宿屋で夕飯のメニューが選べる様になりました。】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "【夕飯のメニューは次の日から加算されるパラメータの内容を決定します。】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "【状況に応じた選択を行う事でより効果的なパラメタ調整を行って行くことをお勧めします。】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "", ActionEvent.HomeTownExecRestInn);
    }
  }

  public static void Message700030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message700020 == false)
    {
      Message(ref m_list, ref e_list, "ラナ：悪いんだけど、少し疲れてるの。先に宿屋に行ってもらえないかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おお、そうだったな。了解了解。", ActionEvent.None);
    }
    else
    {
      if (One.TF.AlreadyRestInn == false)
      {
        Message(ref m_list, ref e_list, "ラナ：悪いんだけど、少し疲れてるの。先に宿屋に行ってもらえないかしら。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：おお、そうだったな。了解了解。", ActionEvent.None);
      }
      else
      {
        One.TF.Event_Message700030 = true;

        Message100021(ref m_list, ref e_list);
      }
    }
  }

  public static void Message700031(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：（今、ファージル宮殿に行く用事はないな・・・他を当たろう）", ActionEvent.None);
  }

  public static void Message700040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "ラナ：ちょっと・・・遠征許可証は？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・もちろん、今から取得しに行くぜ！", ActionEvent.None);

  }

  public static void Message700050(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message700050 == false)
    {
      One.TF.Event_Message700050 = true;
      {
        Message(ref m_list, ref e_list, "アイン：よし、じゃあファージル宮殿に行くとしよう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～ ファージル宮殿にて ～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "　　【受付嬢：ファージル宮殿へようこそ。】", ActionEvent.None);

        Message(ref m_list, ref e_list, "　　【受付嬢：アイン・ウォーレンス様ですね。ご用件をどうぞ。】", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：国王様にお会いしたい。要件があると伝令の者から教えてもらっている。", ActionEvent.None);

        Message(ref m_list, ref e_list, "　　【受付嬢：エルミ・ジョルジュ国王陛下への謁見ですね。しばらくお待ちください。】", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "　　【受付嬢：お待たせいたしました。】", ActionEvent.None);

        Message(ref m_list, ref e_list, "　　【受付嬢：それでは、謁見の間へ行かれます様、よろしくお願い申し上げます。】", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ、サンキューな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：じゃあ、ちょっと行ってくるぜ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "　　【受付嬢：なお、今回の謁見については、アイン様および関係者ご一同様も含めご参席ください。】", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あ、そうなのか。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：い、い、い、意外よね。たいていは一人ずつだけど。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ラナ、なんでお前の方がうろたえてるんだ？別に一緒に入るだけだろ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：え、ええ、えーーそうよ！問題無いんだから。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：珍しく意味が分かんねえな・・・まあ、そこは良いか・・・。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：じゃあ、受付さん。俺とラナ、エオネ、ビリー、アデルの５人で入るが問題ないかな？", ActionEvent.None);

        Message(ref m_list, ref e_list, "　　【受付嬢：はい。】", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：よし、じゃあこのメンバーで謁見の間へ向かおう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、謁見の間にて ～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "アイン：ご・・・ご拝受つかまつります。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：アイン君。よく来てくれたね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：それから、ラナ君、ビリー君、エオネ君、アデル君も来てくれてありがとう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：喋り方については楽にしてくれて構わないよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：は、はい。それでは・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：今回、港町コチューシェには行ってみて、調査する事はできました・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：しかし、港からは船が出てないため、ヴィンスガルデ王国に渡ることはできず。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：で、港町から北に向けて行くルートを町の方達から情報を入手した上で、", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：そこへ向けて俺達は万全の準備を整えて・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：あ、ちょっと良いかな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：そのあたりについてはアイン君も喋る意味はあまりないと既に思っているんだよね？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・いえ、そういうわけでは。", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　国王エルミは、いつになく威厳あるオーラを前面に放ち始めた　）", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：アイン君、普段通り気軽にしゃべってくれて良いんだよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：これは僕からのお願いでもある。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：僕はね。アイン君、ラナ君、エオネ君、ビリー君、アデル君。君達がここに今来てくれている。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：その事に関する【理】を見出すのが僕の役割なんだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：【理】・・・ですか？そう言われても・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：大丈夫。ありのままで喋ってくれれば良いから。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：じゃまあお言葉に甘えまして・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：正直な所、こうなるとは思ってなかったんですよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：エオネからの依頼内容から始まって、まずは古い聖堂のダンジョンへ寄る。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：で、アイテムらしき物をGETしたんだが、勘違い。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：しょうがないから、そこは置いといて、コチューシェに到着したら、ビリーと偶然再会。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：その他はこれといった情報なし。ヒントなし。ついでに船も出ない。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：しょうがないから神秘の森のルートを教えてもらい、ツァルマンの里へ到着。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・いや、その前に神秘の森で・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：良いよ、ペース配分は好きな感じで。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：確かに、手に入れたんです。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ですが、それは幻", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：幻なのは間違いないんですが、感覚が受け入れないというか・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：結局、その感覚を拭いきれず、ツァルマンの里へ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：そして、現れたのが・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：Obsidian Stone・・・授かったのだね？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：はい。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：なかなか面白いね。やっぱりアイン君の喋りは興味が湧くよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あの、すみません。ちょっと聞いても良いでしょうか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：ああ、何でも聞いてくれて構わないよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ラナが持っていた例の剣。あれは国王様がラナに渡したものですよね？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：なっ！ちょっ！ちょ、何言ってるのよ！！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：アハハ。ラナ君、そこまで慌てなくても良いよ。ここまで来た以上隠す必要はもうないんだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：確かに、その剣はファージル宮殿の宝物庫に厳重に保管していた宝剣だ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：僕がラナ君に頼んで、秘密裏に管理してもらう事にしていたんだ。間違いないよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：やっぱりそうだったのか。何か違和感があったからさ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：ど、ど、どーいうふーに違和感があったって言うわけ！！？？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：港町コチューシェの時でハッキリしたが、ラナ。お前はそういうところは分かりやすい。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：な！なっ何がよ！？ちゃんと言いなさいよね！？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：え、あ、いや・・・悪い。そこは別に良いんだ。察してしまった俺も悪いわけだし・・・ハハハ・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：もう、この場では良いわよ。後でちゃんと教えて。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あ、ああ。分かった。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：じゃあ、もう一つだけいいですか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：いくつでも良いよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：俺が入手した奇妙な物体、つまりObsidianStoneとはいったい何なんでしょうか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：その宝剣にはめるためのもので、間違いないよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：いや、ちょっと待ってください。それっておかしいですよね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：ちょっとバカアイン。何突っかかってんのよ！？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：ラナ君。良いんだよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　国王エルミの眼差しは静謐な雰囲気を彩りはじめる ～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "エルミ：アイン君、続けて。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あ、ええとですね・・・つまり・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：国王様は今何等かの事情があって、動けない。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：そう考えれば辻褄としては合う事になりますよね？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：いいや。「ハズレ」と答えておこう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：え！？あれ！？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：うん。でも、さすがアイン君、と付け加えておこう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：これはちょっと限界があるね。じゃあ、少しだけ譲歩しよう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：アイン君が最初にここに訪れる前に", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：僕はとある人とこの謁見の間で情報を取り交わしている。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：その相手とは？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：え、だってそれは毎日山のようにやってるから、誰って言われても・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ま、まさか！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "（　アインはふと、後ろで黙っているエオネの方に顔を向けてみた！　）", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "エオネ：・・・っ・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あ、そうか！そういう事か！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：何だよ俺！そんな事にも気づかずにずっと旅してたって事か！", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ッハッハッハ！いやいや、そうなのか！", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：でも、アイン君なら薄々と勘づいてたんじゃないかな？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：いや、これは本当に意識は行ってなかったです。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：って、待てよ。ちょっとこれって・・・ひょっとして。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：エオネ、すまねえが、ちょっとだけ教えてくれ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：えっ、あ。ハイ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：そうか・・・じゃあ俺達があのツァルマンの里から呼び戻されたってのは・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：宝剣と対になる「Obsidian Stone」が手に入ったからか。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：必然というよりも・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・【理】・・・か。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：いや", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：それもまた、理由の連鎖が合致していない感じがする。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：宝剣は些細な道標でしかなく、", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：選ぶべき対象があるが、", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：その選ぶべき事象が、まだ、存在していない。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：で、あるにも関わらず、認識に至らなければ、存在の可能性も潰える。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：それを防ぐために、国王は俺達にミッションを与えた。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：すみません、駄目です。正直、辿り着ける気がしない。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：いや、凄いよ。そこまで手繰り寄せられるのはアイン君だけじゃないかな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：ラナ君。どうだい？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：勿体なきお言葉。そこにいるバカ者とここまで対話頂けた事が奇跡にも等しい時間です。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：ビリー君、アイン君と話をするのは楽しいかい？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：え！！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：いやいやいや、スンマセン！俺なんかとてもじゃありませっせっせんが！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：ア、ア、アインのヤローのセリフは何時も楽しんでるというかノリ会話なんで。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：ハ、ッハハハハハ！な、なあアイン！？なぁ！？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ビリー、落ち着けって。まあ、ありがとな。お前のそういう所もありがたいぜ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：オ、オウ！ハハハ！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：それと、アデル君だね。ツァルマン爺は今も元気かな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　アデル・ブリガンディは眼を閉じ、顔を床に落とし、声のみを国王へと向ける　～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "アデル：はい。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アデル：国王から仰せつかった【教え】をこの世に広める。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アデル：その責務、片時も忘れた事は無い事をここに証明します。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アデル：ご無礼、お許しください。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：ありがとう。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：彼に伝えておいてほしい。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：現在も、そしてこれからも、私は感謝し続けると。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アデル：はっ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：アイン君。良い仲間を持ったね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：心から感謝の気持ちを忘れずに。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：はい、ありがとうございます。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：国王。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：うん、なんだい？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：後は俺自身が何とか考えます。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：そしてまた、分かった事をお伝えしに来ます。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：必ず、また来ます！", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：さて、どこまで辿り着き、どこまで見出せるかな。後々のお楽しみだね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　国王エルミの眼差しは元の雰囲気へと戻っていった ～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "エルミ：あ、それと。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：実は別の案件を頼みたい事があるんだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：はい、なんでしょうか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：ここから北東に進み、オーランの塔に上り、本大陸全土の視察をしてきてくれないかな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：オーランの塔？そんな場所があるんですか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：ああ、ちょっと面倒なお使いなんだけど、やってもらえるかな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：い、いえいえ。もちろん喜んで。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：オーランの塔周辺は突然危険なモンスターも出没する。準備は怠らないように。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：これは軍資金だ。好きに使ってくれて良いからね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "【 50000 gold 】を獲得しました！", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "50000", ActionEvent.GetGold);

        Message(ref m_list, ref e_list, "アイン：あ、わざわざすみません！大事に使います！", ActionEvent.None);

        Message(ref m_list, ref e_list, "エルミ：じゃ、頼んだよ。くれぐれも気をつけて。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：はい！失礼いたします！", ActionEvent.None);

        Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、エントランスにて ～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "アイン：オーランの塔・・・か・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：が、その前にエオネ。ちょっと今度また教えてくれ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：ハ・・・ハイ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あ、いや正直な所、今は良いんだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：絶妙な機会とタイミングがあればで良い。これからもよろしくな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：・・・ハイ！", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：よし、じゃオーランの塔へ向けて出発とするか！", ActionEvent.None);

        Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_2 + " 】を達成しました！", ActionEvent.QuestComplete);

        Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_11 + " 】が開始されました！", ActionEvent.GetNewQuest);
      }
    }
  }

  public static void Message700021(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message700020 == false)
    {
      One.TF.Event_Message700020 = true;

      Message(ref m_list, ref e_list, "アイン：よし、着いたみたいだな。早速ファージル宮殿に行くとしよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ ファージル宮殿にて ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "　　【受付嬢：ファージル宮殿へようこそ。】", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　【受付嬢：アイン・ウォーレンス様ですね。ご用件をどうぞ。】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：国王様にお会いしたい。オーランの塔で視察を行ってきた結果を報告したい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　【受付嬢：エルミ・ジョルジュ国王陛下への謁見ですね。しばらくお待ちください。】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　【受付嬢：お待たせいたしました。】", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　【受付嬢：それでは、謁見の間へ行かれます様、よろしくお願い申し上げます。】", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　【受付嬢：なお、今回の謁見については、アイン様および関係者ご一同様も含めご参席ください。】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、サンキューな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、受付さん。俺とラナ、エオネ、ビリーの４人で入るが問題ないかな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　【受付嬢：はい。】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあこのメンバーで謁見の間へ向かおう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、謁見の間にて ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：ご拝受つかまつります。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：アイン君、ラナ君、ビリー君、エオネ君。ようこそファージル宮殿へ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：喋り方はいつもの通りでお願いするよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい。それでは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オーランの塔の最上階でエリア全域を視察してきました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：それで、何か見えたものはあったのかな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ええ、非常に小さく薄赤い星が空に出ているのを確認しました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：ラナ君、エオネ君、ビリー君も一緒にそれは見えたのかい？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：いえ、私はあまりちゃんと見てませんでしたので・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私も展望台には行ってないし、見てないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：俺も正直覚えてねーな。あの時の事は。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、お前。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ん？なんだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・えっ、ええと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：フフ、別に良いんじゃないの♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま・・・まあ、良いか。それはそれで。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：じゃあ、その薄赤い星が見えたというのはアイン君一人だけなんだね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい、そういう事になります。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：その他に気づいた点はあるかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いいや、報告できるような内容はあまり・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：アイン君、重要なポイントなんだ。皆にも伝えるつもりで気軽に喋ってくれないかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ！す、すみませんでした！じゃあちょっと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まず、あの薄赤い星の方角なんだが、おおよそ北西のちょい左ぐらいだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：それって西北西に事ね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それだ。西北西辺りといえば、", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ムーンフォーダー雪原区域ですね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あとはヴェルガスの海底神殿もある。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、遠くから見た感じだが、いつもよりその海底神殿の入口の水域が少し下がっている感じがした。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そんなのアンタが分かるわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何となくだよ。直感的だからあまり当てにもならねえし、報告するレベルではないと思ったんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あと、ヴィンスガルデ王国側が山に隠れてほとんど見えなかったが、", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：一か所だけちょっと見えたのがある。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あれはあきらかに自然の地形じゃなかった。人工的な建物だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：それはきっと・・・ダルの門ですね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ダルの門？初耳だが、そんなのがあるのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：え、いえ・・・私も詳しくは知らないです・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、別に良いんだ。内容は後でちょっと調べてみよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あと、西側の方によくわからないが残骸らしきものがあったな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：残骸というか・・・あれは何等かの形成物だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、東側はそこら中が山だらけ。特に何も発見は出来てない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それから、南西側には、何か妙にくぼんだ島も見えたな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それから後は・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょ、ちょっと。話が拡がり過ぎてるんじゃないの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：良いんだよラナ君。おそらく今のがアイン君本来の喋りだろうからさ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：すみません。つい何か・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：いや、ありがとう。凄く助かるよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：でもなんか気になるんですよね。色々と入ってくる事象に意図があるような気がして。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：関係性よりも先に秘められし内容がそこにある。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ・・・はい。なんとなくですが、そう感じるんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：まあ確かに薄赤い星は重要なポイントだったね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：でも、今喋った中で、他にも重要なポイントと感じたのは実はあるんじゃないかな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そ、それは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：いや、今のはこちらの非礼だった。申し訳ない。", ActionEvent.None);
      
      Message(ref m_list, ref e_list, "アイン：あ、いえそんなつもりじゃないんです！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ただ、何というか・・・見ただけじゃ錯覚という事もあるし", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：師匠からも散々言われているんです。自分の目で見てこいと。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：師匠。ああ、オル・ランディスの事だね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい、なのであまりにも不確かな件は、口で言うべきではないと考えています。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：うん、アイン君。本当にありがとう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：ではアイン・ウォーレンスへ次の指令を伝えるとしよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：ファラ。そろそろ出番だよ。こっちに来てくれないかな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ファラ：あらあら、もう出てきても良いのかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：ああ。例の件を頼む。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ファラ：では、アインさん。ちょっとこちらへいらして。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ。ええと、はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ファラ：ウフフ、そんなにかしこまらなくても大丈夫ですよご心配なく（＾＾", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：い、いえいえ。では・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ アインは謁見の間へ顔を上げ、玉座の方へ少し近づいた ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ファラ：はい、じゃあこれをどうぞ（＾＾", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：こ、これは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：ファージル王家に代々から伝わるアイテム【厳正の宝珠】をアイン君に授けようと思うんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：こ、こんな大事な物、俺なんかに勿体ないです！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ファラ：王の命令です。受け取ってください（＾＾", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい、わかりました！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：うん、良い返事だね。ありがとう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ファラ：あと、ついでにこれもどうぞ（＾＾", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：こら。ついでじゃなくて、そちらの方が本来大事なものだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ファラ：しょうがないですわね。ではアインさん、こちらを正式にお受け取り下さい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ 【ムーンフォーダー区域遠征許可証】を手に入れた！ ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：あ、これは遠征許可証ですね！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：やったじゃないアイン。それがあればムーンフォーダー雪原区域に行くことができるわね♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、助かるぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：許可証については、今いる皆の分も配布しておいたから、各自が持っておくように。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、ありがとうとございます。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：っしゃ、許可証ゲット！やったぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうもありがとうございます。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：では、アイン君。ムーンフォーダー方面に行ったらまずは、アーケンダイン街に寄ると良い。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：アーケンダイン街？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：ファージルとムーンフォーダーの国境ライン近辺で栄えている街の事だよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：ムーンフォーダーは正直国交が無いため、情報は入手しにくい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：そこで現地の人々と対話を行ってきて、今どのような状態になっているかを確認してきてほしいんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：引き受けてもらえるかな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい！喜んで！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エルミ：アッハハハ、元気が良いね。じゃあムーンフォーダーの件、よろしく頼んだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：はい！それでは失礼いたします！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、エントランスにて ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：よし！じゃあまずはアーケンダイン街へ向かうとしよう！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何かやたらと張り切ってるわね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ムーンフォーダーは昔から行ってみたいと思ってたんだ。張り切らないわけには行かないだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ッフフ、何かそういえば昔小さい頃そんなこと言ってたわね♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：じゃあ・・・準備を整えておきますね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おいアイン。あんま気張りすぎてコケるんじゃねーぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ははは、大丈夫だって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし！皆よろしく頼んだぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_11 + " 】を達成しました！", ActionEvent.QuestComplete);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_21 + " 】が開始されました！", ActionEvent.GetNewQuest);
    }
  }
  #endregion

  #region "オーランの塔"
  public static void Message800010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：へえ・・・ここが・・・。", ActionEvent.None);

    Message(ref m_list, ref e_list, "～ アインは塔に入った途端、周囲を見回した ～", ActionEvent.MessageDisplay);
    
    Message(ref m_list, ref e_list, "アイン：なかなか面白そうな構造をしてるな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：フロア全体が吹き抜け構造になってるって感じよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：仕掛けもたくさんありそうで、難しそうですね・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：お・・・おいアイン。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ん？どうした。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：これ、まさか上へ登るって話じゃないだろうな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：上へ登るために来たんだろ。塔に来たんだしな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：お、お前まさか・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：っんでもねえよ！ああもう良いから、黙って俺に付いてこいや！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：はいはい、分かりましたよ。じゃあビリー様を先頭にして付いて行くとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：っんで俺が先頭なんだよ！！先頭はてめえが先に行けば良いだろうが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：マジかよ。じゃあまあ一応リーダーはビリー。で、ルート選択は俺がやる。それで良いかな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：ああ、頼んだぜ！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあオーランの塔を進んでみるとするか！", ActionEvent.None);

  }

  public static void Message800090(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message800090 == false)
    {
      One.TF.Event_Message800090 = true;

      Message(ref m_list, ref e_list, "アイン：んっ・・・何か今・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：大きく風が吹き抜けていったわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ:この塔の最上階から流れてきた感じですね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：まあ、こんな作りなんだし、風ぐらいあんじゃねえの？何か気になるってのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：気のせいならそれで良いんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ただし、ある程度警戒はしておいて損はしないだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ:この塔の構造は通路形状ではないので、対流による風は起きにくいお思います。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：という事は・・・やっぱり要警戒かしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：この塔の最上階はおそらくもうすぐだ。ともかく、気をつけて行こう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_20 + " 】が開始されました！", ActionEvent.GetNewQuest);
    }
  }

  public static void Message800100(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.DefeatYodirian == false && One.TF.QuestMain_Complete_00020 == false)
    {
      Message(ref m_list, ref e_list, "アイン：おっと、出たみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：空中に浮いてますね・・・何の生物なんでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：鳥類にしては形態がちょっと異質よね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：行動パターンもちょっと読みにくそうだけど・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アインはどう思う？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：正直言って、殺気の様なものは感じられない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：生物である以上、攻撃意志がないわけじゃない。実際の戦闘になってから本領発揮する感じだろうな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あまり無理に急ぎ過ぎず、着々と戦闘を行おう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、相手が何かやらかしそうだったら、一旦防御に徹するのも手の一つだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：後方が安全とは限らない。この狭さではエリア全体攻撃もやってくると見た方が良いだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：各自で防ぎ切るか、または誰かが全体防御をできるように準備しておいた方が良いかもな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：大体分かったわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ行くぞ。エオネ、ラナ、ビリー、準備は良いか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：は、はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私はいつでも良いわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：任せとけや！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ戦闘開始だ、行くぞ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.THE_YODIRIAN, ActionEvent.EncountBoss);
    }
  }


  public static void Message800110(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.DefeatYodirian && One.TF.QuestMain_Complete_00020 == false && One.TF.Event_Message800100 == false)
    {
      One.TF.Event_Message800100 = true;

      Message(ref m_list, ref e_list, "ヨーディリアン：フッ・・・ッシュウウウウゥゥゥゥ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お、終わったか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ヨーディリアン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何事もなく終わったみたいね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ふう、相変わらずこういう系統は疲れるな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし！制覇制覇！ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：じゃ、そろそろ行くぞ。もういいだろ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあそう焦るなって。この塔の最上階にある展望台から下を眺めて来いっていうのが依頼なんだからさ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：あぁ！？ざけてんじゃねえぞ！ボス倒したら大体こういうのは終わりだろ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：国王からの勅令だぞ。それを無視してどうすんだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：グッ・・・そりゃまあ・・・まあ無視はできねえな・・・グッ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ビリーさん、怖いんですか？下を見るのが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ばっ、そんなわけねーだろーが！女子供は引っ込んでな！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、じゃあ私は怖いので、ビリーさんお願いします・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：なにーーーーーーー！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ビリーさん、私もちょっと高い所から見下ろすのは苦手なんで、お願いします♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：なにーーーーーーー！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そういうわけだ、ビリー。ここはもうお前しかいない。頼む！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おおおおおし、ま、ままままあ、任せておけば良いじゃねえかコラァ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：行ってやらぁ！見とけよ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ ビリーは塔の展望台まで突貫していった ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：おーい、どうだ？何かそこから見えるか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おーい、ビリー？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと、見に行った方が良いんじゃないの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだな。じゃ、俺が行ってくる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ アインは展望台へと向かっていった ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "～ １０分後 ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ビリー：よーーー、てめぇら！元気にしてたか！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あら、展望台は無事だったのね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：あぁ！？何の話か全然わかんねーな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いやいやいや、お前のその応答だと、意味分からなくなるだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そんな事より。展望台から下を見て何か見つけたんだろ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：お、おお。そうだった、忘れる所だったぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：皆、おれは展望台で驚くべき事象を見ちまったんだ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：良いか、聞いて驚くなかれよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お前のそのノリも意味不明だからな。普通に言った方が良いぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：良いじゃねえか、ちょっとぐらい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：まあその、なんだ。見ちまったんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：空には薄赤い星が出てるのをな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：そうなんですか？地上からではそういった事象は見受けられなかったですが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：おそらく、その薄赤いっていうのは本当に見分けが付きにくいレベルなんじゃないかしら？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：なに！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ ビリーは首を動かす事なく、刹那、アインへと視線を飛ばした ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "～ アイン、瞬間的なアイ・コンタクトでビリーへ応答を返した ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ビリー：あ、ああそうだ。天候次第な面もあるが良く見ないと分からないレベルだった。間違いないぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：凄いですね。さすがビリーさんです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おう。ザっとこんなもんだ", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；やるじゃねえか、ビリー。見直したぜ、本当助かったよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ヘッ、今回だけだからな。次はねえぞ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；分かった分かった。いやいやほんとサンキューな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；よし、じゃあこの結果を持って国王エルミに報告に戻るとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：待って。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；ん？どうかしたか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：この部屋の横。通路を見つけたわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；マジかよ？って事は。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ、おそらく初めの入口に戻れる仕組みになってるわよ。きっと。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；助かるぜ、戻る時はそれを使えばいいって事だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；よし、エオネ、ラナ、ビリー。みんなありがとう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おう！", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：は、はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうって事ないわよ♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン；じゃあ、ここは一旦戻って国王エルミに報告するとしよう！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_20 + " 】が完了しました！", ActionEvent.QuestComplete);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_11 + " 】が更新されました！", ActionEvent.QuestUpdate);
    }
  }

  public static void Message800120(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message800110 == false)
    {
      One.TF.Event_Message800110 = true;

      Message(ref m_list, ref e_list, "ビリー：おいちょって待て。そっちにもう用はねえだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、しかし気になる事がまだ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：もう良いんじゃないの？今回はもう特に用は無いでしょ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだな。ここは引き返すとするか", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);

    }
    else
    {
      Message(ref m_list, ref e_list, "ビリー：おい、そっちには行かねえ約束だろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：悪い悪い。じゃ、引き返すとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
    }
  }

  public static void MoveFloatingTile(ref List<string> m_list, ref List<ActionEvent> e_list, DungeonField.Direction direction, int num)
  {
    Message(ref m_list, ref e_list, "アイン：さてと、このタイルで移動するか。", ActionEvent.None);

    if (direction == DungeonField.Direction.Right)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveRight);
    }
    else if (direction == DungeonField.Direction.Left)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveLeft);
    }
    else if (direction == DungeonField.Direction.Top)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveTop);
    }
    else if (direction == DungeonField.Direction.Bottom)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveBottom);
    }

    if (num == 1)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 2)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 3)
    {
      for (int ii = 0; ii < 12; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 4)
    {
      for (int ii = 0; ii < 12; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 5)
    {
      for (int ii = 0; ii < 10; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 6)
    {
      for (int ii = 0; ii < 10; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 7)
    {
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 8)
    {
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 9)
    {
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 10)
    {
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 11)
    {
      for (int ii = 0; ii < 13; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 12)
    {
      for (int ii = 0; ii < 13; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 13)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 14)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 15)
    {
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 16)
    {
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 17)
    {
      for (int ii = 0; ii < 3; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 18)
    {
      for (int ii = 0; ii < 3; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 19)
    {
      for (int ii = 0; ii < 45; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 20)
    {
      for (int ii = 0; ii < 45; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 21)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 22)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 23)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 24)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 25)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 26)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 27)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 28)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 29)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 30)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 31)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 32)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 33)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 34)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 35)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 36)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 37)
    {
      for (int ii = 0; ii < 5; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 38)
    {
      for (int ii = 0; ii < 5; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 39)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 40)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 41)
    {
      for (int ii = 0; ii < 5; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 42)
    {
      for (int ii = 0; ii < 5; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 43)
    {
      for (int ii = 0; ii < 16; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 44)
    {
      for (int ii = 0; ii < 16; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 45)
    {
      for (int ii = 0; ii < 6; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 46)
    {
      for (int ii = 0; ii < 6; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 47)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 48)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 49)
    {
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 50)
    {
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 51)
    {
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 52)
    {
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 53)
    {
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 54)
    {
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 55)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRight);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 56)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjLeft);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 57)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 58)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 59)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 60)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 61)
    {
      for (int ii = 0; ii < 63; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjFall);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 62)
    {
      for (int ii = 0; ii < 63; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjRise);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 63)
    {
      for (int ii = 0; ii < 18; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjBottom);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 64)
    {
      for (int ii = 0; ii < 18; ii++)
      {
        Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveObjTop);
        Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
      }
    }

    Message(ref m_list, ref e_list, "（シュウウウゥゥン）", ActionEvent.None);

    if (num == 1)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 2)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 3)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 4)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 5)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 6)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 7)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 8)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 9)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 10)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 11)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 12)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 13)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 14)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 15)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 16)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 17)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 18)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 19)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 20)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 21)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 22)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 23)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 24)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 25)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 26)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 27)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 28)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 29)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 30)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 31)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 32)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 33)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 34)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 35)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 36)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 37)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 38)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 39)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 40)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 41)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 42)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 43)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 44)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 45)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 46)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 47)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 48)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 49)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 50)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 51)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 52)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 53)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 54)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 55)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 56)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 57)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 58)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }
    else if (num == 59)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 60)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveLeft);
    }
    else if (num == 61)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveBottom);
    }
    else if (num == 62)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 63)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveRight);
    }
    else if (num == 64)
    {
      Message(ref m_list, ref e_list, "0", ActionEvent.ForceMoveTop);
    }

    Message(ref m_list, ref e_list, "アイン：よし、行こう。", ActionEvent.None);
  }

  public static void MoveWarpHoleTile(ref List<string> m_list, ref List<ActionEvent> e_list, DungeonField.Direction direction, int num)
  {
    Message(ref m_list, ref e_list, "アイン：さてと、これでワープ移動するか。", ActionEvent.None);


    if (direction == DungeonField.Direction.Right)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveRight);
    }
    else if (direction == DungeonField.Direction.Left)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveLeft);
    }
    else if (direction == DungeonField.Direction.Top)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveTop);
    }
    else if (direction == DungeonField.Direction.Bottom)
    {
      Message(ref m_list, ref e_list, "0.5", ActionEvent.ForceMoveBottom);
    }

    Message(ref m_list, ref e_list, "", ActionEvent.HidePlayer);

    if (num == 1)
    {
      for (int ii = 0; ii < 13; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 2)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRise);
      }
      for (int ii = 0; ii < 13; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 3)
    {
      for (int ii = 0; ii < 13; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRise);
      }
    }
    else if (num == 4)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveFall);
      }
      for (int ii = 0; ii < 13; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 5)
    {
      for (int ii = 0; ii < 10; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
      for (int ii = 0; ii < 33; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 6)
    {
      for (int ii = 0; ii < 33; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
      for (int ii = 0; ii < 10; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 7)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRise);
      }
      for (int ii = 0; ii < 3; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 8)
    {
      for (int ii = 0; ii < 3; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveFall);
      }
    }
    else if (num == 9)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 10)
    {
      for (int ii = 0; ii < 10; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 11)
    {
      for (int ii = 0; ii < 6; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 18; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 12)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 13)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 14)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 15)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 14; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 16)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 18; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 17)
    {
      for (int ii = 0; ii < 10; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
      for (int ii = 0; ii < 9; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 18)
    {
      for (int ii = 0; ii < 10; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
    }
    else if (num == 19)
    {
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 20)
    {
      for (int ii = 0; ii < 18; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
      for (int ii = 0; ii < 6; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 21)
    {
      for (int ii = 0; ii < 18; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 22)
    {
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 5; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 23)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
      for (int ii = 0; ii < 4; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
    }
    else if (num == 24)
    {
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveRight);
      }
      for (int ii = 0; ii < 11; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveTop);
      }
    }
    else if (num == 25)
    {
      for (int ii = 0; ii < 5; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
      for (int ii = 0; ii < 7; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }
    else if (num == 26)
    {
      for (int ii = 0; ii < 2; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveBottom);
      }
      for (int ii = 0; ii < 8; ii++)
      {
        Message(ref m_list, ref e_list, "0.05", ActionEvent.ForceMoveLeft);
      }
    }

    Message(ref m_list, ref e_list, "", ActionEvent.VisiblePlayer);

    Message(ref m_list, ref e_list, "（シュワアアァァン）", ActionEvent.None);

    if (num == 1)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
    }
    else if (num == 2)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
    }
    else if (num == 3)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
    }
    else if (num == 4)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
    }
    else if (num == 5)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
    }
    else if (num == 6)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
    }
    else if (num == 7)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
    }
    else if (num == 8)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 9)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 10)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
    }
    else if (num == 11)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 12)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
    }
    else if (num == 13)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 14)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
    }
    else if (num == 15)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 16)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
    }
    else if (num == 17)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 18)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
    }
    else if (num == 19)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveLeft);
    }
    else if (num == 20)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 21)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
    }
    else if (num == 22)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
    }
    else if (num == 23)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveBottom);
    }
    else if (num == 24)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 25)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveTop);
    }
    else if (num == 26)
    {
      Message(ref m_list, ref e_list, "0.2", ActionEvent.ForceMoveRight);
    }

    Message(ref m_list, ref e_list, "アイン：よし、行こう。", ActionEvent.None);
  }
  #endregion

  #region "神秘の森"
  public static void Message900010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message900010 == false)
    {
      One.TF.Event_Message900010 = true;

      Message(ref m_list, ref e_list, "アイン：看板だな。ええと、なになに・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　辿るべき道筋はなし。印無き者は通さずが掟　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・なるほど。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：なるほどって、てめぇ何か分かったのかよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：もちろん、分からない。ただ、ある程度の雰囲気は掴んだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：雰囲気ってなによ。もうちょっと詳しく解説。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだなあ・・・何て言うんだろうな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：大概こういうのは壁を辿って行けば、大方網羅はできるだろ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ただし、この森はそれだけは進ませてくれない。って所だろうな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：後、印無き者と書いてあるが、これは進めていくうちに分かるレベルじゃないかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：入ってきた者はそのままの状態ではなく、何らかの経路を経て進む事を示しているんだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：今の時点ではわからない。ただし、気に留めておけばそれで十分。って事だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：って事だ。じゃねーよ、全然意味不明じゃねえか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：頭が痛くなってきたわ・・・やっぱり聞くんじゃなかったわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、まあ、看板は何度でも確認できる。気になったらまた見るとしよう！ッハッハッハ！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　辿るべき道筋はなし。印無き者は通さずが掟　』", ActionEvent.None);
    }
  }

  public static void Message900020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "33:1:-13", ActionEvent.JumpToLocation);

    if (One.TF.Event_Message900020 == false)
    {
      One.TF.Event_Message900020 = true;

      Message(ref m_list, ref e_list, "アイン：なっ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：今・・・突然景色が変わったわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おいアイン。大丈夫なんだろうな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：若干想定外だったが、まあ大丈夫さ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：この手の仕掛けは何度か搔い潜った事はある。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：気にせず、考えすぎず、注意しつつ、進めていこう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：わけわかんねぇ言い方だが、とにかく頼んだぜ！", ActionEvent.None);
    }
  }

  public static void Message900030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "5:1:-8", ActionEvent.JumpToLocation);
  }

  public static void Message900040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "15:1:-22", ActionEvent.JumpToLocation);
  }

  public static void Message900050(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message900030 == false)
    {
      One.TF.Event_Message900030 = true;

      Message(ref m_list, ref e_list, "アイン：看板だな。読んでみるか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　大自然を受諾し、森に選ばれし者のみ、過去と未来を繋ぐ権利が与えられる　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、オーケーオーケー！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：お前、ほんっと適当だよな。どこがオーケーなんだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：これは明らかに示唆を提示している。十分だろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ええと、すまない。解説だったな、よし。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おそらくだが、何らかをこの森から授かって、森の中を通れるようにならないといけないって事だろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：最初は結構迷うのかもしれないが、きっと潜り抜けられる方法がある。そんな感じだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、過去と未来を繋ぐ権利の前に、重要な要素として【最初の迷い方】そのものについてだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ハイハイ、ありがとう。バカアインの奇妙奇天烈な解説はその辺りで結構よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか、悪いな。ちょっと説明は難しいんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ともかく探索を続けよう。きっと抜けられる道があるはずだ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　大自然を受諾し、森に選ばれし者のみ、過去と未来を繋ぐ権利が与えられる　』", ActionEvent.None);
    }
  }

  public static void Message900060(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "5:1:-8", ActionEvent.JumpToLocation);
  }

  public static void Message900070(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "18:1:-6", ActionEvent.JumpToLocation);
  }

  public static void Message900080(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "1:1:-28", ActionEvent.JumpToLocation);
  }

  public static void Message900090(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "3:1:-28", ActionEvent.JumpToLocation);
  }

  public static void Message900100(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "5:1:-28", ActionEvent.JumpToLocation);
  }

  public static void Message900110(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "48:1:-1", ActionEvent.JumpToLocation);
  }

  public static void Message900120(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "46:1:-1", ActionEvent.JumpToLocation);
  }

  public static void Message900130(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "44:1:-1", ActionEvent.JumpToLocation);
  }

  public static void Message900140(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00001 == false)
    {
      One.TF.FieldObject_MysticForest_00001 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_1_O);
    }
  }

  public static void Message900150(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00004 == false)
    {
      One.TF.FieldObject_MysticForest_00004 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_4_O);
    }
  }

  public static void Message900160(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "13:1:-1", ActionEvent.JumpToLocation);
  }

  public static void Message900170(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "9:1:-3", ActionEvent.JumpToLocation);
  }

  public static void Message900180(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "2:1:-5", ActionEvent.JumpToLocation);
  }

  public static void Message900190(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "8:1:-5", ActionEvent.JumpToLocation);
  }

  public static void Message900200(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "5:1:-2", ActionEvent.JumpToLocation);
  }

  public static void Message900210(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00002 == false)
    {
      One.TF.FieldObject_MysticForest_00002 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_2_O);
    }
  }

  public static void Message900220(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "39:1:-13", ActionEvent.JumpToLocation);
  }

  public static void Message900230(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "43:1:-18", ActionEvent.JumpToLocation);
  }

  public static void Message900240(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "43:1:-8", ActionEvent.JumpToLocation);
  }

  public static void Message900250(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00003 == false)
    {
      One.TF.FieldObject_MysticForest_00003 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_3_O);
    }
  }

  public static void Message900260(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00005 == false)
    {
      One.TF.FieldObject_MysticForest_00005 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_5_O);
    }
  }

  public static void Message900270(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message900050 == false)
    {
      One.TF.Event_Message900050 = true;

      Message(ref m_list, ref e_list, "アイン：看板があるな。読むぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　うつろいを重ね、遠くを廻りて、祈願を果たす　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おいアイン。いつものテキトー理論で解説するんだろ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アイン、その場で微動だにせず目を細めた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：分からない、な。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：珍しいわね。そんな考えこむなんて。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ゴラトラム洞窟の時も少し違和感はあったんだが", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：この看板はより色が濃い。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：色が濃い？おい、何言ってんだ、意味わかんねーぞ。ある程度は解説しろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ある程度迷いながら進めて、祈願に相当する何かを会得するんだろうが", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：その祈願が、何を指しているのかがわからない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：エオネ、何か知らないか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：いいえ、何も。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか・・・・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：いつものノリで進めて行くと危ないっていう印象はあるのかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、それは無いな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：分かった。このまま進めよう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：気になったらちゃんと言ってちょうだいよ。バカアインの変な感覚は他の人は察知できないんだから。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、了解だ。", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　うつろいを重ね、遠くを廻りて、祈願を果たす　』", ActionEvent.None);
    }
  }

  public static void Message900280(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "9:1:-20", ActionEvent.JumpToLocation);
  }

  public static void Message900290(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "4:1:-15", ActionEvent.JumpToLocation);
  }

  public static void Message900300(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "35:1:-11", ActionEvent.JumpToLocation);
  }

  public static void Message900310(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "36:1:-5", ActionEvent.JumpToLocation);
  }

  public static void Message900320(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "32:1:-1", ActionEvent.JumpToLocation);
  }

  public static void Message900330(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "32:1:-5", ActionEvent.JumpToLocation);
  }

  public static void Message900340(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "28:1:-5", ActionEvent.JumpToLocation);
  }

  public static void Message900350(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "28:1:-1", ActionEvent.JumpToLocation);
  }

  public static void Message900360(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "24:1:-6", ActionEvent.JumpToLocation);
  }

  public static void Message900370(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "28:1:-6", ActionEvent.JumpToLocation);
  }

  public static void Message900380(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00011 == false)
    {
      One.TF.FieldObject_MysticForest_00011 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_11_O);
    }
  }

  public static void Message900390(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "24:1:-12", ActionEvent.JumpToLocation);
  }

  public static void Message900400(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "24:1:-8", ActionEvent.JumpToLocation);
  }

  public static void Message900410(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "16:1:-11", ActionEvent.JumpToLocation);
  }

  public static void Message900420(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "20:1:-11", ActionEvent.JumpToLocation);
  }

  public static void Message900430(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "33:1:-7", ActionEvent.JumpToLocation);
  }


  public static void Message900440(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message900060 == false)
    {
      One.TF.Event_Message900060 = true;

      Message(ref m_list, ref e_list, "ビリー：おおぉ！これってアレじゃねえのかよ！　アイン！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：祈願の御札・・・か。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：それを持っていれば、また何かに使えそうね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：んだよ、あんま嬉しそうじゃねえな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、そういう訳じゃねえ。このお宝は貴重なアイテムだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ早速このアイテムが使えそうな場所を・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ちょっと良いかしら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アンタらしくないわよ。いつもの意味不明な内容はどこに行ったのよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：バカアインはいつも通りしゃべってた方が普通よ。ちゃんと言いなさいよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ラナさん、それはちょっと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いやいや、悪い悪い。確かにそうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、改めまして・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・（ッ）", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：エオネさん、笑っちゃだめよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：す、すみません・・・（ッ）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：" + Fix.KIGAN_OFUDA + "は使える。それは間違いじゃないんだが", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：例の看板にあった祈願とキーワードの合致はあるんだが", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：その事を指しているのかどうか、どうにも合致しない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どういう意味よ？", ActionEvent.None);

      if (One.TF.Event_Message600120)
      {
        Message(ref m_list, ref e_list, "アイン：ゴラトラム洞窟で、こんな看板があっただろ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　満たされるは精神と英知。語り継ぎし者よ、安らぎと平穏を。 ～", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ビリー。覚えてるだろ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：俺はその洞窟に行ってねーよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：そうなのか。まあ、あったんだよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：で、この看板も同じ感覚が湧いてくるんだよ。", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：ゴラトラム洞窟をきちんと覚えてないんだが、", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：悪いエオネ。覚えてるか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：・・・ええ。内容はこうですね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "～　満たされるは精神と英知。語り継ぎし者よ、安らぎと平穏を。 ～", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ビリー。お前も思い出したか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：俺はその洞窟に一緒には行ってねーよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ハハハ、そういやそうだった。悪い。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：で、この看板からは同じ感覚が湧いてくるんだよ。", ActionEvent.None);
      }

      Message(ref m_list, ref e_list, "アイン：【詩】っていば良いのかな。上手くいえないんだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・（ッ！）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何かの一節に感じないか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：一節と言われてもね。ピンと来るものはないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：キーワード的な何かを指し示すようなものでは無い気がするんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：" + Fix.KIGAN_OFUDA + "は、実際この神秘の森を通過するための要素ではあるだろうが、", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：すまねえ、ちょっとこれ以上は上手く言えない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ほんと、サッパリ分からないわね。", ActionEvent.None);
      // 満たされるは精神と英知。語り継ぎし者よ、安らぎと平穏を。
      // うつろいを重ね、遠くを廻りて、祈願を果たす // todo

      Message(ref m_list, ref e_list, "アイン：まあ、そんな所だ。結局の所、進めるしかないかもな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何か変な所で気づいたらまた言ってよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、分かった。", ActionEvent.None);
    }
  }

  public static void Message900450(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message900070 == false)
    {
      One.TF.Event_Message900070 = true;

      Message(ref m_list, ref e_list, "アイン：看板だな。ええと、どれどれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "『　資格なき者、進むこと叶わず、立ち去るのみ　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：何かと必要な物が無いと、通してくれそうなさそうだな。。。", ActionEvent.None);

      if (One.TF.FindBackPackItem(Fix.KIGAN_OFUDA))
      {
        Message(ref m_list, ref e_list, "ビリー：例の御札を持ってんだろ？行ってみよーぜ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ。", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "ラナ：特に該当しそうなアイテムは入手してないわよね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ、これは進んでも無駄かも知れないな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ここは一旦置いといて、他を当たってみよう。", ActionEvent.None);
      }
    }
    else
    {
      Message(ref m_list, ref e_list, "『　資格なき者、進むこと叶わず、立ち去るのみ　』", ActionEvent.None);
    }
  }

  public static void Message900460(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "29:1:-21", ActionEvent.JumpToLocation);
  }

  public static void Message900470(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "30:1:-16", ActionEvent.JumpToLocation);
  }

  public static void Message900480(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "27:1:-21", ActionEvent.JumpToLocation);
  }

  public static void Message900490(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "26:1:-18", ActionEvent.JumpToLocation);
  }

  public static void Message900500(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message900080 == false)
    {
      One.TF.Event_Message900080 = true;

      Message(ref m_list, ref e_list, "アイン：なっ！これは！", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　突如、森の奥底から激しい突風がアイン達を襲い始めた！　～", ActionEvent.MessageDisplay);

      if (One.TF.FindBackPackItem(Fix.KIGAN_OFUDA) == false)
      {
        Message(ref m_list, ref e_list, "アイン：うわ！！やべ！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);

        Message(ref m_list, ref e_list, "アイン：みんな、大丈夫か？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：ああ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：私も平気よ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：大丈夫です。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：これは駄目だな。あんな突風の中、強引に進む事は出来ない。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ちょっと他を探索してみよう。きっと何かあるはずだ。", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：ッグ・・・！", ActionEvent.None);

        Message(ref m_list, ref e_list, "　～　その時、アインの手元にある" + Fix.KIGAN_OFUDA + "が光り始めた！　～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "アイン：こ、これは・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：みんな、大丈夫か？吹き飛ばされてないか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：お、お、おうよ。何とかな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：驚いたわね、大丈夫よ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：これは・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：どうやらこの御札が効いたみたいだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "　～　数秒後、激しい突風は次第に勢いが弱くなり、そよ風に変わり始めた　～", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "アイン：よし、無事突破できたみたいだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：その御札の中に何かカラクリがあるのかも知れないわね。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ、ちょっと内容は見ない事にするが、ココを通るときは持っておかないとな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：よく分かんねえが行けたって事だな！このままガンガン行こうぜ！", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：オーケー、進めるとしよう。", ActionEvent.None);
      }
    }
    else
    {
      Message(ref m_list, ref e_list, "　～　突如、森の奥底から激しい突風がアイン達を襲い始めた！　～", ActionEvent.None);

      if (One.TF.FindBackPackItem(Fix.KIGAN_OFUDA) == false)
      {
        Message(ref m_list, ref e_list, "アイン：クッ！！", ActionEvent.None);

        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);
        Message(ref m_list, ref e_list, "1", ActionEvent.MoveTop);

        Message(ref m_list, ref e_list, "アイン：このままじゃ駄目だな。他を探索しよう。きっと何かあるはずだ。", ActionEvent.None);
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：ッグ・・・確かこれだったな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "　～　アインは光り輝く" + Fix.KIGAN_OFUDA + "をかざした！　～", ActionEvent.None);

        Message(ref m_list, ref e_list, "　～　数秒後、激しい突風は次第に勢いが弱くなり、そよ風に変わり始めた　～", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：よし、行こう。", ActionEvent.None);
      }
    }
  }

  public static void Message900510(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "23:1:-28", ActionEvent.JumpToLocation);
  }

  public static void Message900520(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "23:1:-24", ActionEvent.JumpToLocation);
  }

  public static void Message900530(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "27:1:-26", ActionEvent.JumpToLocation);
  }

  public static void Message900540(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "23:1:-26", ActionEvent.JumpToLocation);
  }

  public static void Message900550(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "35:1:-24", ActionEvent.JumpToLocation);
  }

  public static void Message900560(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "31:1:-24", ActionEvent.JumpToLocation);
  }

  public static void Message900570(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "33:1:-28", ActionEvent.JumpToLocation);
  }

  public static void Message900580(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "33:1:-24", ActionEvent.JumpToLocation);
  }

  public static void Message900590(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "38:1:-26", ActionEvent.JumpToLocation);
  }

  public static void Message900600(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00006 == false)
    {
      One.TF.FieldObject_MysticForest_00006 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_6_O);
    }
  }

  public static void Message900610(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "31:1:-28", ActionEvent.JumpToLocation);
  }

  public static void Message900620(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00007 == false)
    {
      One.TF.FieldObject_MysticForest_00007 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_7_O);
    }
  }

  public static void Message900630(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00008 == false)
    {
      One.TF.FieldObject_MysticForest_00008 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_8_O);
    }
  }

  public static void Message900640(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00009 == false)
    {
      One.TF.FieldObject_MysticForest_00009 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_9_O);
    }
  }

  public static void Message900650(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00010 == false)
    {
      One.TF.FieldObject_MysticForest_00010 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_10_O);
    }
  }

  public static void Message900660(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "46:1:-15", ActionEvent.JumpToLocation);
  }

  public static void Message900670(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "41:1:-17", ActionEvent.JumpToLocation);
  }

  public static void Message900680(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "40:1:-11", ActionEvent.JumpToLocation);
  }

  public static void Message900690(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "46:1:-9", ActionEvent.JumpToLocation);
  }

  public static void Message900700(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.FieldObject_MysticForest_00012 == false)
    {
      One.TF.FieldObject_MysticForest_00012 = true;

      UpdateBrushwood(ref m_list, ref e_list, Fix.MYSTICFOREST_BRUSHWOOD_12_O);
    }
  }

  public static void Message900710(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "18:1:-16", ActionEvent.JumpToLocation);
  }

  private static void UpdateBrushwood(ref List<string> m_list, ref List<ActionEvent> e_list, string identity)
  {
    if (One.TF.Event_Message900040 == false)
    {
      One.TF.Event_Message900040 = true;

      Message(ref m_list, ref e_list, "アイン：おっ、この茂み・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：・・・っ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうかしたの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、何か不意に動いた気がしたが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：気のせいじゃねえのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ひょっとして、これか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは" + Fix.KODAIEIJU_EDA + "を茂みに向かってかざした　～", ActionEvent.None);

      Message(ref m_list, ref e_list, "　（ザ・・・ッザザザァァァ）", ActionEvent.None);

      Message(ref m_list, ref e_list, identity, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "アイン：おっしゃ！開けたぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：驚いたわ。まさかその枝で開くなんて。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、俺も分かっていたわけじゃないからな。正直な所、偶然だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おめーの偶然はいつもインチキＬＶだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあまあ、見つかってよかったじゃないか、ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そのテキトーさが当たるって所がバカアインの特徴よね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあこれで進めるようになったんだ。次へ行こう！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：おっ、例の茂みだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：じゃあ、頼んだわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは" + Fix.KODAIEIJU_EDA + "を茂みに向かってかざした　～", ActionEvent.None);

      Message(ref m_list, ref e_list, "　（ザ・・・ッザザザァァァ）", ActionEvent.None);

      Message(ref m_list, ref e_list, identity, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "アイン：よし、行こう！", ActionEvent.None);
    }
  }


  public static void Message900720(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message900090 == false)
    {
      One.TF.Event_Message900090 = true;
      One.TF.AvailableSecondEssence = true;

      Message(ref m_list, ref e_list, "アイン：こ、この石は！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アイン・ウォーレンスはその場で静止し、石へ手をかざし始めた　】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：ッグ・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "", ActionEvent.TurnToBlack);

      Message(ref m_list, ref e_list, "　　（　確かに、許容される事象の境界というのは概念で形成化でき得るものでは無い。　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　いや、その考え方自体を問われていた。　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　誰から？　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　存在に頼った訳じゃないが　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　認識に対する根源を追及したい気持ちが強かったんだと思う　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　その時、無限に連なっている認識の外側からどこからともなく　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "　　（　その石に、再び、触れた　）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：石に触れし者よ", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：少年よ", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：繰り返すは永遠に続く未来への記憶", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：未来への・・・記憶・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：我は概念の領域に属さぬ者", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ヒトの子は我を支配竜と呼ぶ", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：支配竜よ。応えてくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：彼ら、彼女らはどうなったんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：在るがままである", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：死んではいない。そういう事か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：意味をなす理にあらず", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：少年が欲する概念に対し我が発するは事象の在り方のみ", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：その連鎖は少年が記憶する過去現在未来に依存せず", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：在るがままである", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか・・・・・・・・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：頼む。もう１つだけ応えてくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：国王は俺にとってどういう存在なんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：少年と国王は遥か未来にて既に接触が刻まれている", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：接触は一つの連鎖と成す", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：少年が戻りしは未来への回帰", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：未来への・・・回帰・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "支配竜：行くがよい", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.MYSTICFOREST_ObsidianPortal_1_O, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "【 アイン・ウォーレンス　ObsidianStoneを取得 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "【 パーティ全員　エッセンス・ツリー＜第二属性＞を習得 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "", ActionEvent.ReturnToNormal);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：はいはい、ボーっと突っ立ってるのもそこまでよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：今度もやたらと冷や汗をかいてるわね。どうしたのよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いやあぁ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、まあ何かが起きてるんだよ。ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：さすがに意味不明過ぎるだろ。ヤキが回ったか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょっとな、どうしても納得が行かない観点があってだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、まさかのひょっとしてだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アインは、何かを掴むような仕草で手のひらを上に向けて少し拡げて見せた 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：無いんだよな、これが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうみても何もないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：アインさんとしては、何かに接触された様な感覚があったんでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 アインは自分の手元に目をやり、同時に、視線を全体へと向けた 】", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：だが、証明するどころか痕跡一つすらない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：完全に不確定な出来事だ。こればかりは表現できない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：てめぇが何かその中央付近にフラフラと行ったのは確かだぜ。俺達はここで見てたしな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうなのか・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：この神秘の森であんたにだけしか感じられない何かがあったのかしらね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：正直な所、分からないけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：うん。この件についてはすまない。忘れてくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：皆、この一件は保留だ。次の探索へ行くとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：別に行くのは良いけど、どこかで突然ぶっ倒れたりしないでよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、大丈夫だ。行こう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　各キャラクターのエッセンス・ツリー＜第二属性＞が開放されました。", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "　キャラクターのエッセンス・ツリーを開いて確認してみましょう。 ", ActionEvent.MessageDisplay);

    }
  }

  public static void Message900730(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.DefeatFlansisQueenOfVerdant == false)
    {
      if (One.TF.Event_Message900100 == false)
      {
        One.TF.Event_Message900100 = true;

        Message(ref m_list, ref e_list, "アイン：まあ・・・居るか・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アインはその先にある広間に視線を向けた", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "1", ActionEvent.UpdateUnknownTile);

        Message(ref m_list, ref e_list, "？？？・・・（コオオォォォ）・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：あいつ、ボスっぽいな。ビンゴか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ、間違いないな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：勝算はあるわけ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ああ、あるな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：作戦としては、まずビリー。お前が突貫してくれ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：マジかよ。まあ、良いけどな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：その後、すぐラッシュで攻勢にしてくれ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：マジかよ。まあ、やって出来なくはねえけどな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あとは頼んだぜ、ビリー。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：おうよ、任せておけ！", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：ちょっと待って。戦術が構築されてないわよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：うっ・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：すまん・・・ええとだな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ビリー、最初の前線構築はお前に頼んだと言っている。文字通り突貫して攻勢の局面を作ってほしい。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：おっ、おうよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ただし一人に任せるわけじゃない。その後の防衛ライン構築、戦線維持は当然俺もやる。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ただし、どうしてもこの手のボスは特殊系能力を使ってくる感じはする。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：そうなると前線崩壊は逃れない。そこでだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：いざという時の支援系や魔法攻撃などは、エオネとラナに頼りたい。行けるか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：任せてちょうだい。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：あと、特にちょっと気になるのが、あれだ。あのボスだが・・・", ActionEvent.None);
        
        Message(ref m_list, ref e_list, "アイン：あの異常な槍の形状をしている箇所があるだろう。あれだけは絶対に気を付けた方が良い。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：気を付けるったって、実際どうすんだよ？", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：避ける、か、防御・・・いや", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：防御じゃすまないかもな・・・どうかな。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：おいおい、マジかよ。食らったらシャレになんねーって話か。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：端的に言うと、そうだ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：エオネ。その弓で何とか対応できそうか？", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：・・・っ・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：ちょ、ちょっと。意味不明な事をエオネさんに投げかけないでよ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：わ、悪かった。ハハハ・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：よし、じゃあ。攻め込むとしますか！", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：１．基本通りの戦局形成で行こう。下手に崩さなくて良い。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：２．敵の戦略めいた動きはある程度察知して対策戦術を出す事。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：３．あとはあのヤバい槍の形状には最大限の警戒を怠らない事。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ビリー：おう！", ActionEvent.None);

        Message(ref m_list, ref e_list, "ラナ：了解よ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "エオネ：はい", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：っしゃ、行くぜ！", ActionEvent.None);
      }
    }
  }

  public static void Message900740(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.DefeatFlansisQueenOfVerdant == false)
    {
      Message(ref m_list, ref e_list, "？？？：コオオォォ・・・ォォァアアアア！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ビリー、ラナ、エオネ。準備はいいか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：いつでも良いわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：っしゃ、来いや！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあ、行くぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.FLANSIS_OF_THE_FOREST_QUEEN, ActionEvent.EncountBoss);
    }
  }

  public static void Message900750(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.DefeatFlansisQueenOfVerdant && One.TF.Event_Message900110 == false)
    {
      One.TF.Event_Message900110 = true;

      Message(ref m_list, ref e_list, "フランシス：コッ・・・コッ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ど、どうだ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "フランシス：ッコオオォォォ・・・　ォォォォォ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "フランシス：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ようやく倒せたみたいね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あの槍は本当ヤバかったな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：皆のおかげだ、助かったぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：しっかし、どんな素材で出来てたんだ、この槍よぉ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：今触れてみましたが、それほど硬度の高い素材ではないようですね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：え・・・触れてんのか？や、やばくね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：大丈夫ですよ、ほら。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネはフランシスの槍の箇所をビリーに突きつけて見せた。", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ビリー：うぁ・・・分かったって、そんなこっち向けんな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、それはしばらく凝視したくは無いわな・・・ハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：さて、じゃあここを抜けるとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええっと、ここを抜けた先はツァルマンの里に出るみたいね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・な、何？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ツァルマンの里よ。知らないの？一般的な伝承話として伝わっている話よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：知らないな。何だ、これを抜けると何かの里に出るって事なのか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ホンット、そういう所は知らないままで行動指針決めてるのね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ビ、ビリー！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：オルガウェイン傭兵訓練施設で普通に習っただろが。そこ覚えてねえのは、ある意味スゲーぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ええと、エオネさんも・・・？", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：スミマセンが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや悪かった。次からはもう少し行き先を確認してから物事を決めるとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そうしてちょうだい。これで上手く進んでる事自体が驚きよホント。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあそのツァルマンの里やらに赴いて一休憩入れるとするか！", ActionEvent.None);
    }
  }
  #endregion

  #region "ヴェルガスの海底神殿"
  public static void Message1000010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "アーケンダインの街"
  public static void Message1100010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1100010 == false)
    {
      One.TF.Event_Message1100010 = true;

      Message(ref m_list, ref e_list, "アイン：よし、アーケンダイン街に着いたみたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ここも結構にぎわってるわね。あちこちにお店があるわよ♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：あ、すみません。みなさん・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：私、どうしても寄りたい所があるので行ってきても良いでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：お、おお。俺は別に構わないぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ビリー、お前もどっか行っていいぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：なんで俺に振ってんだよ。俺は別にどっか行きてーわけじゃねぇ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ッハッハッハ、冗談だよ。気にするなって。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：では・・・すみませんが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、またな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ エオネ・フルネアはパーティを一旦離脱しました ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：・・・本当に行っちゃったわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：良いの？アイン。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし。じゃあ、国王から受けていた依頼をこなしますか！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：依頼って何だ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：聞き込みだよ。アーケンダイン街で色々と情報収集してくれって言われている。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：何を聞き出すんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そりゃあ、色々な事だよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：てめぇ、もう少し説明しろっつうの。適当すぎるだろ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そこのバカには何を言っても無駄よ。まともに相手すると疲れるだけよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：マジっすか・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：い、いや悪かった。まあ簡単に解説しておくとあれだよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：オーランの塔で見た件と、ツァルマンの里で強引に足止めを食らってしまった件なんだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや、その前にアーサリウム工場跡地で見つけたアイテムも気になってる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ていうか、最初にラナが受けもらっていた剣も知る必要が・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：わ、分かった。てめぇに聞いた俺が悪かった。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、そういう事だ。まずは何はともあれ情報収集をしよう！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_21 + " 】が更新されました！", ActionEvent.QuestUpdate);
    }
  }

  public static void Message1100011(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：いや、このアーケンダイン街をもう少し探索を続けよう。", ActionEvent.None);

  }

  public static void Message1100020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1100020 == false)
    {
      One.TF.Event_Message1100020 = true;

      Message(ref m_list, ref e_list, "アイン：おおー、ここはまた大きい広場に出たな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あ♪　大きい噴水があるわね♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：人もそれなりに結構いるんだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、色んな人が行き来している場所。ラナ、聞き込みとは得意か？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：私はそういうのはちょっと不得手ね。初対面の人とはあまり上手く話せないわ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあビリー！聞き込みの方は頼んだ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：マジかよ。で、何聞いてくんだよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ひとまずは妙な伝説とか、あまり聞かない噂話とかをあたってくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：初対面にそんなワケわかんねー内容聞けるかよ。もうちっと具体的に言え。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだなあ・・・じゃあ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ツァルマンの里に行った事が人を探してきてくれないか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ちょ待てよ。今、ツァルマンの里っつったか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、そうだ。俺の読み通りなら、おそらく少しは居るはずだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：頼んだぜ。ビリー。お前はここぞという時、本当に頼りになる！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おぉ！任せとけっつんだ！じゃ行ってくるぞ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "～ しばらくして ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ビリー：っしゃ！聞いてきたぜ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おー！サンキューサンキュー！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：しかし、ツァルマンの里に行った事はあると言っても、だいぶ昔の話らしいぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、別に良いんだ。で、どんな事を言ってた？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：そうだな。昔は交易も少々あって特産品の売買をやってたらしいぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：交易のルートは？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：そりゃあ当然ファージル国を通って、港町コチューシェに寄ってから山登りで決まりだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そう言ってたのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ああ、そうだな。ファージル国王には感謝の意が絶えないとか何とか言ってたぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：あ、そういやもう１個重要な事言ってたぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どんな内容だ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ツァルマンの里には、「神秘の森」っていう不可侵なエリアがあるらしいぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：「神秘の森」・・・か・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：まあウワサ程度の話らしいけどな。本人も直接入って見たわけじゃねえって言ってたぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なるほど、そうかそうか。いや、サンキューな！　助かったぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：マジ助かってんのか？ま、別に良いけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：【神秘の森】か・・・今はこのエリアの探索が先だが、後でツァルマンの里にもう一度赴いても良いかもな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：俺はいつでも行けるぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハハハ、ありがとな。じゃあ【神秘の森】も行く計画ぐらいは立てておくか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おうよ！頼んだぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_22 + " 】が開始されました！", ActionEvent.GetNewQuest);

    }
  }
  public static void Message1100030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1100030 == false)
    {
      One.TF.Event_Message1100030 = true;

      Message(ref m_list, ref e_list, "アイン：ワッツの民芸品店・・・", ActionEvent.None);
      
      Message(ref m_list, ref e_list, "アイン：ラナ、お前こういう場所だったら聞き込み行けるんじゃねえのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：て、あれ？どこ行ったんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：もうその店ん中に入っちまったぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうか。やる気十分って所だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：じゃあちょっと雰囲気見てくる。ビリー、ここで待っててくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おうよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アインがワッツの民芸品店に入った途端・・・　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：キャーーーーーー！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っな！！　だ、大丈夫か！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：見てこれ！！すごい可愛いわ♪♪♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あ、これも良いわね♪　あれもこれも素敵な物ばかりね♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ねえ、アイン。これも良いと思わない？ちっちゃくて可愛いし♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっ、おぉ。まあそうだな、ッハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "店員：ようこそいらっしゃいました。どうぞ、ゆっくりと店内をご覧ください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ねえ店員さん。このアクセサリーの他に、一体どういった物があるの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "店員：オススメ商品ですね、どうぞこちらへ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ありがと♪こっちも見てみるわ♪", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　ラナは店員と共に店の奥へと消えていった・・・ ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（なるほど、どうやらあの様子だと「聞き込み」では無さそうだな）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（かと言って俺がこの店内で聞き込むとかなり違和感があるしな・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（ふう。ちょうどここが裏口か。一旦外に出てみるか・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　店の裏口にて ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：（さてと、どうすっかな・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ハイ。全ては手筈通りです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（ん？　壁の向こうから何か声が聞こえる・・・誰だ？）", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：手筈通りと申したな。それだけかね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：す！すみません！", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：エオネ・フルネア。期待値通りの結果を保持し、それを報告するのみ。それでは貴君を遣わした意味が無いだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ッハ・・・ハイ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（ま、まさかこの声・・・エオネか？）", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：分かっておるな。狙いは。", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ハイ。目的の・・・物は・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：待て。その名称を口にしてはならん。もう少しこちらへ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：（・・・　で・・・）　（・・・それ　・・　に　・・・ついては・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（ん？何だ、聞き取りにくくなったぞ）", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：（・・・　ではなく・・・）　（・・・あれに・・・）　（・・・とはいえ・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：（・・・　と考えた所・・・）　（・・・となる様に　・・・　） （・・・　・・・のシナリオで・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：（・・・　が良いだろう・・・）　（・・・パルメテイシア神殿・・・）　（では・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "エオネ：ハイ、分かりました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：ふむ。では行くがよい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（どうやら会話は終わったようだな）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（重要な部分が今一つ聞こえなかったが・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（パルメティシア神殿。そこだけは聞き取れたな。）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（さてと・・・どうしたものか・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（エオネ・・・お前一体・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：あら、バカアイン。そんなところにいたのね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おい、ボケアイン。てめ聞いてんのかよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（・・・　・・・　・・・）", ActionEvent.None);

      Message(ref m_list, ref e_list, "『ズドゴシッシャアアァァァ！！！』（ラナのアブソリュート・ストライクがアインに炸裂）", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_24 + " 】が開始されました！", ActionEvent.GetNewQuest);

    }
  }
  public static void Message1100040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1100040 == false)
    {
      One.TF.Event_Message1100040 = true;
      Message(ref m_list, ref e_list, "アイン：こんちわー。", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：あら・・・いらっしゃい・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょっと占ってもらえますかね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：何を・・・占って欲しいのかしら・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：えっ・・・じゃ、どれにしようかな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：迷ってる・・・ようですわね・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あっ・・・まあ・・・はい・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：では・・・そのまま・・・で・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：え、ええ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　占い師はスっと目を閉じた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "占い師：・・・いきます・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：お告げが・・・出ました・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ど・・・どうでしょうか・・・？", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：探し人・・・見つからず・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：探すべき物・・・神より隠されたまま・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：隠されしは・・・悠久なる古代への・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：物語・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：です", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：な・・・なるほど・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：つまり・・・・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー（外からの声）：おいアイン！！なげーぞコラァ！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ゲッ、うるさ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：他に・・・何か・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、じゃあ１件だけ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：空に赤い星が見えているだろ。あれについて何か知らないか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：良いでしょう。合格です。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：え？", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：あなたにはこれを差し上げましょう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "【 " + Fix.MARBLE_STAR + " 】を獲得しました！", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, Fix.MARBLE_STAR, ActionEvent.GetItem);

      Message(ref m_list, ref e_list, "アイン：こ、これは？", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：それを持って、サリタンの地を訪れると良いでしょう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "占い師：では・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、どうも。じゃあ失礼いたします。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アインは占いの館から外に出た　～　", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ビリー：よお！すげー長かったみたいだが、どうだったよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：占ってもらった。面白かったぜ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そうじゃないでしょ。で、何か収穫はあったわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：もちろんだ。これを見てみろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：で・・・それは何なわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：" + Fix.MARBLE_STAR + "だよ。どうだ、良いものもらっただろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：使い道はちゃんと教えてもらえたわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：【サリタンの地】に行けとは伝えられたぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：【サリタンの地】ねえ・・・あまり詳しくないんだけど、場所は分かってるの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあまあ・・・これはこれで・・・ハハハ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：情報収集しに行ったのに、またワケわかんない話増やしてどーすんのよ、まったく・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：大丈夫だって。ま、そのうち見つかるさ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：ボケアイン。てめぇ、ともかくキッチリ解決していけよ。分かってんだろうな？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：分かった分かったって。任せておけって。ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_23 + " 】が開始されました！", ActionEvent.GetNewQuest);
    }
  }

  public static void Message1100050(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1100050 == false)
    {
      One.TF.Event_Message1100050 = true;

      Message(ref m_list, ref e_list, "アイン：よし、大体一通り回ってって所だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：で、これからどうするのよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、好きなように進んでみるさ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：いやそうじゃねえだろ。目星ぐらい付いてんだろって話してんだろ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハハハ、悪い悪い。ええとだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まず第一候補は、例のマーブル・スターが何なのかを探る事だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：占い屋でもらってきたやつか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：他に候補は？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：第二候補はツァルマンの里に赴いて、【秘境の森】の調査だな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：で、あと残るは・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：えっ、まだ何かあるわけ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、ああ。そうか言ってなかったな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：黙っていたが・・・第三候補は、パルメティシア神殿だ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、場所についてはこれからだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：パルメティシア神殿の事ね。それなら、ここから少し北に行けばあるみたいよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なに、マジかよ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おお。その神殿なら俺も知ってるぜ。結構有名だしな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ビリー！お前も知ってたのか！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：お前こそ、むしろ知らなかったのが驚きだぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうだったのか・・・俺はてっきり重要な秘密情報を聞いた気がしたんだが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何よそれ。アンタ何か聞いたワケ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：い、いやいや。単にすれ違いで聞いただけさ。ッハッハッハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：まあ良いけど。じゃ、どうするの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、特に決め事は無しだ。行きたい方に行こうぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：相変わらずテキトーよね。じゃあ基本は任せるからちゃんと行動してよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おっしゃ、任せとけ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "", ActionEvent.ViewQuestDisplay);
    }
  }
  #endregion

  #region "廃墟サリタン"
  public static void Message1200010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1200010 == false)
    {
      One.TF.Event_Message1200010 = true;
      Message(ref m_list, ref e_list, "アイン：着いたな。ここが・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：そう、サリタンの町よ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：町って言うか、まるで廃墟みたいだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：この町は過去の大災厄により見捨てられた土地なの。今は誰も住んでいないわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうなのか・・・結構建物自体は残ってるのにな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・ん？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どうしたのよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：今は誰も住んでない。そう言ったか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ええ、ここに住んでいる人はもう居ないはずよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　アイン、真剣な目つきで、とある建物の裏影に視線を映した　～　", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：・・・間違いないぜ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ウソ。誰か居るって事？", ActionEvent.None);

      Message(ref m_list, ref e_list, "　～　しばらくして　～　", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "？？？：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：クッ、ククク。しょうがあるまい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：とりあえず姿を見せてくれ。敵じゃなければ尚更だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：クク、まあ良いだろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：俺の名はセルモイ・ロウ。ひとまず貴様の敵ではないと言っておこう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：俺はアイン・ウォーレンスだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：アイン・・・か。幾度なく聞いた事のある名だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：ここに、何をしに来た？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：（アイン、あんたさっきからどうしたのよ。言葉が詰まってるだけど？）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：（ラナ、下がってろ。こいつは色々と要注意だ）", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：（ふーん、そうなの。まあ、分かったわ）", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：仲間だ。仲間を探しにここに来ている。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：ほう・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：港町コチューシェで行方不明になった者を探している。ここに誰か来なかったか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：知らんな。知っていたとしても教える事はない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：話を変える。ここの地形にお前は詳しいのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：意図が読めんな。答える義理はない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：率直に頼みたい事がある。", ActionEvent.None);
      
      Message(ref m_list, ref e_list, "アイン：このサリタンの町を探索したい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：付き合ってもらえないか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：クッ、クククク・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：ハハハハハ！", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：初対面でよく言えたものだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：面白いやつとは聞いていたが、想像以上だ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：良いだろう。同行してやる。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：ただし、条件がある。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なんだ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：金をよこせ。それだけだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いくら必要だ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：50000Gで良い。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ロウ：その後の追加要求は決して行わない事を約束する。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.DECISION_PARTY_JOIN_SELMOI_RO, ActionEvent.CallDecision);
    }
  }

  public static void Message1200011(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.AvailableSelmoiRo == false)
    {
      if (One.TF.Gold >= 50000)
      {
        One.TF.Gold -= 50000;
        One.TF.AvailableSelmoiRo = true;

        Message(ref m_list, ref e_list, "アイン：50000Gだ。受け取ってくれ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ロウ：確かに受け取った。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：ありがとう。じゃあサリタンの町を今から探索するから、何か発見できる事があったら教えてくれ。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ロウ：よかろう。", ActionEvent.None);

        Message(ref m_list, ref e_list, " 【" + Fix.NAME_SELMOI_RO + "】が仲間になりました！", ActionEvent.MessageDisplay);

        Message(ref m_list, ref e_list, "", ActionEvent.RefreshAllView);
      }
      else
      {
        Message(ref m_list, ref e_list, "アイン：あれ・・・", ActionEvent.None);

        Message(ref m_list, ref e_list, "ロウ：どうした。", ActionEvent.None);

        Message(ref m_list, ref e_list, "アイン：いや、なんでもない。", ActionEvent.None);

        Message(ref m_list, ref e_list, "ロウ：50000G持ってこい。でなければ、去れ。", ActionEvent.None);
      }
    }
  }

  public static void Message1200012(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：すまねえ。今は金を準備できていないんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ロウ：金次第だ。去れ。", ActionEvent.None);
  }

  public static void Message1200013(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：セルモイ・ロウ。頼みたい事がある。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ロウ：なんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.DECISION_PARTY_JOIN_SELMOI_RO, ActionEvent.CallDecision);
  }
  #endregion

  #region "離島ウォズム"
  public static void Message1300010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "ダルの門"
  public static void Message1400010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1400010 == false)
    {
      One.TF.Event_Message1400010 = true;
      One.TF.Fieldobject_GateDhal_00001 = true;

      Message(ref m_list, ref e_list, "アイン：よし、扉発見っと。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：特に仕掛けはなさそうよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ早速開けるとしますか！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【ギッギッギギィィ・・・】", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.EVENT_GATEDHAL_1, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "【ッバン！】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ探索開始だ！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：駄目だ。開かないな。", ActionEvent.None);
    }
  }

  public static void Message1400020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1400020 == false)
    {
      One.TF.Event_Message1400020 = true;
      One.TF.Fieldobject_GateDhal_00002 = true;

      Message(ref m_list, ref e_list, "アイン：よし、扉発見っと。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：特に仕掛けはなさそうよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ早速開けるとしますか！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【ギッギッギギィィ・・・】", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.EVENT_GATEDHAL_2, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "【ッバン！】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ探索開始だ！", ActionEvent.None);
    }
  }

  public static void Message1400030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message1400030 == false)
    {
      One.TF.Event_Message1400030 = true;
      One.TF.Fieldobject_GateDhal_00003 = true;

      Message(ref m_list, ref e_list, "アイン：よし、扉発見っと。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：特に仕掛けはなさそうよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っしゃ、じゃあ早速開けるとしますか！", ActionEvent.None);

      Message(ref m_list, ref e_list, "【ギッギッギギィィ・・・】", ActionEvent.None);

      Message(ref m_list, ref e_list, Fix.EVENT_GATEDHAL_3, ActionEvent.RemoveFieldObject);

      Message(ref m_list, ref e_list, "【ッバン！】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ探索開始だ！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "アイン：駄目だ。開かないな。", ActionEvent.None);
    }
  }

  #endregion

  #region "ディルの街"
  public static void Message1500010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：着いたな。ここがディルの街か。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：何か・・・雰囲気が・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "【　アイン達は街の中を見回した　】", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ビリー：そっけねえ感じだよな。人は一応いるんだけどな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：活気がない。みんな一体どうしたんだ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、あちらを見てください。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっ、何かあるな・・・何かのモニュメントか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：近くに行ってみましょう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "【　アイン達は街の中央にある石碑に近づいた　】", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：おお、結構デカイな。っと、なんか書いてあるぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：これは記念碑ね。この町の歴史とかが書いてあるんじゃないのかしら。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ビリー、読んでくれないか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：俺じゃ無理だろ。そんなん・・・そ・・・そこのエオネに頼めば良いんじゃねえのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや、ここはイルジナに頼みたい。読めるか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：ッフン、ちょっとどきなさい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：悪いな、頼む。", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：｛　原刻の歴７８２年：ここに栄えあるディルの街を建設する ｝", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：｛　ディルは偉大なる古代賢者：ディル・サーカーンより授かりし命名とする ｝", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：｛　ディルには優しき風が吹き　｝", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：｛　ディルには力強き大地が宿る　｝", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：｛　ディルには輝ける太陽kからの加護が降り注ぐ　｝", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：｛　ここに未来永劫の繁栄と栄華を約束する　｝", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：以上よ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なるほど・・・これは辛いな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：なんでだよ。こんなもん単なる記念碑の言葉だろ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：このディルの街の今をザっと見渡したところ、とてもじゃないが良い状態だとは言えない。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：当初の頃からすると、この街は今よりもっと発展していたんじゃないのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：だとすると、記念碑だけが綺麗にされている、という事は・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おそらく、何らかのひどい襲撃を受けた。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：それに対して、退避する事もなく果敢に立ち向かった。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：だが、結果は惨敗。後に残ったのは荒れ果てた地のみ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：生き残った中で、それでもなお復旧を試みる者もいただろうが、", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：当然、この地を捨てて他へ移動した者もいるだろう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：・・・ハン。ったくよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：過去の事をロクに知りもしないヤツが、よくそこまで分かるわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや、分かってる訳じゃないんだ。気に障ったんなら謝る。すまなかった。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ただ、なんとなくこの町の人達はまだ僅かだが希望を持っている。そんな気がするんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "イルジナ：・・・ッチ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：まあ、まずはテキトーに話かけりゃいいんだろ？そういう役は俺に任せろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、情報収集あしたい。ちょっと頼んだぜ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：私とかエオネは良いのかしら？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そうだな。この街では無駄に活気のある奴の方が良いだろう。とりあえずビリーに任せよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：とりあえずって何だよ。俺様にしか出来ないって事だろ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、その通りだ！任せた！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：おうよ！", ActionEvent.None);

  }
  #endregion

  #region "ディスケル戦場跡"
  public static void Message1600010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "ガンロー要塞"
  public static void Message1700010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "ロスロンの洞窟"
  public static void Message1800010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "エデルガイゼン城"
  public static void Message1900010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "ゼールマンの里"
  public static void Message2000010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "ラタの小屋"
  public static void Message2100010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "パルメティシア神殿"
  public static void Message2200010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message2200010 == false)
    {
      One.TF.Event_Message2200010 = true;

      Message(ref m_list, ref e_list, "アイン：よし、パルメティシア神殿に到着っと。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：何か雰囲気が別格よね。ここに入ると。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：そうなのか？俺には普通の場所に感じられるが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アンタはそういう所が、鈍感すぎなのよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ま、まあ・・・そうなのかも知れないな・・・悪い悪い。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：お、おい。あれ見てみろよ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　ビリーはとある女性の方へと視線を移した ～", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：・・・ひょっとして、エオネかしら？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：でしょ！？そう思いますよね！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：中央にある神殿の中に入っていくな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：アイン、追いかけなくて良いの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：なんだ、ずいぶんと慎重じゃねえか。何か気になんのか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：いや・・・ちょっと難しい所なんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ちょっと間をおいてから行こう。尾行不可能になるくらいの時間を置いてからだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：分からないわね、どういう意味よ。それだったら尾行しなくて良いんじゃないの？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあまあ、ちょっとな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～～～　しばらくして　～～～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：よし、そろそろ良いかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：完全に見失っちまったじゃねーか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ハハ・・・悪い悪い。ちょっと女性の後ろを付け回すのはなんだか気が引けたんだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：えええぇぇ！？　　　ビリー：あああぁぁ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：な、何だよ。２人揃って大声出すなよ。ビックリするだろうが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：ごめんなさい、信じられない発言をするもんだから、こっちがびっくりしちゃったわよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、ともかくこれで十分な距離は取ったはずだ。今から神殿の方に向かおう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おーし、すぐにでも行こうぜ。", ActionEvent.None);
    }
  }

  public static void Message2200020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.Event_Message2200020 == false)
    {
      One.TF.Event_Message2200020 = true;

      Message(ref m_list, ref e_list, "アイン：よし、じゃあ中央神殿に入るといたしますか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アイン達は中央神殿へと足を踏み入れた ～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：しかしやたらと広いフロアだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：向こうの方に来訪者向けのカウンターがあるわね。行ってみましょ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：よし、ここだな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あの、すみません。ちょっとお伺いしたい事があるのですが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：天に仕え、子に捧げしは、現世の理と、慈悲によるお導き", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：パルメテイシア神殿へようこそ。いかがなさいましたか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あの、ここをさっき通過して行った者にお会いしたいのですが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：天に誓いしは、お導きに関する相談のみとなります。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ・・・そうなんですか。じゃあちょっとお導き頂きたくお願い致します。", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：迷えし子よ、どうぞこちらへ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っと、じゃあ２人ともここで待っててくれ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アインは神殿内の２階へと誘われた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "神官：こちらでお待ちください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、はい。どうも、ありがとうございます。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：では、こちらへどうぞ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、はい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：私の導きはここまでとなります。", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：この先、法王の間に足をお運びください。", ActionEvent.None);

      Message(ref m_list, ref e_list, "神官：それでは。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　神官はその場から足音を立てる事なく、立ち去った・・・　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "アイン：おし・・・じゃあ、参るとしますか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "【ギッギッギギィィ・・・】", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：子よ。いかがなされたかな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、えっと・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どこに、向かうべきでしょうか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ラインが見えてはいるのですが、それが選択肢とは思えないです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：選択肢を選ぶ権利と選ばない権利があるとは思いつつも", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：選ぶという枠の範囲でしか動くしか術がありません。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：それが理、という事でしょうか・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：・・・　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：さて、これは驚いたの。", ActionEvent.None);
      
      Message(ref m_list, ref e_list, "？？？：そなたのような問いかけを行った者は、過去にあまり例を見ない。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：そうじゃな。。。あれは、そうじゃ。思い出した。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：今のファージル国王、エルミ・ジョルジュと同じ類の問いかけじゃな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：っえ、エルミ国王も？", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：少し容は違うが、確かに。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：おお、そうじゃ。いきなり話し込んですまんかったの。気楽にせい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "？？？：我は。ツヴェルドーゼ１７世。以後、ツヴェルと呼んでもらって構わんよ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ゲッ・・・法皇様相手にその様な・・・？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：よいのだ。この方が喋りやすかろうて。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：こ・・・国王エルミ様も同じような感覚で喋りますよ。まったくどこ行ってもそうなのかな・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：そなたが、そうさせるのであろうな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：して、選択肢についてだが。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：そなたは、まだ渦中の外であるようにも思える。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：だが、その導きについては、既に秤の対象。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：天秤と取るか、定めと取るか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：現時点では、其方次第であるとも言える。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：なるほど　・・・　・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：どうもありがとうございます。大変助かりました。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：よいのかね？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ええ、大丈夫です。何とか行けそうです。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、ところで一つすみませんが、教えてくれないでしょうか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：なにかね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ここに、エオネ・フルネアという人物は来なかったでしょうか？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：その名は、天に名にあらず。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：我々ムーンフォーダーの民は、天の民。", ActionEvent.None);
      
      Message(ref m_list, ref e_list, "ツヴェル：神より授けられし、天の名を持つ者同士でしか分かち合う事は許されておらんのだ。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：な・・・なるほど・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：そなたなら、きっと道を見つけられるであろう。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ツヴェル：では、子に慈悲と加護と導きがあらん事を。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：あ、どうもありがとうございました。失礼いたします。", ActionEvent.None);

      Message(ref m_list, ref e_list, "～　アインは１階フロアへと戻ってきた　～", ActionEvent.MessageDisplay);

      Message(ref m_list, ref e_list, "ラナ：あっ、戻ってきたわね。どうだった？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ、エオネの件だが、実は・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：「天の名」を受けし者でないとコンタクトを取ったらダメらしい。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：んだそりゃ。じゃ、エオネについてはエオネって呼び名だけじゃダメって事かよ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：まあ、ややこしい言い方だがそういう事になるな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：確かに、この人達って喋りかけているのをあまり見かけないわよね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：必要最小限にしか喋らないのも独特の文化なのかもな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ビリー：おい、そろそろ行こうぜ。ここに居てもしょうがねーんだろ？", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：ああ。そうだな。一旦外に出るとするか。", ActionEvent.None);

      Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_24 + " 】が更新されました！", ActionEvent.QuestUpdate);
    }
  }
  #endregion

  #region "雪原の大樹ラタ"
  public static void Message2300010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "シスの墓石"
  public static void Message2400010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    // 満たされるは精神と英知。語り継ぎし者よ、安らぎと平穏を。
    // うつろいを重ね、遠くを廻りて、祈願を果たす // todo
  }
  #endregion

  #region "キルクード山岳地帯"
  public static void Message2500010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "天上界ジェネシスゲート"
  public static void Message2600010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  public static void Message(ref List<string> m_list, ref List<ActionEvent> e_list, string message, ActionEvent eventData)
  {
    m_list.Add(message);
    e_list.Add(eventData);
  }
}