using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MyMoviesAPI.Models.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Title).IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Director).IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.Year).IsRequired();

            builder.Property(x => x.Rate).IsRequired();

            builder.HasData(
                new Movie() { Id = 1, Title = "Reservoir Dogs", Director = "Quentin Tarantino", Year = 1992, Rate = 9 },
                new Movie() { Id = 2, Title = "Django Unchained", Director = "Quentin Tarantino", Year = 2012, Rate = 9 },
                new Movie() { Id = 3, Title = "Wrath of Man", Director = "Guy Ritchie", Year = 2021, Rate = 7 },
                new Movie() { Id = 4, Title = "365 Dni", Director = "Barbara Białowąs", Year = 2020, Rate = 1 }
                );
        }
    }
}
