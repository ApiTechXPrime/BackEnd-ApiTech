﻿namespace BackEnd_ApiTech.TechXPrime.Domain.Models;

public class Client
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Birthday { get; set; }
    public string Cellphone { get; set; }
    public string Problem { get; set; }
    public string Time { get; set; }
    public int Number { get; set; }
}