﻿namespace BookStore.Models;

public class Book
{
    public string ISBN { get; set; } = "";
    public string Author { get; set; } = "";
    public string Title { get; set; } = "";
    public int NbPages { get; set; }
}
