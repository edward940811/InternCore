public static class DotNetCoreConnectionStringsConfig
{
    public static string AuthApiDatabase { get; set; } = @"Server=wishing-developer.database.windows.net,1433;Database=esh_Auth;User Id = wishingsoft; Password=Wishing_soft@99!@;MultipleActiveResultSets=true";
    public static string LegalDatabase { get; set; } = @"Data Source=(LocalDb)\MSSQLLocalDB;Connection Timeout = 90;Initial Catalog=Legal_Develop;Integrated Security=true"" providerName=""System.Data.SqlClient";
    public static string ChemicalDatabase { get; set; } = @"Server=wishing-developer.database.windows.net,1433;Database=esh_Auth;User Id=wishingsoft;Password=Wishing_soft@99!@;MultipleActiveResultSets=true";
    public static string ESHCloudsAuth { get; set; } = @"Server=wishing-developer.database.windows.net,1433;Database=esh_Auth;User Id = wishingsoft; Password=Wishing_soft@99!@;MultipleActiveResultSets=true";
    public static string ESHCloudsCore { get; set; } = @"Data Source=(LocalDb)\MSSQLLocalDB;Connection Timeout = 90;Initial Catalog=esh_core;Integrated Security=True;";
}