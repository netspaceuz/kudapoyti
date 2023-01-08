namespace kudapoyti.api.Configurations
{
    public static class JwtConfiguration
    {
        public static void ConfigureAuth(this WebApplicationBuilder webApplicationBuilder)
        {
            var config = webApplicationBuilder.Configuration.GetSection("Jwt");
        }
    }
}
