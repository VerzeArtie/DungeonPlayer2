using System.Collections.Generic;
using DungeonPlayer.Core.Animation;

/// <summary>
/// コマンドごとの「演出のまとめ方」を宣言するテーブル。既定は一括で、登録したコマンドだけ逐次。
/// 登録基準は「対象がランダムに選ばれ、同じ相手に複数回当たり得るもの」。
/// 一括で出すと何発当たったのか読み取れないため、1発ずつ見せる。
/// </summary>
public static class AnimationChainPolicy
{
  private static readonly HashSet<string> SequentialCommands = new HashSet<string>
  {
    Fix.COMMAND_BERSERKER_RUSH,
    Fix.COMMAND_BURST_CLOUD,
    Fix.COMMAND_CHROMATIC_BULLET,
    Fix.COMMAND_CONTINUOUS_ATTACK,
    Fix.COMMAND_DANCING_LANCER,
    Fix.COMMAND_DARK_SIMULACRUM,
    Fix.COMMAND_DESTRUCTION_CIRCLE,
    Fix.COMMAND_EIGHT_ALL,
    Fix.COMMAND_ETERNAL_CIRCLE,
    Fix.COMMAND_FEROCIOUS_THUNDER,
    Fix.COMMAND_FIRE_BULLET,
    Fix.COMMAND_FROST_SHARD,
    Fix.COMMAND_FROZEN_BULLET,
    Fix.COMMAND_HARSH_CUTTER,
    Fix.COMMAND_HELLFLAME_BULLET,
    Fix.COMMAND_JUDGEMENT_LIGHTNING,
    Fix.COMMAND_JU_STYLE,
    Fix.COMMAND_MUD_PISTOL,
    Fix.COMMAND_OAHN_VOICE,
    Fix.COMMAND_OUT_OF_CONTROL,
    Fix.COMMAND_PARADOXICAL_SLICER,
    Fix.COMMAND_PRISMATIC_BULLET,
    Fix.COMMAND_RAMPAGE,
    Fix.COMMAND_RANSO_RENGEKI,
    Fix.COMMAND_RENSOU_TOSSHIN,
    Fix.COMMAND_RENZOKU_BAKUHATSU,
    Fix.COMMAND_RENZOKU_HOUSYA,
    Fix.COMMAND_SATELLITE_SWORD,
    Fix.COMMAND_SOLID_SQUARE_WATER,
    Fix.COMMAND_SONIC_BLADE,
    Fix.COMMAND_SPANNING_SLASH,
    Fix.COMMAND_SPECTOR_VOICE,
    Fix.COMMAND_STARSWORD_KIRAMEKI,
    Fix.COMMAND_STARSWORD_TSUYA,
    Fix.COMMAND_SUPER_RANDOM_CANNON,
    Fix.COMMAND_WAZAWAI_FLAME,
    Fix.COMMAND_YOUEN_FIRE,
  };

  /// <summary>
  /// コマンド名から演出のまとめ方を決める。未登録のコマンドは一括。
  /// </summary>
  public static AnimationChainMode ResolveMode(string command_name)
  {
    if (string.IsNullOrEmpty(command_name)) { return AnimationChainMode.Simultaneous; }

    return SequentialCommands.Contains(command_name)
      ? AnimationChainMode.Sequential
      : AnimationChainMode.Simultaneous;
  }

}
