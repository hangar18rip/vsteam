﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace vsteam_lib.Test.Provider
{
   [TestClass]
   [ExcludeFromCodeCoverage]
   public class BuildTests
   {
      [TestMethod]
      public void Build_Constructor()
      {
         // Arrange
         var ps = BaseTests.PrepPowerShell();
         var obj = BaseTests.LoadJson("Get-VSTeamBuild.json");

         // Act
         var actual = new Build(obj[0], "Project Name", ps);

         // Assert
         Assert.AreEqual("81", actual.QueueId, "QueueId");
         Assert.IsNotNull(actual.RequestedBy, "RequestedBy");
         Assert.IsNotNull(actual.RequestedFor, "RequestedFor");
         Assert.AreEqual("completed", actual.Status, "Status");
         Assert.AreEqual("succeeded", actual.Result, "Result");
         Assert.IsNotNull(actual.LastChangedBy, "LastChangedBy");
         Assert.AreEqual("568", actual.BuildNumber, "BuildNumber");
         Assert.AreEqual("Default", actual.QueueName, "QueueName");
         Assert.AreEqual("TfsGit", actual.RepositoryType, "RepositoryType");
         Assert.AreEqual("PTracker-CI", actual.DefinitionName, "DefinitionName");
         Assert.AreEqual("Donovan Brown", actual.RequestedByUser, "RequestedByUser");
         Assert.AreEqual("Donovan Brown", actual.RequestedForUser, "RequestedForUser");
         Assert.AreEqual("11/14/2019 12:49:37 AM", actual.StartTime.ToString(), "startTime");
         Assert.AreEqual("Microsoft.VisualStudio.Services.ReleaseManagement", actual.LastChangedByUser, "LastChangedByUser");

         Assert.IsNotNull(actual.Queue, "Queue");
         Assert.IsNotNull(actual.Queue.Pool, "Queue.Pool");
         Assert.AreEqual("81", actual.Queue.Id, "Queue.Id");
         Assert.AreEqual("Default", actual.Queue.PoolName, "Queue.PoolName");

         Assert.IsNotNull(actual.BuildDefinition, "BuildDefinition");
         Assert.AreEqual(23, actual.BuildDefinition.Id, "BuildDefinition.Id");
         Assert.AreEqual("PTracker-CI", actual.BuildDefinition.Name, "BuildDefinition.Name");

         Assert.IsNotNull(actual.Project, "Project");
         Assert.AreEqual("PeopleTracker", actual.Project.Name, "Project.Name");
         Assert.AreEqual("00000000-0000-0000-0000-000000000000", actual.Project.Id, "Project.Id");

         Assert.AreEqual("Test@test.com", actual.RequestedBy.UniqueName, "RequestedBy.UniqueName");
         Assert.AreEqual("Donovan Brown", actual.RequestedFor.DisplayName, "RequestedFor.DisplayName");
         Assert.AreEqual("Microsoft.VisualStudio.Services.ReleaseManagement", actual.LastChangedBy.ToString(), "LastChangedBy.ToString()");
      }
   }
}
