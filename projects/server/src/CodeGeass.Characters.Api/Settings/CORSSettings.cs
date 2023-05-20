namespace CodeGeass.Characters.Api.Settings
{
    /// <summary>
    /// Representação das configurações dos CORS da aplicação
    /// </summary>
    public class CORSSettings
    {
        /// <summary>
        /// Clientes que tem permissão para fazer requisições a API.
        /// Ex: "http://localhost:8081", ... ou "*" para permitir todas as origens
        /// </summary>
        public string[] Origins { get; set; }

        /// <summary>
        /// Métodos HTTP que a API tem permissão para disponibilizar o acesso
        /// Ex: "GET", "POST", "PUT", "DELETE",... ou "*" para permitir todos os métodos
        /// </summary>
        public string[] Methods { get; set; }

        /// <summary>
        /// Cabeçalhos HTTP que a API está autorizada a aceitar
        /// Ex: "Authorization", "Accept", ... ou "*" para permitir todos os cabeçalhos
        /// </summary>
        public string[] Headers { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public CORSSettings()
        {
        }

        /// <summary>
        /// Cria uma configuração padrão quando não é informado no appsettings.json nenhuma configuração para o CORS (seção CORSSettings)
        /// </summary>
        /// <returns>Configuração padrão (permitindo tudo)</returns>
        public CORSSettings Default()
        {
            Origins = new string[] { "*" };
            Methods = new string[] { "*" };
            Headers = new string[] { "*" };

            return this;
        }
    }
}
