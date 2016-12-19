
// include Fake lib
#r "tools/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Testing
 
// Properties
let buildDir = "./build/"
let testDir = "./test/"
 
RestorePackages()

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir]
)
let buildApp () =
        !! "src/app/**/*.csproj"
        |> MSBuildRelease buildDir "Build"
        |> Log "AppBuild-Output: "

Target "BuildApp" (fun _ ->
    buildApp()
)
let buildTests() =
        !! "src/tests/**/*.csproj"
        |> MSBuildDebug testDir "Build"
        |> Log "TestBuild-Output: "

Target "BuildTest" (fun _ ->
    buildTests()
)
let runTests() =
        !! (testDir + "/*Tests.dll")
        |> NUnit3 (fun p -> 
            {
                p with
                    ToolPath = "tools/NUnit.ConsoleRunner/tools/nunit3-console.exe";
                    ShadowCopy = false;
                    OutputDir = testDir + "TestResults.xml";
            }
        )

Target "Test" (fun _ ->
    runTests()
)

Target "Watch" (fun _ ->
    use watcher = !! "src/**/*.cs" |> WatchChanges (fun changes ->
        tracefn "%A" changes
        buildApp()
        buildTests()
        runTests()
    )

    Shell.Exec "docker"
    System.Console.ReadLine() |> ignore

    watcher.Dispose()
)
 
Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)
 
// Dependencies
"Clean"
    ==> "BuildApp"
    ==> "BuildTest"
    ==> "Test"
    ==> "Default"

// start build
RunTargetOrDefault "Default"