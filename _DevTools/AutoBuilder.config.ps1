
#solution name to build
$solutionName = "MiniHTMLTextBox"

#set version
$versionMajor = "1"
$versionMinor = "0"
$versionBuild = GetVersionBuild
$versionRevision = "6"
#build version number
$version = GetVersion $versionMajor $versionMinor $versionBuild $versionRevision

#base folder for of the solution
$baseDir  = Resolve-Path .\..\

#release folder for of the solution
$releaseDir = Resolve-Path .\..\..\Release

#builder parameters
$buildDebugAndRelease = $false
$treatWarningsAsErrors = $true
$releaseDebugFiles = $false

#remove elder release builds for the actual version
$removeElderReleaseWithSameVersion = $true

#folders and files to exclude from the packaged release Source
$releaseSrcExcludeFolders = @('"_DevTools"', '".git"');
$releaseSrcExcludeFiles = @('".git*"');

#builds array
#include here all the solutions file to build	
$builds = @(
	@{
		#solutions filename (.sln)
		Name = "MiniHTMLTextBox";
		#msbuild optionals constants
		Constants = "";
		#projects to exclude from the release binary package
		ReleaseBinExcludeProjects = @();
		#files to include in the release binary package
		ReleaseBinIncludeFiles = @(
			@{
				Name = "MiniHTMLTextBox";
				Files = @(
					@{
						FileNameFrom = "..\License\";
						FileNameTo = "..\"
					},
					@{
						FileNameFrom = "..\README.md";
						FileNameTo = "..\README.md"
					}
				)
			}
		);
		#unit tests to run
		Tests = @();
		#commands to run before packaging of the release source
		ReleaseSrcCmd = @();
		#commands to run before packaging of the release binary
		ReleaseBinCmd = @();
	};
)