﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using System.Management.Automation.Abstractions;
using System.Management.Automation.Language;

namespace vsteam_lib
{
   public class ProjectCompleter : BaseCompleter
   {
      /// <summary>
      /// This constructor is used when running in a PowerShell session. It cannot be
      /// loaded in a unit test.
      /// </summary>
      [ExcludeFromCodeCoverage]
      public ProjectCompleter() : base() { }

      /// <summary>
      /// This constructor is used during unit testings
      /// </summary>
      /// <param name="powerShell">fake instance of IPowerShell used for testing</param>
      public ProjectCompleter(IPowerShell powerShell) : base(powerShell) { }

      public override IEnumerable<CompletionResult> CompleteArgument(string commandName,
                                                                     string parameterName,
                                                                     string wordToComplete,
                                                                     CommandAst commandAst,
                                                                     IDictionary fakeBoundParameters)
      {
         var values = new List<CompletionResult>();

         SelectValues(wordToComplete, ProjectCache.GetCurrent(false), values);

         return values;
      }
   }
}
