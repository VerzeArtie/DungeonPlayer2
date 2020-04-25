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
    MoveTop,
    MoveLeft,
    MoveRight,
    MoveBottom,
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
    HomeTownMessageDisplay,
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

    Message(ref m_list, ref e_list, "～ 休息を取りました ～", ActionEvent.HomeTownMessageDisplay);
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

  #region "アンシェットの街"
  public static void Message100010(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：っしゃ・・・これで準備OKかな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：え、ちょっとそれだけしか持っていかないワケ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.ReturnToNormal);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_ANSHET + "にて ～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_EVENT_TITLE[0] + " 】が開始されました！", ActionEvent.GetNewQuest);

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

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、受付口にて ～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "【 " + Fix.FIELD_RESEARCH_LICENSE + " 】を獲得しました！", ActionEvent.HomeTownMessageDisplay);

    Message(ref m_list, ref e_list, Fix.FIELD_RESEARCH_LICENSE, ActionEvent.GetItem);

    Message(ref m_list, ref e_list, "アイン：サンキュー！助かるぜ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：なお、エルミ・ジョルジュ国王陛下よりアイン・ウォーレンス様へ連絡があるとの事です。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "　　【受付嬢：本日、この国内外遠征許可証をお持ちの上、必ず謁見の間へ行かれます様、よろしくお願い申し上げます。】", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：エルミ国王が・・・なんだろう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：バカアインが許可証もらうのをサボってたから、心配してるんじゃないの？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ハハハ・・・言われてみりゃそうかもな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：謁見の間は宮殿の中央から３階まで上がった場所にあるわよ。早く行きましょう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：了解！", ActionEvent.None);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、謁見の間にて ～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "【 2000 gold 】を獲得しました！", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_EVENT_TITLE[1] + " 】が開始されました！", ActionEvent.GetNewQuest);

    Message(ref m_list, ref e_list, "～ " + Fix.TOWN_FAZIL_CASTLE + "、エントランスにて ～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, " 【エオネ・フルネア】が仲間になりました！", ActionEvent.HomeTownMessageDisplay);

    Message(ref m_list, ref e_list, Fix.NAME_EONE_FULNEA, ActionEvent.HomeTownAddNewCharacter);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_EVENT_TITLE[0] + " 】を達成しました！", ActionEvent.QuestComplete);
  }
  // フィールド
  public static void Message101000(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：よっしゃ、回復の泉だな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.Fountain);

    Message(ref m_list, ref e_list, "パーティは全回復しました。", ActionEvent.HomeTownMessageDisplay);
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

    Message(ref m_list, ref e_list, "～ ヴァスタの武器屋にて ～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_EVENT_TITLE[3] + " 】が開始されました！", ActionEvent.GetNewQuest);

    Message(ref m_list, ref e_list, "ヴァスタ：あそこはモンスターも出てくるという噂を聞いておる。準備は万全にな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：オーケー！じゃあ、ゼタニウム鉱石を取ってきたらまた戻ってくるぜ。少し待っててくれよな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：すまんが、よろしく頼む。", ActionEvent.None);
  }
  public static void Message200030(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message200030 = true;

    Message(ref m_list, ref e_list, "アイン：ども、こんちわー", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：おー、アインか。いらっしゃい！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：前にお願いしていたゼタニウム鉱石を持ってきました♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：お、そいつは嬉しいねえ！では、早速例のアイテムの鑑定を行うとするかの！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ちなみに、そのゼタニウム鉱石は５つあるから２５００ＧＯＬＤで引き取るぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：えっ、ちょっとお金なんていいですよ。そんなつもりで持ってきたんじゃないですし。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：ええからええから。ワシとて商売人。売買は人との礼儀そのもの。取っておくがよい。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：すみません、ではありがたく頂戴します。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：鉱石の中に、超微細レンズの仕組みを担う物質が含まれておってな。それをちょっと抽出してくる。待っておれ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よろしくおねがいします！", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　しばらくして　～　", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "～　【法剣？？？】を手に入れた！　～", ActionEvent.HomeTownMessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：鑑定、ありがとうございました♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：よし。じゃあ、ありがとうな、ヴァスタのおっさん！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ヴァスタ：おっさんか！ガハハハハ！また好きな時にどんとこい。いくらでも付き合うぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、またよろしくな！", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.None);
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

    Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
  }

  public static void Message300031(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
  }

  public static void Message300032(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
  }

  public static void Message300033(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
      return;
    }

    Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveLeft);
  }

  public static void Message300034(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    if (One.TF.QuestMain_00005 == false)
    {
      SearchMatockQuest(ref m_list, ref e_list);
      Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
      return;
    }

    Message(ref m_list, ref e_list, "アイン：マトックが無いと、ここは通れないな。探してこよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveRight);
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

    Message(ref m_list, ref e_list, "アイン：マジか・・・まあ・・・何とか探してみるか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：っしゃ、任せておけ！ッハッハッハ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_EVENT_TITLE[4] + " 】が開始されました！", ActionEvent.GetNewQuest);
  }

  public static void Message300040(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：扉か・・・鍵がかかってるな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：他を探してみましょう。きっとどこかに鍵があるはずよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：まあ、ある事には間違いないんだろうが・・・どこら辺だろうな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "エオネ：えっと・・・どうかされたんですか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・ッハ！　あ、いやいやいや！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：また何かくだらないこと考えてたんでしょ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：考えてないでとにかく探してみましょ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ああ、探索開始だ！", ActionEvent.None);

    Message(ref m_list, ref e_list, "クエスト【 " + Fix.QUEST_EVENT_TITLE[5] + " 】が開始されました！", ActionEvent.GetNewQuest);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);

  }
  public static void Message300041(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    Message(ref m_list, ref e_list, "アイン：この工場跡地向けの鍵を探さないと、ここを開く事は出来ないな。鍵を見つけよう。", ActionEvent.None);

    Message(ref m_list, ref e_list, "0", ActionEvent.MoveBottom);
  }

  public static void Message300050(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
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
    One.TF.Event_Message400010 = true;

    Message(ref m_list, ref e_list, "アイン：よし、" + Fix.TOWN_COTUHSYE + "に着いたみたいだな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：結構ここまで長い道のりだったわね。ちょっと一休みできる所は無いかしら。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あっ、ラナさん。あちらの角を左に曲がって、3軒目の所に美味しいパフェを売ってる店があるんですよ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：本当！？じゃあ早速行きましょ♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ゲッ、マジかよ。俺はとっとと" + Fix.AREA_VINSGARDE + "に渡ってしまいたいんだが", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：そんなのいつでも行けるじゃない。今しか出来ない事をやるのよ♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ま・・・まあ、そう言われればそうだが・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：じゃ、私は先に行ってるからね♪ほら、フルネアもおいで♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：え、あ、ハイ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　行っちまったか　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：ま、いいか。この辺りで一旦休むのもアリかな。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　アインが、曲がり角まで差し掛かった所で　～", ActionEvent.HomeTownMessageDisplay);

    Message(ref m_list, ref e_list, "ラナ：キャア！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：（今の、ラナの声か！？）", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：おい、大丈夫か！！", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：え、えぇ・・・大丈夫よ。ビックリしたわ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：何があったんだ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：うーん、それがね。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：よく分からなかったのよ。何かが横切ったのは確かなんだけど。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：フルネア、お前は何か見なかったのか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：い、いえ。わ、わたくしは何も・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：そうか。まあとにかく誰も傷付いてなくて何よりだ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：まあ今後は気をつけるとして・・・えー何だっけ。パフェの店に行くんだろ？", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：はい、今目の前にあるお店です。ラナさんは既に入っていきました。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：早ぇなあ・・・そういう所は見境がないんだよな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：・・・っ・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：お、フルネアも入るのか？ココ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：あっと・・・え、ええっと・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：はい。では行ってまいります。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：うん。じゃ、俺はここで待ってるから。二人とも食い終わったらサッサと出てくるんだぞ。", ActionEvent.None);

    Message(ref m_list, ref e_list, "フルネア：え、えっ、ええ・・・では。", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　２時間　経過後　～", ActionEvent.HomeTownMessageDisplay);

    Message(ref m_list, ref e_list, "アイン：・・・　・・・　・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：・・・　っお。出てきたか。", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：ふぅ、美味しかった♪", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：どうだった。ちょっとはスタミナ回復したか？", ActionEvent.None);

    Message(ref m_list, ref e_list, "ラナ：スタミナとか変な言い方しないでよ。せっかく美味しかったのが台無しになっちゃうじゃない。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：すまねえ・・・次から気を付ける。", ActionEvent.None);

    Message(ref m_list, ref e_list, "アイン：それじゃ、気を取り直して。船着き場まで歩くとするか！", ActionEvent.None);

    Message(ref m_list, ref e_list, "", ActionEvent.None);
  }

  public static void Message400020(ref List<string> m_list, ref List<ActionEvent> e_list)
  {
    One.TF.Event_Message400020 = true;

    Message(ref m_list, ref e_list, "アイン：ええと、たしか船着き場はこっちのほうだったな・・・", ActionEvent.None);

    Message(ref m_list, ref e_list, "　～　船着き場にて　～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "　～　数分経過後　～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, " 【ビリー・ラキ】が仲間になりました！", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "　～　ラナとフルネアが門番に近づき、何かを話し始めた　～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "　～　ラナは【法剣？？？】を長老へと差し出した　～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "　～　アイン達は部屋の外へ放り出されてしまった　～", ActionEvent.HomeTownMessageDisplay);

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

    Message(ref m_list, ref e_list, "　～　使者はその場から立ち去っていった　～", ActionEvent.HomeTownMessageDisplay);

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