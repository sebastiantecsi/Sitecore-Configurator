namespace ScConf
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Net;
  using CsvHelper;
  using JetBrains.Annotations;

  public static class Program
  {
    private static void Main(string[] args)
    {
      if (args.Length != 2)
      {
        Console.WriteLine("supply 2 arguments: ");
        Console.WriteLine("1. path to website folder");
        Console.WriteLine("2. mode (can be CM|CD|PR[ocessing]|RE[porting]|CMPR)");
        return;
      }

      var mode = GetMode(args.Last());
      var include = Path.Combine(args.First(), @"App_Config\Include");
      var Location = new DirectoryInfo(include);

      var namesToIgnore = new[] {"UseServerSideRedirect.config", "DataFolder.config"}
        .Select(x => new ConfigFileName(x))
        .ToArray();

      var actualFileNames = Directory.GetFiles(include, "*", SearchOption.AllDirectories)
        .Select(x => new ConfigFileName(x))
        .Where(name => !namesToIgnore.Any(name.Equals))
        .ToList();

      var data = GetFileDetails()
        .Where(x => !namesToIgnore.Any(z => x.FileName.Equals(z)))
        .Where(x => x.Actions[mode] != FileAction.NA)
        .ToList();

      // make sure all necessary files are disabled
      foreach (var actualFileName in actualFileNames)
      {
        var details = data.FirstOrDefault(x => x.FileName.Equals(actualFileName));
        if ((details?.Actions[mode] == FileAction.Disable) && (details.SearchProvider != SearchProvider.Solr))
        {
          data.Remove(details);

          var files = Location.GetFiles(actualFileName.FileName, SearchOption.AllDirectories);
          foreach (var file in files)
          {
            Console.WriteLine($"  ===== ");
            Console.WriteLine();
            Console.WriteLine($"> {file.FullName.Substring(include.Length)}");
            Console.WriteLine();
            Console.WriteLine("The file must be disabled according to selected mode.");
            Console.WriteLine("Press D to disable the file (or any other key to skip)... ");
            Console.WriteLine();
            var result = Console.ReadKey();

            if (result.KeyChar.ToString().ToUpper() != "D")
            {
              Console.WriteLine();
              Console.WriteLine("Skipped.");
              Console.WriteLine();
              continue;
            }

            var disabledFilePath = Path.Combine(file.DirectoryName, actualFileName.DisabledFileName);

            if (File.Exists(disabledFilePath))
            {
              File.Delete(disabledFilePath);
            }

            file.MoveTo(disabledFilePath);

            Console.WriteLine("isabled.");
            Console.WriteLine();
          }
        }
      }

      // make sure all necessary files are enabled
      foreach (var detail in data)
      {
        if ((detail.Actions[mode] != FileAction.Enable) || (detail.SearchProvider == SearchProvider.Solr))
        {
          continue;
        }

        var actualFile = actualFileNames.FirstOrDefault(name => name.Equals(detail.FileName));
        if (actualFile == null)
        {
          Console.WriteLine($"  ===== ");
          Console.WriteLine();
          Console.WriteLine($"> {detail.FileName.FileName}");
          Console.WriteLine();
          Console.WriteLine($"The configuration file needs to be enabled.");

          var files = Location.GetFiles(detail.FileName + ".*", SearchOption.AllDirectories);
          if (files.Length == 0)
          {
            Console.WriteLine();
            Console.WriteLine("WARN! No appropriate .disabled or .example files found to be enabled.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();

            continue;
          }

          Console.WriteLine("One or several files can be enabled:");
          Console.WriteLine();

          for (var i = 0; i < files.Length; i++)
          {
            Console.WriteLine($"  {i + 1}. {files[i].FullName.Substring(include.Length)}");
            Console.WriteLine();
          }

          if (files.Length == 1)
          {
            Console.WriteLine($"Press 1 to enable the file (or any other key to skip)... ");
          }
          else
          {
            Console.WriteLine($"Press 1-{files.Length} to enable the file (or any other key to skip)... ");
          }

          var result = Console.ReadKey();
          Console.WriteLine();

          int num;
          if (!int.TryParse(result.KeyChar.ToString().ToUpper(), out num))
          {
            Console.WriteLine("Skipped.");
            Console.WriteLine();
            continue;
          }

          var file = files[num - 1];
          var enabledFilePath = Path.Combine(file.DirectoryName, detail.FileName.FileName);
          if (File.Exists(enabledFilePath))
          {
            throw new InvalidOperationException($"The file already exists: {enabledFilePath}");
          }

          file.MoveTo(enabledFilePath);

          Console.WriteLine("Enabled.");
          Console.WriteLine();
        }
      }

      Console.WriteLine();
      Console.WriteLine("All done!");
      Console.WriteLine();
    }

    private static InstanceType GetMode(string mode)
    {
      switch (mode.ToUpper().Trim().Replace(" ", ""))
      {
        case "CM":
        case "MANAGEMENT":
        case "CONTENTMANAGEMENT":
        case "AUTH":
        case "AUTHORING":
          return InstanceType.CM;

        case "CD":
        case "DELIVERY":
        case "CONTENTDELIVERY":
          return InstanceType.CD;

        case "CMPR":
          return InstanceType.CMPR;

        case "PR":
        case "PROCESSING":
        case "AGGREGATION":
        case "AGG":
          return InstanceType.PR;

        case "RE":
        case "REPORT":
        case "REPORTING":
          return InstanceType.RE;

        default:
          throw new NotSupportedException($"Invalid mode: {mode}");
      }
    }

    [NotNull]
    private static FileDetail[] GetFileDetails()
    {
      var tmp = Path.GetTempFileName();
      new WebClient().DownloadFile("http://dl.sitecore.net/updater/info/static/config.csv", tmp);
      var csv = new CsvReader(File.OpenText(tmp))
      {
        Configuration =
        {
          IgnoreHeaderWhiteSpace = true
        }
      };

      var data = csv.GetRecords<DataRow>()
        .Where(x => x.FilePath.IndexOf("App_Config\\Include", StringComparison.OrdinalIgnoreCase) >= 0)
        .Select(x => new FileDetail(x))
        .ToArray();
      return data;
    }
  }
}