namespace CodeGeass.Characters.Api.Settings
{
    /// <summary>
    /// Classe responsavél pela configuração do swagger
    /// </summary>
    public class SwaggerSettings
    {
        public string AuthorizationUrl { get; set; }
        public string TokenUrl { get; set; }
        public string OAuthClientId { get; set; }
        public string Scopes { get; set; }
    }
}
