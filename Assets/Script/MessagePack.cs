using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class MessagePack
{
  #region "アクションイベント"
  public enum ActionEvent
  {
    None,
    MessageClear,
    GetItem,
    GetGold,
    GetNewQuest,
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
    InstantiateObject,
    GainSoulFragment,
    MessageDisplay,

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

  public static void MessageX00001(ref List<string> m_list, ref List<ActionEvent> e_list)
  {    
    Message(ref m_list, ref e_list, "", ActionEvent.MessageClear);

    Message(ref m_list, ref e_list, "～ 休息を取りました ～", ActionEvent.MessageDisplay);
  }

  public static void MessageX00002(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：今、休息を取ったばかりだ。他に何かやらねえとな。", ActionEvent.None);
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

  #region "アンシェットの街"
  public static void Message100010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：っしゃ・・・これで準備OKかな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：え、ちょっとそれだけしか持っていかないワケ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.ReturnToNormal);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_ANSHET + "にて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：旅に出るんだ。荷物はこれぐらい軽くしておいたほうが良いだろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, Fix.SMALL_RED_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.SMALL_RED_POTION, ActionEvent.GetItem);
    Message(ref m_list, ref e_list, Fix.SMALL_RED_POTION, ActionEvent.GetItem);

    Message(ref m_list, ref e_list, "ラナ：旅に出るわけじゃなくて、正式な調査依頼を受けて、任務遂行しに行くのよ。ちゃんと準備してよね、ホント。", ActionEvent.None);

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
    Message(ref m_list, ref e_list, "ラナ：ちょっと、そこのバカアイン！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：（　国内外遠征許可証を取りに行かねえと。ラナに睨まれている以上、他の行動は出来そうもないな・・・　）", ActionEvent.None);
  }

  public static void Message100020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よし、" + Fix.TOWN_FAZIL_CASTLE + "に到着。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：正面ゲートから入ったらすぐ横の受付を済ませてちょうだいね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、わかった。了解了解！", ActionEvent.None);

    //Message(ref m_list, ref e_list, "アイン：って、おわぁ！！　なんで横に居るんだよ！？", ActionEvent.None);

    //Message(ref m_list, ref e_list, "ラナ：バカアインが迷子になるのは目に見えてるからよ。しょーがないから来てあげたんじゃない。", ActionEvent.None);

    //Message(ref m_list, ref e_list, "アイン：ま・・・まあ、正直なところ宮殿はほぼ歩いた事がねえ・・・助かるけどな。", ActionEvent.None);

    //Message(ref m_list, ref e_list, "ラナ：ホラ、そこの受付に早く行って頂戴。", ActionEvent.None);

    //Message(ref m_list, ref e_list, "アイン：ああ、わかった。", ActionEvent.None);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、受付口にて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "　　【受付嬢：" + Fix.TOWN_FAZIL_CASTLE + "へようこそ。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：すまないがちょっと教えてくれ。国内外遠征のための通行証が欲しいんだが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：ファージル王国からの推薦状をご提示願いますでしょうか。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：えっ！なんだって！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：何言ってんのよ。さっき話してた用紙の事よ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ。あの紙の事か。それならここに持ってるぜ。", ActionEvent.None);

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

    Message(ref m_list, ref e_list, "エルミ：国内外遠征先のヴィンスガルデ王国エリアで調査して欲しい案件があるんだ。", ActionEvent.None);

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

    Message(ref m_list, ref e_list, "ファラ：その名は【ObisidianStone】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：Obisidian・・・Stone・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：アインさんには、そのObsidianStoneの調査を秘密裏に遂行していただきたいの。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：秘密裏・・・え。どういう事ですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：ファラ、そこまでで良いよ。後はボクが話すから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ファラ：あら、じゃあお願いしても良いかしら（＾＾", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：アイン君。" + Fix.AREA_VINSGARDE + "王国に行くため、まずは" + Fix.TOWN_COTUHSYE + "へ寄って欲しい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：" + Fix.TOWN_COTUHSYE + "？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：ああ、沿岸沿いにある小さな港町だよ。そこから船を使って" + Fix.AREA_VINSGARDE + "王国へ向かって欲しい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：分かりました。じゃあ、まずは" + Fix.TOWN_COTUHSYE + "へ行ってみます。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：それから、少しばかりだが軍資金を用意しておいた。この軍資金は好きに使ってもらって構わないから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "【 2000 gold 】を獲得しました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "2000", ActionEvent.GetGold);

    Message(ref m_list, ref e_list, "アイン：あ、ありがとうございます！僭越ながら、拝受つかまつります！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：アッハハハ、丁寧にどうもありがとう。固苦しい言葉は本当に気にしなくていいからね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：さて、港町までは少し距離がある。途中にある" + Fix.TOWN_QVELTA_TOWN + "に立ち寄ってみるのも良いだろう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：それでは、よろしく頼んだよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：えっと・・・すみませんが、到着したら何かやる事はありますか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：いや、特に「何か」っていうのは気にしなくて良いよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：天の導きがあれば、自然と道は拓かれる。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そ、そんなもんですかね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エルミ：アイン君ならきっと大丈夫だよ。いつも通りで。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：はい、分かりました！", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_2 + " 】が開始されました！", ActionEvent.GetNewQuest);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、エントランスにて ～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：じゃあ、まずは" + Fix.TOWN_COTUHSYE + "へ向かえば良いみたいね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、遠征許可証も手に入れたし、それじゃ、そろそろ・・・", ActionEvent.None);

    //Message(ref m_list, ref e_list, "ラナ：私は別に良いけど、ひとまずショップに寄っておいた方が良いんじゃないの？", ActionEvent.None);

    //Message(ref m_list, ref e_list, "アイン：オーケー！じゃあ、ショップに寄ってから出発とするか！", ActionEvent.None);

    //  Message(ref m_list, ref e_list, "", ActionEvent.AutoSaveWorldEnvironment);
    //}

    //public static void Message100040(ref List<string> m_list, ref List<ActionEvent> e_list)
    //{
    //Message(ref m_list, ref e_list, "アイン：じゃあ、いざ出発！", ActionEvent.None);

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

    Message(ref m_list, ref e_list, "エオネ：私を" + Fix.TOWN_QVELTA_TOWN + "までお送りいただけないでしょうか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おお、俺たちもそこは通過するつもりだ。タイミングが良いな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え、えっと、あの・・・その" + Fix.TOWN_QVELTA_TOWN + "まで・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：（ちょっ、バカアイン出てくるとややこしいから、引っ込んでてよ）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：（あ、あぁ・・・）", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：" + Fix.TOWN_QVELTA_TOWN + "まで護衛して欲しいって事よね、承るわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：確認なんだけど、一般市民としてかしら？それとも、戦闘で何か出来る事はある？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：え、えっと。多少ですが、魔法は使えます。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：じゃあ、戦闘グループとして同行してもらう形のほうが良いかしら？", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：ハ、ハイ！喜んで！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：決まりみたいね♪　じゃあ、" + Fix.TOWN_QVELTA_TOWN + "まで、一緒に行きましょう♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます！よろしくお願いします！", ActionEvent.None);

    Message(ref m_list, ref e_list, " 【エオネ・フルネア】が仲間になりました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, Fix.NAME_EONE_FULNEA, ActionEvent.HomeTownAddNewCharacter);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_TITLE_1 + " 】を達成しました！", ActionEvent.QuestComplete);
  }
  // フィールド
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

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ通行許可証を・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと待ってよ。今から港町コチューシェの方へ向かうんでしょ？そっちじゃないわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっと、悪い悪い・・・ここは一旦戻るとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
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

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ通行許可証を・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと待ってよ。今から港町コチューシェの方へ向かうんでしょ？そっちじゃないわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっと、悪い悪い・・・ここは一旦戻るとするか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
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

  #endregion

  #region "フィールド"
  public static void Message101005(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "ラナ：ちょっと、そこのバカ。港町コチューシェはそっちじゃないわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おっと、そうか。悪い悪い。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
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

    Message(ref m_list, ref e_list, "アイン：フルネア、お前はヴァスタって叔父さんの事、知ってるか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：え、えっと・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：そこのバカアイン、何勝手に話しかけてるのよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：え、いやフルネアさんなら何か噂とか聞いたことあるのかなって思っただけだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：無理に答えなくて良いのよ。バカが何か適当に喋ってるだけだから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：え・・・えぇ・・・", ActionEvent.None);

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

    Message(ref m_list, ref e_list, "フルネア：あっ・・・エオネ・フルネアと言います、よろしくお願いします。", ActionEvent.None);

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

    Message(ref m_list, ref e_list, "ラナ：フルネア、足元に危ない破片が落ちてるわ。気をつけてね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ、ありがとうございます。気をつけます。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なあ、ここは特に街ってワケでもなさそうだから、無理せず待っててくれても良いんだぞ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ、いえ。大丈夫です。わ、私、その・・・慣れてますから・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あれ？慣れてるのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ、いえ・・・え、ええと・・・その・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアインはなんでそう人の気持ちにズカズカと踏み込んでるのよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：バカな。俺はそんな特別な会話はしてないつもりだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：フルネア、足元も注意だけど、そこのバカアインとの会話にも要注意だからね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ・・・はい、わかりました。", ActionEvent.None);

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

      Message(ref m_list, ref e_list, "フルネア：あ、おめでとうございます。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：おお、フルネアも戦闘は助かったぜ、サンキューな！", ActionEvent.None);

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
    Debug.Log("Message300032(S)");
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

      Debug.Log("UseMatockForRock (ARTHARIUM_Rock_3_O)");
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

      Message(ref m_list, ref e_list, "『　本エリア奥にて凶暴な生物が発生。至急、本通路を封鎖する。　』", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：穏やかな内容じゃないわね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：今まで通ってきた道でも、モンスターなら普通に出現してるけどな。", ActionEvent.None);

      Message(ref m_list, ref e_list, "ラナ：どこに潜んでるかも把握出来ていないんだし、まあ慎重に進んだ方がよさそうね。", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：確かにそうだな、了解！", ActionEvent.None);
    }
    else
    {
      Message(ref m_list, ref e_list, "『　廃坑奥に凶暴な生物が発生。至急、本通路を封鎖する。　』", ActionEvent.None);
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
      Message(ref m_list, ref e_list, "ガルヴァ：ゴッ・・・ゴガガガガガガ！！！", ActionEvent.None);

      Message(ref m_list, ref e_list, "アイン：うお！　こいつまだ！？", ActionEvent.None);

      Message(ref m_list, ref e_list, "ガルヴァ：ゴガア・・・ガ・・・ガアァァァ・・・ガ・・・", ActionEvent.None);

      Message(ref m_list, ref e_list, "ガルヴァ：・・・　・・・　・・・", ActionEvent.None);

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

      Message(ref m_list, ref e_list, "アイン：まあ今後は気をつけるとして・・・えー何だっけ。パフェの店に行くんだろ？", ActionEvent.None);

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

  public static void Message400020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message400020 = true;

    Message(ref m_list, ref e_list, "アイン：ええと、たしか船着き場はこっちのほうだったな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　船着き場にて　～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "係員：だから、他を当たってくれと言ってるんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：だから、他も何もねーだろ。船が出る所はココしかないだろーが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "係員：とにかく、船は出ない。他を当たってくれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：チッ、ありえねぇだろ・・・くそ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：なあ、何か起きてるのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：ここの係員が船に乗せてくれねえんだよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：船自体はそこの発着場にある。出ないワケがねえだろって言ってるんだが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：船があったとしてもメンテナンスか何かで出航しない場合だってあるだろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：ちょっと待てよ、何でお前まで係員と同じ事を言うんだよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そんなの係員に聞くまでも無いだろ。大体予想は付く。", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：「大体予想は付くって」、テメーの予想なんか聞いてねんだよ・・・俺は船に乗る方法を・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：あっ！そのセリフ回し！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：てめぇ、まさか" + Fix.NAME_EIN_WOLENCE + "じゃねえだろうな！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、俺がそうだが。なんで知ってるんだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：「なんで知ってるんだ？」じゃねえよ！！おまえ、俺の顔見て何も思い出さねえのかよ！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あ！・・・あー・・・ああ、ああ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・誰だっけ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：なんだよそれ！！もう・・・お前マジで記憶がテキトーだな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "？？？：俺だよ、" + Fix.NAME_BILLY_RAKI + "だよ。覚えてねえか！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：お、おお！　ビリー！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラキ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ハーッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：・・・なんてヤツだ・・・コイツは・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いやいや、お前雰囲気少し変わったよな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：オルガウェイン傭兵施設では、何かこう尖がりヘルメットみたいな雰囲気だったし。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：んだその、尖がりヘルメットってのは。変な言い方はよしてくれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ここにやってきたのは何でだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：理由は特にねーな。ぶらぶらと色んな所に行ってみたいだけだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ッハッハッハ、そういう所は相変わらずだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：おい、お前。俺の事覚えてるのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そりゃ覚えているさ。オルガウェインで結構遊んでたもんな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ま、昔話はちょっと置いておこう。船が出ねえってのは何かの事情があるんだろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ちょっとそのあたりの内容を聞いてみる。良いよな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：別に俺は構わねえが。でもあの係員と話しても何もでねーぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：まあまあ、やってみるさ。任せておきな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　数分経過後　～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：う～ん・・・何だろうなあ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：おい、何か分かったのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、そこのバカアイン。黙ってないで答えなさいよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ。悪い悪い。まあ係員が言うには、船先のヴィンスガルデは何等かの理由によって交易を閉ざしてるみたいなんだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ふうん、じゃあそもそも船が出ないのは納得が行くわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：でだ。係員が言うには、船のルートはもう無理だからって事で、別のルートを紹介された。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：封鎖区域、ツァルマンの里と言っていた。どうだ分かるか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：この港町から北に向かった所にあるわね。今ではほとんど人が通過することは無いそうよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：まあ、基本船が出来てからは、そうそう通ることは無くなったんだろうな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：どうする？そっちを当たってみるか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ええ、別に良いわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：フルネア、お前はどうだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：えっと、はい。大丈夫です。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ビリー、お前は来るのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：・・・え？俺もか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：何だよ。旅は道連れなんだろ？お前が昔よく言ってたセリフじゃないか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：おっしゃ！じゃあ俺もお供させてもらうぜ！よろしくな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、頼んだぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, " 【ビリー・ラキ】が仲間になりました！", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "", ActionEvent.None);
  }
  #endregion

  #region "ツァルマンの里"
  public static void Message500010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message500010 = true;

    Message(ref m_list, ref e_list, "アイン：着いたな。ここがツァルマンの里か・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ねえ、あの入口の門に誰か居るわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、声をかけてみるか・・・！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：こんにちわー。", ActionEvent.None);

    Message(ref m_list, ref e_list, "門番：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あの、アイン・ウォーレンスという者ですが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ここって、通過しても良いものでしょうか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "門番：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：どけ。ちょっと俺が何とかしてやる。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：たのもう！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "門番：！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：いざ、尋常に・・・！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ちょ、っちょっと待てって。戦いに来たわけじゃないんだぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：何でだよ。あの門番、はじめっから戦うオーラがバンバン出てるぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あれは常に警戒心を怠ってないだけだろ。別に俺たちに向けているわけじゃない。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：クソ・・・じゃ、どうすんだよ。指加えて見てるだけってか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ・・・あの。す、す、すみません・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ・・・ちょ、ちょっとだけ・・・私が出ても良いでしょうか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：交渉のネタでもあるのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：と、とにかく・・・ちょっとだけで良いので　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：バカアインみたいにノープランってワケじゃなさそうね。フルネア、大丈夫？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：ハ・・・ハ、ハイ。　おそらくあの・・・ハイ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：う～ん、まあ何か作戦があるなら頼みたい所だが、ちょっとリスキーだよな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラナ、お前も傍に居てやってくれ。頼んだぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：うん、わかったわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　ラナとフルネアが門番に近づき、何かを話し始めた　～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：・・・何か普通に会話してるな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：あの門番。女子に弱いんじゃねーのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや、違うだろ。ツァルマンの里の者達は卓越した精神力を保持しているという噂を聞いた事がある。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：女子とか男子とかそういった類では動かないはずだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：へぇ、そんなもんかな。こういった所に限ってそういうのが弱点だったりするのが普通だけどな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ともかく、結構話してるみたいだし・・・少し様子を・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・おっ、戻ってきたな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よう、どうだった？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：大丈夫、通っても良いみたよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ありがと、フルネア♪　あなたのおかげね♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：いえ・・・あ、いえ、どういたしまして。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：どういう話の内容で説得したんだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：少々・・・ObsidianStoneにまつわる話を・・・いたしました。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：伝承の真実を追い求めている。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：真実か偽りかは私達で判断はできない。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：だからこそ、この目で見ておきたい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：そういった流れの話を少々・・・すみません、出しゃばりすぎました。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：へえぇ！いやいやいや、凄いな！よくそんな交渉ができたな！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアイン失礼よ、今の言い方は。感謝しなさいよね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おお、ああ。悪い悪い、サンキューな！フルネア！", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ・・・いえ、えっと・・・と、ともかく終わりましたので、先に進んでください。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：オーケー！じゃ、早速通過させてもらうとしますか！", ActionEvent.None);
  }

  public static void Message500020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message500020 = true;

    Message(ref m_list, ref e_list, "アイン：よし、じゃあツァルマンの長老に話してみよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ごめんください。", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：うむ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：あ、ええと。俺の名前は", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：アイン・ウォーレンス。そう聞いておる。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：え、既にご存じなんですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：うむ。ファージルの国王より、仰せつかっておる。", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：お主がかならずここへ訪れるとな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：え、そうなんですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：要件は、ObsidianStoneじゃな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：え、ええ。まあ、その途中というかなんと言うか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：" + Fix.AREA_VINSGARDE + "のほうへ船で渡ろうとしたんですけど、今は封鎖中みたいで。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：それで、こちらの方に迂回ルートがあると聞いてやってきたんです。", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：うむ、そういった経緯であったか、なるほど・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：お主。ファージル国王より、何を受け取っておる？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや、俺自身は何も受け取ってないんですが。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ラナ、例の物を出してくれるか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ええ、いいわよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　ラナは【法剣？？？】を長老へと差し出した　～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "長老：うむ、どれ・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：うむ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：これは確かに、ファージル国王が持っていた宝剣の一つじゃな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：剣の柄にくぼみがある。そこにはObsidianStoneをはめる事で真価が発揮される。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：へえ・・・そういうものなんだ。そのアイテムって。", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：お主達の要件は、おおよそは掴めた。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おお、それじゃあ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：いや、すまないがお主達をここから通すわけにはいかん。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：え、どうしてですか！？", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：それは言えん。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：あの、すみません。そのアイテムの管理でしたら私が責任を持ちますから。", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：ならぬ。これは、掟である。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：お、おいジジイ！そりゃねえだろーが！？理由ぐらい言えよ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：なっ、何じゃお主は！！　間違ってもお主だけは通さん！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：バ、バカ！　挑発してどうすんだよ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：と、とにかく！ここを通してくれないか！後生だ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：ならぬ！　ならぬならぬ！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "長老：出てゆくがよい！！　もう二度と顔を見せるでないぞ！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　アイン達は部屋の外へ放り出されてしまった　～", ActionEvent.MessageDisplay);

    Message(ref m_list, ref e_list, "アイン：な・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：追い出されちゃったわね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：あのジジイ。始めっから通す気がねーだろ。もったいぶりやがって。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：いや・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ま、ここはしょうがないか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：何がしょうがねえんだ？このまま引き下がるってのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：でも、今なんとかしようとしても、あの感じだとさすがに無理だろ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ビリー：・・・じゃ、どうすんだよ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：まあ・・・今考えてる所だが・・・。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あの・・・すみません、お取込み中に・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：ファージル宮殿からの使者が、アインさん宛てに連絡があるとの事の様です。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ファージル宮殿からの・・・使者？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ、わ、わたくしよりも、使者の方が実際に来てますので・・・。", ActionEvent.None);

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

    Message(ref m_list, ref e_list, "アイン：フルネアも一緒に来るよな？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あ、はい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし、じゃあ一旦皆でファージル宮殿に戻ろう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.None);
  }
  #endregion

  #region "ゴルトラム洞窟"
  public static void Message600010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "ファージル宮殿"
  public static void Message700010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "オーランの塔"
  public static void Message800010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
  }
  #endregion

  #region "フィオーネの湖"
  public static void Message900010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
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
  }
  #endregion

  #region "廃墟サリタン"
  public static void Message1200010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
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
  }
  #endregion

  #region "ディルの街"
  public static void Message1500010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
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