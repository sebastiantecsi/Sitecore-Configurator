using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScConf
{
  using System.IO;
  using JetBrains.Annotations;

  public class ConfigFileName : IEquatable<ConfigFileName>
  {
    public ConfigFileName([NotNull] string path)
    {                                          
      FileName = GetFileName(path);
    }

    [NotNull]
    public string FileName { get; }

    public string DisabledFileName => Path.GetFileNameWithoutExtension(FileName) + ".disabled";

    [NotNull]
    private static string GetFileName(string path)
    {
      var fileName = Path.GetFileName(path);
      var configIndex = fileName.IndexOf(".config", StringComparison.OrdinalIgnoreCase);
      if (configIndex >= 0)
      {
        fileName = fileName.Substring(0, configIndex);
      }

      var exts = new [] {".example", ".disabled", ".disable", ".sample"};
      var exit = false;
      while (!exit)
      {
        exit = true;
        foreach (var ext in exts)
        {
          if (fileName.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
          {
            fileName = fileName.Substring(0, fileName.Length - ext.Length);
            exit = false;
          }
        }        
      }

      return fileName + ".config";
    }

    public override string ToString()
    {
      return FileName;
    }

    public bool Equals(ConfigFileName other)
    {
      return ReferenceEquals(this, other) || FileName.Equals(other?.FileName, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object obj)
    {
      var other = obj as ConfigFileName;

      return other != null && Equals(other);
    }

    public override int GetHashCode()
    {
      return FileName?.GetHashCode() ?? 0;
    }
  }
}
