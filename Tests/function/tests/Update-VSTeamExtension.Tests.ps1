Set-StrictMode -Version Latest

Describe 'VSTeamExtension' {
   BeforeAll {
      . "$PSScriptRoot\_testInitialize.ps1" $PSCommandPath

      Mock _getInstance { return 'https://dev.azure.com/test' }
   }

   Context 'Update-VSTeamExtension' {
      BeforeAll {
         $env:Team_TOKEN = '1234'
         Mock _callAPI { Open-SampleFile 'Get-VSTeamExtension.json' -Index 0 }
      }

      AfterAll {
         $env:TEAM_TOKEN = $null
      }

      It 'Should update an extension' {
         Update-VSTeamExtension -PublisherId 'test' -ExtensionId 'test' -ExtensionState disabled -Force

         Should -Invoke _callAPI -Exactly 1 -Scope It -ParameterFilter {
            $Method -eq 'Post' -and
            $subDomain -eq 'extmgmt' -and
            $version -eq [vsteam_lib.Versions]::ExtensionsManagement
            $Url -like "*https://extmgmt.dev.azure.com/test/_apis/_apis/extensionmanagement/installedextensionsbyname/test/test*"
         }
      }
   }
}