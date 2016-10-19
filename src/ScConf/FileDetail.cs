namespace ScConf
{
  using System.Collections.Generic;
  using System.IO;

  public class FileDetail
  {
    public FileDetail(DataRow row)
    {
      FileName = new ConfigFileName(row.Configfilename);
      FilePath = Path.Combine(row.FilePath, row.Configfilename);
      SearchProvider = ParseSearchProvider(row.SearchProviderUsed);

      Actions = new Dictionary<InstanceType, FileAction>
      {
        {InstanceType.CD, ParseFileAction(row.ContentDeliveryCD)},
        {InstanceType.CM, ParseFileAction(row.ContentManagementCM)},
        {InstanceType.PR, ParseFileAction(row.Processing)},
        {InstanceType.RE, ParseFileAction(row.Reporting)},
        {InstanceType.CMPR, ParseFileAction(row.CMProcessing)}
      };
    }

    /// <summary>
    ///   The configuration file name that ends with .config and doesn't contain any .example, .sample etc. suffixes.
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
}