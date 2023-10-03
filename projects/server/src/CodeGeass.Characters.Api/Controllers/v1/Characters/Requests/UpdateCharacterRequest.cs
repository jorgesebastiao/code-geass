namespace CodeGeass.Characters.Api.Controllers.v1.Characters.Requests
{
    public class UpdateCharacterRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
