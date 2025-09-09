namespace Speccon.Learnership.FrontEnd.Models.Client
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public Guid ClientKey { get; set; }
        public string? ClientName { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientAddress { get; set; }
        public string? ClientContactNo { get; set; }
        public string? ClientLogoName { get; set; }
        public string? ClientWebsite { get; set; }
    }
}
