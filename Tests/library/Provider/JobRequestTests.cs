﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace vsteam_lib.Test.Provider
{
   [TestClass]
   [ExcludeFromCodeCoverage]
   public class JobRequestTests
   {
      [TestMethod]
      public void JobRequest_Constructor_Completed()
      {
         // Arrange
         var jobRequests = BaseTests.LoadJson("Get-VSTeamJobRequest-PoolId1-AgentID111.json");

         // Act
         var target = new JobRequest(jobRequests[0]);

         // Assert
         Assert.AreEqual("3123", target.Id, "ID");
         Assert.IsNotNull(target.Demands, "Demands");
         Assert.AreEqual("Release", target.Type, "Type");
         Assert.AreEqual("failed", target.Result, "Result");
         Assert.AreEqual(null, target.ProjectName, "ProjectName");
         Assert.IsNotNull(target.InternalObject, "InternalObject");
         Assert.AreEqual("PTracker-CD", target.Pipeline, "Pipeline");
         Assert.AreEqual("------", target.DisplayMode, "DisplayMode");
         Assert.AreEqual(TimeSpan.Parse("00:10:58"), target.Duration, "Duration");
         Assert.AreEqual("11/14/2019 12:56:12 AM", target.QueueTime.ToString(), "QueueTime");
         Assert.AreEqual("11/14/2019 12:56:15 AM", target.StartTime.ToString(), "StartTime");
         Assert.AreEqual("11/14/2019 1:07:13 AM", target.FinishTime.ToString(), "FinishTime");
         Assert.AreEqual("11/14/2019 12:56:12 AM", target.AssignedTime.ToString(), "AssignedTime");
      }

      [TestMethod]
      public void JobRequest_Constructor_Running()
      {
         // Arrange
         var jobRequests = BaseTests.LoadJson("Get-VSTeamJobRequest-PoolId1-AgentID111.json");

         // Act
         var target = new JobRequest(jobRequests[2]);

         // Assert
         Assert.AreEqual("running", target.Result, "Result");
      }

      [TestMethod]
      public void JobRequest_Constructor_Queued()
      {
         // Arrange
         var jobRequests = BaseTests.LoadJson("Get-VSTeamJobRequest-PoolId1-AgentID111.json");

         // Act
         var target = new JobRequest(jobRequests[1]);

         // Assert
         Assert.AreEqual("queued", target.Result, "Result");
      }
   }
}
