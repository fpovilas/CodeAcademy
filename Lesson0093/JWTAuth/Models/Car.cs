namespace JWTAuth.Models;

public partial class Car
{
    public int Id { get; set; }
    public string? Manufacturer { get; set; }
    public string? Color { get; set; }

    public void ConvertFromDto(CarDto dto)
    {
        Manufacturer = dto.Manufacturer;
        Color = dto.Color;
    }
}
