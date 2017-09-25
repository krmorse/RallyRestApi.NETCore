# RallyRestApi.NETCore

An exploration into creating a lighter weight version of the [RallyRestToolkitFor.NET](https://github.com/RallyTools/RallyRestToolkitFor.NET) compatible with .NET Core

## Example usage:
RallyRestApi rallyApi = new RallyRestApi("https://rally1.rallydev.com", "username", "password");
JObject j = rallyApi.Get("https://rally1.rallydev.com/slm/webservice/v2.0/hierarchicalrequirement/12345");
Console.WriteLine(j.ToString());
