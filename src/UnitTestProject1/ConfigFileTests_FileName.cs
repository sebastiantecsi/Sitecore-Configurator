namespace UnitTestProject1
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using ScConf;

  [TestClass]
  public class ConfigFileTests_FileName
  {
    [TestMethod]
    public void ConfigExample()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config.example";
      var sut = new ConfigFileName(path);

      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }

    [TestMethod]
    public void Config()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config";
      var sut = new ConfigFileName(path);

      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }

    [TestMethod]
    public void Example()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.example";
      var sut = new ConfigFileName(path);

      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }

    [TestMethod]
    public void ExampleConfig()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.example.config";
      var sut = new ConfigFileName(path);

      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }
  }
}