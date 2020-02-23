using System.ComponentModel;

namespace Assets.Scripts.Enuns
{

    public enum EnumPlanetas
    {
        [Description("Planeta Oceanico")]
        PlanetaOceanico,
        [Description("Planeta Pantanoso")]
        PlanetaPantanoso,
        [Description("Planeta Continental")]
        PlanetaContinental,
        [Description("Planeta Desertico")]
        PlanetaDesertico,
        [Description("Planeta Vulcanico")]
        PlanetaVulcanico,
        [Description("Planeta Gelado")]
        PlanetaGelado,
    }
}
