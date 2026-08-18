using System;
using System.Collections.Generic;

namespace DungeonPlayer.Core.Animation
{
  /// <summary>
  /// 演出（ダメージ表示など）をどう見せるかの宣言。
  /// </summary>
  public enum AnimationChainMode
  {
    /// <summary>1件ずつ順番に見せる。ランダムで対象が選ばれる連続攻撃など。</summary>
    Sequential = 0,

    /// <summary>まとめて同時に見せる。全体攻撃・全体回復など。</summary>
    Simultaneous = 1,
  }

  /// <summary>
  /// 「同じ拍でまとめて見せたい演出」に共通のチェインIDを与える採番機。
  /// IDは入れ子の深さではなく単調増加のユニーク値なので、別スコープの演出が混ざらない。
  /// </summary>
  public sealed class AnimationChainAllocator
  {
    /// <summary>逐次再生を表すチェインID。この ID を持つ演出は 1 件ずつ再生される。</summary>
    public const int SequentialChainId = 0;

    private const int FirstGroupChainId = 1;

    private readonly List<int> _scopes = new List<int>();
    private int _nextGroupChainId = FirstGroupChainId;

    /// <summary>
    /// いま発行される演出に付与すべきチェインID。スコープが無ければ
    /// <see cref="SequentialChainId"/>。
    /// </summary>
    public int CurrentChainId
    {
      get { return _scopes.Count == 0 ? SequentialChainId : _scopes[_scopes.Count - 1]; }
    }


    /// <summary>
    /// スコープを開き、以降の演出に付与されるチェインIDを返す。
    ///
    /// <see cref="AnimationChainMode.Simultaneous"/> は、外側に既にグループがあれば
    /// その ID を引き継ぐ（外側が「これで1つの拍」と宣言しているため、最も外側を優先する）。
    /// <see cref="AnimationChainMode.Sequential"/> は外側にグループがあっても
    /// 明示的に逐次へ抜ける。
    /// </summary>
    public int Begin(AnimationChainMode mode)
    {
      int chainId;

      if (mode == AnimationChainMode.Sequential)
      {
        chainId = SequentialChainId;
      }
      else if (CurrentChainId != SequentialChainId)
      {
        chainId = CurrentChainId;
      }
      else
      {
        chainId = AllocateGroupChainId();
      }

      _scopes.Add(chainId);
      return chainId;
    }

    /// <summary>
    /// スコープを閉じる。閉じるべきスコープが無かった場合は false を返す（例外は投げない）。
    /// 呼び出し漏れは <see cref="ResetScopes"/> が毎フレーム回収する。
    /// </summary>
    public bool End()
    {
      if (_scopes.Count == 0) { return false; }
      _scopes.RemoveAt(_scopes.Count - 1);
      return true;
    }

    /// <summary>
    /// using で使えるスコープを開く。早期 return のある処理でも閉じ忘れない。
    /// </summary>
    public AnimationChainScope BeginScope(AnimationChainMode mode)
    {
      Begin(mode);
      return new AnimationChainScope(this);
    }

    /// <summary>開きっぱなしのスコープを畳み、その段数を返す。フレーム境界で呼ぶこと。</summary>
    public int ResetScopes()
    {
      int leaked = _scopes.Count;
      _scopes.Clear();
      return leaked;
    }

    private int AllocateGroupChainId()
    {
      // 実用上到達しないが、一巡しても 0（＝逐次）に落ちないようにする。
      if (_nextGroupChainId == int.MaxValue) { _nextGroupChainId = FirstGroupChainId; }

      int chainId = _nextGroupChainId;
      _nextGroupChainId++;
      return chainId;
    }
  }

  /// <summary>
  /// <see cref="AnimationChainAllocator.BeginScope"/> が返す using 用スコープ。
  /// </summary>
  public struct AnimationChainScope : IDisposable
  {
    private AnimationChainAllocator _owner;

    internal AnimationChainScope(AnimationChainAllocator owner)
    {
      _owner = owner;
    }

    public void Dispose()
    {
      if (_owner == null) { return; }
      _owner.End();
      _owner = null;
    }
  }
}
