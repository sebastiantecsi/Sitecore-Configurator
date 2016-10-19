namespace ScConf
{
  using System.Collections.Generic;
  using System.IO;

  public class FileDetail
  {
    public FileDetail(DataRow row)
    {
      this.FileName = new ConfigFileName(row.Configfilename);
      this.FilePath = Path.Combine(row.FilePath, row.Configfilename);
      this.SearchProvider = ParseSearchProvider(row.SearchProviderUsed);

      this.Actions = new Dictionary<InstanceType, FileAction>
      {
        { InstanceType.CD, ParseFileAction(row.ContentDeliveryCD) },
        { InstanceType.CM, ParseFileAction(row.ContentManagementCM) },
        { InstanceType.PR, ParseFileAction(row.Processing) },
        { InstanceType.RE, ParseFileAction(row.Reporting) },
        { InstanceType.CMPR, ParseFileAction(row.CMProcessing) },
      };
    }

    /// <summary>
    /// The configuration file name that ends with .config and doesn't contain any .example, .sample etc. suffixes.
    /// </summary>
    public ConfigFileName FileName { get; }


    public string FilePath { get; }

    public IDictionary<InstanceType, FileAction> Actions { get; }

    public SearchProvider SearchProvider { get; }

    public override string ToString()
    {
      return FileName.ToString();
    }

    private static FileAction ParseFileAction(string str)
    {
      switch (str)
      {
        case "Disable":
          return FileAction.Disable;

        case "Enable":
          return FileAction.Enable;

        default:
          return FileAction.NA;
      }
    }

    private static SearchProvider ParseSearchProvider(string str)
    {
      switch (str)
      {
        case "Lucene is used":
          return SearchProvider.Lucene;

        case "Solr is used":
          return SearchProvider.Solr;

        default:
          return SearchProvider.NA;
      }
    }
  }

  public enum InstanceType
  {
    CD,
    CM,
    PR,
    RE,
    CMPR
  }

  public enum SearchProvider
  {
    NA,
    Lucene,
    Solr
  }

  public enum FileAction
  {
    NA,
    Enable,
    Disable
  }
}