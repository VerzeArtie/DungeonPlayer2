#if UNITY_IOS
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

/// <summary>
/// iOSビルド後にInfo.plistへ対応言語を書き込む。
/// UnityはCFBundleLocalizationsを自動生成しないため、これが無いと
/// App Storeの「言語」欄が英語のみの表示になる。
/// </summary>
public static class IOSPlistLocalizations
{
  // アプリがサポートする言語（One.GameLanguage に対応）
  private static readonly string[] SupportedLocalizations = { "ja", "en" };

  [PostProcessBuild(999)]
  public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
  {
    if (target != BuildTarget.iOS) { return; }

    string plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
    if (!File.Exists(plistPath)) { return; }

    PlistDocument plist = new PlistDocument();
    plist.ReadFromFile(plistPath);

    // 既存のエントリがあれば作り直す（CreateArrayは同名キーを上書きする）
    PlistElementArray langs = plist.root.CreateArray("CFBundleLocalizations");
    foreach (string lang in SupportedLocalizations)
    {
      langs.AddString(lang);
    }

    plist.WriteToFile(plistPath);
  }
}
#endif
