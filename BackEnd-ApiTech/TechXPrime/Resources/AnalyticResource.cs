﻿namespace BackEnd_ApiTech.TechXPrime.Resources;

public class AnalyticResource
{
    public int Id { get; set; }
    public int Week { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public float Incomes { get; set; }
    public float Expenses { get; set; }
    public float Profits { get; set; }
}