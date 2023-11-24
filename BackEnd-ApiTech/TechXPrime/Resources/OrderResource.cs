namespace BackEnd_ApiTech.TechXPrime.Resources;

public class OrderResource
{
    public int Id { get; set; }
    public int TechnicalId { get; set; }
    public string ClientName { get; set; }
    public string PhoneName { get; set; }
    public string Problem { get; set; }
    public string ComponentsToUse { get; set; }
    public int ValueProgress { get; set; }
    public DateTime DeliveryDay { get; set; }
    public float Income { get; set; }
    public int Finished { get; set; }
    public float Investment { get; set; }
}