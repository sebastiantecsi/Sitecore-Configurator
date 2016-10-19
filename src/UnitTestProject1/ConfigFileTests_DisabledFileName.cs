namespace UnitTestProject1
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using ScConf;

  [TestClass]
  public class ConfigFileTests_DisabledFileName
  {            
    [TestMethod]
    public void Disabled()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.disabled";
      var sut = new ConfigFileName(path);

      Assert.AreEqual(@"ForwardingSecurityEvents.disabled", sut.DisabledFileName);
    }

    [TestMethod]
    public void Config()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config";
      var sut = new ConfigFileName(path);

      Assert.AreEqual(@"ForwardingSecurityEvents.disabled", sut.DisabledFileName);
    }

    [TestMethod]
    public void ConfigExample()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config.example";
      var sut = new ConfigFileName(path);

      Assert.AreEqual(@"ForwardingSecurityEvents.disabled", sut.DisabledFileName);
    }

    [TestMethod]
    public void ConfigDisabled()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config.disabled";
      var sut = new ConfigFileName(path);

      Assert.AreEqual(@"ForwardingSecurityEvents.disabled", sut.DisabledFileName);
    }
  }
}