using System;
using P03_FootballBetting.Data;
using Microsoft.EntityFrameworkCore;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new P03_FootballBetting.Data.Models.FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
