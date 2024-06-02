using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Transport.Api
{
    public class ApplicationOptions
    {
        
    }

    public class EnvironmentVars
    {
        public int MyVar1 { get; init; }
        public string MyVar2 { get; init; }
        public string MyVar3 { get; init; }
        public Subclase1 SubClase1 { get; init; }
    }

    public class Subclase1
    {
        public int VarSub1 { get; init; }
        public int VarSub2 { get; init; }
        public string VarSub3 { get; init; }
    }

    public class EnvironmentVarsSetup : IConfigureOptions<EnvironmentVars>
    {
        private readonly IConfiguration configuration;

        public EnvironmentVarsSetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Configure(EnvironmentVars options)
        {
            configuration.GetSection(nameof(EnvironmentVars)).Bind(options);
        }
    }
}
