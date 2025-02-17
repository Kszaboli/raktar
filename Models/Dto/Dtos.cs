namespace WebApplication5.Models.Dto
{
    //termek
    public record CreateTermekDto(int Id, string Nev, int Dbszam);
    public record UpdateTermekDto(int Dbszam);

    //beszallito
    public record CreateBeszallitoDto(int Id, string Nev);
    public record UpdateBeszallitoDto(string Nev);
}
