namespace ScConf
{
  using JetBrains.Annotations;

  public class DataRow
  {
    [UsedImplicitly]
    public DataRow()
    {
    }

    public string ProductName { get; set; }
    public string FilePath { get; set; }
    public string Configfilename { get; set; }
    public string ConfigType { get; set; }
    public string SearchProviderUsed { get; set; }
    public string ContentDeliveryCD { get; set; }
    public string ContentManagementCM { get; set; }
    public string Processing { get; set; }
    public string CMProcessing { get; set; }
    public string Reporting { get; set; }
  }
}