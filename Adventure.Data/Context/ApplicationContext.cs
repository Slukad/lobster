using Adventure.Models.Custom;
using Microsoft.EntityFrameworkCore;

namespace Adventure.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.Custom.Adventure> Adventure { get; set; }
        public DbSet<Models.Custom.Player> Player { get; set; }
        public DbSet<Models.Custom.Decision> Decision { get; set; }
        public DbSet<Models.Custom.SelectedChoice> SelectedChoice { get; set; }
        public DbSet<Models.Custom.Choice> Choice { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>()
            .HasOne(p => p.Decision)
            .WithMany(b => b.Choices);

            modelBuilder.Entity<Choice>()
            .HasOne(p => p.NextDecision)
            .WithMany(b => b.NextDecisionChoices);

            modelBuilder.Entity<SelectedChoice>()
            .HasOne(p => p.Adventure)
            .WithMany(b => b.SelectedChoices);

            modelBuilder.Entity<SelectedChoice>()
            .HasOne<Decision>()
            .WithMany()
            .HasForeignKey(p => p.DecisionId);


            SeedDecisions(modelBuilder);
            SeedChoices(modelBuilder);
        }

        private void SeedDecisions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Decision>().HasData(new Decision
            {
                // Start
                Id = 1,
                Text = "Are your reflexes below average?",
                Level = 1,
                Order = 1
            }, new Decision
            {
                Id = 2,
                Text = "Do you like arcade-type games?",
                Level = 2,
                Order = 1
            }, new Decision
            {
                Id = 3,
                Text = "Are you into sports?",
                Level = 2,
                Order = 2
            }, new Decision
            {
                Id = 4,
                Text = "Are you ok using small devices?",
                Level = 3,
                Order = 1
            }, new Decision
            {
                Id = 5,
                Text = "Do you enjoy simulations?",
                Level = 3,
                Order = 2
            }, new Decision
            {
                Id = 6,
                Text = "Are you into football?",
                Level = 3,
                Order = 3
            }, new Decision
            {
                Id = 7,
                Text = "Are you into FPS games?",
                Level = 3,
                Order = 4
            }, new Decision
            {
                Id = 8,
                Text = "Are you ok with microtransactions?",
                Level = 4,
                Order = 1
            }, new Decision
            {
                Id = 9,
                Text = "Good Storytelling?",
                Level = 4,
                Order = 2
            }, new Decision
            {
                Id = 10,
                Text = "Play Cities Skilynes",
                Level = 4,
                Order = 3
            }, new Decision
            {
                Id = 11,
                Text = "Play Assassins Creed",
                Level = 4,
                Order = 4
            }, new Decision
            {
                Id = 12,
                Text = "Play FIFA 2020",
                Level = 4,
                Order = 5
            }, new Decision
            {
                Id = 13,
                Text = "Play Mario Kart",
                Level = 4,
                Order = 6
            }, new Decision
            {
                Id = 14,
                Text = "Play Apex Legends",
                Level = 4,
                Order = 7
            }, new Decision
            {
                Id = 15,
                Text = "Play League of legends",
                Level = 4,
                Order = 8
            }, new Decision
            {
                Id = 16,
                Text = "Play Tekken",
                Level = 5,
                Order = 1
            }, new Decision
            {
                Id = 17,
                Text = "Play Metal Slug",
                Level = 5,
                Order = 2
            }, new Decision
            {
                Id = 18,
                Text = "Play Candy crush",
                Level = 5,
                Order = 1
            }, new Decision
            {
                Id = 19,
                Text = "PlayPlague inc",
                Level = 5,
                Order = 2
            });
        }

        private void SeedChoices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>().HasData(new Choice
            {
                Id = 1,
                Text = "Yes"                
            }, new Choice
            {
                Id = 2,
                Text = "No"
            }, new Choice
            {
                Id = 3,
                Text = "Yes"
            }, new Choice
            {
                Id = 4,
                Text = "No"
            }, new Choice
            {
                Id = 5,
                Text = "Yes"
            }, new Choice
            {
                Id = 6,
                Text = "No"
            }, new Choice
            {
                Id = 7,
                Text = "Yes"
            }, new Choice
            {
                Id = 8,
                Text = "No"
            }, new Choice
            {
                Id = 9,
                Text = "Yes"
            }, new Choice
            {
                Id = 10,
                Text = "No"
            }, new Choice
            {
                Id = 11,
                Text = "Yes"
            }, new Choice
            {
                Id = 12,
                Text = "No"
            }, new Choice
            {
                Id = 13,
                Text = "Yes"
            }, new Choice
            {
                Id = 14,
                Text = "No"
            }, new Choice
            {
                Id = 15,
                Text = "Yes"
            }, new Choice
            {
                Id = 16,
                Text = "No"
            }, new Choice
            {
                Id = 17,
                Text = "Yes"
            }, new Choice
            {
                Id = 18,
                Text = "No"
            });
        }        
    }
}
