namespace QuiSNCF.DTO;

public class CreateStationDTO
{
    public string Name { get; set; }
    public string City { get; set; }
    public string PictureUrl { get; set; }
    public string Hint { get; set; }
    public DateOnly LastTimePlayed { get; set; }
}