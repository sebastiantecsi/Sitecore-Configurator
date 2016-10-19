using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
  using ScConf;

  [TestClass]
  public class XXX
  {
    [TestMethod]
    public void TT()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config.example";
      var sut = new ConfigFileName(path);
                                              
      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }
    [TestMethod]
    public void TT0()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config";
      var sut = new ConfigFileName(path);
                                           
      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }
    [TestMethod]
    public void TT1()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.example";
      var sut = new ConfigFileName(path);
                                          
      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }
    [TestMethod]
    public void TT2()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.example.config";
      var sut = new ConfigFileName(path);  

      Assert.AreEqual("ForwardingSecurityEvents.config", sut.FileName);
    }
    [TestMethod]
    public void aTT3()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config.example";
      var enabled = @"ForwardingSecurityEvents.config";
      var sut = new ConfigFileName(path);

      Assert.AreEqual(enabled, sut.FileName);
    }
    [TestMethod]
    public void aTT4()
    {
      var path = @"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config";
      var disabled = @"ForwardingSecurityEvents.disabled";
      var sut = new ConfigFileName(path);

      Assert.AreEqual(disabled, sut.DisabledFileName);
    }
  }

  [TestClass]
  public class UnitTest1
  {
    #region data
    string[] actualFiles = new[]
    {
        @"E:\wwwroot\App_Config\Include\001.Sitecore.Speak.Important.config",
@"E:\wwwroot\App_Config\Include\1.txt",
@"E:\wwwroot\App_Config\Include\CES",
@"E:\wwwroot\App_Config\Include\Channel",
@"E:\wwwroot\App_Config\Include\ContentTesting",
@"E:\wwwroot\App_Config\Include\DataFolder.config.example",
@"E:\wwwroot\App_Config\Include\EventHandler.config.example",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics",
@"E:\wwwroot\App_Config\Include\ExperienceProfile",
@"E:\wwwroot\App_Config\Include\ForwardingSecurityEvents.config.example",
@"E:\wwwroot\App_Config\Include\FXM",
@"E:\wwwroot\App_Config\Include\ja-JP.config.example",
@"E:\wwwroot\App_Config\Include\ListManagement",
@"E:\wwwroot\App_Config\Include\LiveMode.config.example",
@"E:\wwwroot\App_Config\Include\Marketing",
@"E:\wwwroot\App_Config\Include\ScalabilitySettings.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Automation.TimeoutProcessing.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Compatibility.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.ExcludeRobots.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.MarketingTaxonomy.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.MarketingTaxonomyCD.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Model.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.MongoDb.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Oracle.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Outcome.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Processing.Aggregation.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Processing.Aggregation.ProcessingPools.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Processing.Aggregation.Services.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Processing.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Processing.Services.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Reporting.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Tracking.Aggregation.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Tracking.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Tracking.Database.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Tracking.Database.ScaledCM.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Tracking.Outcome.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Analytics.Tracking.RobotDetection.config",
@"E:\wwwroot\App_Config\Include\Sitecore.AntiCsrf.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Buckets.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Buckets.WarmupQueries.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.Commerce.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Commerce.ExperienceProfile.ReportingServer.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Analytics.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.DefaultConfigurations.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.DefaultIndexConfiguration.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.Index.Analytics.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.Index.Core.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.Index.Master.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.Index.Web.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.Indexes.Sharded.Core.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.Indexes.Sharded.Master.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Lucene.Indexes.Sharded.Web.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Solr.DefaultIndexConfiguration.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Solr.Index.Analytics.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Solr.Index.Core.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Solr.Index.Master.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.Solr.Index.Web.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.ContentSearch.VerboseLogging.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.DefaultLanguage.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Diagnostics.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ExperienceEditor.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ExperienceEditor.Speak.Requests.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ExperienceExplorer.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ExperienceExplorer.Speak.Requests.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Interning.config",
@"E:\wwwroot\App_Config\Include\Sitecore.ItemWebApi.config",
@"E:\wwwroot\App_Config\Include\Sitecore.JSNLog.config",
@"E:\wwwroot\App_Config\Include\Sitecore.LanguageFallback.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Client.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.Repositories.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.Repositories.Lucene.Index.Master.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.Repositories.Lucene.Index.Web.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.Repositories.Lucene.IndexConfiguration.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.Repositories.Solr.Index.Master.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.Repositories.Solr.Index.Web.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.Repositories.Solr.IndexConfiguration.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Definitions.MarketingAssets.RepositoriesCD.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Lucene.Index.Master.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Lucene.Index.Web.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Lucene.IndexConfiguration.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Search.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Solr.Index.Master.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Solr.Index.Web.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Marketing.Solr.IndexConfiguration.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.MarketingCD.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.MarketingProcessingRole.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.MarketingReportingRole.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Media.RequestProtection.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Mvc.config",
@"E:\wwwroot\App_Config\Include\Sitecore.MvcAnalytics.config",
@"E:\wwwroot\App_Config\Include\Sitecore.MvcExperienceEditor.config",
@"E:\wwwroot\App_Config\Include\Sitecore.MvcSimulator.config",
@"E:\wwwroot\App_Config\Include\Sitecore.PathAnalyzer.Client.config",
@"E:\wwwroot\App_Config\Include\Sitecore.PathAnalyzer.config",
@"E:\wwwroot\App_Config\Include\Sitecore.PathAnalyzer.Processing.config",
@"E:\wwwroot\App_Config\Include\Sitecore.PathAnalyzer.RemoteClient.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.PathAnalyzer.Services.config",
@"E:\wwwroot\App_Config\Include\Sitecore.PathAnalyzer.Services.RemoteServer.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.PathAnalyzer.StorageProviders.config",
@"E:\wwwroot\App_Config\Include\Sitecore.PipelineProfiling.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Processing.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Publishing.DedicatedInstance.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.Publishing.EventProvider.Async.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Publishing.Optimizations.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.Publishing.Parallel.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Publishing.Recovery.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.SegmentBuilder.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Services.Client.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Shell.MarketingAutomation.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.AntiCsrf.SheerUI.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.Applications.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.Components.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.ContentSearch.Lucene.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.ContentSearch.Solr.config.example",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.ItemWebApi.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.LaunchPad.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Speak.Mvc.config",
@"E:\wwwroot\App_Config\Include\Sitecore.WebDAV.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Xdb.config",
@"E:\wwwroot\App_Config\Include\Sitecore.Xdb.Remote.Client.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Xdb.Remote.Client.MarketingAssets.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Xdb.Remote.Server.config.disabled",
@"E:\wwwroot\App_Config\Include\Sitecore.Xdb.Remote.Server.MarketingAssets.config.disabled",
@"E:\wwwroot\App_Config\Include\SitecoreSettings.config.example",
@"E:\wwwroot\App_Config\Include\SiteDefinition.config.example",
@"E:\wwwroot\App_Config\Include\Social",
@"E:\wwwroot\App_Config\Include\WebDeploy.config.example",
@"E:\wwwroot\App_Config\Include\XdbCloud",
@"E:\wwwroot\App_Config\Include\XslExtension.config.example",
@"E:\wwwroot\App_Config\Include\Z.SwitchMasterToWeb",
@"E:\wwwroot\App_Config\Include\CES\Sitecore.CES.config",
@"E:\wwwroot\App_Config\Include\CES\Sitecore.CES.DeviceDetection.CheckInitialization.config.disabled",
@"E:\wwwroot\App_Config\Include\CES\Sitecore.CES.DeviceDetection.config",
@"E:\wwwroot\App_Config\Include\CES\Sitecore.CES.GeoIp.config",
@"E:\wwwroot\App_Config\Include\CES\Sitecore.CES.GeoIp.LegacyLocation.config",
@"E:\wwwroot\App_Config\Include\Channel\Sitecore.Analytics.Channel.config",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.ApplicationDependencies.config",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.Client.RulePerformance.config.disabled",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.config",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.Intelligence.config",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.Lucene.IndexConfiguration.config",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.Mvc.config",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.PreemptiveScreenshot.config.disabled",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.Processing.Aggregation.config",
@"E:\wwwroot\App_Config\Include\ContentTesting\Sitecore.ContentTesting.Solr.IndexConfiguration.config.disabled",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics\Sitecore.ExperienceAnalytics.Aggregation.config",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics\Sitecore.ExperienceAnalytics.Client.config",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics\Sitecore.ExperienceAnalytics.ReAggregation.config.disabled",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics\Sitecore.ExperienceAnalytics.ReAggregation.Scheduling.config.disabled",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics\Sitecore.ExperienceAnalytics.Reduce.config",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics\Sitecore.ExperienceAnalytics.StorageProviders.config",
@"E:\wwwroot\App_Config\Include\ExperienceAnalytics\Sitecore.ExperienceAnalytics.WebAPI.config",
@"E:\wwwroot\App_Config\Include\ExperienceProfile\Sitecore.ExperienceProfile.Client.config",
@"E:\wwwroot\App_Config\Include\ExperienceProfile\Sitecore.ExperienceProfile.config",
@"E:\wwwroot\App_Config\Include\ExperienceProfile\Sitecore.ExperienceProfile.Reporting.config",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Bundle.config",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.config",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Lucene.DomainsSearch.DefaultIndexConfiguration.config",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Lucene.DomainsSearch.Index.Master.config",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Lucene.DomainsSearch.Index.Web.config",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Solr.DomainsSearch.DefaultIndexConfiguration.config.disabled",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Solr.DomainsSearch.Index.Master.config.disabled",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Solr.DomainsSearch.Index.Web.config.disabled",
@"E:\wwwroot\App_Config\Include\FXM\Sitecore.FXM.Speak.config",
@"E:\wwwroot\App_Config\Include\ListManagement\Sitecore.ListManagement.Client.config",
@"E:\wwwroot\App_Config\Include\ListManagement\Sitecore.ListManagement.config",
@"E:\wwwroot\App_Config\Include\ListManagement\Sitecore.ListManagement.Lucene.Index.List.config",
@"E:\wwwroot\App_Config\Include\ListManagement\Sitecore.ListManagement.Lucene.IndexConfiguration.config",
@"E:\wwwroot\App_Config\Include\ListManagement\Sitecore.ListManagement.Services.config",
@"E:\wwwroot\App_Config\Include\ListManagement\Sitecore.ListManagement.Solr.Index.List.config.disabled",
@"E:\wwwroot\App_Config\Include\ListManagement\Sitecore.ListManagement.Solr.IndexConfiguration.config.disabled",
@"E:\wwwroot\App_Config\Include\Marketing\Sitecore.Marketing.Campaigns.Client.config",
@"E:\wwwroot\App_Config\Include\Marketing\Sitecore.Marketing.Campaigns.Services.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.ExperienceProfile.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Facebook.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.GooglePlus.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Klout.config.disabled",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.LinkedIn.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Lucene.Index.Master.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Lucene.Index.Web.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Lucene.IndexConfiguration.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.ProfileMapping.Facebook.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.ProfileMapping.GooglePlus.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.ProfileMapping.LinkedIn.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.ProfileMapping.Twitter.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.ScalabilitySettings.config.disabled",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.SocialMarketer.config",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Solr.Index.Master.config.disabled",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Solr.Index.Web.config.disabled",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Solr.IndexConfiguration.config.disabled",
@"E:\wwwroot\App_Config\Include\Social\Sitecore.Social.Twitter.config",
@"E:\wwwroot\App_Config\Include\XdbCloud\Sitecore.Cloud.Xdb.config.disabled",
@"E:\wwwroot\App_Config\Include\XdbCloud\Sitecore.ContentSearch.Cloud.DefaultIndexConfiguration.config.disabled",
@"E:\wwwroot\App_Config\Include\XdbCloud\Sitecore.ContentSearch.Cloud.Index.Analytics.config.disabled",
@"E:\wwwroot\App_Config\Include\Z.SwitchMasterToWeb\important.txt",
@"E:\wwwroot\App_Config\Include\Z.SwitchMasterToWeb\SwitchMasterToWeb.config.example",
      };
#endregion

    [TestMethod]
    public void TestMethod1()
    {
    }
  }
}
